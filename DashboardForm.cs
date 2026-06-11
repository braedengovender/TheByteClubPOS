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
        // ── Constructor params ────────────────────────────────────────
        private readonly int    _employeeID;
        private readonly string _employeeName;
        private readonly string _employeeRole;

        // ── Colours ───────────────────────────────────────────────────
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
        // The canvas is ALWAYS drawn at these fixed pixel dimensions.
        // The scroll wrapper shows whatever the MDI window can fit and
        // provides scrollbars for the rest.
        private const int RENDER_W = 1134;
        private const int RENDER_H = 720;
        private const int PAD      = 14;
        private const int VPAD     = 10;
        private const int GAP      =  8;

        // ── Named control refs ────────────────────────────────────────
        private Label        _lblName, _lblRole;
        private Label        _lblMonthSales, _lblTxCount, _lblLowCount;
        private Label        _lblCustCount,  _lblEmpCount;
        private Chart        _chart;
        private Panel        _pnlTop, _pnlLeast;
        private DataGridView _dgvTx,  _dgvStock;
        private Label        _lblBestName, _lblBestSpent, _lblBestTx;
        private Label        _lblFooter;

        // ── Data ──────────────────────────────────────────────────────
        private readonly DashboardService _svc   = new DashboardService();
        private readonly Timer            _timer = new Timer();
        private DashboardData             _cache;
        private bool                      _layoutReady;

        // =============================================================
        // CONSTRUCTORS
        // =============================================================

        public DashboardForm()
        {
            _employeeName = "Manager";
            _employeeRole = "Manager";
            InitializeComponent();
            SetupForm();
        }

        public DashboardForm(int id, string name, string role)
        {
            _employeeID   = id;
            _employeeName = name;
            _employeeRole = role;
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

            // ── Fixed-size canvas that always renders at RENDER_W x RENDER_H ──
            var canvas = new Panel
            {
                Location  = new Point(0, 0),
                Size      = new Size(RENDER_W, RENDER_H),
                BackColor = C_BG
            };
            PlaceAll(canvas, RENDER_W, RENDER_H);

            // ── Scroll wrapper ────────────────────────────────────────
            // We do NOT use Dock=Fill here. Instead we size it explicitly
            // in Shown/Resize so it always matches the MDI client area.
            // AutoScroll=true on a Panel works correctly inside MDI children
            // (unlike the Form's own scrollbars which the MDI suppresses).
            var scroll = new Panel
            {
                Location   = new Point(0, 0),
                BackColor  = C_BG,
                AutoScroll = true
            };
            scroll.Controls.Add(canvas);
            this.Controls.Add(scroll);

            // Resize the scroll wrapper whenever the form size changes
            Action sizeScroll = () =>
            {
                scroll.Size = new Size(
                    Math.Max(this.ClientSize.Width,  1),
                    Math.Max(this.ClientSize.Height, 1));
            };

            this.Resize += (s, e) => sizeScroll();

            this.Shown += (s, e) =>
            {
                sizeScroll();        // set correct size after MDI layout
                _layoutReady = true;
                LoadData();
            };

            // Auto-refresh every 60 s
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
        // LAYOUT  (called once at setup — static, no resize needed)
        // =============================================================

        private void PlaceAll(Panel c, int W, int H)
        {
            int totalGaps = VPAD * 2 + GAP * 4;
            int available = H - totalGaps;

            int hHdr   = (int)(available * 0.10);
            int hCards = (int)(available * 0.13);
            int hMid   = (int)(available * 0.34);
            int hBot   = (int)(available * 0.34);
            int hFtr   = available - hHdr - hCards - hMid - hBot;

            int y = VPAD;
            PlaceHeader   (c, ref y, W, hHdr);
            PlaceStatCards(c, ref y, W, hCards);
            PlaceMiddleRow(c, ref y, W, hMid);
            PlaceBottomRow(c, ref y, W, hBot);
            PlaceFooter   (c, ref y, W, hFtr);
        }

        // ── HEADER ────────────────────────────────────────────────────

        private void PlaceHeader(Panel c, ref int y, int W, int H)
        {
            c.Controls.Add(MkLbl("Welcome back,", F(9.5f), C_MID,
                new Rectangle(PAD, y, 300, 20)));

            _lblName = MkLbl(_employeeName, F(17, FontStyle.Bold), C_DARK,
                new Rectangle(PAD, y + 20, W - PAD * 2, 34));
            c.Controls.Add(_lblName);

            _lblRole = MkLbl(_employeeRole, F(9.5f), C_LINK,
                new Rectangle(PAD, y + 56, 200, 20));
            c.Controls.Add(_lblRole);

            y += H + GAP;
        }

        // ── STAT CARDS ────────────────────────────────────────────────

        private void PlaceStatCards(Panel c, ref int y, int W, int H)
        {
            int usable = W - PAD * 2;
            int cardW  = (usable - GAP * 4) / 5;

            var defs = new (string title, string def, Color accent)[]
            {
                ("This Month Sales",    "R\u2013", C_GREEN),
                ("No. of Transactions", "\u2013",  C_ORANGE),
                ("Low Stock Items",     "\u2013",  C_PURPLE),
                ("Total Customers",     "\u2013",  C_TEAL),
                ("Total Employees",     "\u2013",  C_TEAL),
            };

            var refs = new Label[5];

            for (int i = 0; i < defs.Length; i++)
            {
                int x    = PAD + i * (cardW + GAP);
                var card = MkCard(new Rectangle(x, y, cardW, H));

                // Fixed pixel positions — title at top, value fills remaining
                card.Controls.Add(MkLbl(defs[i].title, F(8.5f), C_MID,
                    new Rectangle(12, 10, cardW - 24, 20)));

                var val = MkLbl(defs[i].def, F(20, FontStyle.Bold), defs[i].accent,
                    new Rectangle(12, 32, cardW - 24, H - 40));
                card.Controls.Add(val);
                refs[i] = val;

                c.Controls.Add(card);
            }

            _lblMonthSales = refs[0];
            _lblTxCount    = refs[1];
            _lblLowCount   = refs[2];
            _lblCustCount  = refs[3];
            _lblEmpCount   = refs[4];

            y += H + GAP;
        }

        // ── MIDDLE ROW ────────────────────────────────────────────────

        private void PlaceMiddleRow(Panel c, ref int y, int W, int H)
        {
            int usable = W - PAD * 2;
            int pieW   = (int)(usable * 0.37) - GAP / 2;
            int rankW  = (usable - pieW - GAP * 2) / 2;

            int xPie   = PAD;
            int xTop   = xPie + pieW + GAP;
            int xLeast = xTop + rankW + GAP;

            var pieCard = MkCard(new Rectangle(xPie, y, pieW, H));
            AddTitle(pieCard, "Sales by Category (This Month)", pieW);
            _chart = MkPieChart(pieCard, pieW, H);
            c.Controls.Add(pieCard);

            var topCard = MkCard(new Rectangle(xTop, y, rankW, H));
            AddTitle(topCard, "Top Selling Products (This Month)", rankW);
            _pnlTop = new Panel
            {
                Location  = new Point(1, 35),
                Size      = new Size(rankW - 2, H - 36),
                BackColor = C_CARD
            };
            topCard.Controls.Add(_pnlTop);
            c.Controls.Add(topCard);

            var leastCard = MkCard(new Rectangle(xLeast, y, rankW, H));
            AddTitle(leastCard, "Least Selling Products (This Month)", rankW);
            _pnlLeast = new Panel
            {
                Location  = new Point(1, 35),
                Size      = new Size(rankW - 2, H - 36),
                BackColor = C_CARD
            };
            leastCard.Controls.Add(_pnlLeast);
            c.Controls.Add(leastCard);

            y += H + GAP;
        }

        // ── BOTTOM ROW ────────────────────────────────────────────────

        private void PlaceBottomRow(Panel c, ref int y, int W, int H)
        {
            int usable = W - PAD * 2;
            int txW    = (int)(usable * 0.48) - GAP / 2;
            int stW    = (int)(usable * 0.30) - GAP / 2;
            int bestW  = usable - txW - stW - GAP * 2;

            int xTx   = PAD;
            int xSt   = xTx + txW  + GAP;
            int xBest = xSt + stW  + GAP;
            int gridH = H - 52;

            // Recent Transactions
            var txCard = MkCard(new Rectangle(xTx, y, txW, H));
            AddTitle(txCard, "Recent Transactions", txW);
            _dgvTx = MkGrid(
                ("Invoice",      "InvoiceNumber",  90, DataGridViewContentAlignment.MiddleLeft),
                ("Date",         "SaleDateStr",   140, DataGridViewContentAlignment.MiddleLeft),
                ("Customer",     "CustomerName",  120, DataGridViewContentAlignment.MiddleLeft),
                ("Total Amount", "TotalAmtStr",    90, DataGridViewContentAlignment.MiddleRight));
            _dgvTx.Location = new Point(1, 35);
            _dgvTx.Size     = new Size(txW - 2, gridH);
            txCard.Controls.Add(_dgvTx);
            txCard.Controls.Add(MkLbl("Showing latest 5 transactions", F(7.5f), C_MID,
                new Rectangle(10, H - 18, txW - 20, 15)));
            c.Controls.Add(txCard);

            // Low Stock
            var stCard = MkCard(new Rectangle(xSt, y, stW, H));
            AddTitle(stCard, "Low Stock Items", stW);
            _dgvStock = MkGrid(
                ("Product",    "ProductName",  110, DataGridViewContentAlignment.MiddleLeft),
                ("Cur. Stock", "CurrentStock",  70, DataGridViewContentAlignment.MiddleCenter),
                ("Reorder",    "ReorderLevel",  70, DataGridViewContentAlignment.MiddleCenter));
            _dgvStock.Location        = new Point(1, 35);
            _dgvStock.Size            = new Size(stW - 2, gridH);
            stCard.Controls.Add(_dgvStock);
            stCard.Controls.Add(MkLbl("Showing latest 5 low stock items", F(7.5f), C_MID,
                new Rectangle(10, H - 18, stW - 20, 15)));
            c.Controls.Add(stCard);

            // Best Customer
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

            // Distribute remaining card height into 5 equal slots
            int contentTop = 44 + avSize + 4;   // 104
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
        // CONTROL FACTORIES
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

        private Chart MkPieChart(Panel card, int cardW, int cardH)
        {
            var ch = new Chart
            {
                Location  = new Point(1, 35),
                Size      = new Size(cardW - 2, cardH - 36),
                BackColor = C_CARD
            };
            var area = new ChartArea("main") { BackColor = C_CARD };
            area.Position          = new ElementPosition(2, 2, 56, 96);
            area.InnerPlotPosition = new ElementPosition(5, 5, 90, 90);
            ch.ChartAreas.Add(area);
            var ser = new Series("cat")
            {
                ChartType           = SeriesChartType.Pie,
                IsValueShownAsLabel = false,
                Label               = ""
            };
            ser["PieLabelStyle"] = "Disabled";
            ch.Series.Add(ser);
            ch.Legends.Add(new Legend("main")
            {
                DockedToChartArea       = "main",
                IsDockedInsideChartArea = false,
                Docking                 = Docking.Right,
                Alignment               = StringAlignment.Center,
                BackColor               = C_CARD,
                Font                    = F(7.5f),
                IsTextAutoFit           = false,
                LegendStyle             = LegendStyle.Column
            });
            ch.PaletteCustomColors = new[]
            {
                Color.FromArgb(52,  152, 219),
                Color.FromArgb(46,  204, 113),
                Color.FromArgb(155,  89, 182),
                Color.FromArgb(230, 126,  34),
                Color.FromArgb(26,  188, 156)
            };
            ch.Palette = ChartColorPalette.None;
            card.Controls.Add(ch);
            return ch;
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
        // RANK PANEL
        // =============================================================

        private void PopulateRankPanel(Panel pnl, List<ProductSalesRankDto> items)
        {
            pnl.Controls.Clear();
            if (items == null || items.Count == 0) return;

            int rowH = Math.Max((pnl.Height - 4) / Math.Max(items.Count, 1), 34);
            int y    = 2;

            Color[] badges =
            {
                C_BLUE, C_GREEN, C_ORANGE,
                Color.FromArgb(127,140,141),
                Color.FromArgb(127,140,141)
            };

            foreach (var item in items)
            {
                Color bc = (item.Rank - 1 < badges.Length)
                           ? badges[item.Rank - 1] : badges[badges.Length - 1];

                var badge = new Panel
                {
                    Size      = new Size(22, 22),
                    Location  = new Point(8, y + (rowH - 22) / 2),
                    BackColor = Color.Transparent,
                    Tag       = new object[] { bc, item.Rank.ToString() }
                };
                badge.Paint += (s, pe) =>
                {
                    var obj = (object[])((Panel)s).Tag;
                    var col = (Color)obj[0];
                    var num = (string)obj[1];
                    pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (var br = new SolidBrush(col))
                        pe.Graphics.FillEllipse(br, 0, 0, 21, 21);
                    using (var sf = new StringFormat
                    {
                        Alignment     = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    })
                        pe.Graphics.DrawString(num, F(8, FontStyle.Bold), Brushes.White,
                            new RectangleF(0, 0, 22, 22), sf);
                };

                var icon  = MkLbl("🍾", F(12f), C_DARK,
                    new Rectangle(36, y + (rowH - 22) / 2, 26, 22));
                var name  = MkLbl(item.ProductName, F(9f), C_DARK,
                    new Rectangle(66, y, pnl.Width - 110, rowH),
                    ContentAlignment.MiddleLeft);
                var units = MkLbl(item.UnitsSold.ToString(), F(9f, FontStyle.Bold), C_DARK,
                    new Rectangle(pnl.Width - 40, y, 36, rowH),
                    ContentAlignment.MiddleRight);
                var sep = new Panel
                {
                    BackColor = C_BORDER,
                    Location  = new Point(6, y + rowH - 1),
                    Size      = new Size(pnl.Width - 12, 1)
                };

                pnl.Controls.AddRange(new Control[] { badge, icon, name, units, sep });
                y += rowH;
            }
        }

        // =============================================================
        // DATA LOADING & BINDING
        // =============================================================

        public void LoadData()
        {
            if (!_layoutReady) return;
            try
            {
                _cache = _svc.LoadAll();
                BindAll(_cache);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dashboard failed to load:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BindAll(DashboardData d)
        {
            if (d == null) return;

            _lblMonthSales.Text = string.Format("R{0:N2}", d.Summary.MonthSalesTotal);
            _lblTxCount.Text    = d.Summary.MonthTransactionCount.ToString("N0");
            _lblLowCount.Text   = d.Summary.LowStockCount.ToString();
            _lblCustCount.Text  = d.Summary.TotalCustomers.ToString("N0");
            _lblEmpCount.Text   = d.Summary.TotalEmployees.ToString();

            BindPie(d.CategorySales);
            PopulateRankPanel(_pnlTop,   d.TopSelling);
            PopulateRankPanel(_pnlLeast, d.LeastSelling);

            _dgvTx.DataSource = d.RecentTransactions.Select(t => new
            {
                t.InvoiceNumber,
                SaleDateStr = t.SaleDateTime.ToString("dd MMM yyyy HH:mm"),
                t.CustomerName,
                TotalAmtStr = string.Format("R{0:N2}", t.TotalAmount)
            }).ToList();

            // Pre-convert stock integers to strings to avoid DataGridView
            // FormatException when CellFormatting fires on raw int values.
            _dgvStock.DataSource = d.LowStockItems.Select(s => new
            {
                s.ProductName,
                CurrentStock = s.CurrentStock.ToString(),
                ReorderLevel = s.ReorderLevel.ToString()
            }).ToList();

            // Colour low-stock numbers after binding
            foreach (DataGridViewRow row in _dgvStock.Rows)
            {
                if (row.IsNewRow) continue;
                var cell = row.Cells["col_CurrentStock"];
                if (cell.Value != null &&
                    int.TryParse(cell.Value.ToString(), out int qty))
                {
                    cell.Style.ForeColor = qty <= 3 ? C_RED : C_ORANGE;
                }
            }

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

        private void BindPie(List<CategorySalesDto> items)
        {
            var ser = _chart.Series["cat"];
            ser.Points.Clear();
            if (items == null || items.Count == 0) return;
            decimal total = items.Sum(x => x.TotalSales);
            foreach (var item in items)
            {
                double pct = total > 0
                    ? (double)(item.TotalSales / total * 100m) : 0;
                int idx = ser.Points.AddXY(item.CategoryName, pct);
                ser.Points[idx].LegendText =
                    string.Format("{0}   {1:F0}%", item.CategoryName, pct);
            }
        }


    }
}
