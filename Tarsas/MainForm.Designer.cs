namespace TKR
{
    partial class MainForm
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
            lblHello = new Label();
            btnGames = new Button();
            btnLog = new Button();
            btnMembers = new Button();
            btnLogout = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // lblHello
            // 
            lblHello.AutoSize = true;
            lblHello.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHello.Location = new Point(20, 19);
            lblHello.Name = "lblHello";
            lblHello.Size = new Size(74, 15);
            lblHello.TabIndex = 0;
            lblHello.Text = "Üdvözöljük!";
            // 
            // btnGames
            // 
            btnGames.Location = new Point(90, 60);
            btnGames.Name = "btnGames";
            btnGames.Size = new Size(200, 28);
            btnGames.TabIndex = 1;
            btnGames.Text = "Játékok keresése";
            btnGames.UseVisualStyleBackColor = true;
            btnGames.Click += btnGames_Click;
            // 
            // btnLog
            // 
            btnLog.Location = new Point(90, 100);
            btnLog.Name = "btnLog";
            btnLog.Size = new Size(200, 28);
            btnLog.TabIndex = 2;
            btnLog.Text = "Kölcsönzési napló";
            btnLog.UseVisualStyleBackColor = true;
            btnLog.Click += btnLog_Click;
            // 
            // btnMembers
            // 
            btnMembers.Location = new Point(90, 140);
            btnMembers.Name = "btnMembers";
            btnMembers.Size = new Size(200, 28);
            btnMembers.TabIndex = 3;
            btnMembers.Text = "Tagok nyilvántartása";
            btnMembers.UseVisualStyleBackColor = true;
            btnMembers.Click += btnMembers_Click;
            // 
            // btnLogout
            //
            btnLogout.Location = new Point(90, 190);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(95, 28);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Kijelentkezés";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(195, 190);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(95, 28);
            btnExit.TabIndex = 5;
            btnExit.Text = "Kilépés";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 245);
            Controls.Add(lblHello);
            Controls.Add(btnGames);
            Controls.Add(btnLog);
            Controls.Add(btnMembers);
            Controls.Add(btnLogout);
            Controls.Add(btnExit);
            Name = "MainForm";
            Text = "[2.] Főmenü";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHello;
        private Button btnGames;
        private Button btnLog;
        private Button btnMembers;
        private Button btnLogout;
        private Button btnExit;
    }
}
