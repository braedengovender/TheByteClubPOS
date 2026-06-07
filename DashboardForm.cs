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
    /// Sam's Liquor Shop – Manager Dashboard.
    ///
    /// Layout strategy: single scrollable Panel (canvas) that fills the
    /// MDI client area. All controls use absolute Bounds + Anchor so the
    /// layout is stable whether the window is maximised, resized, or shown
    /// as a borderless MDI child (FormBorderStyle.None + Maximized).
    ///
    /// Usage from MainForm:
    ///   OpenChildForm(new DashboardForm(employeeID, employeeFullName, employeeRole));
    /// </summary>
    public partial class DashboardForm : Form
    {
        // ── Constructor params ────────────────────────────────────────
        private readonly int    _employeeID;
        private readonly string _employeeName;
        private readonly string _employeeRole;

        // ── Colour palette ────────────────────────────────────────────
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

        // ── Font helper ───────────────────────────────────────────────
        private static Font F(float sz, FontStyle s = FontStyle.Regular) =>
            new Font("Segoe UI", sz, s, GraphicsUnit.Point);

        // ── Layout constants ──────────────────────────────────────────
        private const int PAD    = 18;   // outer left/right padding
        private const int VPAD   = 14;   // outer top padding
        private const int GAP    = 10;   // gap between cards
        private const int CARD_H = 88;   // stat card height
        private const int MID_H  = 255;  // middle row height
        private const int BOT_H  = 215;  // bottom row height
        private const int FTR_H  = 36;   // footer height
        private const int HDR_H  = 82;   // header section height

        // ── Named control refs (for data binding) ─────────────────────
        private Label        _lblName;
        private Label        _lblRole;
        private Label        _lblMonthSales;
        private Label        _lblTxCount;
        private Label        _lblLowCount;
        private Label        _lblCustCount;
        private Label        _lblEmpCount;
        private Chart        _chart;
        private Panel        _pnlTop;
        private Panel        _pnlLeast;
        private DataGridView _dgvTx;
        private DataGridView _dgvStock;
        private Label        _lblBestName;
        private Label        _lblBestSpent;
        private Label        _lblBestTx;
        private Label        _lblFooter;
        private Panel        _canvas;

        // ── Data service ──────────────────────────────────────────────
        private readonly DashboardService _svc = new DashboardService();

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
            this.Text            = "Dashboard – Sam's Liquor Shop";
            this.BackColor       = C_BG;
            this.AutoScroll      = true;
            this.DoubleBuffered  = true;

            BuildCanvas();
        }

        // =============================================================
        // CANVAS CONSTRUCTION
        // =============================================================

        /// <summary>
        /// Creates the scrollable canvas and populates it.
        /// Called once on startup; the Resize handler tears down and
        /// rebuilds so proportional widths stay correct.
        /// </summary>
        private void BuildCanvas()
        {
            // Remove any previous canvas
            if (_canvas != null)
            {
                this.Controls.Remove(_canvas);
                _canvas.Dispose();
            }

            int W = Math.Max(this.ClientSize.Width, 1050);

            _canvas = new Panel
            {
                Name        = "_canvas",
                BackColor   = C_BG,
                Location    = new Point(0, 0),
                Width       = W,
                AutoSize    = false
            };

            PlaceAll(_canvas, W);

            _canvas.Height = ComputeCanvasHeight();
            this.AutoScrollMinSize = new Size(1050, _canvas.Height);
            this.Controls.Add(_canvas);
        }

        private int ComputeCanvasHeight()
        {
            return VPAD + HDR_H + GAP
                 + CARD_H + GAP
                 + MID_H  + GAP
                 + BOT_H  + GAP
                 + FTR_H  + VPAD;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Rebuild canvas when form width changes
            if (_canvas != null && this.ClientSize.Width > 0)
                BuildCanvas();
        }

        // =============================================================
        // PLACEMENT (all sections)
        // =============================================================

        private void PlaceAll(Panel c, int W)
        {
            int y = VPAD;

            PlaceHeader   (c, ref y, W);
            PlaceStatCards(c, ref y, W);
            PlaceMiddleRow(c, ref y, W);
            PlaceBottomRow(c, ref y, W);
            PlaceFooter   (c, ref y, W);
        }

        // ── HEADER ───────────────────────────────────────────────────

        private void PlaceHeader(Panel c, ref int y, int W)
        {
            // "Welcome back,"
            c.Controls.Add(MkLbl("Welcome back,", F(10f), C_MID,
                new Rectangle(PAD, y, 300, 20)));
            y += 22;

            // Name
            _lblName = MkLbl(_employeeName, F(18, FontStyle.Bold), C_DARK,
                new Rectangle(PAD, y, W - PAD * 2, 34));
            c.Controls.Add(_lblName);
            y += 36;

            // Role
            _lblRole = MkLbl(_employeeRole, F(9.5f), C_LINK,
                new Rectangle(PAD, y, 200, 20));
            c.Controls.Add(_lblRole);

            y += 28; // total header ≈ HDR_H
        }

        // ── STAT CARDS ────────────────────────────────────────────────

        private void PlaceStatCards(Panel c, ref int y, int W)
        {
            int usable = W - PAD * 2;
            int cardW  = (usable - GAP * 4) / 5;

            // title | default value | accent colour | link text
            var defs = new (string title, string def, Color accent, string link)[]
            {
                ("This Month Sales",    "R–", C_GREEN,  "View sales"),
                ("No. of Transactions", "–",  C_ORANGE, "View all"),
                ("Low Stock Items",     "–",  C_PURPLE, "View items"),
                ("Total Customers",     "–",  C_TEAL,   "View customers"),
                ("Total Employees",     "–",  C_TEAL,   "View employees"),
            };

            var valLabels = new Label[5];

            for (int i = 0; i < defs.Length; i++)
            {
                int x    = PAD + i * (cardW + GAP);
                var card = MkCard(new Rectangle(x, y, cardW, CARD_H));

                var lblTitle = MkLbl(defs[i].title, F(8.5f), C_MID,
                    new Rectangle(12, 10, cardW - 24, 18));

                var lblVal = MkLbl(defs[i].def, F(17, FontStyle.Bold), defs[i].accent,
                    new Rectangle(12, 28, cardW - 24, 34));

                var lblLink = MkLbl(defs[i].link, F(8.5f), C_LINK,
                    new Rectangle(12, 64, cardW - 24, 18));
                lblLink.Cursor = Cursors.Hand;

                card.Controls.AddRange(new Control[] { lblTitle, lblVal, lblLink });
                c.Controls.Add(card);
                valLabels[i] = lblVal;
            }

            _lblMonthSales = valLabels[0];
            _lblTxCount    = valLabels[1];
            _lblLowCount   = valLabels[2];
            _lblCustCount  = valLabels[3];
            _lblEmpCount   = valLabels[4];

            y += CARD_H + GAP;
        }

        // ── MIDDLE ROW ────────────────────────────────────────────────

        private void PlaceMiddleRow(Panel c, ref int y, int W)
        {
            int usable = W - PAD * 2;
            // Pie ≈ 37 %, Top ≈ 31.5 %, Least ≈ 31.5 %
            int pieW  = (int)(usable * 0.37) - GAP / 2;
            int rankW = (usable - pieW - GAP * 2) / 2;

            int xPie   = PAD;
            int xTop   = xPie + pieW + GAP;
            int xLeast = xTop + rankW + GAP;

            // ── Pie card ─────────────────────────────────────────────
            var pieCard = MkCard(new Rectangle(xPie, y, pieW, MID_H));
            AddTitle(pieCard, "Sales by Category (This Month)", pieW);
            _chart = MkPieChart(pieCard, pieW, MID_H);
            c.Controls.Add(pieCard);

            // ── Top Selling card ──────────────────────────────────────
            var topCard = MkCard(new Rectangle(xTop, y, rankW, MID_H));
            AddTitle(topCard, "Top Selling Products (This Month)", rankW, viewAll: true);
            _pnlTop = new Panel
            {
                Location  = new Point(1, 35),
                Size      = new Size(rankW - 2, MID_H - 36),
                BackColor = C_CARD
            };
            topCard.Controls.Add(_pnlTop);
            c.Controls.Add(topCard);

            // ── Least Selling card ────────────────────────────────────
            var leastCard = MkCard(new Rectangle(xLeast, y, rankW, MID_H));
            AddTitle(leastCard, "Least Selling Products (This Month)", rankW, viewAll: true);
            _pnlLeast = new Panel
            {
                Location  = new Point(1, 35),
                Size      = new Size(rankW - 2, MID_H - 36),
                BackColor = C_CARD
            };
            leastCard.Controls.Add(_pnlLeast);
            c.Controls.Add(leastCard);

            y += MID_H + GAP;
        }

        // ── BOTTOM ROW ────────────────────────────────────────────────

        private void PlaceBottomRow(Panel c, ref int y, int W)
        {
            int usable = W - PAD * 2;
            int txW    = (int)(usable * 0.38) - GAP / 2;
            int stW    = (int)(usable * 0.38) - GAP / 2;
            int bestW  = usable - txW - stW - GAP * 2;

            int xTx   = PAD;
            int xSt   = xTx   + txW  + GAP;
            int xBest = xSt   + stW  + GAP;

            int gridH = BOT_H - 56;   // card height minus title bar and footer note

            // ── Recent Transactions ───────────────────────────────────
            var txCard = MkCard(new Rectangle(xTx, y, txW, BOT_H));
            AddTitle(txCard, "Recent Transactions", txW, viewAll: true);

            _dgvTx = MkGrid(
                ("Invoice",      "InvoiceNumber",  88, DataGridViewContentAlignment.MiddleLeft),
                ("Date",         "SaleDateStr",   130, DataGridViewContentAlignment.MiddleLeft),
                ("Customer",     "CustomerName",  110, DataGridViewContentAlignment.MiddleLeft),
                ("Total Amount", "TotalAmtStr",    82, DataGridViewContentAlignment.MiddleRight)
            );
            _dgvTx.Location = new Point(1, 35);
            _dgvTx.Size     = new Size(txW - 2, gridH);
            txCard.Controls.Add(_dgvTx);
            txCard.Controls.Add(MkLbl("Showing latest 5 transactions", F(8f), C_MID,
                new Rectangle(10, BOT_H - 19, txW - 20, 16)));
            c.Controls.Add(txCard);

            // ── Low Stock Items ───────────────────────────────────────
            var stCard = MkCard(new Rectangle(xSt, y, stW, BOT_H));
            AddTitle(stCard, "Low Stock Items", stW, viewAll: true);

            _dgvStock = MkGrid(
                ("Product",       "ProductName",  150, DataGridViewContentAlignment.MiddleLeft),
                ("Current Stock", "CurrentStock",  90, DataGridViewContentAlignment.MiddleCenter),
                ("Reorder Level", "ReorderLevel",  90, DataGridViewContentAlignment.MiddleCenter)
            );
            _dgvStock.Location          = new Point(1, 35);
            _dgvStock.Size              = new Size(stW - 2, gridH);
            _dgvStock.CellFormatting   += StockGrid_CellFormatting;
            stCard.Controls.Add(_dgvStock);
            stCard.Controls.Add(MkLbl("Showing latest 5 low stock items", F(8f), C_MID,
                new Rectangle(10, BOT_H - 19, stW - 20, 16)));
            c.Controls.Add(stCard);

            // ── Best Customer ─────────────────────────────────────────
            var bestCard = MkCard(new Rectangle(xBest, y, bestW, BOT_H));
            BuildBestCustomerCard(bestCard, bestW, BOT_H);
            c.Controls.Add(bestCard);

            y += BOT_H + GAP;
        }

        private void BuildBestCustomerCard(Panel card, int W, int H)
        {
            AddTitle(card, "Best Customer (This Month)", W);

            // Avatar
            var av = new Panel
            {
                Size      = new Size(56, 56),
                Location  = new Point((W - 56) / 2, 44),
                BackColor = Color.Transparent
            };
            av.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (var br = new SolidBrush(Color.FromArgb(189, 195, 199)))
                    g.FillEllipse(br, 0, 0, 55, 55);
                g.FillEllipse(Brushes.White, 16, 6, 22, 22);   // head
                g.FillEllipse(Brushes.White, 7, 30, 42, 28);   // body
            };
            card.Controls.Add(av);

            _lblBestName = MkLbl("No data", F(11, FontStyle.Bold), C_DARK,
                new Rectangle(6, 108, W - 12, 22), ContentAlignment.MiddleCenter);
            card.Controls.Add(_lblBestName);

            card.Controls.Add(MkLbl("Total Spent", F(8.5f), C_MID,
                new Rectangle(6, 134, W - 12, 16), ContentAlignment.MiddleCenter));

            _lblBestSpent = MkLbl("R0.00", F(14, FontStyle.Bold), C_BLUE,
                new Rectangle(6, 150, W - 12, 28), ContentAlignment.MiddleCenter);
            card.Controls.Add(_lblBestSpent);

            card.Controls.Add(MkLbl("No. of Transactions", F(8.5f), C_MID,
                new Rectangle(6, 182, W - 12, 16), ContentAlignment.MiddleCenter));

            _lblBestTx = MkLbl("0", F(12, FontStyle.Bold), C_DARK,
                new Rectangle(6, 198, W - 12, 20), ContentAlignment.MiddleCenter);
            card.Controls.Add(_lblBestTx);
        }

        // ── FOOTER ───────────────────────────────────────────────────

        private void PlaceFooter(Panel c, ref int y, int W)
        {
            int footW = W - PAD * 2;
            var foot  = new Panel
            {
                Bounds    = new Rectangle(PAD, y, footW, FTR_H),
                BackColor = C_INFO
            };
            foot.Paint += CardPaint;

            _lblFooter = MkLbl(
                "Dashboard data is updated daily.  Last updated: –",
                F(8.5f), C_BLUE,
                new Rectangle(10, 0, footW - 110, FTR_H),
                ContentAlignment.MiddleLeft);
            foot.Controls.Add(_lblFooter);

            var btn = new Button
            {
                Text      = "⟳  Refresh",
                Font      = F(9f),
                ForeColor = C_BLUE,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size      = new Size(90, FTR_H),
                Location  = new Point(footW - 92, 0),
                Cursor    = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += (s, e) => LoadData();
            foot.Controls.Add(btn);

            c.Controls.Add(foot);
            y += FTR_H + VPAD;
        }

        // =============================================================
        // CONTROL FACTORY HELPERS
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

            // Soft shadow
            using (var sh = new SolidBrush(Color.FromArgb(18, 0, 0, 0)))
                g.FillRectangle(sh, new Rectangle(3, 3, p.Width - 2, p.Height - 2));

            // White fill
            var r = new Rectangle(0, 0, p.Width - 3, p.Height - 3);
            using (var path = RoundRect(r, 8))
            using (var br   = new SolidBrush(p.BackColor))
                g.FillPath(br, path);

            // Border
            using (var path = RoundRect(r, 8))
            using (var pen  = new Pen(C_BORDER, 1f))
                g.DrawPath(pen, path);
        }

        private static void AddTitle(Panel card, string text, int cardW,
                                      bool viewAll = false)
        {
            var title = new Label
            {
                Text      = text,
                Font      = F(9.5f, FontStyle.Bold),
                ForeColor = C_DARK,
                Location  = new Point(12, 8),
                Size      = new Size(cardW - (viewAll ? 72 : 26), 22),
                BackColor = Color.Transparent
            };
            card.Controls.Add(title);

            // Divider
            card.Controls.Add(new Panel
            {
                BackColor = C_BORDER,
                Location  = new Point(0, 33),
                Size      = new Size(cardW, 1)
            });

            if (viewAll)
            {
                var lnk = new Label
                {
                    Text      = "View all",
                    Font      = F(8.5f),
                    ForeColor = C_LINK,
                    Location  = new Point(cardW - 62, 10),
                    Size      = new Size(55, 16),
                    Cursor    = Cursors.Hand,
                    TextAlign = ContentAlignment.MiddleRight,
                    BackColor = Color.Transparent
                };
                card.Controls.Add(lnk);
            }
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

        // ── Pie chart ─────────────────────────────────────────────────

        private Chart MkPieChart(Panel card, int cardW, int cardH)
        {
            var ch = new Chart
            {
                Location  = new Point(1, 35),
                Size      = new Size(cardW - 2, cardH - 36),
                BackColor = C_CARD
            };

            var area = new ChartArea("main") { BackColor = C_CARD };
            area.Position.Auto = true;
            ch.ChartAreas.Add(area);

            var ser = new Series("cat")
            {
                ChartType           = SeriesChartType.Pie,
                IsValueShownAsLabel = false
            };
            ch.Series.Add(ser);

            ch.Legends.Add(new Legend("main")
            {
                Docking    = Docking.Right,
                BackColor  = C_CARD,
                Font       = F(8f),
                IsTextAutoFit = false,
                Alignment  = StringAlignment.Center
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

        // ── DataGridView ──────────────────────────────────────────────

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

            // Enable double-buffering via reflection (protected property, must use reflection
            // when setting it on a DataGridView instance from outside the class hierarchy).
            typeof(DataGridView)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance)
                ?.SetValue(g, true, null);

            g.ColumnHeadersDefaultCellStyle.BackColor          = C_BG;
            g.ColumnHeadersDefaultCellStyle.ForeColor          = C_MID;
            g.ColumnHeadersDefaultCellStyle.Font               = F(8.5f, FontStyle.Bold);
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = C_BG;
            g.ColumnHeadersBorderStyle                         = DataGridViewHeaderBorderStyle.None;

            g.DefaultCellStyle.BackColor          = C_CARD;
            g.DefaultCellStyle.ForeColor          = C_DARK;
            g.DefaultCellStyle.Font               = F(8.5f);
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            g.DefaultCellStyle.SelectionForeColor = C_DARK;

            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            foreach (var (hdr, field, minW, align) in cols)
            {
                g.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name             = "col_" + field,
                    HeaderText       = hdr,
                    DataPropertyName = field,
                    MinimumWidth     = minW,
                    FillWeight       = minW,
                    DefaultCellStyle = { Alignment = align }
                });
            }

            return g;
        }

        // ── Round rect helper ─────────────────────────────────────────

        private static GraphicsPath RoundRect(Rectangle r, int rad)
        {
            var path = new GraphicsPath();
            int d = rad * 2;
            path.AddArc(r.X,           r.Y,            d, d, 180, 90);
            path.AddArc(r.Right - d,   r.Y,            d, d, 270, 90);
            path.AddArc(r.Right - d,   r.Bottom - d,   d, d,   0, 90);
            path.AddArc(r.X,           r.Bottom - d,   d, d,  90, 90);
            path.CloseFigure();
            return path;
        }

        // =============================================================
        // RANK PANEL (Top / Least Selling)
        // =============================================================

        private void PopulateRankPanel(Panel pnl, List<ProductSalesRankDto> items)
        {
            pnl.Controls.Clear();
            if (items == null || items.Count == 0) return;

            int rows  = items.Count;
            int rowH  = Math.Max((pnl.Height - 4) / rows, 36);
            int y     = 2;

            Color[] badges =
            {
                C_BLUE,
                C_GREEN,
                C_ORANGE,
                Color.FromArgb(127, 140, 141),
                Color.FromArgb(127, 140, 141)
            };

            foreach (var item in items)
            {
                Color bc = (item.Rank - 1 < badges.Length)
                           ? badges[item.Rank - 1]
                           : badges[badges.Length - 1];

                // Rank badge (drawn entirely in Paint — text painted manually)
                int badgeY = y + (rowH - 22) / 2;
                var badge  = new Panel
                {
                    Size      = new Size(22, 22),
                    Location  = new Point(8, badgeY),
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
                        pe.Graphics.DrawString(num, F(8, FontStyle.Bold),
                            Brushes.White, new RectangleF(0, 0, 22, 22), sf);
                };

                // Bottle icon
                var icon = MkLbl("🍾", F(12f), C_DARK,
                    new Rectangle(36, y + (rowH - 22) / 2, 26, 22));

                // Product name
                var name = MkLbl(item.ProductName, F(9f), C_DARK,
                    new Rectangle(66, y, pnl.Width - 110, rowH),
                    ContentAlignment.MiddleLeft);

                // Units sold (right-aligned)
                var units = MkLbl(item.UnitsSold.ToString(),
                    F(9f, FontStyle.Bold), C_DARK,
                    new Rectangle(pnl.Width - 40, y, 36, rowH),
                    ContentAlignment.MiddleRight);

                // Separator
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                var d = _svc.LoadAll();

                // ── Stat cards ─────────────────────────────────────────
                _lblMonthSales.Text = string.Format("R{0:N2}", d.Summary.MonthSalesTotal);
                _lblTxCount.Text    = d.Summary.MonthTransactionCount.ToString("N0");
                _lblLowCount.Text   = d.Summary.LowStockCount.ToString();
                _lblCustCount.Text  = d.Summary.TotalCustomers.ToString("N0");
                _lblEmpCount.Text   = d.Summary.TotalEmployees.ToString();

                // ── Pie chart ──────────────────────────────────────────
                BindPie(d.CategorySales);

                // ── Rank panels ────────────────────────────────────────
                PopulateRankPanel(_pnlTop,   d.TopSelling);
                PopulateRankPanel(_pnlLeast, d.LeastSelling);

                // ── Recent transactions ────────────────────────────────
                _dgvTx.DataSource = d.RecentTransactions.Select(t => new
                {
                    t.InvoiceNumber,
                    SaleDateStr  = t.SaleDateTime.ToString("dd MMM yyyy HH:mm"),
                    t.CustomerName,
                    TotalAmtStr  = string.Format("R{0:N2}", t.TotalAmount)
                }).ToList();

                // ── Low stock ──────────────────────────────────────────
                _dgvStock.DataSource = d.LowStockItems;

                // ── Best customer ──────────────────────────────────────
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

                // ── Footer ─────────────────────────────────────────────
                _lblFooter.Text = string.Format(
                    "Dashboard data is updated daily.  Last updated: {0:dd MMM yyyy}",
                    d.LastUpdated);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Dashboard failed to load:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void StockGrid_CellFormatting(object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            var grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex].Name == "col_CurrentStock" &&
                e.Value is int qty)
            {
                e.CellStyle.ForeColor = qty <= 3 ? C_RED : C_ORANGE;
                e.FormattingApplied   = true;
            }
        }
    }
}
