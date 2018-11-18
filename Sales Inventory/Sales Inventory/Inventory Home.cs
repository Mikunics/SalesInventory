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
    public partial class InventoryHome : Form
    {
        public InventoryHome()
        {
            InitializeComponent();
        }

        private void InventoryHome_Load(object sender, EventArgs e)
        {

        }

        private void InventoryHome_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void buttonSalesReport_Click(object sender, EventArgs e)
        {
            Form SalesReport = new SalesReport();
            SalesReport.ShowDialog();
        }

        private void buttonSalesHistory_Click(object sender, EventArgs e)
        {
            Form SalesHistory = new SalesHistory();
            SalesHistory.ShowDialog();
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            Form AddItem = new AddItem();
            AddItem.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Form EditItem = new EditItem();
            EditItem.ShowDialog();
        }
    }
}
