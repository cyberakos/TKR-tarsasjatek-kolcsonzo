namespace TKR
{
    partial class MembersForm
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
            txtVn = new TextBox();
            label2 = new Label();
            txtKn = new TextBox();
            label3 = new Label();
            txtId = new TextBox();
            chkActive = new CheckBox();
            btnRefresh = new Button();
            lv = new ListView();
            colId = new ColumnHeader();
            colVn = new ColumnHeader();
            colKn = new ColumnHeader();
            colSzuletes = new ColumnHeader();
            colAktiv = new ColumnHeader();
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
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Vezetéknév";
            // 
            // txtVn
            // 
            txtVn.Location = new Point(90, 15);
            txtVn.MaxLength = 50;
            txtVn.Name = "txtVn";
            txtVn.Size = new Size(120, 23);
            txtVn.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(230, 19);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 2;
            label2.Text = "Keresztnév";
            // 
            // txtKn
            // 
            txtKn.Location = new Point(305, 15);
            txtKn.MaxLength = 50;
            txtKn.Name = "txtKn";
            txtKn.Size = new Size(120, 23);
            txtKn.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(445, 19);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 4;
            label3.Text = "Tag-azonosító";
            // 
            // txtId
            // 
            txtId.Location = new Point(535, 15);
            txtId.MaxLength = 50;
            txtId.Name = "txtId";
            txtId.Size = new Size(90, 23);
            txtId.TabIndex = 5;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Location = new Point(15, 57);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(112, 19);
            chkActive.TabIndex = 6;
            chkActive.Text = "Csak aktív tagok";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(640, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(125, 28);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Lista frissítése";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lv
            // 
            lv.Columns.AddRange(new ColumnHeader[] { colId, colVn, colKn, colSzuletes, colAktiv });
            lv.FullRowSelect = true;
            lv.GridLines = true;
            lv.Location = new Point(15, 95);
            lv.MultiSelect = false;
            lv.Name = "lv";
            lv.Size = new Size(750, 320);
            lv.TabIndex = 8;
            lv.UseCompatibleStateImageBehavior = false;
            lv.View = View.Details;
            lv.SelectedIndexChanged += lv_SelectedIndexChanged;
            lv.DoubleClick += lv_DoubleClick;
            // 
            // colId
            // 
            colId.Text = "Tag-azonosító";
            colId.Width = 110;
            // 
            // colVn
            // 
            colVn.Text = "Vezetéknév";
            colVn.Width = 190;
            // 
            // colKn
            // 
            colKn.Text = "Keresztnév";
            colKn.Width = 190;
            // 
            // colSzuletes
            // 
            colSzuletes.Text = "Születési dátum";
            colSzuletes.Width = 130;
            // 
            // colAktiv
            // 
            colAktiv.Text = "Aktív";
            colAktiv.Width = 80;
            // 
            // btnInfo
            // 
            btnInfo.Location = new Point(15, 430);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(110, 28);
            btnInfo.TabIndex = 9;
            btnInfo.Text = "Tag adatai";
            btnInfo.UseVisualStyleBackColor = true;
            btnInfo.Click += btnInfo_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(135, 430);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(100, 28);
            btnNew.TabIndex = 10;
            btnNew.Text = "Új tag";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnMain
            // 
            btnMain.Location = new Point(665, 430);
            btnMain.Name = "btnMain";
            btnMain.Size = new Size(100, 28);
            btnMain.TabIndex = 11;
            btnMain.Text = "Főmenü";
            btnMain.UseVisualStyleBackColor = true;
            btnMain.Click += btnMain_Click;
            // 
            // MembersForm
            // 
            AcceptButton = btnRefresh;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 470);
            Controls.Add(label1);
            Controls.Add(txtVn);
            Controls.Add(label2);
            Controls.Add(txtKn);
            Controls.Add(label3);
            Controls.Add(txtId);
            Controls.Add(chkActive);
            Controls.Add(btnRefresh);
            Controls.Add(lv);
            Controls.Add(btnInfo);
            Controls.Add(btnNew);
            Controls.Add(btnMain);
            Name = "MembersForm";
            Text = "[8.] Tagok nyilvántartása";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtVn;
        private Label label2;
        private TextBox txtKn;
        private Label label3;
        private TextBox txtId;
        private CheckBox chkActive;
        private Button btnRefresh;
        private ListView lv;
        private ColumnHeader colId;
        private ColumnHeader colVn;
        private ColumnHeader colKn;
        private ColumnHeader colSzuletes;
        private ColumnHeader colAktiv;
        private Button btnInfo;
        private Button btnNew;
        private Button btnMain;
    }
}
