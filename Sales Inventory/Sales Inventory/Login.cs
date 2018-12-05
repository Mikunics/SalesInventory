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
    public partial class Login : Form
    {
        public int Access {get; private set;}
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
        private int Authenticate()
        {
            /*
            Authenticate whether typed in credentials are in the database and return the access level of said credentials
            Returns 0 if credentials are invalid
            */

            string hashed = GetStringSha256Hash(textBoxPassword.Text);
            string connectionString = ConnectionString.Connection;
            string query = "SELECT * FROM login_module WHERE username = '"+textBoxUsername.Text+"' AND password = '"+hashed+"' ";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand databaseCommand = new MySqlCommand(query, databaseConnection);
            databaseCommand.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = databaseCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    myReader.Read();
                    int i = myReader.GetInt16("accesslevel");
                    databaseConnection.Close();
                    return i;
                }
                else
                {
                    MessageBox.Show("The username or password you have inputed is invalid", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = Authenticate();
            if (i >= 1) {
                this.Access = i;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Login_VisibleChanged(object sender, EventArgs e)
        {
        }
    }
}
