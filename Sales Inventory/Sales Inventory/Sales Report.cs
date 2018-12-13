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
    public partial class SalesReport : Form
    {
        public SalesReport()
        {
            InitializeComponent();
        }

        private bool GenerateReport(DateTime To, DateTime From)
        {
            string connectionString = ConnectionString.Connection;
            string query = "SELECT DISTINCT name";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand databaseCommand = new MySqlCommand(query, databaseConnection);
            databaseCommand.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = databaseCommand.ExecuteReader();
                databaseConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (radioButtonDaily.Checked)
            {
                DateTime To = DateTime.Today;
                DateTime From = DateTime.Today;
                GenerateReport(To, From);
            }else if (radioButtonCustom.Checked)
            {
                DateTime To = dateTimePickerTo.Value;
                DateTime From = dateTimePickerFrom.Value;
                GenerateReport(To, From);
            }
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }
    }
}
