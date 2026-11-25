using System;
using System.Windows.Forms;

namespace TKR
{
    // [5.] Kölcsönzés kiadása
    public partial class IssueForm : BaseForm
    {
        private string leltari;
        private bool ready = false;      // az ablak felépítése alatt ne számoljunk

        public IssueForm(string leltariSzam)
        {
            InitializeComponent();

            leltari = leltariSzam;
            GameRow g = GameService.GetCopy(leltari);
            lblJatek.Text = g == null ? leltari : g.Leltari + " – " + g.Cim;
            lblDolgozo.Text = Session.UserId;

            foreach (MemberRow m in MemberService.Active())
            {
                cmbTag.Items.Add(m.Id + " – " + m.FullName);
            }

            dtpKivetel.Value = Clock.Now;
            dtpKivetel.Enabled = Session.IsManager;    // csak az üzletvezető módosíthatja
            dtpHat.Value = Clock.Today.AddDays(RentalService.DefaultDays);

            ready = true;
            Recalc();
        }

        // A tag-azonosító a "T-0001 – Kovács Anna" szövegből
        private string TagId()
        {
            string t = cmbTag.Text.Trim();
            int i = t.IndexOf(" – ");
            if (i > 0) t = t.Substring(0, i).Trim();
            return t;
        }

        private IssueInput GetInput()
        {
            IssueInput x = new IssueInput();
            x.Leltari = leltari;
            x.Tipus = radAway.Checked ? RentalTypes.TakeAway : RentalTypes.OnSite;
            x.Asztal = txtAsztal.Text;
            x.TagId = TagId();
            x.Kivetel = Session.IsManager ? Fmt.ShowTime(dtpKivetel.Value) : "";
            x.Hatarido = Fmt.Show(dtpHat.Value);
            x.Megjegyzes = txtNote.Text;
            return x;
        }

        // Díj, kaució, napok és figyelmeztetés élő számítása
        private void Recalc()
        {
            if (!ready) return;
            bool away = radAway.Checked;
            txtAsztal.Enabled = !away;
            dtpHat.Enabled = away;

            IssueCalc c = RentalService.Calculate(GetInput());
            if (away)
            {
                lblNapok.Text = c.Napok.ToString();
                lblDij.Text = c.Dij.ToString();
                lblKauc.Text = c.Kaucio.ToString();
            }
            else
            {
                lblNapok.Text = "0";
                lblDij.Text = "0";
                lblKauc.Text = "0";
            }
            lblWarn.Text = c.Warning == null ? "" : c.Warning;
        }

        // Bármelyik mező változik, újraszámolunk
        private void Input_Changed(object sender, EventArgs e)
        {
            Recalc();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            IssueInput x = GetInput();
            string err = RentalService.ValidateIssue(x);
            if (err != null) { UI.Error(err); return; }

            if (!UI.Confirm()) return;

            int id;
            err = RentalService.Issue(x, out id);
            if (err != null) { UI.Error(err); return; }

            UI.Saved();
            Nav.Show(new LogForm(id));      // az új sor kijelölve
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        protected override void GoBack()
        {
            Nav.Show(new GamesForm());
        }
    }
}
