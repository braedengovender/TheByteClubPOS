// CashierDashboardForm.cs
// Author: [Your Name] - [Student Number]
// Date: June 2026
// Description: Cashier dashboard for Sam's Liquor Shop POS.
//              Shows the cashier's own transactions, low stock items and best customer.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace TheByteClubPOS
{
    public partial class CashierDashboardForm : Form
    {
        private Label lblWelcome = new Label();
        private Label lblName = new Label();
        private Label lblRole = new Label();

        private int cashierID;
        private string cashierName;

        // Colours
        private Color navyBlue = Color.FromArgb(31, 73, 125);
        private Color green = Color.FromArgb(0, 153, 76);
        private Color orange = Color.FromArgb(204, 85, 0);
        private Color purple = Color.FromArgb(102, 0, 153);
        private Color teal = Color.FromArgb(0, 128, 128);
        private Color red = Color.FromArgb(192, 0, 0);

        private const int CANVAS_W = 1134;
        private const int CANVAS_H = 740;
        private const int PAD = 20;
        private const int GAP = 10;
        private const int VPAD = 12;

        // Data-bound controls
        private Label lblLowStock;
        private Label lblCustomers;
        private Label lblMyTxCount;
        private Label lblMyRevenue;
        private DataGridView dgvMyTransactions;
        private DataGridView dgvLowStock;
        private Label lblBestName;
        private Label lblBestSpent;
        private Label lblBestTx;
        private Label lblLastUpdated;

        // Service and timer
        private CashierDashboardService dashboardService = new CashierDashboardService();
        private Timer refreshTimer = new Timer();
        private CashierDashboardData currentData;
        private bool isLoaded = false;

        public CashierDashboardForm()
        {
            cashierName = "Cashier";
            InitializeComponent();
            SetupDashboard();
        }

        public CashierDashboardForm(int id, string name)
        {
            cashierID = id;
            cashierName = name;
            InitializeComponent();
            SetupDashboard();
        }

        private void SetupDashboard()
        {
            this.Text = "Dashboard - Sam's Liquor Shop";
            this.DoubleBuffered = true;
            this.AutoScroll = false;
            this.BackgroundImage = Properties.Resources.Background;
            this.BackgroundImageLayout = ImageLayout.Stretch;


            Panel canvas = new Panel();
            canvas.BackColor = Color.Transparent;
            canvas.Location = new Point(0, 0);
            canvas.Size = new Size(10, 10);

            this.Controls.Add(canvas);

            Action rebuildLayout = () =>
            {
                int w = Math.Max(this.ClientSize.Width, CANVAS_W);
                int h = Math.Max(this.ClientSize.Height, 400);
                if (w < 50 || h < 50) return;
                canvas.Size = new Size(w, h);
                canvas.BackColor = Color.Transparent;
                canvas.Location = new Point(0, 0);
                canvas.Controls.Clear();
                BuildDashboard(canvas);
                isDarkMode(LoginForm.IsDarkMode); // Reapply theme
            };

            // Use a one-shot timer so the MDI framework finishes its layout
            // before we build the dashboard. Shown fires too early — ClientSize
            // is stale. 150ms gives the MDI host time to settle.
            Timer initTimer = new Timer();
            initTimer.Interval = 150;
            initTimer.Tick += (s, e) =>
            {
                initTimer.Stop();
                initTimer.Dispose();
                rebuildLayout();
                isLoaded = true;
                LoadDashboardData();
            };

            this.Shown += (s, e) => initTimer.Start();

            this.Resize += (s, e) =>
            {
                if (!isLoaded) return;
                rebuildLayout();
                if (currentData != null) BindDataToControls(currentData);
            };

            refreshTimer.Interval = 60000;
            refreshTimer.Tick += (s, e) => LoadDashboardData();
            refreshTimer.Start();
        }

        protected override void OnLoad(EventArgs e) { base.OnLoad(e); }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            refreshTimer.Stop();
            refreshTimer.Dispose();
            base.OnFormClosed(e);
        }

        private void BuildDashboard(Panel canvas)
        {
            int totalGaps = VPAD * 2 + GAP * 3;
            int footHeight = 40;
            int available = canvas.Height - totalGaps - footHeight;

            int headerHeight = Math.Max((int)(available * 0.09), 38);
            int cardHeight = Math.Max((int)(available * 0.11), 58);
            int mainHeight = available - headerHeight - cardHeight;

            int y = VPAD;
            BuildHeader(canvas, ref y, headerHeight);
            BuildStatCards(canvas, ref y, cardHeight);
            BuildMainRow(canvas, ref y, mainHeight);
            BuildFooter(canvas, ref y, footHeight);
        }

        private void BuildHeader(Panel canvas, ref int y, int h)
        {
            // Label lblWelcome = new Label();
            lblWelcome.Text = "Welcome back,";
            lblWelcome.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular);
            lblWelcome.ForeColor = LoginForm.IsDarkMode ? Color.White : Color.FromArgb(20, 20, 40); ;
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Bounds = new Rectangle(PAD, y, 300, 20);
            canvas.Controls.Add(lblWelcome);

            // Label lblName = new Label();
            lblName.Text = cashierName;
            lblName.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Bold | FontStyle.Underline);
            lblName.ForeColor = LoginForm.IsDarkMode ? Color.White : Color.FromArgb(20, 20, 60);
            lblName.BackColor = Color.Transparent;
            lblName.AutoSize = true;
            lblName.Location = new Point(PAD, y + 20);
            canvas.Controls.Add(lblName);

            SizeF nameSize = canvas.CreateGraphics().MeasureString(
                cashierName,
                new Font("Microsoft Sans Serif", 18f, FontStyle.Bold | FontStyle.Underline));
            int roleX = PAD + (int)nameSize.Width + 12;

            // Label lblRole = new Label();
            lblRole.Text = "Cashier - Dashboard";
            lblRole.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
            lblRole.ForeColor = LoginForm.IsDarkMode ? Color.White : navyBlue; ;
            lblRole.BackColor = Color.Transparent;
            lblRole.AutoSize = true;
            // Vertically align baseline with the 18pt name label:
            // name is at y+20, height ~36. 12pt label height ~20.
            // Centre it: y + 20 + (36-20)/2 = y + 28
            lblRole.Location = new Point(roleX, y + 28);
            canvas.Controls.Add(lblRole);

            y += h + GAP;
        }

        private void BuildStatCards(Panel canvas, ref int y, int h)
        {
            int usable = CANVAS_W - PAD * 2;
            int cardW = (usable - GAP * 3) / 4;

            string[] titles = { "Low Stock Items", "Total Customers", "My Transactions (Month)", "My Revenue (Month)" };
            string[] defaults = { "-", "-", "-", "R-" };
            Color[] accents = { purple, teal, orange, green };

            Label[] valueLabels = new Label[4];

            for (int i = 0; i < 4; i++)
            {
                int x = PAD + i * (cardW + GAP);

                Panel card = new Panel();
                card.Bounds = new Rectangle(x, y, cardW, h);
                card.BackColor = Color.White;

                Panel topBar = new Panel();
                topBar.Bounds = new Rectangle(0, 0, cardW, 4);
                topBar.BackColor = accents[i];
                card.Controls.Add(topBar);

                Label lblTitle = new Label();
                lblTitle.Text = titles[i];
                lblTitle.Font = new Font("Microsoft Sans Serif", 8.5f, FontStyle.Regular);
                lblTitle.ForeColor = Color.FromArgb(80, 80, 80);
                lblTitle.BackColor = Color.Transparent;
                lblTitle.Bounds = new Rectangle(10, 8, cardW - 20, 18);
                card.Controls.Add(lblTitle);

                Label lblVal = new Label();
                lblVal.Text = defaults[i];
                lblVal.Font = new Font("Microsoft Sans Serif", 20f, FontStyle.Bold);
                lblVal.ForeColor = accents[i];
                lblVal.BackColor = Color.Transparent;
                lblVal.Bounds = new Rectangle(10, 28, cardW - 20, h - 36);
                card.Controls.Add(lblVal);

                valueLabels[i] = lblVal;
                canvas.Controls.Add(card);
            }

            lblLowStock = valueLabels[0];
            lblCustomers = valueLabels[1];
            lblMyTxCount = valueLabels[2];
            lblMyRevenue = valueLabels[3];

            y += h + GAP;
        }

        private void BuildMainRow(Panel canvas, ref int y, int h)
        {
            int usable = CANVAS_W - PAD * 2;
            int txW = (int)(usable * 0.50) - GAP / 2;
            int stW = (int)(usable * 0.27) - GAP / 2;
            int bestW = usable - txW - stW - GAP * 2;
            int gridH = h - 34;

            int xTx = PAD;
            int xSt = xTx + txW + GAP;
            int xBest = xSt + stW + GAP;

            // My Transactions
            Panel txCard = MakeSectionPanel(new Rectangle(xTx, y, txW, h), "My Transactions (This Month)");

            dgvMyTransactions = MakeGrid(txW, gridH);
            dgvMyTransactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "col_InvoiceNumber", HeaderText = "Invoice", DataPropertyName = "InvoiceNumber", FillWeight = 90 });
            dgvMyTransactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "col_SaleDateStr", HeaderText = "Date", DataPropertyName = "SaleDateStr", FillWeight = 140 });
            dgvMyTransactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "col_CustomerName", HeaderText = "Customer", DataPropertyName = "CustomerName", FillWeight = 130 });
            dgvMyTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "col_TotalAmtStr",
                HeaderText = "Total Amount",
                DataPropertyName = "TotalAmtStr",
                FillWeight = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvMyTransactions.Size = new Size(txW, gridH);
            dgvMyTransactions.Location = new Point(0, 32);
            txCard.Controls.Add(dgvMyTransactions);
            canvas.Controls.Add(txCard);

            // Low Stock
            Panel stCard = MakeSectionPanel(new Rectangle(xSt, y, stW, h), "Low Stock Items");

            dgvLowStock = MakeGrid(stW, gridH);
            dgvLowStock.Columns.Add(new DataGridViewImageColumn
            {
                Name = "col_ProductImage",
                HeaderText = "",
                DataPropertyName = "ProductImage",
                Width = 32,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                DefaultCellStyle = new DataGridViewCellStyle { NullValue = null }
            });
            dgvLowStock.Columns.Add(new DataGridViewTextBoxColumn { Name = "col_ProductName", HeaderText = "Product", DataPropertyName = "ProductName", FillWeight = 100 });
            dgvLowStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "col_CurrentStock",
                HeaderText = "Stock",
                DataPropertyName = "CurrentStock",
                FillWeight = 58,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvLowStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "col_ReorderLevel",
                HeaderText = "Reorder",
                DataPropertyName = "ReorderLevel",
                FillWeight = 58,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvLowStock.RowTemplate.Height = 32;
            dgvLowStock.DataError += (s, e) => e.ThrowException = false;
            dgvLowStock.Size = new Size(stW, gridH);
            dgvLowStock.Location = new Point(0, 32);
            stCard.Controls.Add(dgvLowStock);
            canvas.Controls.Add(stCard);

            // Best Customer
            Panel bestCard = MakeSectionPanel(new Rectangle(xBest, y, bestW, h), "Best Customer (This Month)");
            BuildBestCustomerSection(bestCard, bestW, h);
            canvas.Controls.Add(bestCard);

            y += h + GAP;
        }

        private void BuildBestCustomerSection(Panel card, int w, int h)
        {
            Panel body = new Panel();
            body.Location = new Point(0, 30);
            body.Size = new Size(w, h - 30);
            body.BackColor = Color.White;
            body.Tag = new string[] { "No data", "R0.00", "0" };
            body.Paint += BestCustomerBodyPaint;
            card.Controls.Add(body);

            lblBestName = new Label { Visible = false, Text = "No data" };
            lblBestSpent = new Label { Visible = false, Text = "R0.00" };
            lblBestTx = new Label { Visible = false, Text = "0" };

            lblBestName.TextChanged += (s, e) => RefreshBestBody(body);
            lblBestSpent.TextChanged += (s, e) => RefreshBestBody(body);
            lblBestTx.TextChanged += (s, e) => RefreshBestBody(body);

            card.Controls.Add(lblBestName);
            card.Controls.Add(lblBestSpent);
            card.Controls.Add(lblBestTx);
        }

        private void RefreshBestBody(Panel body)
        {
            body.Tag = new string[] { lblBestName.Text, lblBestSpent.Text, lblBestTx.Text };
            body.Invalidate();
        }

        private void BestCustomerBodyPaint(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            string[] vals = p.Tag as string[];
            if (vals == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            int pw = p.Width;
            int ph = p.Height;

            int top = 6;
            int slot = Math.Max((ph - top - 4) / 5, 16);

            StringFormat sfC = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            g.DrawString(vals[0],
                new Font("Microsoft Sans Serif", 10f, FontStyle.Bold),
                new SolidBrush(navyBlue),
                new RectangleF(4, top, pw - 8, slot), sfC);

            g.DrawString("Total Spent",
                new Font("Microsoft Sans Serif", 8f, FontStyle.Regular),
                new SolidBrush(Color.FromArgb(100, 100, 100)),
                new RectangleF(4, top + slot, pw - 8, slot), sfC);

            g.DrawString(vals[1],
                new Font("Microsoft Sans Serif", 13f, FontStyle.Bold),
                new SolidBrush(green),
                new RectangleF(4, top + slot * 2, pw - 8, slot), sfC);

            g.DrawString("No. of Transactions",
                new Font("Microsoft Sans Serif", 8f, FontStyle.Regular),
                new SolidBrush(Color.FromArgb(100, 100, 100)),
                new RectangleF(4, top + slot * 3, pw - 8, slot), sfC);

            g.DrawString(vals[2],
                new Font("Microsoft Sans Serif", 11f, FontStyle.Bold),
                new SolidBrush(navyBlue),
                new RectangleF(4, top + slot * 4, pw - 8, slot), sfC);
        }

        private void BuildFooter(Panel canvas, ref int y, int h)
        {
            int fH = Math.Max(h, 36);
            int footW = CANVAS_W - PAD * 2;

            Panel footer = new Panel();
            footer.Bounds = new Rectangle(PAD, y, footW, fH);
            footer.BackColor = Color.FromArgb(220, 230, 242);

            lblLastUpdated = new Label();
            lblLastUpdated.Text = "Dashboard data is updated daily.  Last updated: -";
            lblLastUpdated.Font = new Font("Microsoft Sans Serif", 8.5f, FontStyle.Regular);
            lblLastUpdated.ForeColor = navyBlue;
            lblLastUpdated.BackColor = Color.Transparent;
            lblLastUpdated.Bounds = new Rectangle(8, 0, footW - 110, fH);
            lblLastUpdated.TextAlign = ContentAlignment.MiddleLeft;
            footer.Controls.Add(lblLastUpdated);

            Button btnRefresh = new Button();
            btnRefresh.Text = "Refresh";
            btnRefresh.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
            btnRefresh.TextAlign = ContentAlignment.MiddleCenter;
            btnRefresh.ForeColor = navyBlue;
            btnRefresh.BackColor = Color.FromArgb(220, 230, 242);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Size = new Size(100, fH);
            btnRefresh.Location = new Point(footW - 102, 0);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderColor = navyBlue;
            btnRefresh.FlatAppearance.BorderSize = 1;
            btnRefresh.Click += (s, e) => LoadDashboardData();
            footer.Controls.Add(btnRefresh);

            canvas.Controls.Add(footer);
            y += fH + VPAD;
        }

        private Panel MakeSectionPanel(Rectangle bounds, string title)
        {
            Panel card = new Panel();
            card.Bounds = bounds;
            card.BackColor = Color.White;

            Panel header = new Panel();
            header.Bounds = new Rectangle(0, 0, bounds.Width, 30);
            header.BackColor = navyBlue;

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Bounds = new Rectangle(8, 0, bounds.Width - 16, 30);
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            header.Controls.Add(lblTitle);

            card.Controls.Add(header);
            return card;
        }

        private DataGridView MakeGrid(int w, int h)
        {
            DataGridView g = new DataGridView();
            g.BackgroundColor = Color.White;
            g.BorderStyle = BorderStyle.FixedSingle;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.GridColor = Color.FromArgb(200, 200, 210);
            g.ColumnHeadersHeight = 28;
            g.RowTemplate.Height = 28;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.ReadOnly = true;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.MultiSelect = false;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.ScrollBars = ScrollBars.Vertical;
            g.RowHeadersVisible = false;
            g.AutoGenerateColumns = false;
            g.EnableHeadersVisualStyles = false;
            g.Size = new Size(w, h);

            typeof(DataGridView)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance)
                ?.SetValue(g, true, null);

            g.ColumnHeadersDefaultCellStyle.BackColor = navyBlue;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.5f, FontStyle.Bold);
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = navyBlue;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            g.DefaultCellStyle.BackColor = Color.White;
            g.DefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);
            g.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.5f, FontStyle.Regular);
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(190, 210, 235);
            g.DefaultCellStyle.SelectionForeColor = Color.Black;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 242, 250);

            return g;
        }

        private Image BytesToImage(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return null;

            try
            {
                return Image.FromStream(new System.IO.MemoryStream(bytes));
            }
            catch
            {
                return null;
            }
        }

        public void LoadDashboardData()
        {
            if (!isLoaded)
                return;

            try
            {
                currentData = dashboardService.LoadAll(cashierID);
                BindDataToControls(currentData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dashboard failed to load data:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BindDataToControls(CashierDashboardData data)
        {
            if (data == null)
                return;

            lblLowStock.Text = data.Summary.LowStockCount.ToString();
            lblCustomers.Text = data.Summary.TotalCustomers.ToString("N0");
            lblMyTxCount.Text = data.Summary.MyTxCount.ToString("N0");
            lblMyRevenue.Text = "R" + data.Summary.MyTxTotal.ToString("N2");

            // My transactions grid
            dgvMyTransactions.DataSource = data.MyTransactions.Select(t => new
            {
                t.InvoiceNumber,
                SaleDateStr = t.SaleDateTime.ToString("dd MMM yyyy HH:mm"),
                t.CustomerName,
                TotalAmtStr = "R" + t.TotalAmount.ToString("N2")
            }).ToList();

            // Low stock grid
            dgvLowStock.DataSource = data.LowStockItems.Select(s => new
            {
                ProductImage = BytesToImage(s.ProductImageBytes),
                s.ProductName,
                CurrentStock = s.CurrentStock.ToString(),
                ReorderLevel = s.ReorderLevel.ToString()
            }).ToList();

            foreach (DataGridViewRow row in dgvLowStock.Rows)
            {
                if (row.IsNewRow) continue;
                DataGridViewCell cell = row.Cells["col_CurrentStock"];
                int qty;
                if (cell.Value != null && int.TryParse(cell.Value.ToString(), out qty))
                {
                    cell.Style.ForeColor = qty <= 3 ? red : orange;
                }
            }

            // Best customer
            if (data.BestCustomer != null)
            {
                lblBestName.Text = data.BestCustomer.CustomerName;
                lblBestSpent.Text = "R" + data.BestCustomer.TotalSpent.ToString("N2");
                lblBestTx.Text = data.BestCustomer.TransactionCount.ToString();
            }
            else
            {
                lblBestName.Text = "No data this month";
                lblBestSpent.Text = "R0.00";
                lblBestTx.Text = "0";
            }

            lblLastUpdated.Text = "Dashboard data is updated daily.  Last updated: "
                + data.LastUpdated.ToString("dd MMM yyyy HH:mm");
        }

        public void isDarkMode(bool dark)
        {
            //this.BackgroundImage = dark ? Properties.Resources.Dark_Background : Properties.Resources.POINT_OF_SALES;
            if (dark)
            {
                this.BackgroundImage = null;
                this.BackColor = Color.Black;
                lblWelcome.ForeColor = Color.White;
                lblName.ForeColor = Color.White;
                lblRole.ForeColor = Color.White;
            }
            else
            {
                this.BackgroundImage = Properties.Resources.POINT_OF_SALES;
                lblWelcome.ForeColor = Color.FromArgb(20, 20, 40);
                lblName.ForeColor = Color.FromArgb(20, 20, 60);
                lblRole.ForeColor = navyBlue;
            }
        }
    }
}
