namespace TKR
{
    partial class ReturnForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            lblJatek = new Label();
            label2 = new Label();
            lblTipus = new Label();
            label3 = new Label();
            lblTag = new Label();
            label4 = new Label();
            lblKivetel = new Label();
            label5 = new Label();
            lblHatarido = new Label();
            label6 = new Label();
            lblKiado = new Label();
            lblMegj = new Label();
            label7 = new Label();
            dtpVissza = new DateTimePicker();
            chkMissing = new CheckBox();
            chkKauc = new CheckBox();
            label8 = new Label();
            lblNapok = new Label();
            label9 = new Label();
            lblDij = new Label();
            label10 = new Label();
            lblKauc = new Label();
            label11 = new Label();
            txtNote = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 19);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 0;
            label1.Text = "Játék";
            // 
            // lblJatek
            // 
            lblJatek.AutoSize = true;
            lblJatek.Location = new Point(100, 19);
            lblJatek.Name = "lblJatek";
            lblJatek.Size = new Size(0, 15);
            lblJatek.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(380, 19);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 2;
            label2.Text = "Típus";
            // 
            // lblTipus
            // 
            lblTipus.AutoSize = true;
            lblTipus.Location = new Point(470, 19);
            lblTipus.Name = "lblTipus";
            lblTipus.Size = new Size(0, 15);
            lblTipus.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 49);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 4;
            label3.Text = "Tag / asztal";
            // 
            // lblTag
            // 
            lblTag.AutoSize = true;
            lblTag.Location = new Point(100, 49);
            lblTag.Name = "lblTag";
            lblTag.Size = new Size(0, 15);
            lblTag.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(380, 49);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 6;
            label4.Text = "Kivétel ideje";
            // 
            // lblKivetel
            // 
            lblKivetel.AutoSize = true;
            lblKivetel.Location = new Point(470, 49);
            lblKivetel.Name = "lblKivetel";
            lblKivetel.Size = new Size(0, 15);
            lblKivetel.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 79);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 8;
            label5.Text = "Határidő";
            // 
            // lblHatarido
            // 
            lblHatarido.AutoSize = true;
            lblHatarido.Location = new Point(100, 79);
            lblHatarido.Name = "lblHatarido";
            lblHatarido.Size = new Size(0, 15);
            lblHatarido.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(380, 79);
            label6.Name = "label6";
            label6.Size = new Size(83, 15);
            label6.TabIndex = 10;
            label6.Text = "Kiadó dolgozó";
            // 
            // lblKiado
            // 
            lblKiado.AutoSize = true;
            lblKiado.Location = new Point(470, 79);
            lblKiado.Name = "lblKiado";
            lblKiado.Size = new Size(0, 15);
            lblKiado.TabIndex = 11;
            // 
            // lblMegj
            // 
            lblMegj.AutoSize = true;
            lblMegj.Location = new Point(15, 109);
            lblMegj.Name = "lblMegj";
            lblMegj.Size = new Size(0, 15);
            lblMegj.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 144);
            label7.Name = "label7";
            label7.Size = new Size(91, 15);
            label7.TabIndex = 13;
            label7.Text = "Visszavétel ideje";
            // 
            // dtpVissza
            // 
            dtpVissza.CustomFormat = "yyyy.MM.dd. HH:mm";
            dtpVissza.Format = DateTimePickerFormat.Custom;
            dtpVissza.Location = new Point(120, 140);
            dtpVissza.Name = "dtpVissza";
            dtpVissza.Size = new Size(135, 23);
            dtpVissza.TabIndex = 14;
            dtpVissza.ValueChanged += Input_Changed;
            // 
            // chkMissing
            // 
            chkMissing.AutoSize = true;
            chkMissing.Location = new Point(280, 142);
            chkMissing.Name = "chkMissing";
            chkMissing.Size = new Size(109, 19);
            chkMissing.TabIndex = 15;
            chkMissing.Text = "Hiányos / sérült";
            chkMissing.UseVisualStyleBackColor = true;
            chkMissing.CheckedChanged += Input_Changed;
            // 
            // chkKauc
            // 
            chkKauc.AutoSize = true;
            chkKauc.Location = new Point(400, 142);
            chkKauc.Name = "chkKauc";
            chkKauc.Size = new Size(195, 19);
            chkKauc.TabIndex = 16;
            chkKauc.Text = "Kaució visszatartva (üzletvezető)";
            chkKauc.UseVisualStyleBackColor = true;
            chkKauc.CheckedChanged += Input_Changed;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 184);
            label8.Name = "label8";
            label8.Size = new Size(77, 15);
            label8.TabIndex = 17;
            label8.Text = "Késed. napok";
            // 
            // lblNapok
            // 
            lblNapok.AutoSize = true;
            lblNapok.Location = new Point(120, 184);
            lblNapok.Name = "lblNapok";
            lblNapok.Size = new Size(13, 15);
            lblNapok.TabIndex = 18;
            lblNapok.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(200, 184);
            label9.Name = "label9";
            label9.Size = new Size(98, 15);
            label9.TabIndex = 19;
            label9.Text = "Késedelmi díj (Ft)";
            // 
            // lblDij
            // 
            lblDij.AutoSize = true;
            lblDij.Location = new Point(320, 184);
            lblDij.Name = "lblDij";
            lblDij.Size = new Size(13, 15);
            lblDij.TabIndex = 20;
            lblDij.Text = "0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(400, 184);
            label10.Name = "label10";
            label10.Size = new Size(117, 15);
            label10.TabIndex = 21;
            label10.Text = "Visszajáró kaució (Ft)";
            label10.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblKauc
            // 
            lblKauc.AutoSize = true;
            lblKauc.Location = new Point(540, 184);
            lblKauc.Name = "lblKauc";
            lblKauc.Size = new Size(13, 15);
            lblKauc.TabIndex = 22;
            lblKauc.Text = "0";
            lblKauc.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(15, 229);
            label11.Name = "label11";
            label11.Size = new Size(69, 15);
            label11.TabIndex = 23;
            label11.Text = "Megjegyzés";
            // 
            // txtNote
            // 
            txtNote.Location = new Point(100, 225);
            txtNote.MaxLength = 500;
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(520, 70);
            txtNote.TabIndex = 24;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(440, 330);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(85, 28);
            btnOk.TabIndex = 25;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(535, 330);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 28);
            btnCancel.TabIndex = 26;
            btnCancel.Text = "Mégse";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // ReturnForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 380);
            Controls.Add(label1);
            Controls.Add(lblJatek);
            Controls.Add(label2);
            Controls.Add(lblTipus);
            Controls.Add(label3);
            Controls.Add(lblTag);
            Controls.Add(label4);
            Controls.Add(lblKivetel);
            Controls.Add(label5);
            Controls.Add(lblHatarido);
            Controls.Add(label6);
            Controls.Add(lblKiado);
            Controls.Add(lblMegj);
            Controls.Add(label7);
            Controls.Add(dtpVissza);
            Controls.Add(chkMissing);
            Controls.Add(chkKauc);
            Controls.Add(label8);
            Controls.Add(lblNapok);
            Controls.Add(label9);
            Controls.Add(lblDij);
            Controls.Add(label10);
            Controls.Add(lblKauc);
            Controls.Add(label11);
            Controls.Add(txtNote);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Name = "ReturnForm";
            Text = "[6.] Visszavétel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblJatek;
        private Label label2;
        private Label lblTipus;
        private Label label3;
        private Label lblTag;
        private Label label4;
        private Label lblKivetel;
        private Label label5;
        private Label lblHatarido;
        private Label label6;
        private Label lblKiado;
        private Label lblMegj;
        private Label label7;
        private DateTimePicker dtpVissza;
        private CheckBox chkMissing;
        private CheckBox chkKauc;
        private Label label8;
        private Label lblNapok;
        private Label label9;
        private Label lblDij;
        private Label label10;
        private Label lblKauc;
        private Label label11;
        private TextBox txtNote;
        private Button btnOk;
        private Button btnCancel;
    }
}
