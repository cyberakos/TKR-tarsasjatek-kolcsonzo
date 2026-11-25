using System;
using System.Windows.Forms;

namespace TKR
{
    // [2.] Főmenü
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();

            string role = Session.IsManager ? "üzletvezető" : "pultos";
            lblHello.Text = "Üdvözöljük, " + Session.FullName + " (" + role + ")!";
        }

        private void btnGames_Click(object sender, EventArgs e)
        {
            Nav.Show(new GamesForm());
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Nav.Show(new LogForm());
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            Nav.Show(new MembersForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Nav.Show(new LoginForm());
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
