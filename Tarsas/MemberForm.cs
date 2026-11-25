using System;
using System.Windows.Forms;

namespace TKR
{
    // [9.] Tag adatlapja
    public partial class MemberForm : BaseForm
    {
        private string id;      // null = új tag

        public MemberForm(string tagId)
        {
            InitializeComponent();

            id = tagId;
            MemberRow m = null;
            if (id != null) m = MemberService.Get(id);
            if (id != null && m == null)
            {
                Shown += delegate
                {
                    UI.Error("A tag nem található!");
                    Nav.Show(new MembersForm());
                };
                return;
            }

            lblId.Text = id == null ? "(automatikus)" : id;
            lblBelepes.Text = id == null ? Fmt.Show(Clock.Today) : Fmt.Show(m.Belepes);
            lblNyitott.Text = id == null ? "0" : MemberService.OpenTakeAwayCount(id).ToString();

            // születési dátum: 1900 és a mai nap között
            dtpDob.Value = Clock.Today;
            dtpDob.MaxDate = Clock.Today;

            if (m != null)
            {
                txtVn.Text = m.Vezeteknev;
                txtKn.Text = m.Keresztnev;
                dtpDob.Value = m.Szuletes;
                txtEmail.Text = m.Email;
                txtTel.Text = m.Telefon;
                chkActive.Checked = m.Aktiv;
            }

            // a pultos meglévő tagnál csak az e-mailt és a telefonszámot módosíthatja,
            // új tagnál az aktív jelölés nem változtatható
            if (!Session.IsManager)
            {
                chkActive.Enabled = false;
                if (id != null)
                {
                    txtVn.Enabled = false;
                    txtKn.Enabled = false;
                    dtpDob.Enabled = false;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs ev)
        {
            MemberEdit e = new MemberEdit();
            e.Id = id;
            e.Vezeteknev = txtVn.Text;
            e.Keresztnev = txtKn.Text;
            e.Szuletes = Fmt.Show(dtpDob.Value);
            e.Email = txtEmail.Text;
            e.Telefon = txtTel.Text;
            e.Aktiv = chkActive.Checked;

            string err = MemberService.Validate(e);
            if (err != null) { UI.Error(err); return; }

            if (!UI.Confirm()) return;

            string newId;
            err = MemberService.Save(e, out newId);
            if (err != null) { UI.Error(err); return; }

            UI.Saved();
            Nav.Show(new MembersForm());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        protected override void GoBack()
        {
            Nav.Show(new MembersForm());
        }
    }
}
