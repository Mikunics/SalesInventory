using System;
using System.IO;
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
            string query = "SELECT DISTINCT item_code FROM sales_history";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand databaseCommand = new MySqlCommand(query, databaseConnection);
            databaseCommand.CommandTimeout = 60;
            List<int> existingItemCodes = new List<int>();
            List<string> output = new List<string>();
            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = databaseCommand.ExecuteReader();
                while (myReader.HasRows)
                {
                    existingItemCodes.Add(myReader.GetInt32("item_code"));
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
                return false;
            }
            float Total = 0;
            for (int i = 0; i < existingItemCodes.Count - 1; i++)
            {
                query = "SELECT price, quantity FROM sales_history WHERE item_code = '" + existingItemCodes[i] + "' AND BETWEEN '"+From.ToShortDateString()+"' AND '"+To.ToShortDateString()+"'";
                string query2 = "SELECT Name FROM item_catalog WHERE ItemCode = '" + existingItemCodes[i] + "'";
                databaseCommand = new MySqlCommand(query, databaseConnection);
                int curQuantity = 0;
                float curTotal = 0;
                try
                {
                    MySqlDataReader myReader = databaseCommand.ExecuteReader();
                    while (myReader.HasRows)
                    {
                        myReader.Read();
                        curQuantity += myReader.GetInt32("quantity");
                        curTotal += myReader.GetFloat("price") * myReader.GetInt32("quantity");
                    }
                    myReader.Close();
                    databaseCommand = new MySqlCommand(query2, databaseConnection);
                    myReader = databaseCommand.ExecuteReader();
                    string itemname = "Error";
                    if (myReader.HasRows)
                    {
                        myReader.Read();
                        itemname = myReader.GetString("Name");
                    }
                    string record = $"{itemname} has sold {curQuantity} units to make a total of {curTotal}.";
                    output.Add(record);
                    Total += curTotal;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            output.Add($"You have made a total of {Total} from {From.ToString("D")} to {To.ToString("D")}");
            try
            {
                File.WriteAllLines(@"C:\Users\walte\Desktop\SalesReport.txt", output);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
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
