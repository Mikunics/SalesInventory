using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sales_Inventory
{
    public partial class CashierHomePage : Form
    {
        public class transaction
        {
            private string _ItemName;
            private int _quantity;
            [System.ComponentModel.DisplayName("Item Name")]
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

            public transaction(string a, int i)
            {
                ItemName = a;
                Quantity = i;
            }
        }
        List<transaction> transactions = new List<transaction>();

        private bool RecordTransaction()
        {
            // Records to database a finished transaction
            return false;
        }

        private void PopulateItemName()
        {
            string connectionString = ConnectionString.Connection;
            string query = "SELECT Name FROM item_catalog";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand databaseCommand = new MySqlCommand(query, databaseConnection);
            databaseCommand.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = databaseCommand.ExecuteReader();
                if(myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        comboBoxItemName.Items.Add(myReader.GetString("Name"));
                    }
                }
            }

            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }

        public CashierHomePage(int i)
        {
            InitializeComponent();
            if (i >= 2)
            {
                buttonAdmin.Dispose();
            }
            if (i == 3)
            {
                buttonSalesInventory.Dispose();
            }
        }

        private void buttonEndTransaction_Click(object sender, EventArgs e)
        {
            Form EndTransaction = new EndTransactionPage();
            EndTransaction.ShowDialog();
            if(EndTransaction.DialogResult == DialogResult.OK)
            {
                transactions.Clear();
                var bindinglist = new BindingList<transaction>(transactions);
                dataGridView1.DataSource = bindinglist;
            }
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
            PopulateItemName();
            var bindingList = new BindingList<transaction>(transactions);
            dataGridView1.DataSource = bindingList;
        }

        private void buttonResetTransaction_Click(object sender, EventArgs e)
        {
            transactions.Clear();
            var bindinglist = new BindingList<transaction>(transactions);
            dataGridView1.DataSource = bindinglist;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            transactions.Add(new transaction(comboBoxItemName.Text, (int)numericUpDownQuantity.Value));
            var bindinglist = new BindingList<transaction>(transactions);
            dataGridView1.DataSource = bindinglist;
        }
    }
}
