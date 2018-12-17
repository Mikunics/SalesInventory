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
    public partial class EndTransactionPage : Form
    {

        float Total = 0, Paid = 0, Change = 0;

        public EndTransactionPage()
        {
            InitializeComponent();
        }

        public EndTransactionPage(float due) : this()
        {
            InitializeComponent();
            Total = due;
        }

        private void EndTransactionPage_Load(object sender, EventArgs e)
        {
            labelDue.Text = Total.ToString("0.00");
            labelDue.Visible = true;
        }

        private void textBoxPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Paid = Single.Parse(textBoxPaid.Text);
                Change = Paid - Total;
                labelChange.Text = Change.ToString("0.00");
                labelChange.Visible = true;
            }

            catch
            {

            }
        }

        private void textBoxPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
