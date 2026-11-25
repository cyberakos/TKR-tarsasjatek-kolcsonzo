namespace TKR
{
    partial class MemberForm
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
            lblId = new Label();
            label2 = new Label();
            lblBelepes = new Label();
            label3 = new Label();
            txtVn = new TextBox();
            label4 = new Label();
            txtKn = new TextBox();
            label5 = new Label();
            dtpDob = new DateTimePicker();
            label6 = new Label();
            txtEmail = new TextBox();
            label7 = new Label();
            txtTel = new TextBox();
            label8 = new Label();
            lblNyitott = new Label();
            chkActive = new CheckBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 19);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 0;
            label1.Text = "Tag-azonosító";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(120, 19);
            lblId.Name = "lblId";
            lblId.Size = new Size(0, 15);
            lblId.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(340, 19);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 2;
            label2.Text = "Belépés dátuma";
            // 
            // lblBelepes
            // 
            lblBelepes.AutoSize = true;
            lblBelepes.Location = new Point(450, 19);
            lblBelepes.Name = "lblBelepes";
            lblBelepes.Size = new Size(0, 15);
            lblBelepes.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 59);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 4;
            label3.Text = "Vezetéknév";
            // 
            // txtVn
            // 
            txtVn.Location = new Point(120, 55);
            txtVn.MaxLength = 50;
            txtVn.Name = "txtVn";
            txtVn.Size = new Size(180, 23);
            txtVn.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(340, 59);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 6;
            label4.Text = "Keresztnév";
            // 
            // txtKn
            // 
            txtKn.Location = new Point(450, 55);
            txtKn.MaxLength = 50;
            txtKn.Name = "txtKn";
            txtKn.Size = new Size(150, 23);
            txtKn.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 99);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 8;
            label5.Text = "Születési dátum";
            // 
            // dtpDob
            // 
            dtpDob.CustomFormat = "yyyy.MM.dd.";
            dtpDob.Format = DateTimePickerFormat.Custom;
            dtpDob.Location = new Point(120, 95);
            dtpDob.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(110, 23);
            dtpDob.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(340, 99);
            label6.Name = "label6";
            label6.Size = new Size(41, 15);
            label6.TabIndex = 10;
            label6.Text = "E-mail";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(450, 95);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(150, 23);
            txtEmail.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 139);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 12;
            label7.Text = "Telefon";
            // 
            // txtTel
            // 
            txtTel.Location = new Point(120, 135);
            txtTel.MaxLength = 20;
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(150, 23);
            txtTel.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(340, 139);
            label8.Name = "label8";
            label8.Size = new Size(90, 15);
            label8.TabIndex = 14;
            label8.Text = "Nyitott elvitelek";
            // 
            // lblNyitott
            // 
            lblNyitott.AutoSize = true;
            lblNyitott.Location = new Point(450, 139);
            lblNyitott.Name = "lblNyitott";
            lblNyitott.Size = new Size(0, 15);
            lblNyitott.TabIndex = 15;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Location = new Point(15, 182);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(143, 19);
            chkActive.TabIndex = 16;
            chkActive.Text = "Aktív tag (üzletvezető)";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(410, 230);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(85, 28);
            btnOk.TabIndex = 17;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(505, 230);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 28);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "Mégse";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // MemberForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 280);
            Controls.Add(label1);
            Controls.Add(lblId);
            Controls.Add(label2);
            Controls.Add(lblBelepes);
            Controls.Add(label3);
            Controls.Add(txtVn);
            Controls.Add(label4);
            Controls.Add(txtKn);
            Controls.Add(label5);
            Controls.Add(dtpDob);
            Controls.Add(label6);
            Controls.Add(txtEmail);
            Controls.Add(label7);
            Controls.Add(txtTel);
            Controls.Add(label8);
            Controls.Add(lblNyitott);
            Controls.Add(chkActive);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Name = "MemberForm";
            Text = "[9.] Tag adatlapja";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblId;
        private Label label2;
        private Label lblBelepes;
        private Label label3;
        private TextBox txtVn;
        private Label label4;
        private TextBox txtKn;
        private Label label5;
        private DateTimePicker dtpDob;
        private Label label6;
        private TextBox txtEmail;
        private Label label7;
        private TextBox txtTel;
        private Label label8;
        private Label lblNyitott;
        private CheckBox chkActive;
        private Button btnOk;
        private Button btnCancel;
    }
}
