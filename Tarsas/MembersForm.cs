using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TKR
{
    // [8.] Tagok nyilvántartása
    public partial class MembersForm : BaseForm
    {
        public MembersForm()
        {
            InitializeComponent();
            Query();
        }

        private void OpenSelected()
        {
            if (lv.SelectedItems.Count == 0) return;
            MemberRow m = (MemberRow)lv.SelectedItems[0].Tag;
            Nav.Show(new MemberForm(m.Id));
        }

        private void Query()
        {
            string err = MemberService.ValidateSearch(txtVn.Text, txtKn.Text, txtId.Text);
            if (err != null)
            {
                UI.Error(err);
                return;
            }

            List<MemberRow> rows = MemberService.Search(txtVn.Text, txtKn.Text, txtId.Text, chkActive.Checked);
            lv.Items.Clear();
            foreach (MemberRow m in rows)
            {
                ListViewItem it = new ListViewItem(new string[] {
                    m.Id, m.Vezeteknev, m.Keresztnev, Fmt.Show(m.Szuletes), m.Aktiv ? "Igen" : "Nem" });
                it.Tag = m;
                lv.Items.Add(it);
            }
            btnInfo.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnInfo.Enabled = lv.SelectedItems.Count > 0;
        }

        private void lv_DoubleClick(object sender, EventArgs e)
        {
            OpenSelected();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            OpenSelected();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Nav.Show(new MemberForm(null));
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
