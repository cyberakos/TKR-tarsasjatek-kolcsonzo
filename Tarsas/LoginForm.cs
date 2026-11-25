using System;
using System.Windows.Forms;

namespace TKR
{
    // [1.] Bejelentkezés
    public partial class LoginForm : BaseForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string err = AuthService.Login(txtId.Text, txtPass.Text);
            if (err != null)
            {
                UI.Error(err);
                txtPass.Clear();
                txtPass.Focus();
                return;
            }
            Nav.Show(new MainForm());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void GoBack()
        {
            Application.Exit();
        }
    }
}
