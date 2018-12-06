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
    public partial class SalesHistory : Form
    {
        public SalesHistory()
        {
            InitializeComponent();
        }

        private void LoadView()
        {
            // Loads the Data Grid View to see the what the table item_catalog contains.

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

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
        
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadView();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void SalesHistory_Load(object sender, EventArgs e)
        {
            LoadView();
        }
    }
}
