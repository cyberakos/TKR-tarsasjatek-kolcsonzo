namespace TKR
{
    partial class GamesForm
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
            txtCim = new TextBox();
            label2 = new Label();
            cmbKat = new ComboBox();
            label3 = new Label();
            txtPl = new TextBox();
            btnRefresh = new Button();
            label4 = new Label();
            chkKeszleten = new CheckBox();
            chkHasznalatban = new CheckBox();
            chkElvitt = new CheckBox();
            chkHianyos = new CheckBox();
            chkKivonva = new CheckBox();
            lv = new ListView();
            colLeltari = new ColumnHeader();
            colCim = new ColumnHeader();
            colJatekosok = new ColumnHeader();
            colPerc = new ColumnHeader();
            colMinKor = new ColumnHeader();
            colAllapot = new ColumnHeader();
            btnIssue = new Button();
            btnInfo = new Button();
            btnNew = new Button();
            btnMain = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 19);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 0;
            label1.Text = "Cím";
            // 
            // txtCim
            // 
            txtCim.Location = new Point(60, 15);
            txtCim.MaxLength = 80;
            txtCim.Name = "txtCim";
            txtCim.Size = new Size(170, 23);
            txtCim.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(250, 19);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Kategória";
            // 
            // cmbKat
            // 
            cmbKat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKat.Location = new Point(320, 15);
            cmbKat.Name = "cmbKat";
            cmbKat.Size = new Size(150, 23);
            cmbKat.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(490, 19);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 4;
            label3.Text = "Játékosszám";
            // 
            // txtPl
            // 
            txtPl.Location = new Point(575, 15);
            txtPl.MaxLength = 2;
            txtPl.Name = "txtPl";
            txtPl.Size = new Size(50, 23);
            txtPl.TabIndex = 5;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(660, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(140, 28);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Lista frissítése";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 59);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 7;
            label4.Text = "Állapot:";
            // 
            // chkKeszleten
            // 
            chkKeszleten.AutoSize = true;
            chkKeszleten.Checked = true;
            chkKeszleten.CheckState = CheckState.Checked;
            chkKeszleten.Location = new Point(75, 57);
            chkKeszleten.Name = "chkKeszleten";
            chkKeszleten.Size = new Size(75, 19);
            chkKeszleten.TabIndex = 8;
            chkKeszleten.Text = "Készleten";
            chkKeszleten.UseVisualStyleBackColor = true;
            // 
            // chkHasznalatban
            // 
            chkHasznalatban.AutoSize = true;
            chkHasznalatban.Checked = true;
            chkHasznalatban.CheckState = CheckState.Checked;
            chkHasznalatban.Location = new Point(190, 57);
            chkHasznalatban.Name = "chkHasznalatban";
            chkHasznalatban.Size = new Size(97, 19);
            chkHasznalatban.TabIndex = 9;
            chkHasznalatban.Text = "Használatban";
            chkHasznalatban.UseVisualStyleBackColor = true;
            // 
            // chkElvitt
            // 
            chkElvitt.AutoSize = true;
            chkElvitt.Checked = true;
            chkElvitt.CheckState = CheckState.Checked;
            chkElvitt.Location = new Point(305, 57);
            chkElvitt.Name = "chkElvitt";
            chkElvitt.Size = new Size(52, 19);
            chkElvitt.TabIndex = 10;
            chkElvitt.Text = "Elvitt";
            chkElvitt.UseVisualStyleBackColor = true;
            // 
            // chkHianyos
            // 
            chkHianyos.AutoSize = true;
            chkHianyos.Checked = true;
            chkHianyos.CheckState = CheckState.Checked;
            chkHianyos.Location = new Point(420, 57);
            chkHianyos.Name = "chkHianyos";
            chkHianyos.Size = new Size(69, 19);
            chkHianyos.TabIndex = 11;
            chkHianyos.Text = "Hiányos";
            chkHianyos.UseVisualStyleBackColor = true;
            // 
            // chkKivonva
            // 
            chkKivonva.AutoSize = true;
            chkKivonva.Location = new Point(535, 57);
            chkKivonva.Name = "chkKivonva";
            chkKivonva.Size = new Size(68, 19);
            chkKivonva.TabIndex = 12;
            chkKivonva.Text = "Kivonva";
            chkKivonva.UseVisualStyleBackColor = true;
            // 
            // lv
            // 
            lv.Columns.AddRange(new ColumnHeader[] { colLeltari, colCim, colJatekosok, colPerc, colMinKor, colAllapot });
            lv.FullRowSelect = true;
            lv.GridLines = true;
            lv.Location = new Point(15, 95);
            lv.MultiSelect = false;
            lv.Name = "lv";
            lv.Size = new Size(790, 360);
            lv.TabIndex = 13;
            lv.UseCompatibleStateImageBehavior = false;
            lv.View = View.Details;
            lv.SelectedIndexChanged += lv_SelectedIndexChanged;
            lv.DoubleClick += lv_DoubleClick;
            // 
            // colLeltari
            // 
            colLeltari.Text = "Leltári sz.";
            colLeltari.Width = 90;
            // 
            // colCim
            // 
            colCim.Text = "Cím";
            colCim.Width = 280;
            // 
            // colJatekosok
            // 
            colJatekosok.Text = "Játékosszám";
            colJatekosok.Width = 100;
            // 
            // colPerc
            // 
            colPerc.Text = "Idő (perc)";
            colPerc.Width = 90;
            // 
            // colMinKor
            // 
            colMinKor.Text = "Min. kor";
            colMinKor.Width = 80;
            // 
            // colAllapot
            // 
            colAllapot.Text = "Állapot";
            colAllapot.Width = 120;
            // 
            // btnIssue
            // 
            btnIssue.Location = new Point(15, 475);
            btnIssue.Name = "btnIssue";
            btnIssue.Size = new Size(150, 28);
            btnIssue.TabIndex = 14;
            btnIssue.Text = "Kölcsönzés kiadása";
            btnIssue.UseVisualStyleBackColor = true;
            btnIssue.Click += btnIssue_Click;
            // 
            // btnInfo
            // 
            btnInfo.Location = new Point(175, 475);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(120, 28);
            btnInfo.TabIndex = 15;
            btnInfo.Text = "Játék adatai";
            btnInfo.UseVisualStyleBackColor = true;
            btnInfo.Click += btnInfo_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(305, 475);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(160, 28);
            btnNew.TabIndex = 16;
            btnNew.Text = "Új játék (üzletvezető)";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnMain
            // 
            btnMain.Location = new Point(705, 475);
            btnMain.Name = "btnMain";
            btnMain.Size = new Size(100, 28);
            btnMain.TabIndex = 17;
            btnMain.Text = "Főmenü";
            btnMain.UseVisualStyleBackColor = true;
            btnMain.Click += btnMain_Click;
            // 
            // GamesForm
            // 
            AcceptButton = btnRefresh;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 520);
            Controls.Add(label1);
            Controls.Add(txtCim);
            Controls.Add(label2);
            Controls.Add(cmbKat);
            Controls.Add(label3);
            Controls.Add(txtPl);
            Controls.Add(btnRefresh);
            Controls.Add(label4);
            Controls.Add(chkKeszleten);
            Controls.Add(chkHasznalatban);
            Controls.Add(chkElvitt);
            Controls.Add(chkHianyos);
            Controls.Add(chkKivonva);
            Controls.Add(lv);
            Controls.Add(btnIssue);
            Controls.Add(btnInfo);
            Controls.Add(btnNew);
            Controls.Add(btnMain);
            Name = "GamesForm";
            Text = "[3.] Játékok keresése";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCim;
        private Label label2;
        private ComboBox cmbKat;
        private Label label3;
        private TextBox txtPl;
        private Button btnRefresh;
        private Label label4;
        private CheckBox chkKeszleten;
        private CheckBox chkHasznalatban;
        private CheckBox chkElvitt;
        private CheckBox chkHianyos;
        private CheckBox chkKivonva;
        private ListView lv;
        private ColumnHeader colLeltari;
        private ColumnHeader colCim;
        private ColumnHeader colJatekosok;
        private ColumnHeader colPerc;
        private ColumnHeader colMinKor;
        private ColumnHeader colAllapot;
        private Button btnIssue;
        private Button btnInfo;
        private Button btnNew;
        private Button btnMain;
    }
}
