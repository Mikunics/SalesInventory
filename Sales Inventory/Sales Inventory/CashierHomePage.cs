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
    public partial class CashierHomePage : Form
    {
        public CashierHomePage()
        {
            InitializeComponent();
        }

        private void buttonEndTransaction_Click(object sender, EventArgs e)
        {
            Form EndTransaction = new EndTransactionPage();
            EndTransaction.ShowDialog();
        }

        private void buttonCancelTransaction_Click(object sender, EventArgs e)
        {
            Form CancelTransaction = new CancelTransactionPage();
            CancelTransaction.ShowDialog();
        }

        private void buttonSalesInventory_Click(object sender, EventArgs e)
        {
            Form SalesInventory = new InventoryHome();
            SalesInventory.ShowDialog();
        }

        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            Form AdminControl = new AdminHome();
            AdminControl.ShowDialog();
        }

        private void CashierHomePage_Load(object sender, EventArgs e)
        {

        }
    }
}
