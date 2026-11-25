using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace TKR
{
    // [7.] Kölcsönzési napló
    public partial class LogForm : BaseForm
    {
        private List<RentalRow> current = new List<RentalRow>();
        private int printIndex;
        private int selectId;

        public LogForm() : this(0)
        {
        }

        // selectId: az a kölcsönzés, amelyiket a lista betöltése után ki kell jelölni
        public LogForm(int selectId)
        {
            InitializeComponent();

            this.selectId = selectId;

            // alapból az elmúlt 30 nap kölcsönzései látszanak
            dtpFrom.Value = Clock.Today.AddDays(-30);
            if (selectId > 0)
            {
                RentalRow sel = RentalService.Get(selectId);
                if (sel != null && sel.Kivetel < dtpFrom.Value) dtpFrom.Value = sel.Kivetel.Date;
            }
            dtpTo.Value = Clock.Today.AddHours(23).AddMinutes(59);

            cmbCopy.Items.Add(new Choice("", "Mind"));
            foreach (KeyValuePair<string, string> kv in LogService.AllCopies())
            {
                cmbCopy.Items.Add(new Choice(kv.Key, kv.Value));
            }
            cmbCopy.SelectedIndex = 0;

            cmbMember.Items.Add(new Choice("", "Mind"));
            foreach (KeyValuePair<string, string> kv in LogService.AllMembers())
            {
                cmbMember.Items.Add(new Choice(kv.Key, kv.Value));
            }
            cmbMember.SelectedIndex = 0;

            Query();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            RentalRow r = Selected();
            if (r != null && r.IsOpen) Nav.Show(new ReturnForm(r.Id));
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Nav.Show(new GamesForm());
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            Nav.Show(new MainForm());
        }

        private RentalRow Selected()
        {
            if (lv.SelectedItems.Count == 0) return null;
            return (RentalRow)lv.SelectedItems[0].Tag;
        }

        private void UpdateButtons()
        {
            RentalRow r = Selected();
            btnReturn.Enabled = r != null && r.IsOpen;
            btnPrint.Enabled = Session.IsManager;
        }

        private static string DateText(DateTime? d, bool withTime)
        {
            if (!d.HasValue) return "–";
            return withTime ? Fmt.ShowTime(d.Value) : Fmt.Show(d.Value);
        }

        private void Query()
        {
            LogFilter f = new LogFilter();
            f.From = Fmt.ShowTime(dtpFrom.Value);
            f.To = Fmt.ShowTime(dtpTo.Value);
            f.OnSite = chkOn.Checked;
            f.TakeAway = chkAway.Checked;
            f.Open = chkOpen.Checked;
            f.Closed = chkClosed.Checked;
            f.Leltari = ((Choice)cmbCopy.SelectedItem).Key;
            f.TagId = ((Choice)cmbMember.SelectedItem).Key;

            List<RentalRow> rows;
            string err = LogService.Query(f, out rows);
            if (err != null)
            {
                UI.Error(err);
                return;
            }

            current = rows;
            lv.Items.Clear();
            foreach (RentalRow r in rows)
            {
                ListViewItem it = new ListViewItem(new string[] {
                    Fmt.ShowTime(r.Kivetel),
                    r.Cim + " (" + r.Leltari + ")",
                    r.Tipus,
                    r.TagAsztal,
                    DateText(r.Hatarido, false),
                    DateText(r.Visszavetel, true),
                    r.Dij + " Ft",
                    r.KesedelmiDij.HasValue ? r.KesedelmiDij.Value + " Ft" : "–",
                    r.Megjegyzes ?? "" });
                it.Tag = r;
                lv.Items.Add(it);
                if (r.Id == selectId)
                {
                    it.Selected = true;
                    it.EnsureVisible();
                }
            }
            selectId = 0;
            UpdateButtons();
        }

        // Nyomtatás (csak üzletvezető)

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!Session.IsManager)
            {
                UI.Error("A napló nyomtatásához üzletvezetői jogosultság szükséges!");
                return;
            }
            if (current.Count == 0)
            {
                UI.Error("Nincs kinyomtatható sor a jelenlegi szűréssel!");
                return;
            }

            PrintDocument doc = new PrintDocument();
            doc.DocumentName = "Kölcsönzési napló";
            doc.DefaultPageSettings.Landscape = true;
            PrintDialog dlg = new PrintDialog();
            dlg.Document = doc;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            printIndex = 0;
            doc.PrintPage += PrintPage;
            try
            {
                doc.Print();
            }
            catch (Exception ex)
            {
                UI.Error("A nyomtatás nem sikerült (a nyomtató nem érhető el?): " + ex.Message);
            }
            finally
            {
                doc.PrintPage -= PrintPage;
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            string[] heads = { "Kivétel ideje", "Játék", "Típus", "Tag / asztal", "Kiadó", "Határidő", "Visszavétel", "Díj", "Késedelmi", "Hiányos", "Megjegyzés" };
            float[] widths = { 95, 140, 50, 120, 75, 65, 95, 40, 50, 40, 190 };

            using (Font normal = new Font("Arial", 8))
            using (Font bold = new Font("Arial", 8, FontStyle.Bold))
            using (StringFormat sf = new StringFormat())
            {
                sf.FormatFlags = StringFormatFlags.NoWrap;
                sf.Trimming = StringTrimming.EllipsisCharacter;

                float lineHeight = normal.GetHeight(e.Graphics) + 4;
                float y = e.MarginBounds.Top;

                e.Graphics.DrawString("Kölcsönzési napló: " + Fmt.ShowTime(dtpFrom.Value) + " – " + Fmt.ShowTime(dtpTo.Value), bold, Brushes.Black, e.MarginBounds.Left, y);
                y += lineHeight * 2;

                float x = e.MarginBounds.Left;
                for (int i = 0; i < heads.Length; i++)
                {
                    e.Graphics.DrawString(heads[i], bold, Brushes.Black, new RectangleF(x, y, widths[i] - 3, lineHeight), sf);
                    x += widths[i];
                }
                y += lineHeight;

                while (printIndex < current.Count)
                {
                    if (y + lineHeight > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;     // a többi a következő oldalra kerül
                        return;
                    }
                    RentalRow r = current[printIndex];
                    string[] cells = {
                        Fmt.ShowTime(r.Kivetel),
                        r.Cim + " (" + r.Leltari + ")",
                        r.Tipus,
                        r.TagAsztal,
                        r.KiadoDolgozo,
                        DateText(r.Hatarido, false),
                        DateText(r.Visszavetel, true),
                        r.Dij.ToString(),
                        r.KesedelmiDij.HasValue ? r.KesedelmiDij.Value.ToString() : "–",
                        r.Hianyos == true ? "igen" : (r.Hianyos == false ? "nem" : "–"),
                        r.Megjegyzes ?? "" };
                    x = e.MarginBounds.Left;
                    for (int i = 0; i < cells.Length; i++)
                    {
                        e.Graphics.DrawString(cells[i], normal, Brushes.Black, new RectangleF(x, y, widths[i] - 3, lineHeight), sf);
                        x += widths[i];
                    }
                    y += lineHeight;
                    printIndex++;
                }
                e.HasMorePages = false;
            }
        }

        protected override void GoBack()
        {
            Nav.Show(new MainForm());
        }
    }
}
