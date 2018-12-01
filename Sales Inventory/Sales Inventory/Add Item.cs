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
    public partial class AddItem : Form
    {
        public AddItem()
        {
            InitializeComponent();
        }

        private bool AddNewItem()
        {
            string connectionString = ConnectionString.Connection;
            string query = "INSERT INTO item_catalog(ItemCode, Name, Price) VALUES (NULL,'" + textBoxItemName.Text + "', '"+textBoxItemPrice.Text+"')";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand databaseCommand = new MySqlCommand(query, databaseConnection);
            databaseCommand.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = databaseCommand.ExecuteReader();
                MessageBox.Show("Item successfully added");
                databaseConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (AddNewItem())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
