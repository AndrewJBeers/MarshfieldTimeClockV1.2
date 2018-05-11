using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Real_Time_Clock
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

            var form1 = new Log_Table();
            var form2 = new Employee();
            var form3 = new Employee_Role();

            form1.Show();
            form2.Show();
            form3.Show();

            Application.Run();
        }
    }
}
