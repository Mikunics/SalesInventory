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
    public partial class EditLogin : Form
    {
        public EditLogin()
        {
            InitializeComponent();
        }

        internal static string GetStringSha256Hash(string text)
        {
            // Hashes given string using SHA256

            if (String.IsNullOrEmpty(text))
                return String.Empty;

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }

        private bool EditCredentials()
        {
            // Updates specified ID credentials to the corresponding inputed username, password and access level

            string hashed = GetStringSha256Hash(textBoxPassword.Text);
            string connectionString = ConnectionString.Connection;
            int accesslevel;
            switch (comboBoxAccessLevel.Text)
            {
                /*
                This translates text access levels into integers
                ------------------------------------------------
                Which access levels can access what?
                Cashier Level = 1,2,3
                Sales Manager = 1,2
                Admin Manager = 1
                */

                case ("Cashier Level Access"):
                    accesslevel = 3;
                    break;
                case ("Sales Manager Level Access"):
                    accesslevel = 2;
                    break;
                case ("Admin Level Access"):
                    accesslevel = 1;
                    break;
                default:
                    MessageBox.Show("You have input an invalid access level", "Invalid Access Level", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
            }
            string query = "UPDATE login_module SET username = '"+ textBoxUsername.Text +"', password = '"+hashed+"',accesslevel = '"+accesslevel+"' WHERE id = '"+textBoxID.Text+"'";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand databaseCommand = new MySqlCommand(query, databaseConnection);
            databaseCommand.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = databaseCommand.ExecuteReader();
                MessageBox.Show("Login Credentials Succesfully Updated");
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

        private void LoadView()
        {
            
            // Loads the Data Grid View to see the what the table login_module contains.
            
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            MySqlConnection databaseConnection = new MySqlConnection(ConnectionString.Connection);

            MySqlCommand databaseCommand = new MySqlCommand("SELECT id, username, accesslevel FROM login_module", databaseConnection);

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (EditCredentials())
            {
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void EditLogin_Load(object sender, EventArgs e)
        {
            LoadView();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadView();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxAccessLevel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Focused)
            {
                textBoxID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBoxUsername.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                int i = (int)dataGridView1.SelectedRows[0].Cells[2].Value;
                switch (i)
                {
                    case (3):
                        comboBoxAccessLevel.SelectedItem = "Cashier Level Access";
                        break;
                    case (2):
                        comboBoxAccessLevel.SelectedItem = "Sales Manager Level Access";
                        break;
                    case (1):
                        comboBoxAccessLevel.SelectedItem = "Admin Level Access";
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
