using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TKR
{
    // [3.] Játékok keresése
    public partial class GamesForm : BaseForm
    {
        // az állapot-jelölőnégyzetek ugyanabban a sorrendben, mint a GameStates.All
        private CheckBox[] chkAllapot;

        public GamesForm()
        {
            InitializeComponent();

            chkAllapot = new CheckBox[] { chkKeszleten, chkHasznalatban, chkElvitt, chkHianyos, chkKivonva };

            cmbKat.Items.Add(new Item(0, "Mind"));
            foreach (Item k in GameService.Categories()) cmbKat.Items.Add(k);
            cmbKat.SelectedIndex = 0;

            Frissites();
        }

        private GameRow Selected()
        {
            if (lv.SelectedItems.Count == 0) return null;
            return (GameRow)lv.SelectedItems[0].Tag;
        }

        private void OpenInfo()
        {
            GameRow g = Selected();
            if (g != null) Nav.Show(new GameForm(g.Leltari));
        }

        private void UpdateButtons()
        {
            GameRow g = Selected();
            btnIssue.Enabled = g != null && g.Allapot == GameStates.Available;
            btnInfo.Enabled = g != null;
            btnNew.Enabled = Session.IsManager;
        }

        // A lista újratöltése a szűrők alapján
        private void Frissites()
        {
            GameFilter f = new GameFilter();
            f.Cim = txtCim.Text;
            Item k = (Item)cmbKat.SelectedItem;
            if (k.Id > 0) f.KategoriaId = k.Id;
            f.Jatekosok = txtPl.Text;
            for (int i = 0; i < chkAllapot.Length; i++)
            {
                if (chkAllapot[i].Checked) f.Allapotok.Add(GameStates.All[i]);
            }

            List<GameRow> rows;
            string err = GameService.Search(f, out rows);
            if (err != null)
            {
                UI.Error(err);
                return;
            }

            lv.Items.Clear();
            foreach (GameRow g in rows)
            {
                ListViewItem it = new ListViewItem(new string[] {
                    g.Leltari, g.Cim, g.Jatekosok, g.Perc.ToString(), g.MinKor.ToString(), g.Allapot });
                it.Tag = g;
                lv.Items.Add(it);
            }
            UpdateButtons();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Frissites();
        }

        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void lv_DoubleClick(object sender, EventArgs e)
        {
            OpenInfo();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            GameRow g = Selected();
            if (g != null) Nav.Show(new IssueForm(g.Leltari));
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            OpenInfo();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Nav.Show(new GameForm(null));
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            Nav.Show(new MainForm());
        }

        protected override void GoBack()
        {
            Nav.Show(new MainForm());
        }
    }
}
