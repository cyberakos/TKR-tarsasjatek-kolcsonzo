using System;
using System.Windows.Forms;

namespace TKR
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Db.Init();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Nav.Show(new LoginForm());
            Application.Run();
        }
    }
}
