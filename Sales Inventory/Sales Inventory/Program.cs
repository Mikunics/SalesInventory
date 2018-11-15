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

            Form Login = new Login();
            while (true)
            {
                if (Login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new CashierHomePage());
                    break;
                }
            }
        }
    }
}
