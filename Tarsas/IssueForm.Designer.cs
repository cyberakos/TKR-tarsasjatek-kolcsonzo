namespace TKR
{
    partial class IssueForm
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
            lblDolgozo = new Label();
            label3 = new Label();
            radLocal = new RadioButton();
            radAway = new RadioButton();
            label4 = new Label();
            txtAsztal = new TextBox();
            label5 = new Label();
            cmbTag = new ComboBox();
            label6 = new Label();
            dtpKivetel = new DateTimePicker();
            label7 = new Label();
            dtpHat = new DateTimePicker();
            label8 = new Label();
            lblNapok = new Label();
            label9 = new Label();
            lblDij = new Label();
            label10 = new Label();
            lblKauc = new Label();
            lblWarn = new Label();
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
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Dolgozó";
            // 
            // lblDolgozo
            // 
            lblDolgozo.AutoSize = true;
            lblDolgozo.Location = new Point(450, 19);
            lblDolgozo.Name = "lblDolgozo";
            lblDolgozo.Size = new Size(0, 15);
            lblDolgozo.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 54);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 4;
            label3.Text = "Típus";
            // 
            // radLocal
            // 
            radLocal.AutoSize = true;
            radLocal.Checked = true;
            radLocal.Location = new Point(100, 52);
            radLocal.Name = "radLocal";
            radLocal.Size = new Size(69, 19);
            radLocal.TabIndex = 5;
            radLocal.TabStop = true;
            radLocal.Text = "Helyben";
            radLocal.UseVisualStyleBackColor = true;
            radLocal.CheckedChanged += Input_Changed;
            // 
            // radAway
            // 
            radAway.AutoSize = true;
            radAway.Location = new Point(190, 52);
            radAway.Name = "radAway";
            radAway.Size = new Size(56, 19);
            radAway.TabIndex = 6;
            radAway.Text = "Elvitel";
            radAway.UseVisualStyleBackColor = true;
            radAway.CheckedChanged += Input_Changed;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(380, 54);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 7;
            label4.Text = "Asztalszám";
            // 
            // txtAsztal
            // 
            txtAsztal.Location = new Point(470, 50);
            txtAsztal.MaxLength = 2;
            txtAsztal.Name = "txtAsztal";
            txtAsztal.Size = new Size(50, 23);
            txtAsztal.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 94);
            label5.Name = "label5";
            label5.Size = new Size(26, 15);
            label5.TabIndex = 9;
            label5.Text = "Tag";
            // 
            // cmbTag
            // 
            cmbTag.Location = new Point(100, 90);
            cmbTag.Name = "cmbTag";
            cmbTag.Size = new Size(280, 23);
            cmbTag.TabIndex = 10;
            cmbTag.SelectedIndexChanged += Input_Changed;
            cmbTag.TextChanged += Input_Changed;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(400, 94);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 11;
            label6.Text = "Kivétel ideje";
            // 
            // dtpKivetel
            // 
            dtpKivetel.CustomFormat = "yyyy.MM.dd. HH:mm";
            dtpKivetel.Format = DateTimePickerFormat.Custom;
            dtpKivetel.Location = new Point(490, 90);
            dtpKivetel.Name = "dtpKivetel";
            dtpKivetel.Size = new Size(135, 23);
            dtpKivetel.TabIndex = 12;
            dtpKivetel.ValueChanged += Input_Changed;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 134);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 13;
            label7.Text = "Határidő";
            // 
            // dtpHat
            // 
            dtpHat.CustomFormat = "yyyy.MM.dd.";
            dtpHat.Format = DateTimePickerFormat.Custom;
            dtpHat.Location = new Point(100, 130);
            dtpHat.Name = "dtpHat";
            dtpHat.Size = new Size(110, 23);
            dtpHat.TabIndex = 14;
            dtpHat.ValueChanged += Input_Changed;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(230, 134);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 15;
            label8.Text = "Napok";
            // 
            // lblNapok
            // 
            lblNapok.AutoSize = true;
            lblNapok.Location = new Point(280, 134);
            lblNapok.Name = "lblNapok";
            lblNapok.Size = new Size(13, 15);
            lblNapok.TabIndex = 16;
            lblNapok.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(330, 134);
            label9.Name = "label9";
            label9.Size = new Size(42, 15);
            label9.TabIndex = 17;
            label9.Text = "Díj (Ft)";
            // 
            // lblDij
            // 
            lblDij.AutoSize = true;
            lblDij.Location = new Point(390, 134);
            lblDij.Name = "lblDij";
            lblDij.Size = new Size(13, 15);
            lblDij.TabIndex = 18;
            lblDij.Text = "0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(460, 134);
            label10.Name = "label10";
            label10.Size = new Size(64, 15);
            label10.TabIndex = 19;
            label10.Text = "Kaució (Ft)";
            // 
            // lblKauc
            // 
            lblKauc.AutoSize = true;
            lblKauc.Location = new Point(540, 134);
            lblKauc.Name = "lblKauc";
            lblKauc.Size = new Size(13, 15);
            lblKauc.TabIndex = 20;
            lblKauc.Text = "0";
            // 
            // lblWarn
            // 
            lblWarn.ForeColor = Color.Red;
            lblWarn.Location = new Point(15, 174);
            lblWarn.Name = "lblWarn";
            lblWarn.Size = new Size(600, 35);
            lblWarn.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(15, 219);
            label11.Name = "label11";
            label11.Size = new Size(69, 15);
            label11.TabIndex = 22;
            label11.Text = "Megjegyzés";
            // 
            // txtNote
            // 
            txtNote.Location = new Point(100, 215);
            txtNote.MaxLength = 500;
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(520, 60);
            txtNote.TabIndex = 23;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(440, 300);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(85, 28);
            btnOk.TabIndex = 24;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(535, 300);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 28);
            btnCancel.TabIndex = 25;
            btnCancel.Text = "Mégse";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // IssueForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 345);
            Controls.Add(label1);
            Controls.Add(lblJatek);
            Controls.Add(label2);
            Controls.Add(lblDolgozo);
            Controls.Add(label3);
            Controls.Add(radLocal);
            Controls.Add(radAway);
            Controls.Add(label4);
            Controls.Add(txtAsztal);
            Controls.Add(label5);
            Controls.Add(cmbTag);
            Controls.Add(label6);
            Controls.Add(dtpKivetel);
            Controls.Add(label7);
            Controls.Add(dtpHat);
            Controls.Add(label8);
            Controls.Add(lblNapok);
            Controls.Add(label9);
            Controls.Add(lblDij);
            Controls.Add(label10);
            Controls.Add(lblKauc);
            Controls.Add(lblWarn);
            Controls.Add(label11);
            Controls.Add(txtNote);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Name = "IssueForm";
            Text = "[5.] Kölcsönzés kiadása";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblJatek;
        private Label label2;
        private Label lblDolgozo;
        private Label label3;
        private RadioButton radLocal;
        private RadioButton radAway;
        private Label label4;
        private TextBox txtAsztal;
        private Label label5;
        private ComboBox cmbTag;
        private Label label6;
        private DateTimePicker dtpKivetel;
        private Label label7;
        private DateTimePicker dtpHat;
        private Label label8;
        private Label lblNapok;
        private Label label9;
        private Label lblDij;
        private Label label10;
        private Label lblKauc;
        private Label lblWarn;
        private Label label11;
        private TextBox txtNote;
        private Button btnOk;
        private Button btnCancel;
    }
}
