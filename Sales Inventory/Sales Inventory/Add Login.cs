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
    public partial class AddLogin : Form
    {
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
            string query = "INSERT INTO login_module(`id`, `username`, `password`, `access level`) VALUES (NULL, '" + textBoxUsername.Text + "', '" + textBoxPassword.Text + "', '" + accesslevel + "')";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
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
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void comboBoxAccessLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
