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
using System.Security.Cryptography;

namespace Sales_Inventory
{
    public partial class AddLogin : Form
    {
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
        private bool AddCredentials()
        {
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
                    MessageBox.Show("You have input an invalid access level","Invalid Access Level",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
            }
            string connectionString = ConnectionString.Connection;
            string hashed = GetStringSha256Hash(textBoxPassword.Text);
            string query = "INSERT INTO login_module(`id`, `username`, `password`, `accesslevel`) VALUES (NULL, '" + textBoxUsername.Text + "', '" + hashed + "', '" + accesslevel + "')";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand databaseCommand = new MySqlCommand(query, databaseConnection);
            databaseCommand.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = databaseCommand.ExecuteReader();
                MessageBox.Show("Login Credentials Succesfully Added");
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
        public AddLogin()
        {
            InitializeComponent();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (AddCredentials())
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

        private void comboBoxAccessLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
