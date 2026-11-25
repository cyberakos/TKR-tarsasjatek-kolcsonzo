namespace TKR
{
    partial class GameForm
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
            radCopy = new RadioButton();
            radTitle = new RadioButton();
            label1 = new Label();
            txtCim = new TextBox();
            cmbTitle = new ComboBox();
            label2 = new Label();
            lblLeltari = new Label();
            label3 = new Label();
            txtKiado = new TextBox();
            label4 = new Label();
            cmbKat = new ComboBox();
            label5 = new Label();
            txtMin = new TextBox();
            label6 = new Label();
            txtMax = new TextBox();
            label7 = new Label();
            txtPerc = new TextBox();
            label8 = new Label();
            txtMinKor = new TextBox();
            label9 = new Label();
            txtNeh = new TextBox();
            label10 = new Label();
            txtNap = new TextBox();
            label11 = new Label();
            txtKauc = new TextBox();
            label12 = new Label();
            lblAllapot = new Label();
            lblBesz = new Label();
            dtpBesz = new DateTimePicker();
            label13 = new Label();
            txtNote = new TextBox();
            lblOpen = new Label();
            chkMissing = new CheckBox();
            chkReEnable = new CheckBox();
            chkWithdraw = new CheckBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // radCopy
            // 
            radCopy.AutoSize = true;
            radCopy.Checked = true;
            radCopy.Location = new Point(15, 17);
            radCopy.Name = "radCopy";
            radCopy.Size = new Size(163, 19);
            radCopy.TabIndex = 0;
            radCopy.TabStop = true;
            radCopy.Text = "Meglévő játék új példánya";
            radCopy.UseVisualStyleBackColor = true;
            radCopy.CheckedChanged += radCopy_CheckedChanged;
            // 
            // radTitle
            // 
            radTitle.AutoSize = true;
            radTitle.Location = new Point(230, 17);
            radTitle.Name = "radTitle";
            radTitle.Size = new Size(84, 19);
            radTitle.TabIndex = 1;
            radTitle.Text = "Új játékcím";
            radTitle.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 54);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 2;
            label1.Text = "Cím";
            // 
            // txtCim
            // 
            txtCim.Location = new Point(100, 50);
            txtCim.MaxLength = 80;
            txtCim.Name = "txtCim";
            txtCim.Size = new Size(250, 23);
            txtCim.TabIndex = 3;
            // 
            // cmbTitle
            // 
            cmbTitle.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTitle.Location = new Point(100, 50);
            cmbTitle.Name = "cmbTitle";
            cmbTitle.Size = new Size(250, 23);
            cmbTitle.TabIndex = 4;
            cmbTitle.SelectedIndexChanged += cmbTitle_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(400, 54);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 5;
            label2.Text = "Leltári szám";
            // 
            // lblLeltari
            // 
            lblLeltari.AutoSize = true;
            lblLeltari.Location = new Point(500, 54);
            lblLeltari.Name = "lblLeltari";
            lblLeltari.Size = new Size(0, 15);
            lblLeltari.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 89);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 7;
            label3.Text = "Kiadó";
            // 
            // txtKiado
            // 
            txtKiado.Location = new Point(100, 85);
            txtKiado.MaxLength = 50;
            txtKiado.Name = "txtKiado";
            txtKiado.Size = new Size(250, 23);
            txtKiado.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(400, 89);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 9;
            label4.Text = "Kategória";
            // 
            // cmbKat
            // 
            cmbKat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKat.Location = new Point(500, 85);
            cmbKat.Name = "cmbKat";
            cmbKat.Size = new Size(180, 23);
            cmbKat.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 124);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 11;
            label5.Text = "Játékosszám";
            // 
            // txtMin
            // 
            txtMin.Location = new Point(100, 120);
            txtMin.Name = "txtMin";
            txtMin.Size = new Size(40, 23);
            txtMin.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(145, 124);
            label6.Name = "label6";
            label6.Size = new Size(13, 15);
            label6.TabIndex = 13;
            label6.Text = "–";
            // 
            // txtMax
            // 
            txtMax.Location = new Point(160, 120);
            txtMax.Name = "txtMax";
            txtMax.Size = new Size(40, 23);
            txtMax.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(230, 124);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 15;
            label7.Text = "Idő (perc)";
            // 
            // txtPerc
            // 
            txtPerc.Location = new Point(300, 120);
            txtPerc.Name = "txtPerc";
            txtPerc.Size = new Size(50, 23);
            txtPerc.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(400, 124);
            label8.Name = "label8";
            label8.Size = new Size(51, 15);
            label8.TabIndex = 17;
            label8.Text = "Min. kor";
            // 
            // txtMinKor
            // 
            txtMinKor.Location = new Point(500, 120);
            txtMinKor.Name = "txtMinKor";
            txtMinKor.Size = new Size(40, 23);
            txtMinKor.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(560, 124);
            label9.Name = "label9";
            label9.Size = new Size(58, 15);
            label9.TabIndex = 19;
            label9.Text = "Nehézség";
            // 
            // txtNeh
            // 
            txtNeh.Location = new Point(630, 120);
            txtNeh.Name = "txtNeh";
            txtNeh.Size = new Size(40, 23);
            txtNeh.TabIndex = 20;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(15, 159);
            label10.Name = "label10";
            label10.Size = new Size(66, 15);
            label10.TabIndex = 21;
            label10.Text = "Napidíj (Ft)";
            // 
            // txtNap
            // 
            txtNap.Location = new Point(100, 155);
            txtNap.Name = "txtNap";
            txtNap.Size = new Size(80, 23);
            txtNap.TabIndex = 22;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(230, 159);
            label11.Name = "label11";
            label11.Size = new Size(64, 15);
            label11.TabIndex = 23;
            label11.Text = "Kaució (Ft)";
            // 
            // txtKauc
            // 
            txtKauc.Location = new Point(300, 155);
            txtKauc.Name = "txtKauc";
            txtKauc.Size = new Size(80, 23);
            txtKauc.TabIndex = 24;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(400, 159);
            label12.Name = "label12";
            label12.Size = new Size(45, 15);
            label12.TabIndex = 25;
            label12.Text = "Állapot";
            // 
            // lblAllapot
            // 
            lblAllapot.AutoSize = true;
            lblAllapot.Location = new Point(500, 159);
            lblAllapot.Name = "lblAllapot";
            lblAllapot.Size = new Size(0, 15);
            lblAllapot.TabIndex = 26;
            // 
            // lblBesz
            // 
            lblBesz.AutoSize = true;
            lblBesz.Location = new Point(15, 194);
            lblBesz.Name = "lblBesz";
            lblBesz.Size = new Size(100, 15);
            lblBesz.TabIndex = 27;
            lblBesz.Text = "Beszerzés dátuma";
            // 
            // dtpBesz
            // 
            dtpBesz.CustomFormat = "yyyy.MM.dd.";
            dtpBesz.Format = DateTimePickerFormat.Custom;
            dtpBesz.Location = new Point(130, 190);
            dtpBesz.Name = "dtpBesz";
            dtpBesz.Size = new Size(110, 23);
            dtpBesz.TabIndex = 28;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(15, 229);
            label13.Name = "label13";
            label13.Size = new Size(69, 15);
            label13.TabIndex = 29;
            label13.Text = "Megjegyzés";
            // 
            // txtNote
            // 
            txtNote.Location = new Point(100, 225);
            txtNote.MaxLength = 500;
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(580, 60);
            txtNote.TabIndex = 30;
            // 
            // lblOpen
            // 
            lblOpen.AutoSize = true;
            lblOpen.Location = new Point(15, 304);
            lblOpen.Name = "lblOpen";
            lblOpen.Size = new Size(0, 15);
            lblOpen.TabIndex = 31;
            // 
            // chkMissing
            // 
            chkMissing.AutoSize = true;
            chkMissing.Location = new Point(15, 337);
            chkMissing.Name = "chkMissing";
            chkMissing.Size = new Size(109, 19);
            chkMissing.TabIndex = 32;
            chkMissing.Text = "Hiányos / sérült";
            chkMissing.UseVisualStyleBackColor = true;
            chkMissing.CheckedChanged += chkMissing_CheckedChanged;
            // 
            // chkReEnable
            // 
            chkReEnable.AutoSize = true;
            chkReEnable.Location = new Point(170, 337);
            chkReEnable.Name = "chkReEnable";
            chkReEnable.Size = new Size(197, 19);
            chkReEnable.TabIndex = 33;
            chkReEnable.Text = "Újra kölcsönözhető (üzletvezető)";
            chkReEnable.UseVisualStyleBackColor = true;
            chkReEnable.CheckedChanged += chkReEnable_CheckedChanged;
            // 
            // chkWithdraw
            // 
            chkWithdraw.AutoSize = true;
            chkWithdraw.Location = new Point(430, 337);
            chkWithdraw.Name = "chkWithdraw";
            chkWithdraw.Size = new Size(137, 19);
            chkWithdraw.TabIndex = 34;
            chkWithdraw.Text = "Kivonás (üzletvezető)";
            chkWithdraw.UseVisualStyleBackColor = true;
            chkWithdraw.CheckedChanged += chkWithdraw_CheckedChanged;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(500, 390);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(85, 28);
            btnOk.TabIndex = 35;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(595, 390);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 28);
            btnCancel.TabIndex = 36;
            btnCancel.Text = "Mégse";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 440);
            Controls.Add(radCopy);
            Controls.Add(radTitle);
            Controls.Add(label1);
            Controls.Add(txtCim);
            Controls.Add(cmbTitle);
            Controls.Add(label2);
            Controls.Add(lblLeltari);
            Controls.Add(label3);
            Controls.Add(txtKiado);
            Controls.Add(label4);
            Controls.Add(cmbKat);
            Controls.Add(label5);
            Controls.Add(txtMin);
            Controls.Add(label6);
            Controls.Add(txtMax);
            Controls.Add(label7);
            Controls.Add(txtPerc);
            Controls.Add(label8);
            Controls.Add(txtMinKor);
            Controls.Add(label9);
            Controls.Add(txtNeh);
            Controls.Add(label10);
            Controls.Add(txtNap);
            Controls.Add(label11);
            Controls.Add(txtKauc);
            Controls.Add(label12);
            Controls.Add(lblAllapot);
            Controls.Add(lblBesz);
            Controls.Add(dtpBesz);
            Controls.Add(label13);
            Controls.Add(txtNote);
            Controls.Add(lblOpen);
            Controls.Add(chkMissing);
            Controls.Add(chkReEnable);
            Controls.Add(chkWithdraw);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Name = "GameForm";
            Text = "[4.] Játék adatai";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radCopy;
        private RadioButton radTitle;
        private Label label1;
        private TextBox txtCim;
        private ComboBox cmbTitle;
        private Label label2;
        private Label lblLeltari;
        private Label label3;
        private TextBox txtKiado;
        private Label label4;
        private ComboBox cmbKat;
        private Label label5;
        private TextBox txtMin;
        private Label label6;
        private TextBox txtMax;
        private Label label7;
        private TextBox txtPerc;
        private Label label8;
        private TextBox txtMinKor;
        private Label label9;
        private TextBox txtNeh;
        private Label label10;
        private TextBox txtNap;
        private Label label11;
        private TextBox txtKauc;
        private Label label12;
        private Label lblAllapot;
        private Label lblBesz;
        private DateTimePicker dtpBesz;
        private Label label13;
        private TextBox txtNote;
        private Label lblOpen;
        private CheckBox chkMissing;
        private CheckBox chkReEnable;
        private CheckBox chkWithdraw;
        private Button btnOk;
        private Button btnCancel;
    }
}
