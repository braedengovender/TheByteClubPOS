using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheByteClubPOS
{
    public partial class ManageEmployeeDetailsForm : Form
    {
        public ManageEmployeeDetailsForm()
        {
            InitializeComponent();
        }

        private void ManageEmployeeDetailsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.dsSamsLiqourShop.Employee);

        }
    }
}
