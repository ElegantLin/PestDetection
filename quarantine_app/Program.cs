using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quarantine_app
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loginForm loginPanel = new loginForm();
            loginPanel.StartPosition = FormStartPosition.CenterScreen;
            loginPanel.ShowDialog();
            
            if (loginPanel.DialogResult == DialogResult.OK)
            {
                loginPanel.Dispose();
                index indexPanel = new index(loginPanel.user_name, loginPanel.auth);
                indexPanel.StartPosition = FormStartPosition.CenterScreen;
                Application.Run(indexPanel);
            }
            else if (loginPanel.DialogResult == DialogResult.Cancel)
            {
                loginPanel.Dispose();
                return;
            }
            Application.Run(new loginForm());
        }
    }
}
