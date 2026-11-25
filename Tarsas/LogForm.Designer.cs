namespace TKR
{
    partial class LogForm
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
            dtpFrom = new DateTimePicker();
            label2 = new Label();
            dtpTo = new DateTimePicker();
            label3 = new Label();
            chkOn = new CheckBox();
            chkAway = new CheckBox();
            label4 = new Label();
            chkOpen = new CheckBox();
            chkClosed = new CheckBox();
            label5 = new Label();
            cmbCopy = new ComboBox();
            label6 = new Label();
            cmbMember = new ComboBox();
            btnRefresh = new Button();
            lv = new ListView();
            colKivetel = new ColumnHeader();
            colJatek = new ColumnHeader();
            colTipus = new ColumnHeader();
            colTag = new ColumnHeader();
            colHatarido = new ColumnHeader();
            colVisszavetel = new ColumnHeader();
            colDij = new ColumnHeader();
            colKesedelmi = new ColumnHeader();
            colMegjegyzes = new ColumnHeader();
            btnReturn = new Button();
            btnNew = new Button();
            btnPrint = new Button();
            btnMain = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 19);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 0;
            label1.Text = "Időszak  -tól";
            // 
            // dtpFrom
            // 
            dtpFrom.CustomFormat = "yyyy.MM.dd. HH:mm";
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.Location = new Point(95, 15);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(135, 23);
            dtpFrom.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(235, 19);
            label2.Name = "label2";
            label2.Size = new Size(22, 15);
            label2.TabIndex = 2;
            label2.Text = "-ig";
            // 
            // dtpTo
            // 
            dtpTo.CustomFormat = "yyyy.MM.dd. HH:mm";
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.Location = new Point(260, 15);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(135, 23);
            dtpTo.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(410, 19);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 4;
            label3.Text = "Típus:";
            // 
            // chkOn
            // 
            chkOn.AutoSize = true;
            chkOn.Checked = true;
            chkOn.CheckState = CheckState.Checked;
            chkOn.Location = new Point(455, 17);
            chkOn.Name = "chkOn";
            chkOn.Size = new Size(70, 19);
            chkOn.TabIndex = 5;
            chkOn.Text = "Helyben";
            chkOn.UseVisualStyleBackColor = true;
            // 
            // chkAway
            // 
            chkAway.AutoSize = true;
            chkAway.Checked = true;
            chkAway.CheckState = CheckState.Checked;
            chkAway.Location = new Point(535, 17);
            chkAway.Name = "chkAway";
            chkAway.Size = new Size(57, 19);
            chkAway.TabIndex = 6;
            chkAway.Text = "Elvitel";
            chkAway.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(620, 19);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 7;
            label4.Text = "Állapot:";
            // 
            // chkOpen
            // 
            chkOpen.AutoSize = true;
            chkOpen.Checked = true;
            chkOpen.CheckState = CheckState.Checked;
            chkOpen.Location = new Point(675, 17);
            chkOpen.Name = "chkOpen";
            chkOpen.Size = new Size(63, 19);
            chkOpen.TabIndex = 8;
            chkOpen.Text = "Nyitott";
            chkOpen.UseVisualStyleBackColor = true;
            // 
            // chkClosed
            // 
            chkClosed.AutoSize = true;
            chkClosed.Checked = true;
            chkClosed.CheckState = CheckState.Checked;
            chkClosed.Location = new Point(755, 17);
            chkClosed.Name = "chkClosed";
            chkClosed.Size = new Size(57, 19);
            chkClosed.TabIndex = 9;
            chkClosed.Text = "Lezárt";
            chkClosed.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 59);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 10;
            label5.Text = "Játék";
            // 
            // cmbCopy
            // 
            cmbCopy.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCopy.Location = new Point(60, 55);
            cmbCopy.Name = "cmbCopy";
            cmbCopy.Size = new Size(270, 23);
            cmbCopy.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(350, 59);
            label6.Name = "label6";
            label6.Size = new Size(26, 15);
            label6.TabIndex = 12;
            label6.Text = "Tag";
            // 
            // cmbMember
            // 
            cmbMember.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMember.Location = new Point(385, 55);
            cmbMember.Name = "cmbMember";
            cmbMember.Size = new Size(270, 23);
            cmbMember.TabIndex = 13;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(680, 51);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(140, 28);
            btnRefresh.TabIndex = 14;
            btnRefresh.Text = "Lista frissítése";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lv
            // 
            lv.Columns.AddRange(new ColumnHeader[] { colKivetel, colJatek, colTipus, colTag, colHatarido, colVisszavetel, colDij, colKesedelmi, colMegjegyzes });
            lv.FullRowSelect = true;
            lv.GridLines = true;
            lv.Location = new Point(15, 95);
            lv.MultiSelect = false;
            lv.Name = "lv";
            lv.Size = new Size(970, 400);
            lv.TabIndex = 15;
            lv.UseCompatibleStateImageBehavior = false;
            lv.View = View.Details;
            lv.SelectedIndexChanged += lv_SelectedIndexChanged;
            // 
            // colKivetel
            // 
            colKivetel.Text = "Kivétel ideje";
            colKivetel.Width = 120;
            // 
            // colJatek
            // 
            colJatek.Text = "Játék";
            colJatek.Width = 190;
            // 
            // colTipus
            // 
            colTipus.Text = "Típus";
            // 
            // colTag
            // 
            colTag.Text = "Tag / asztal";
            colTag.Width = 150;
            // 
            // colHatarido
            // 
            colHatarido.Text = "Határidő";
            colHatarido.Width = 85;
            // 
            // colVisszavetel
            // 
            colVisszavetel.Text = "Visszavétel";
            colVisszavetel.Width = 120;
            // 
            // colDij
            // 
            colDij.Text = "Díj";
            // 
            // colKesedelmi
            // 
            colKesedelmi.Text = "Késedelmi díj";
            colKesedelmi.Width = 90;
            // 
            // colMegjegyzes
            // 
            colMegjegyzes.Text = "Megjegyzés";
            colMegjegyzes.Width = 95;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(15, 512);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(110, 28);
            btnReturn.TabIndex = 16;
            btnReturn.Text = "Visszavétel";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(135, 512);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(120, 28);
            btnNew.TabIndex = 17;
            btnNew.Text = "Új kölcsönzés";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(265, 512);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(160, 28);
            btnPrint.TabIndex = 18;
            btnPrint.Text = "Nyomtatás (üzletvez.)";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnMain
            // 
            btnMain.Location = new Point(885, 512);
            btnMain.Name = "btnMain";
            btnMain.Size = new Size(100, 28);
            btnMain.TabIndex = 19;
            btnMain.Text = "Főmenü";
            btnMain.UseVisualStyleBackColor = true;
            btnMain.Click += btnMain_Click;
            // 
            // LogForm
            // 
            AcceptButton = btnRefresh;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 555);
            Controls.Add(label1);
            Controls.Add(dtpFrom);
            Controls.Add(label2);
            Controls.Add(dtpTo);
            Controls.Add(label3);
            Controls.Add(chkOn);
            Controls.Add(chkAway);
            Controls.Add(label4);
            Controls.Add(chkOpen);
            Controls.Add(chkClosed);
            Controls.Add(label5);
            Controls.Add(cmbCopy);
            Controls.Add(label6);
            Controls.Add(cmbMember);
            Controls.Add(btnRefresh);
            Controls.Add(lv);
            Controls.Add(btnReturn);
            Controls.Add(btnNew);
            Controls.Add(btnPrint);
            Controls.Add(btnMain);
            Name = "LogForm";
            Text = "[7.] Kölcsönzési napló";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpFrom;
        private Label label2;
        private DateTimePicker dtpTo;
        private Label label3;
        private CheckBox chkOn;
        private CheckBox chkAway;
        private Label label4;
        private CheckBox chkOpen;
        private CheckBox chkClosed;
        private Label label5;
        private ComboBox cmbCopy;
        private Label label6;
        private ComboBox cmbMember;
        private Button btnRefresh;
        private ListView lv;
        private ColumnHeader colKivetel;
        private ColumnHeader colJatek;
        private ColumnHeader colTipus;
        private ColumnHeader colTag;
        private ColumnHeader colHatarido;
        private ColumnHeader colVisszavetel;
        private ColumnHeader colDij;
        private ColumnHeader colKesedelmi;
        private ColumnHeader colMegjegyzes;
        private Button btnReturn;
        private Button btnNew;
        private Button btnPrint;
        private Button btnMain;
    }
}
