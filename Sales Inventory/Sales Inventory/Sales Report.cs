using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sales_Inventory
{
    public partial class SalesReport : Form
    {
        public SalesReport()
        {
            InitializeComponent();
        }

        private bool GenerateReport(DateTime To, DateTime From)
        {
            
            return false;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (radioButtonDaily.Checked)
            {
                DateTime To = DateTime.Today;
                DateTime From = DateTime.Today;
                GenerateReport(To, From);
            }else if (radioButtonCustom.Checked)
            {
                DateTime To = dateTimePickerTo.Value;
                DateTime From = dateTimePickerFrom.Value;
                GenerateReport(To, From);
            }
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }
    }
}
