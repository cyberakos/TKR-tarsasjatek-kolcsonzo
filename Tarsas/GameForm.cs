using System;
using System.Windows.Forms;

namespace TKR
{
    // [4.] Játék adatai / új játék vagy példány felvétele
    public partial class GameForm : BaseForm
    {
        private string leltari;        // null = új felvétel
        private bool isNew;
        private TextBox[] dataBoxes;
        private string state;

        public GameForm(string leltariSzam)
        {
            InitializeComponent();

            leltari = leltariSzam;
            isNew = leltariSzam == null;

            foreach (Item t in GameService.Titles()) cmbTitle.Items.Add(t);
            foreach (Item k in GameService.Categories()) cmbKat.Items.Add(k);

            // a példány/új cím választó és a beszerzés dátuma csak új felvételnél kell
            radCopy.Visible = isNew;
            radTitle.Visible = isNew;
            lblBesz.Visible = isNew;
            dtpBesz.Visible = isNew;
            dtpBesz.Value = Clock.Today;

            dataBoxes = new TextBox[] { txtCim, txtKiado, txtMin, txtMax, txtPerc, txtMinKor, txtNeh, txtNap, txtKauc };

            if (isNew) { ModeChanged(); }
            else { LoadCopy(); }
        }

        // Betöltés

        private void SetDataEditable(bool editable)
        {
            foreach (TextBox t in dataBoxes) t.Enabled = editable;
            cmbKat.Enabled = editable;
        }

        private void Fill(GameRow g)
        {
            txtCim.Text = g.Cim;
            txtKiado.Text = g.Kiado;
            txtMin.Text = g.MinJatekos.ToString();
            txtMax.Text = g.MaxJatekos.ToString();
            txtPerc.Text = g.Perc.ToString();
            txtMinKor.Text = g.MinKor.ToString();
            txtNeh.Text = g.Nehezseg.ToString();
            txtNap.Text = g.Napidij.ToString();
            txtKauc.Text = g.Kaucio.ToString();
            cmbKat.SelectedIndex = -1;
            foreach (Item k in cmbKat.Items)
            {
                if (k.Id == g.KategoriaId) cmbKat.SelectedItem = k;
            }
        }

        private void ClearFields()
        {
            foreach (TextBox t in dataBoxes) t.Text = "";
            cmbKat.SelectedIndex = -1;
        }

        // Meglévő példány megnyitása
        private void LoadCopy()
        {
            GameRow g = GameService.GetCopy(leltari);
            if (g == null)
            {
                Shown += delegate
                {
                    UI.Error("A kiválasztott példány nem található!");
                    Nav.Show(new GamesForm());
                };
                return;
            }
            cmbTitle.Visible = false;
            Fill(g);
            state = g.Allapot;
            lblLeltari.Text = g.Leltari;
            lblAllapot.Text = g.Allapot;
            txtNote.Text = g.Megjegyzes;
            SetDataEditable(Session.IsManager);

            // állapotváltások: ki, mikor jelölheti
            chkMissing.Enabled = state == GameStates.Available;
            chkReEnable.Enabled = Session.IsManager && (state == GameStates.Missing || state == GameStates.Withdrawn);
            chkWithdraw.Enabled = Session.IsManager && (state == GameStates.Available || state == GameStates.Missing);

            if (state == GameStates.InUse || state == GameStates.Taken)
            {
                RentalRow o = GameService.OpenRentalOf(leltari);
                if (o != null)
                {
                    string s = "Nyitott kölcsönzés: kivétel " + Fmt.ShowTime(o.Kivetel) + ", " + o.TagAsztal;
                    if (o.Hatarido.HasValue) s += ", határidő " + Fmt.Show(o.Hatarido.Value);
                    lblOpen.Text = s;
                }
            }
        }

        // Új felvételnél: példány / új cím váltás
        private void ModeChanged()
        {
            bool copy = radCopy.Checked;
            cmbTitle.Visible = copy;
            txtCim.Visible = !copy;
            lblLeltari.Text = "(automatikus)";
            lblAllapot.Text = GameStates.Available;
            chkMissing.Enabled = false;
            chkReEnable.Enabled = false;
            chkWithdraw.Enabled = false;
            ClearFields();
            SetDataEditable(!copy);
            if (copy)
            {
                // a cím listából választható, az adatok betöltődnek és nem módosíthatók
                cmbTitle.SelectedIndex = -1;
            }
        }

        private void radCopy_CheckedChanged(object sender, EventArgs e)
        {
            if (isNew) ModeChanged();
        }

        private void cmbTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item t = cmbTitle.SelectedItem as Item;
            if (t == null) return;
            GameRow g = GameService.GetTitle(t.Id);
            if (g != null) Fill(g);
        }

        // egyszerre csak egy állapotváltás jelölhető
        private void chkMissing_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMissing.Checked) { chkReEnable.Checked = false; chkWithdraw.Checked = false; }
        }

        private void chkReEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReEnable.Checked) { chkMissing.Checked = false; chkWithdraw.Checked = false; }
        }

        private void chkWithdraw_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWithdraw.Checked) { chkMissing.Checked = false; chkReEnable.Checked = false; }
        }

        // Mentés

        private void btnOk_Click(object sender, EventArgs ev)
        {
            GameEdit e = new GameEdit();
            if (isNew)
            {
                if (radCopy.Checked)
                {
                    e.Mode = GameMode.NewCopy;
                    Item t = cmbTitle.SelectedItem as Item;
                    e.JatekId = t == null ? 0 : t.Id;
                }
                else
                {
                    e.Mode = GameMode.NewTitle;
                }
                e.Beszerzes = Fmt.Show(dtpBesz.Value);
            }
            else
            {
                e.Mode = GameMode.Edit;
                e.Leltari = leltari;
            }

            e.Cim = txtCim.Text;
            e.Kiado = txtKiado.Text;
            Item k = cmbKat.SelectedItem as Item;
            e.KategoriaId = k == null ? 0 : k.Id;
            e.Min = txtMin.Text;
            e.Max = txtMax.Text;
            e.Perc = txtPerc.Text;
            e.MinKor = txtMinKor.Text;
            e.Nehezseg = txtNeh.Text;
            e.Napidij = txtNap.Text;
            e.Kaucio = txtKauc.Text;
            e.Megjegyzes = txtNote.Text;
            e.MarkMissing = chkMissing.Checked;
            e.ReEnable = chkReEnable.Checked;
            e.Withdraw = chkWithdraw.Checked;

            string err = GameService.Validate(e);
            if (err != null) { UI.Error(err); return; }

            if (!UI.Confirm()) return;     // Mégse: marad az űrlap

            string newLeltari;
            err = GameService.Save(e, out newLeltari);
            if (err != null) { UI.Error(err); return; }

            UI.Saved();
            Nav.Show(new GamesForm());
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
