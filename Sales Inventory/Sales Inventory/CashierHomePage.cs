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
        class transaction
        {
            private string _ItemName;
            private int _quantity;
            public string ItemName
            {
                get { return _ItemName; }
                set { _ItemName = value; }
            }
            public int quantity
            {
                get { return _quantity; }
                set { _quantity = value; }
            }

            public transaction(string a, int i)
            {
                ItemName = a;
                quantity = i;
            }
        }
        List<transaction> transactions = new List<transaction>();


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
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        private void buttonResetTransaction_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            transactions.Add(new transaction(comboBoxItemName.Text, (int)numericUpDownQuantity.Value));
            
        }
    }
}
