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
        public class transaction
        {
            private string _ItemName;
            private int _quantity;
            private float _pricePerUnit;
            private float _totalPrice;

            [DisplayName("Item Name")]
            public string ItemName
            {
                get { return _ItemName; }
                set { _ItemName = value; }
            }
            public int Quantity
            {
                get { return _quantity; }
                set { _quantity = value; }
            }
            [DisplayName("Price Per Unit")]
            public float PricePerUnit
            {
                get { return _pricePerUnit; }
                set { _pricePerUnit = value; }
            }
            [DisplayName("Total Price")]
            public float TotalPrice
            {
                get { return _totalPrice; }
                set { _totalPrice = value; }
            }
        }
        private List<transaction> transactions;
        public EndTransactionPage()
        {
            InitializeComponent();
        }

        public EndTransactionPage(List<transaction> list)
        {
            InitializeComponent();
            transactions = list;
        }

        float Total = 0, Paid = 0, Change = 0;

        private void EndTransactionPage_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < transactions.Count; i++)
            {
                Total += transactions[i].TotalPrice;
            }
            labelDue.Text = Total.ToString();
        }

        private void textBoxPaid_TextChanged(object sender, EventArgs e)
        {
            Paid = float.Parse(textBoxPaid.Text);
            Change = Paid - Total;
            labelChange.Text = Change.ToString();
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
