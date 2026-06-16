// DashboardForm.cs
// Author: [Your Name] - [Student Number]
// Date: June 2026
// Description: Manager dashboard form for Sam's Liquor Shop POS system.
//              Shows monthly sales summary, stock levels, top products and recent transactions.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TheByteClubPOS
{
    public partial class DashboardForm : Form
    {
        // Employee info passed in from MainForm
        private int employeeID;
        private string employeeName;
        private string employeeRole;

        // Colours used throughout the dashboard
        private Color navyBlue = Color.FromArgb(31, 73, 125);
        private Color lightBlue = Color.FromArgb(220, 230, 242);
        private Color green = Color.FromArgb(0, 153, 76);
        private Color orange = Color.FromArgb(204, 85, 0);
        private Color purple = Color.FromArgb(102, 0, 153);
        private Color teal = Color.FromArgb(0, 128, 128);
        private Color red = Color.FromArgb(192, 0, 0);

        // Fixed canvas size - matches the MDI client area at design time
        private const int CANVAS_W = 1134;
        private const int CANVAS_H = 740;

        // Spacing constants
        private const int PAD = 20;
        private const int GAP = 10;
        private const int VPAD = 12;

        // Controls that need to be updated when data loads
        private Label lblMonthSales;
        private Label lblTxCount;
        private Label lblLowStock;
        private Label lblCustomers;
        private Label lblEmployees;
        private Chart pieChart;
        private Panel pnlTopSelling;
        private Panel pnlLeastSelling;
        private DataGridView dgvTransactions;
        private DataGridView dgvLowStock;
        private Label lblBestCustomerName;
        private Label lblBestCustomerSpent;
        private Label lblBestCustomerTx;
        private Label lblLastUpdated;

        // Data service and auto-refresh timer
        private DashboardService dashboardService = new DashboardService();
        private Timer refreshTimer = new Timer();
        private DashboardData currentData;
        private bool isLoaded = false;

        public DashboardForm()
        {
            employeeName = "Manager";
            employeeRole = "Manager";
            InitializeComponent();
            SetupDashboard();
        }

        public DashboardForm(int id, string name, string role)
        {
            employeeID = id;
            employeeName = name;
            employeeRole = role;
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

            // Returns the true MDI client area size by reading it directly
            // from the MdiClient control on the parent form. This is reliable
            // even before the child has been fully sized by the MDI framework.
            Action rebuildLayout = () =>
            {
                // this.ClientSize returns the SCREEN size because the MDI child
                // has FormBorderStyle.None + WindowState.Maximized (maximises to screen).
                // Use MdiParent.ClientSize and subtract the known chrome instead.
                int parentW = this.MdiParent != null
                    ? this.MdiParent.ClientSize.Width : this.ClientSize.Width;
                int parentH = this.MdiParent != null
                    ? this.MdiParent.ClientSize.Height : this.ClientSize.Height;
                int w = Math.Max(parentW - 220, CANVAS_W);  // subtract sidebar (220px)
                int h = Math.Max(parentH - 59, 380);       // subtract menu(30)+status(29)
                if (w < 50 || h < 50) return;
                canvas.Size = new Size(w, h);
                canvas.BackColor = Color.Transparent;
                canvas.Location = new Point(0, 0);
                canvas.Controls.Clear();
                BuildDashboard(canvas);
            };


            // Use a one-shot timer so the MDI framework finishes its layout
            // before we build. Shown fires too early and ClientSize is stale.
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

            // Auto-refresh every 60 seconds
            refreshTimer.Interval = 60000;
            refreshTimer.Tick += (s, e) => LoadDashboardData();
            refreshTimer.Start();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            refreshTimer.Stop();
            refreshTimer.Dispose();
            base.OnFormClosed(e);
        }

        // Builds all the controls and places them on the canvas
        private void BuildDashboard(Panel canvas)
        {
            int H = canvas.Height;
            int totalGaps = VPAD * 2 + GAP * 4;
            int footHeight = 36;

            // Distribute height into fixed header+cards and proportional mid+bot.
            // At small windows the header shrinks first, then cards,
            // and mid+bot share everything that is left.
            int headerHeight = Math.Min(76, Math.Max(52, (int)(H * 0.12)));
            int cardHeight = Math.Min(72, Math.Max(60, (int)(H * 0.13)));
            int midAndBot = H - totalGaps - footHeight - headerHeight - cardHeight;
            int midHeight = Math.Max((int)(midAndBot * 0.52), 147);
            int botHeight = midAndBot - midHeight;

            int y = VPAD;
            BuildHeader(canvas, ref y, headerHeight);
            BuildStatCards(canvas, ref y, cardHeight);
            BuildMiddleRow(canvas, ref y, midHeight);
            BuildBottomRow(canvas, ref y, botHeight);
            BuildFooter(canvas, ref y, footHeight);
        }

        private void BuildHeader(Panel canvas, ref int y, int h)
        {
            // Labels placed directly on canvas — dark navy text that reads
            // clearly over the background image without any overlay panel.
            Label lblWelcome = new Label();
            lblWelcome.Text = "Welcome back,";
            lblWelcome.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular);
            lblWelcome.ForeColor = Color.FromArgb(20, 20, 40);
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Bounds = new Rectangle(PAD, y, 300, 20);
            canvas.Controls.Add(lblWelcome);

            Label lblName = new Label();
            lblName.Text = employeeName;
            lblName.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Bold | FontStyle.Underline);
            lblName.ForeColor = Color.FromArgb(20, 20, 60);
            lblName.BackColor = Color.Transparent;
            lblName.AutoSize = true;
            lblName.Location = new Point(PAD, y + 20);
            canvas.Controls.Add(lblName);

            // Role badge sits on the same line as the name, just to the right
            // We use AutoSize on lblName so we can position lblRole after it.
            // Since AutoSize doesn't work before the control is shown, we
            // estimate the name width using MeasureString.
            SizeF nameSize = canvas.CreateGraphics().MeasureString(
                employeeName,
                new Font("Microsoft Sans Serif", 18f, FontStyle.Bold | FontStyle.Underline));
            int roleX = PAD + (int)nameSize.Width + 12;

            Label lblRole = new Label();
            lblRole.Text = employeeRole + " - Dashboard";
            lblRole.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
            lblRole.ForeColor = navyBlue;
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
            int cardW = (usable - GAP * 4) / 5;

            // Card definitions: title, default value, accent colour
            string[] titles = { "This Month Sales", "No. of Transactions", "Low Stock Items", "Total Customers", "Total Employees" };
            string[] defaults = { "R-", "-", "-", "-", "-" };
            Color[] accents = { green, orange, purple, teal, navyBlue };

            Label[] valueLabels = new Label[5];

            for (int i = 0; i < 5; i++)
            {
                int x = PAD + i * (cardW + GAP);

                // White semi-transparent card
                Panel card = new Panel();
                card.Bounds = new Rectangle(x, y, cardW, h);
                card.BackColor = Color.White;

                // Coloured accent bar at top
                Panel topBar = new Panel();
                topBar.Bounds = new Rectangle(0, 0, cardW, 4);
                topBar.BackColor = accents[i];
                card.Controls.Add(topBar);

                // Title label
                Label lblTitle = new Label();
                lblTitle.Text = titles[i];
                lblTitle.Font = new Font("Microsoft Sans Serif", 8.5f, FontStyle.Regular);
                lblTitle.ForeColor = Color.FromArgb(80, 80, 80);
                lblTitle.BackColor = Color.Transparent;
                lblTitle.Bounds = new Rectangle(10, 8, cardW - 20, 18);
                card.Controls.Add(lblTitle);

                // Value label (large, coloured)
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

            // Assign to named fields for data binding later
            lblMonthSales = valueLabels[0];
            lblTxCount = valueLabels[1];
            lblLowStock = valueLabels[2];
            lblCustomers = valueLabels[3];
            lblEmployees = valueLabels[4];

            y += h + GAP;
        }

        private void BuildMiddleRow(Panel canvas, ref int y, int h)
        {
            int usable = CANVAS_W - PAD * 2;
            int pieW = (int)(usable * 0.37) - GAP / 2;
            int rankW = (usable - pieW - GAP * 2) / 2;

            int xPie = PAD;
            int xTop = xPie + pieW + GAP;
            int xLeast = xTop + rankW + GAP;

            // Pie chart card
            Panel pieCard = MakeSectionPanel(new Rectangle(xPie, y, pieW, h), "Sales by Category (This Month)");
            pieChart = BuildPieChart(pieCard, pieW, h);
            canvas.Controls.Add(pieCard);

            // Top selling card
            Panel topCard = MakeSectionPanel(new Rectangle(xTop, y, rankW, h), "Top Selling Products (This Month)");
            pnlTopSelling = new Panel();
            pnlTopSelling.Location = new Point(0, 32);
            pnlTopSelling.Size = new Size(rankW, h - 33);
            pnlTopSelling.BackColor = Color.White;
            pnlTopSelling.AutoScroll = false;
            topCard.Controls.Add(pnlTopSelling);
            canvas.Controls.Add(topCard);

            // Least selling card
            Panel leastCard = MakeSectionPanel(new Rectangle(xLeast, y, rankW, h), "Least Selling Products (This Month)");
            pnlLeastSelling = new Panel();
            pnlLeastSelling.Location = new Point(0, 32);
            pnlLeastSelling.Size = new Size(rankW, h - 33);
            pnlLeastSelling.BackColor = Color.White;
            pnlLeastSelling.AutoScroll = false;
            leastCard.Controls.Add(pnlLeastSelling);
            canvas.Controls.Add(leastCard);

            y += h + GAP;
        }

        private void BuildBottomRow(Panel canvas, ref int y, int h)
        {
            int usable = CANVAS_W - PAD * 2;
            int txW = (int)(usable * 0.48) - GAP / 2;
            int stW = (int)(usable * 0.30) - GAP / 2;
            int bestW = usable - txW - stW - GAP * 2;
            int gridH = h - 34;   // card height minus 32px header + 2px border

            int xTx = PAD;
            int xSt = xTx + txW + GAP;
            int xBest = xSt + stW + GAP;

            // Recent Transactions
            Panel txCard = MakeSectionPanel(new Rectangle(xTx, y, txW, h), "Recent Transactions");

            dgvTransactions = MakeGrid(txW, gridH);
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "col_InvoiceNumber", HeaderText = "Invoice", DataPropertyName = "InvoiceNumber", FillWeight = 90 });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "col_SaleDateStr", HeaderText = "Date", DataPropertyName = "SaleDateStr", FillWeight = 140 });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "col_CustomerName", HeaderText = "Customer", DataPropertyName = "CustomerName", FillWeight = 120 });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "col_TotalAmtStr",
                HeaderText = "Total Amount",
                DataPropertyName = "TotalAmtStr",
                FillWeight = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvTransactions.Size = new Size(txW, gridH);
            dgvTransactions.Location = new Point(0, 32);
            txCard.Controls.Add(dgvTransactions);
            canvas.Controls.Add(txCard);

            // Low Stock Items
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
            dgvLowStock.Columns.Add(new DataGridViewTextBoxColumn { Name = "col_ProductName", HeaderText = "Product", DataPropertyName = "ProductName", FillWeight = 110 });
            dgvLowStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "col_CurrentStock",
                HeaderText = "Stock",
                DataPropertyName = "CurrentStock",
                FillWeight = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvLowStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "col_ReorderLevel",
                HeaderText = "Reorder",
                DataPropertyName = "ReorderLevel",
                FillWeight = 65,
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

            // Hidden labels used only as data holders — BindDataToControls
            // writes to their Text and the TextChanged event repaints the body.
            lblBestCustomerName = new Label { Visible = false, Text = "No data" };
            lblBestCustomerSpent = new Label { Visible = false, Text = "R0.00" };
            lblBestCustomerTx = new Label { Visible = false, Text = "0" };

            lblBestCustomerName.TextChanged += (s, e) => RefreshBestBody(body);
            lblBestCustomerSpent.TextChanged += (s, e) => RefreshBestBody(body);
            lblBestCustomerTx.TextChanged += (s, e) => RefreshBestBody(body);

            card.Controls.Add(lblBestCustomerName);
            card.Controls.Add(lblBestCustomerSpent);
            card.Controls.Add(lblBestCustomerTx);
        }

        private void RefreshBestBody(Panel body)
        {
            body.Tag = new string[]
            {
                lblBestCustomerName.Text,
                lblBestCustomerSpent.Text,
                lblBestCustomerTx.Text
            };
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

            // Divide available height into 5 slots — no minimum floor so
            // content never overflows the card at any window size.
            int top = 4;
            int slot = Math.Max((ph - top) / 5, 1);

            // Scale font sizes down gracefully when slots are small
            float nameFnt = slot >= 20 ? 10f : slot >= 14 ? 8.5f : 7f;
            float valFnt = slot >= 20 ? 13f : slot >= 14 ? 10f : 8f;
            float lblFnt = slot >= 16 ? 8f : 7f;
            float txFnt = slot >= 20 ? 11f : slot >= 14 ? 9f : 7.5f;

            StringFormat sfC = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            g.DrawString(vals[0],
                new Font("Microsoft Sans Serif", nameFnt, FontStyle.Bold),
                new SolidBrush(navyBlue),
                new RectangleF(4, top, pw - 8, slot), sfC);

            g.DrawString("Total Spent",
                new Font("Microsoft Sans Serif", lblFnt, FontStyle.Regular),
                new SolidBrush(Color.FromArgb(100, 100, 100)),
                new RectangleF(4, top + slot, pw - 8, slot), sfC);

            g.DrawString(vals[1],
                new Font("Microsoft Sans Serif", valFnt, FontStyle.Bold),
                new SolidBrush(green),
                new RectangleF(4, top + slot * 2, pw - 8, slot), sfC);

            g.DrawString("No. of Transactions",
                new Font("Microsoft Sans Serif", lblFnt, FontStyle.Regular),
                new SolidBrush(Color.FromArgb(100, 100, 100)),
                new RectangleF(4, top + slot * 3, pw - 8, slot), sfC);

            g.DrawString(vals[2],
                new Font("Microsoft Sans Serif", txFnt, FontStyle.Bold),
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

        // Creates a section panel with a navy header bar
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

        // Creates a styled DataGridView
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

            // Enable double buffering to reduce flicker
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

        private Chart BuildPieChart(Panel card, int cardW, int cardH)
        {
            Chart ch = new Chart();
            ch.Location = new Point(0, 32);
            ch.Size = new Size(cardW, cardH - 32);
            ch.BackColor = Color.Transparent;

            ChartArea area = new ChartArea("main");
            area.BackColor = Color.Transparent;
            area.Position = new ElementPosition(0, 2, 50, 96);
            area.InnerPlotPosition = new ElementPosition(2, 2, 96, 96);
            ch.ChartAreas.Add(area);

            Series ser = new Series("cat");
            ser.ChartType = SeriesChartType.Pie;
            ser.IsValueShownAsLabel = false;
            ser.Label = "";
            ser["PieLabelStyle"] = "Disabled";
            ch.Series.Add(ser);

            Legend leg = new Legend("main");
            leg.DockedToChartArea = "main";
            leg.IsDockedInsideChartArea = false;
            leg.Docking = Docking.Right;
            leg.Alignment = StringAlignment.Center;
            leg.BackColor = Color.Transparent;
            leg.Font = new Font("Microsoft Sans Serif", 7f);
            leg.IsTextAutoFit = true;
            leg.LegendStyle = LegendStyle.Column;
            leg.ItemColumnSpacing = 0;
            ch.Legends.Add(leg);

            ch.PaletteCustomColors = new Color[]
            {
                Color.FromArgb(31,  73, 125),
                Color.FromArgb(0,  153,  76),
                Color.FromArgb(102,  0, 153),
                Color.FromArgb(204, 85,   0),
                Color.FromArgb(0,  128, 128)
            };
            ch.Palette = ChartColorPalette.None;

            card.Controls.Add(ch);
            return ch;
        }

        // Converts a byte array to an Image (for product photos)
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

        // Fills the rank panel entirely via Paint — avoids all WinForms
        // child-control transparency bugs that caused even rows to vanish.
        private void FillRankPanel(Panel panel, List<ProductSalesRankDto> items)
        {
            // Store items on the panel so the Paint event can use them
            panel.Tag = items;
            panel.BackColor = Color.White;

            // Remove old Paint handlers by recreating a fresh reference.
            // We store the handler so it can be removed if called again.
            panel.Controls.Clear();
            panel.Paint -= RankPanelPaint;
            panel.Paint += RankPanelPaint;
            panel.Invalidate();
        }

        private void RankPanelPaint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            List<ProductSalesRankDto> items = panel.Tag as List<ProductSalesRankDto>;
            if (items == null || items.Count == 0) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int rowH = Math.Max((panel.Height - 2) / Math.Max(items.Count, 1), 22);
            int imgSize = Math.Min(rowH - 8, 28);
            int y = 1;

            Color[] badgeColors = new Color[]
            {
                Color.FromArgb(31,  73, 125),
                Color.FromArgb(0,  153,  76),
                Color.FromArgb(204,  85,   0),
                Color.FromArgb(100, 100, 120),
                Color.FromArgb(100, 100, 120)
            };

            Font fontName = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular);
            Font fontUnits = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold);
            Font fontBadge = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold);

            StringFormat sfLeft = new StringFormat { LineAlignment = StringAlignment.Center };
            StringFormat sfRight = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };
            StringFormat sfCtr = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            foreach (ProductSalesRankDto item in items)
            {
                Color rowBg = (item.Rank % 2 == 0)
                    ? Color.FromArgb(235, 242, 250)
                    : Color.White;
                g.FillRectangle(new SolidBrush(rowBg),
                    new Rectangle(0, y, panel.Width, rowH));

                // Badge circle
                Color bc = (item.Rank - 1 < badgeColors.Length)
                    ? badgeColors[item.Rank - 1]
                    : badgeColors[badgeColors.Length - 1];
                int bY = y + (rowH - 22) / 2;
                g.FillEllipse(new SolidBrush(bc), 6, bY, 22, 22);
                g.DrawString(item.Rank.ToString(), fontBadge, Brushes.White,
                    new RectangleF(6, bY, 22, 22), sfCtr);

                // Product image
                int imgX = 34;
                int imgY = y + (rowH - imgSize) / 2;
                Image productImg = BytesToImage(item.ProductImageBytes);
                if (productImg != null)
                {
                    g.DrawImage(productImg,
                        new Rectangle(imgX, imgY, imgSize, imgSize));
                }
                else
                {
                    // Simple bottle placeholder
                    g.FillRectangle(new SolidBrush(Color.FromArgb(180, 180, 200)),
                        new Rectangle(imgX + 6, imgY + 2, 10, imgSize - 4));
                    g.FillRectangle(new SolidBrush(Color.FromArgb(180, 180, 200)),
                        new Rectangle(imgX + 8, imgY, 6, 4));
                }

                // Product name
                int nameX = imgX + imgSize + 4;
                g.DrawString(item.ProductName, fontName,
                    new SolidBrush(Color.FromArgb(20, 20, 20)),
                    new RectangleF(nameX, y, panel.Width - nameX - 44, rowH),
                    sfLeft);

                // Units sold
                g.DrawString(item.UnitsSold.ToString(), fontUnits,
                    new SolidBrush(navyBlue),
                    new RectangleF(panel.Width - 42, y, 40, rowH),
                    sfRight);

                // Row separator
                g.DrawLine(new Pen(Color.FromArgb(200, 200, 215)),
                    0, y + rowH - 1, panel.Width, y + rowH - 1);

                y += rowH;
            }
        }

        public void LoadDashboardData()
        {
            if (!isLoaded)
                return;

            try
            {
                currentData = dashboardService.LoadAll();
                BindDataToControls(currentData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dashboard failed to load data:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BindDataToControls(DashboardData data)
        {
            if (data == null)
                return;

            // Stat cards
            lblMonthSales.Text = "R" + data.Summary.MonthSalesTotal.ToString("N2");
            lblTxCount.Text = data.Summary.MonthTransactionCount.ToString("N0");
            lblLowStock.Text = data.Summary.LowStockCount.ToString();
            lblCustomers.Text = data.Summary.TotalCustomers.ToString("N0");
            lblEmployees.Text = data.Summary.TotalEmployees.ToString();

            // Pie chart
            BindPieChart(data.CategorySales);

            // Top and least selling
            FillRankPanel(pnlTopSelling, data.TopSelling);
            FillRankPanel(pnlLeastSelling, data.LeastSelling);

            // Recent transactions
            dgvTransactions.DataSource = data.RecentTransactions.Select(t => new
            {
                t.InvoiceNumber,
                SaleDateStr = t.SaleDateTime.ToString("dd MMM yyyy HH:mm"),
                t.CustomerName,
                TotalAmtStr = "R" + t.TotalAmount.ToString("N2")
            }).ToList();

            // Low stock items
            dgvLowStock.DataSource = data.LowStockItems.Select(s => new
            {
                ProductImage = BytesToImage(s.ProductImageBytes),
                s.ProductName,
                CurrentStock = s.CurrentStock.ToString(),
                ReorderLevel = s.ReorderLevel.ToString()
            }).ToList();

            // Colour the stock numbers
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
                lblBestCustomerName.Text = data.BestCustomer.CustomerName;
                lblBestCustomerSpent.Text = "R" + data.BestCustomer.TotalSpent.ToString("N2");
                lblBestCustomerTx.Text = data.BestCustomer.TransactionCount.ToString();
            }
            else
            {
                lblBestCustomerName.Text = "No data this month";
                lblBestCustomerSpent.Text = "R0.00";
                lblBestCustomerTx.Text = "0";
            }

            // Footer
            lblLastUpdated.Text = "Dashboard data is updated daily.  Last updated: "
                + data.LastUpdated.ToString("dd MMM yyyy HH:mm");
        }

        private void BindPieChart(List<CategorySalesDto> items)
        {
            Series ser = pieChart.Series["cat"];
            ser.Points.Clear();

            if (items == null || items.Count == 0)
                return;

            decimal total = items.Sum(x => x.TotalSales);

            foreach (CategorySalesDto item in items)
            {
                double pct = total > 0 ? (double)(item.TotalSales / total * 100m) : 0;
                int idx = ser.Points.AddXY(item.CategoryName, pct);
                ser.Points[idx].LegendText = item.CategoryName + "   " + pct.ToString("F0") + "%";
            }
        }

        public void isDarkMode(bool dark)
        {
            //this.BackgroundImage = dark ? Properties.Resources.Dark_Background : Properties.Resources.POINT_OF_SALES;
            if (dark)
            {
                this.BackgroundImage = null;
                this.BackColor = Color.Black;
            }
            else
            {
                this.BackgroundImage = Properties.Resources.POINT_OF_SALES;
            }
        }
    }
}
