using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sales_Inventory
{
    public partial class AdminHome : Form
    {
        // Directory page for login module controls

        public AdminHome()
        {
            InitializeComponent();
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {

        }

        private void AdminHome_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form AddLogin = new AddLogin();
            AddLogin.ShowDialog();
        }

        private void buttonEditLogin_Click(object sender, EventArgs e)
        {
            Form EditLogin = new EditLogin();
            EditLogin.ShowDialog();
        }
    }
}
