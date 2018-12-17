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
        Timer t = null;
        private void StartTimer()
        {
            t = new Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString();
        }

        private static float getItemPrice(string ItemName)
        {
            string query = "SELECT price FROM item_catalog WHERE Name = '" + ItemName + "'";
            MySqlConnection databaseConnection = new MySqlConnection(ConnectionString.Connection);
            MySqlCommand databaseCommand = new MySqlCommand(query, databaseConnection);
            databaseCommand.CommandTimeout = 60;
            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = databaseCommand.ExecuteReader();
                myReader.Read();
                return myReader.GetFloat("price");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

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

            public transaction(string a, int i)
            {
                ItemName = a;
                Quantity = i;
                PricePerUnit = getItemPrice(ItemName);
                TotalPrice = PricePerUnit * Quantity;
            }
        }
        public List<transaction> transactions = new List<transaction>();

        private bool RecordTransaction()
        {
            // Records to database a finished transaction
            for (int i = 0; i < transactions.Count; i++)
            {
                string connectionString = ConnectionString.Connection;
                string query1 = "SELECT ItemCode, price FROM item_catalog WHERE Name = '" + transactions[i].ItemName + "'";

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand databaseCommand1 = new MySqlCommand(query1, databaseConnection);
                databaseCommand1.CommandTimeout = 60;

                try
                {
                    databaseConnection.Open();
                    MySqlDataReader myReader1 = databaseCommand1.ExecuteReader();
                    myReader1.Read();
                    int ItemCode = myReader1.GetInt32("ItemCode");
                    float price = myReader1.GetFloat("price");
                    myReader1.Close();
                    string query2 = "INSERT INTO sales_history(ID, item_code, price, quantity) VALUES (NULL,'"+ ItemCode +"','"+ price +"','"+ transactions[i].Quantity +"')";
                    MySqlCommand databaseCommand2 = new MySqlCommand(query2, databaseConnection);
                    databaseCommand2.CommandTimeout = 60;
                    MySqlDataReader myReader2 = databaseCommand2.ExecuteReader();
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            MessageBox.Show("Successfully added transaction into database");
            return true;
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
            comboBoxItemName.SelectedIndex = 0;
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
                RecordTransaction();
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
            StartTimer();
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
            numericUpDownQuantity.Value = 1;
        }
    }
}
