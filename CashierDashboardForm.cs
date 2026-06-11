using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TheByteClubPOS
{
    /// <summary>
    /// Cashier Dashboard — shown when a Cashier role logs in.
    /// Displays: Low Stock count, Total Customers, Best Customer this month,
    ///           and the cashier's own transaction history.
    ///
    /// Call from MainForm.btnDashboard_Click when employeeRole == "cashier":
    ///   OpenChildForm(new CashierDashboardForm(employeeID, employeeFullName));
    /// </summary>
    public partial class CashierDashboardForm : Form
    {
        // ── Constructor params ────────────────────────────────────────
        private readonly int    _employeeID;
        private readonly string _employeeName;

        // ── Colours (matches manager dashboard palette) ───────────────
        private static readonly Color C_BG     = Color.FromArgb(245, 247, 250);
        private static readonly Color C_CARD   = Color.White;
        private static readonly Color C_BORDER = Color.FromArgb(220, 225, 230);
        private static readonly Color C_DARK   = Color.FromArgb(30,  39,  46);
        private static readonly Color C_MID    = Color.FromArgb(100, 110, 120);
        private static readonly Color C_LINK   = Color.FromArgb(41,  128, 185);
        private static readonly Color C_GREEN  = Color.FromArgb(39,  174,  96);
        private static readonly Color C_ORANGE = Color.FromArgb(230, 126,  34);
        private static readonly Color C_PURPLE = Color.FromArgb(142,  68, 173);
        private static readonly Color C_TEAL   = Color.FromArgb(26,  188, 156);
        private static readonly Color C_BLUE   = Color.FromArgb(41,  128, 185);
        private static readonly Color C_RED    = Color.FromArgb(231,  76,  60);
        private static readonly Color C_INFO   = Color.FromArgb(232, 244, 253);

        private static Font F(float sz, FontStyle s = FontStyle.Regular) =>
            new Font("Segoe UI", sz, s, GraphicsUnit.Point);

        // ── Render dimensions ─────────────────────────────────────────
        // Fixed canvas size — scroll panel handles smaller windows.
        private const int RENDER_W = 1134;
        private const int RENDER_H = 700;
        private const int PAD      = 14;
        private const int VPAD     = 10;
        private const int GAP      =  8;

        // ── Named control refs ────────────────────────────────────────
        private Label        _lblName;
        private Label        _lblLowCount, _lblCustCount;
        private Label        _lblMyTxCount, _lblMyTxTotal;
        private DataGridView _dgvMyTx;
        private DataGridView _dgvLowStock;
        private Label        _lblBestName, _lblBestSpent, _lblBestTx;
        private Label        _lblFooter;

        // ── Data ──────────────────────────────────────────────────────
        private readonly CashierDashboardService _svc   = new CashierDashboardService();
        private readonly Timer                   _timer = new Timer();
        private CashierDashboardData             _cache;
        private bool                             _layoutReady;

        // =============================================================
        // CONSTRUCTORS
        // =============================================================

        public CashierDashboardForm()
        {
            _employeeName = "Cashier";
            InitializeComponent();
            SetupForm();
        }

        public CashierDashboardForm(int id, string name)
        {
            _employeeID   = id;
            _employeeName = name;
            InitializeComponent();
            SetupForm();
        }

        // =============================================================
        // FORM SETUP
        // =============================================================

        private void SetupForm()
        {
            this.Text           = "Dashboard \u2013 Sam's Liquor Shop";
            this.BackColor      = C_BG;
            this.DoubleBuffered = true;
            this.AutoScroll     = false;

            // Fixed-size canvas
            var canvas = new Panel
            {
                Location  = new Point(0, 0),
                Size      = new Size(RENDER_W, RENDER_H),
                BackColor = C_BG
            };
            PlaceAll(canvas);

            // Scroll wrapper — sized explicitly to MDI client area
            var scroll = new Panel
            {
                Location   = new Point(0, 0),
                BackColor  = C_BG,
                AutoScroll = true
            };
            scroll.Controls.Add(canvas);
            this.Controls.Add(scroll);

            Action sizeScroll = () =>
            {
                scroll.Size = new Size(
                    Math.Max(this.ClientSize.Width,  1),
                    Math.Max(this.ClientSize.Height, 1));
            };

            this.Resize += (s, e) => sizeScroll();

            this.Shown += (s, e) =>
            {
                sizeScroll();
                _layoutReady = true;
                LoadData();
            };

            _timer.Interval = 60_000;
            _timer.Tick    += (s, e) => LoadData();
            _timer.Start();
        }

        protected override void OnLoad(EventArgs e) { base.OnLoad(e); }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timer.Stop();
            _timer.Dispose();
            base.OnFormClosed(e);
        }

        // =============================================================
        // LAYOUT
        // =============================================================

        private void PlaceAll(Panel c)
        {
            int W = RENDER_W;
            int H = RENDER_H;

            int totalGaps = VPAD * 2 + GAP * 3;
            int available = H - totalGaps;

            // Sections: header 9%, cards 11%, main 55%, footer 7%
            // "main" row splits into transactions (left 60%) | stock+best (right 40%)
            int hHdr   = (int)(available * 0.09);
            int hCards = (int)(available * 0.11);
            int hMain  = (int)(available * 0.73);
            int hFtr   = available - hHdr - hCards - hMain;

            int y = VPAD;
            PlaceHeader  (c, ref y, W, hHdr);
            PlaceStatCards(c, ref y, W, hCards);
            PlaceMainRow (c, ref y, W, hMain);
            PlaceFooter  (c, ref y, W, hFtr);
        }

        // ── HEADER ────────────────────────────────────────────────────

        private void PlaceHeader(Panel c, ref int y, int W, int H)
        {
            c.Controls.Add(MkLbl("Welcome back,", F(9.5f), C_MID,
                new Rectangle(PAD, y, 300, 20)));

            _lblName = MkLbl(_employeeName, F(17, FontStyle.Bold), C_DARK,
                new Rectangle(PAD, y + 20, W - PAD * 2, 34));
            c.Controls.Add(_lblName);

            c.Controls.Add(MkLbl("Cashier", F(9.5f), C_LINK,
                new Rectangle(PAD, y + 56, 200, 20)));

            y += H + GAP;
        }

        // ── STAT CARDS ────────────────────────────────────────────────
        // Four cards: Low Stock | Total Customers | My Transactions | My Revenue

        private void PlaceStatCards(Panel c, ref int y, int W, int H)
        {
            int usable = W - PAD * 2;
            int cardW  = (usable - GAP * 3) / 4;

            var defs = new (string title, string def, Color accent)[]
            {
                ("Low Stock Items",           "\u2013", C_PURPLE),
                ("Total Customers",           "\u2013", C_TEAL),
                ("My Transactions (Month)",   "\u2013", C_ORANGE),
                ("My Revenue (Month)",        "R\u2013",C_GREEN),
            };

            var refs = new Label[4];

            for (int i = 0; i < defs.Length; i++)
            {
                int x    = PAD + i * (cardW + GAP);
                var card = MkCard(new Rectangle(x, y, cardW, H));

                card.Controls.Add(MkLbl(defs[i].title, F(8.5f), C_MID,
                    new Rectangle(12, 10, cardW - 24, 20)));

                var val = MkLbl(defs[i].def, F(20, FontStyle.Bold), defs[i].accent,
                    new Rectangle(12, 32, cardW - 24, H - 40));
                card.Controls.Add(val);
                refs[i] = val;

                c.Controls.Add(card);
            }

            _lblLowCount  = refs[0];
            _lblCustCount = refs[1];
            _lblMyTxCount = refs[2];
            _lblMyTxTotal = refs[3];

            y += H + GAP;
        }

        // ── MAIN ROW: Transactions | Low Stock | Best Customer ────────

        private void PlaceMainRow(Panel c, ref int y, int W, int H)
        {
            int usable = W - PAD * 2;

            // Tx = 50%, Low Stock = 27%, Best Customer = 23%
            int txW    = (int)(usable * 0.50) - GAP / 2;
            int stW    = (int)(usable * 0.27) - GAP / 2;
            int bestW  = usable - txW - stW - GAP * 2;

            int xTx   = PAD;
            int xSt   = xTx + txW  + GAP;
            int xBest = xSt + stW  + GAP;
            int gridH = H - 52;

            // ── My Transactions ───────────────────────────────────────
            var txCard = MkCard(new Rectangle(xTx, y, txW, H));
            AddTitle(txCard, "My Transactions (This Month)", txW);

            _dgvMyTx = MkGrid(
                ("Invoice",      "InvoiceNumber",  90, DataGridViewContentAlignment.MiddleLeft),
                ("Date",         "SaleDateStr",   145, DataGridViewContentAlignment.MiddleLeft),
                ("Customer",     "CustomerName",  130, DataGridViewContentAlignment.MiddleLeft),
                ("Total Amount", "TotalAmtStr",    90, DataGridViewContentAlignment.MiddleRight));
            _dgvMyTx.Location = new Point(1, 35);
            _dgvMyTx.Size     = new Size(txW - 2, gridH);
            txCard.Controls.Add(_dgvMyTx);
            txCard.Controls.Add(MkLbl("Showing latest 10 transactions", F(7.5f), C_MID,
                new Rectangle(10, H - 18, txW - 20, 15)));
            c.Controls.Add(txCard);

            // ── Low Stock Items ───────────────────────────────────────
            var stCard = MkCard(new Rectangle(xSt, y, stW, H));
            AddTitle(stCard, "Low Stock Items", stW);

            _dgvLowStock = MkGridWithImage(
                ("Product",    "ProductName",  100, DataGridViewContentAlignment.MiddleLeft),
                ("Stock",      "CurrentStock",  58, DataGridViewContentAlignment.MiddleCenter),
                ("Reorder",    "ReorderLevel",  58, DataGridViewContentAlignment.MiddleCenter));
            _dgvLowStock.Location        = new Point(1, 35);
            _dgvLowStock.Size            = new Size(stW - 2, gridH);
            stCard.Controls.Add(_dgvLowStock);
            stCard.Controls.Add(MkLbl("Showing latest 5 low stock items", F(7.5f), C_MID,
                new Rectangle(10, H - 18, stW - 20, 15)));
            c.Controls.Add(stCard);

            // ── Best Customer ─────────────────────────────────────────
            var bestCard = MkCard(new Rectangle(xBest, y, bestW, H));
            BuildBestCustomerCard(bestCard, bestW, H);
            c.Controls.Add(bestCard);

            y += H + GAP;
        }

        private void BuildBestCustomerCard(Panel card, int W, int H)
        {
            AddTitle(card, "Best Customer (This Month)", W);

            int avSize = 56;
            var av = new Panel
            {
                Size      = new Size(avSize, avSize),
                Location  = new Point((W - avSize) / 2, 44),
                BackColor = Color.Transparent
            };
            av.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (var br = new SolidBrush(Color.FromArgb(189, 195, 199)))
                    g.FillEllipse(br, 0, 0, avSize - 1, avSize - 1);
                g.FillEllipse(Brushes.White, 17, 7, 22, 22);
                g.FillEllipse(Brushes.White, 8, 32, 40, 26);
            };
            card.Controls.Add(av);

            int contentTop = 44 + avSize + 4;
            int remaining  = H - contentTop - 4;
            int slot       = Math.Max(remaining / 5, 18);

            _lblBestName = MkLbl("No data", F(10, FontStyle.Bold), C_DARK,
                new Rectangle(4, contentTop, W - 8, slot),
                ContentAlignment.MiddleCenter);
            card.Controls.Add(_lblBestName);

            card.Controls.Add(MkLbl("Total Spent", F(7.5f), C_MID,
                new Rectangle(4, contentTop + slot, W - 8, slot),
                ContentAlignment.MiddleCenter));

            _lblBestSpent = MkLbl("R0.00", F(13, FontStyle.Bold), C_BLUE,
                new Rectangle(4, contentTop + slot * 2, W - 8, slot),
                ContentAlignment.MiddleCenter);
            card.Controls.Add(_lblBestSpent);

            card.Controls.Add(MkLbl("No. of Transactions", F(7.5f), C_MID,
                new Rectangle(4, contentTop + slot * 3, W - 8, slot),
                ContentAlignment.MiddleCenter));

            _lblBestTx = MkLbl("0", F(11, FontStyle.Bold), C_DARK,
                new Rectangle(4, contentTop + slot * 4, W - 8, slot),
                ContentAlignment.MiddleCenter);
            card.Controls.Add(_lblBestTx);
        }

        // ── FOOTER ────────────────────────────────────────────────────

        private void PlaceFooter(Panel c, ref int y, int W, int H)
        {
            int fH    = Math.Max(H, 30);
            int footW = W - PAD * 2;
            var foot  = new Panel
            {
                Bounds    = new Rectangle(PAD, y, footW, fH),
                BackColor = C_INFO
            };
            foot.Paint += CardPaint;

            _lblFooter = MkLbl(
                "Dashboard data is updated daily.  Last updated: \u2013",
                F(8.5f), C_BLUE,
                new Rectangle(10, 0, footW - 110, fH),
                ContentAlignment.MiddleLeft);
            foot.Controls.Add(_lblFooter);

            var btn = new Button
            {
                Text      = "\u27f3  Refresh",
                Font      = F(9f),
                ForeColor = C_BLUE,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size      = new Size(90, fH),
                Location  = new Point(footW - 92, 0),
                Cursor    = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += (s, e) => LoadData();
            foot.Controls.Add(btn);
            c.Controls.Add(foot);
            y += fH + VPAD;
        }

        // =============================================================
        // CONTROL FACTORIES  (identical helpers to DashboardForm)
        // =============================================================

        private static Panel MkCard(Rectangle bounds)
        {
            var p = new Panel { Bounds = bounds, BackColor = C_CARD };
            p.Paint += CardPaint;
            return p;
        }

        private static void CardPaint(object sender, PaintEventArgs e)
        {
            var p = (Panel)sender;
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var sh = new SolidBrush(Color.FromArgb(18, 0, 0, 0)))
                g.FillRectangle(sh, new Rectangle(3, 3, p.Width - 2, p.Height - 2));
            var r = new Rectangle(0, 0, p.Width - 3, p.Height - 3);
            using (var path = RoundRect(r, 8))
            using (var br   = new SolidBrush(p.BackColor))
                g.FillPath(br, path);
            using (var path = RoundRect(r, 8))
            using (var pen  = new Pen(C_BORDER, 1f))
                g.DrawPath(pen, path);
        }

        private static void AddTitle(Panel card, string text, int cardW)
        {
            card.Controls.Add(new Label
            {
                Text      = text,
                Font      = F(9.5f, FontStyle.Bold),
                ForeColor = C_DARK,
                Location  = new Point(12, 8),
                Size      = new Size(cardW - 26, 22),
                BackColor = Color.Transparent
            });
            card.Controls.Add(new Panel
            {
                BackColor = C_BORDER,
                Location  = new Point(0, 33),
                Size      = new Size(cardW, 1)
            });
        }

        private static Label MkLbl(string text, Font font, Color fore,
                                    Rectangle bounds,
                                    ContentAlignment align = ContentAlignment.TopLeft)
        {
            return new Label
            {
                Text      = text,
                Font      = font,
                ForeColor = fore,
                Bounds    = bounds,
                TextAlign = align,
                BackColor = Color.Transparent
            };
        }

        private static Image BytesToImage(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return null;
            try { return Image.FromStream(new System.IO.MemoryStream(bytes)); }
            catch { return null; }
        }

        private static DataGridView MkGridWithImage(
            params (string hdr, string field, int minW,
                    DataGridViewContentAlignment align)[] cols)
        {
            var g = MkGrid(cols);
            var imgCol = new DataGridViewImageColumn
            {
                Name             = "col_ProductImage",
                HeaderText       = "",
                DataPropertyName = "ProductImage",
                Width            = 32,
                ImageLayout      = DataGridViewImageCellLayout.Zoom,
                DefaultCellStyle = { NullValue = null, Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            g.Columns.Insert(0, imgCol);
            g.RowTemplate.Height = 32;
            g.DataError += (s, e) => e.ThrowException = false;
            return g;
        }

        private static DataGridView MkGrid(
            params (string hdr, string field, int minW,
                    DataGridViewContentAlignment align)[] cols)
        {
            var g = new DataGridView
            {
                BackgroundColor       = C_CARD,
                BorderStyle           = BorderStyle.None,
                CellBorderStyle       = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor             = C_BORDER,
                ColumnHeadersHeight   = 28,
                RowTemplate           = { Height = 28 },
                AllowUserToAddRows    = false,
                AllowUserToDeleteRows = false,
                ReadOnly              = true,
                SelectionMode         = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect           = false,
                AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill,
                ScrollBars            = ScrollBars.Vertical,
                RowHeadersVisible     = false,
                AutoGenerateColumns   = false,
                EnableHeadersVisualStyles = false
            };
            typeof(DataGridView)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance)
                ?.SetValue(g, true, null);

            g.ColumnHeadersDefaultCellStyle.BackColor          = C_BG;
            g.ColumnHeadersDefaultCellStyle.ForeColor          = C_MID;
            g.ColumnHeadersDefaultCellStyle.Font               = F(8.5f, FontStyle.Bold);
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = C_BG;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.DefaultCellStyle.BackColor          = C_CARD;
            g.DefaultCellStyle.ForeColor          = C_DARK;
            g.DefaultCellStyle.Font               = F(8.5f);
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            g.DefaultCellStyle.SelectionForeColor = C_DARK;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            foreach (var (hdr, field, minW, align) in cols)
                g.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name             = "col_" + field,
                    HeaderText       = hdr,
                    DataPropertyName = field,
                    MinimumWidth     = minW,
                    FillWeight       = minW,
                    DefaultCellStyle = { Alignment = align }
                });
            return g;
        }

        private static GraphicsPath RoundRect(Rectangle r, int rad)
        {
            var path = new GraphicsPath();
            int d = rad * 2;
            path.AddArc(r.X,         r.Y,          d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y,          d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d,   0, 90);
            path.AddArc(r.X,         r.Bottom - d, d, d,  90, 90);
            path.CloseFigure();
            return path;
        }

        // =============================================================
        // DATA LOADING & BINDING
        // =============================================================

        public void LoadData()
        {
            if (!_layoutReady) return;
            try
            {
                _cache = _svc.LoadAll(_employeeID);
                BindAll(_cache);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dashboard failed to load:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BindAll(CashierDashboardData d)
        {
            if (d == null) return;

            // Stat cards
            _lblLowCount.Text  = d.Summary.LowStockCount.ToString();
            _lblCustCount.Text = d.Summary.TotalCustomers.ToString("N0");
            _lblMyTxCount.Text = d.Summary.MyTxCount.ToString("N0");
            _lblMyTxTotal.Text = string.Format("R{0:N2}", d.Summary.MyTxTotal);

            // My transactions grid
            _dgvMyTx.DataSource = d.MyTransactions.Select(t => new
            {
                t.InvoiceNumber,
                SaleDateStr = t.SaleDateTime.ToString("dd MMM yyyy HH:mm"),
                t.CustomerName,
                TotalAmtStr = string.Format("R{0:N2}", t.TotalAmount)
            }).ToList();

            // Bind low stock with product images
            _dgvLowStock.DataSource = d.LowStockItems.Select(s => new
            {
                ProductImage = BytesToImage(s.ProductImageBytes),
                s.ProductName,
                CurrentStock = s.CurrentStock.ToString(),
                ReorderLevel = s.ReorderLevel.ToString()
            }).ToList();

            foreach (DataGridViewRow row in _dgvLowStock.Rows)
            {
                if (row.IsNewRow) continue;
                var cell = row.Cells["col_CurrentStock"];
                if (cell.Value != null &&
                    int.TryParse(cell.Value.ToString(), out int qty))
                {
                    cell.Style.ForeColor = qty <= 3
                        ? Color.FromArgb(231, 76, 60)
                        : Color.FromArgb(230, 126, 34);
                }
            }

            // Best customer
            if (d.BestCustomer != null)
            {
                _lblBestName.Text  = d.BestCustomer.CustomerName;
                _lblBestSpent.Text = string.Format("R{0:N2}", d.BestCustomer.TotalSpent);
                _lblBestTx.Text    = d.BestCustomer.TransactionCount.ToString();
            }
            else
            {
                _lblBestName.Text  = "No data this month";
                _lblBestSpent.Text = "R0.00";
                _lblBestTx.Text    = "0";
            }

            _lblFooter.Text = string.Format(
                "Dashboard data is updated daily.  Last updated: {0:dd MMM yyyy HH:mm}",
                d.LastUpdated);
        }


    }
}
