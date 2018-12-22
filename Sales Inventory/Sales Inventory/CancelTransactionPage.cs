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
    public partial class CancelTransactionPage : Form
    {
        public CancelTransactionPage()
        {
            InitializeComponent();
        }

        private bool DeleteTransaction()
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                string connectionString = ConnectionString.Connection;
                string query = "DELETE FROM sales_history WHERE ID = '" + dataGridView1.SelectedRows[i].Cells[0].Value.ToString() + "'";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand databaseCommand = new MySqlCommand(query, databaseConnection);
                databaseCommand.CommandTimeout = 60;

                try
                {
                    databaseConnection.Open();
                    MySqlDataReader myReader = databaseCommand.ExecuteReader();
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            MessageBox.Show("Transaction Succesfully Deleted");
            return true;
        }

        private void LoadView()
        {
            // Loads the Data Grid View to see the what the table item_catalog contains.

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            MySqlConnection databaseConnection = new MySqlConnection(ConnectionString.Connection);

            MySqlCommand databaseCommand = new MySqlCommand("SELECT * FROM sales_history", databaseConnection);

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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (DeleteTransaction())
            {
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CancelTransactionPage_Load(object sender, EventArgs e)
        {
            LoadView();
        }
    }
}
