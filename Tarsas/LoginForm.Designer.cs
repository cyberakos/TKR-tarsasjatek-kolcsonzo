namespace TKR
{
    partial class LoginForm
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
            lblTitle = new Label();
            label1 = new Label();
            txtId = new TextBox();
            label2 = new Label();
            txtPass = new TextBox();
            btnOk = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(205, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Társasjáték-kölcsönző kávézó – TKR";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 64);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 1;
            label1.Text = "Felhasználói azonosító";
            // 
            // txtId
            // 
            txtId.Location = new Point(170, 60);
            txtId.MaxLength = 30;
            txtId.Name = "txtId";
            txtId.Size = new Size(180, 23);
            txtId.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 99);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 3;
            label2.Text = "Jelszó";
            // 
            // txtPass
            // 
            txtPass.Location = new Point(170, 95);
            txtPass.MaxLength = 30;
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(180, 23);
            txtPass.TabIndex = 4;
            txtPass.UseSystemPasswordChar = true;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(170, 145);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(85, 28);
            btnOk.TabIndex = 5;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(265, 145);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(85, 28);
            btnExit.TabIndex = 6;
            btnExit.Text = "Kilépés";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // LoginForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 200);
            Controls.Add(lblTitle);
            Controls.Add(label1);
            Controls.Add(txtId);
            Controls.Add(label2);
            Controls.Add(txtPass);
            Controls.Add(btnOk);
            Controls.Add(btnExit);
            Name = "LoginForm";
            Text = "[1.] Bejelentkezés";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label label1;
        private TextBox txtId;
        private Label label2;
        private TextBox txtPass;
        private Button btnOk;
        private Button btnExit;
    }
}
