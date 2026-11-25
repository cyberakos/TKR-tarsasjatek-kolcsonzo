using System;
using System.Drawing;
using System.Windows.Forms;

namespace TKR
{
    // Egy elem a legördülő listákhoz (kulcs + megjelenő szöveg)
    public class Choice
    {
        public string Key;
        public string Text;
        public Choice(string key, string text) { Key = key; Text = text; }
        public override string ToString() { return Text; }
    }

    // Közös üzenetablakok
    public static class UI
    {
        public static void Error(string message)
        {
            MessageBox.Show(message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // [10.a] Megerősítés kérése. A Mégse és az [X] is "nem"-et jelent.
        public static bool Confirm()
        {
            DialogResult r = MessageBox.Show("Biztosan mented a módosított adatokat?", "[10.a] Megerősítés kérése",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return r == DialogResult.OK;
        }

        // [10.b] Visszaigazolás
        public static void Saved()
        {
            MessageBox.Show("Az adatok mentése megtörtént.", "[10.b] Visszaigazolás",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // Az ablakok közötti váltás. Mindig csak egy ablak látszik (a [10.] párbeszédablakok kivételével).
    public static class Nav
    {
        private static Form aktualis;

        // Megnyitja az új ablakot, a régit pedig eltünteti
        public static void Show(Form uj)
        {
            uj.Show();
            if (aktualis != null)
            {
                aktualis.Hide();
                aktualis.Dispose();
            }
            aktualis = uj;
        }
    }

    // Az ablakok közös őse: egységes kinézet, és az [X] gomb a GoBack() metódust hívja
    public class BaseForm : Form
    {
        public BaseForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Font = new Font("Segoe UI", 9F);
            FormClosing += BaseForm_FormClosing;
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                GoBack();
            }
        }

        // Ezt írják felül az ablakok: mit csináljon az [X] / Mégse
        protected virtual void GoBack()
        {
        }
    }
}
