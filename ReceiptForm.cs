using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheByteClubPOS
{
    public partial class ReceiptForm : Form
    {
        // Custom constructor that accepts a compiled PrintDocument object pipeline stream
        public ReceiptForm(PrintDocument doc)
        {
            InitializeComponent();

            // Link the document layout engine to the embedded UI control
            printPreviewControl1.Document = doc;

            // Set default display magnification (1.20 = 120% scale view layout)
            printPreviewControl1.Zoom = 1.2;
        }

        private void ReceiptForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
