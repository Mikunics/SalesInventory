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
    public partial class EditItem : Form
    {
        public EditItem()
        {
            InitializeComponent();
        }

        private void LoadView()
        {

            // Loads the Data Grid View to see the what the table item_catalog contains.

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            MySqlConnection databaseConnection = new MySqlConnection(ConnectionString.Connection);

            MySqlCommand databaseCommand = new MySqlCommand("SELECT * FROM item_catalog", databaseConnection);

            try

            {

                MySqlDataAdapter databaseAdapter = new MySqlDataAdapter();

                databaseAdapter.SelectCommand = databaseCommand;

                DataTable databaseTable = new DataTable();

                databaseAdapter.Fill(databaseTable);

                BindingSource bSource = new BindingSource();

                bSource.DataSource = databaseTable;

                dataGridView1.DataSource = bSource;

            }

            catch (Exception ec)

            {

                MessageBox.Show(ec.Message);

            }
        }

        private bool DeleteExistingItem()
        {
            // deletes a row in item_catalog given an ID
            string connectionString = ConnectionString.Connection;
            string query = "DELETE FROM item_catalog WHERE ItemCode = '" + textBoxItemCode.Text + "'";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand databaseCommand = new MySqlCommand(query, databaseConnection);
            databaseCommand.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = databaseCommand.ExecuteReader();
                MessageBox.Show("Item Succesfully Deleted");
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

        private bool EditExistingItem()
        {
            // edits a row in item_catalog given an ID

            string connectionString = ConnectionString.Connection;
            string query = "UPDATE item_catalog SET Name = '" + textBoxItemName.Text + "', Price = '" + textBoxPrice.Text + "' WHERE ItemCode = '" + textBoxItemCode.Text + "'";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand databaseCommand = new MySqlCommand(query, databaseConnection);
            databaseCommand.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = databaseCommand.ExecuteReader();
                MessageBox.Show("Item Succesfully Updated");
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (EditExistingItem())
            {
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Focused)
            {
                textBoxItemCode.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBoxItemName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBoxPrice.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadView();
        }

        private void EditItem_Load(object sender, EventArgs e)
        {
            LoadView();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (DeleteExistingItem())
            {
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }
    }
}
