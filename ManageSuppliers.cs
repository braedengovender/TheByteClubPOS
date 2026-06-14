using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace TheByteClubPOS
{
    public partial class ManageSuppliers : Form
    {
        public ManageSuppliers()
        {
            InitializeComponent();
        }

        private void webBrowserMap_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void supplierBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.supplierBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsSamsLiqourShop);

        }

        private async void ManageSuppliers_Load(object sender, EventArgs e)
        {
            this.supplierTableAdapter.Fill(this.dsSamsLiqourShop.Supplier);

            await webViewMap.EnsureCoreWebView2Async();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSupplier.SelectedValue == null)
                    return;

                string address = cmbSupplier.SelectedValue.ToString();

                if (string.IsNullOrWhiteSpace(address))
                    return;

                string url =
                    "https://www.google.com/maps/search/?api=1&query="
                    + Uri.EscapeDataString(address);

                webViewMap.Source = new Uri(url);
            }
            catch (Exception ex)
            {
                // Ignore binding startup errors
                MessageBox.Show("Error loading map: " + ex.Message);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
