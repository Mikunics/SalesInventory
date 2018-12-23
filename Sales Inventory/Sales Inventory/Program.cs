using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sales_Inventory
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var Login = new Login())
            {
                // Passes into CashierHomePage the access level of the authenticated user
                var result = Login.ShowDialog();
                if (result == DialogResult.OK)
                {
                    int i = Login.Access;
                    Login.Dispose();
                    Application.Run(new CashierHomePage(i));
                } 
            }
        }
    }
}
