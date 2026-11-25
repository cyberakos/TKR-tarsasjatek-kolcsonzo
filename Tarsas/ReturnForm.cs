using System;
using System.Windows.Forms;

namespace TKR
{
    // [6.] Visszavétel
    public partial class ReturnForm : BaseForm
    {
        private int rentalId;
        private RentalRow r;
        private bool ready = false;

        public ReturnForm(int id)
        {
            InitializeComponent();

            rentalId = id;
            r = RentalService.Get(id);
            if (r == null || !r.IsOpen)
            {
                // az ablak megjelenése után szólunk és visszalépünk a naplóba
                Shown += delegate
                {
                    UI.Error("A kölcsönzés nem található vagy már le van zárva!");
                    Nav.Show(new LogForm());
                };
                return;
            }

            lblJatek.Text = r.Leltari + " – " + r.Cim;
            lblTipus.Text = r.Tipus;
            lblTag.Text = r.TagAsztal;
            lblKivetel.Text = Fmt.ShowTime(r.Kivetel);
            lblHatarido.Text = r.Hatarido.HasValue ? Fmt.Show(r.Hatarido.Value) : "–";
            lblKiado.Text = r.KiadoDolgozo;
            if (!string.IsNullOrEmpty(r.Megjegyzes))
            {
                lblMegj.Text = "Kiadáskori megjegyzés: " + r.Megjegyzes;
            }

            dtpVissza.Value = Clock.Now;
            dtpVissza.Enabled = Session.IsManager;

            ready = true;
            Recalc();
        }

        private RentalService.ReturnInput GetInput()
        {
            RentalService.ReturnInput x = new RentalService.ReturnInput();
            x.Id = rentalId;
            x.Visszavetel = Session.IsManager ? Fmt.ShowTime(dtpVissza.Value) : "";
            x.Hianyos = chkMissing.Checked;
            x.KaucioVisszatartva = chkKauc.Checked;
            x.Megjegyzes = txtNote.Text;
            return x;
        }

        private void Recalc()
        {
            if (!ready) return;

            // a kaució csak üzletvezetőnek, elvitelnél és hiányos doboznál tartható vissza
            chkKauc.Enabled = Session.IsManager && r.IsTakeAway && chkMissing.Checked;
            if (!chkKauc.Enabled) chkKauc.Checked = false;

            ReturnCalc c = RentalService.CalculateReturn(r, GetInput());
            lblNapok.Text = c.KesedelmesNapok.ToString();
            lblDij.Text = c.KesedelmiDij.ToString();
            lblKauc.Text = c.VisszajaroKaucio.ToString();
        }

        // Bármelyik mező változik, újraszámolunk
        private void Input_Changed(object sender, EventArgs e)
        {
            Recalc();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            RentalService.ReturnInput x = GetInput();
            string err = RentalService.ValidateReturn(x);
            if (err != null) { UI.Error(err); return; }

            if (!UI.Confirm()) return;

            err = RentalService.Return(x);
            if (err != null) { UI.Error(err); return; }

            UI.Saved();
            Nav.Show(new LogForm(rentalId));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        protected override void GoBack()
        {
            Nav.Show(new LogForm());
        }
    }
}
