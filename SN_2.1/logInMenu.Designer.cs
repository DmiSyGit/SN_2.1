namespace SN_1._0
{
    partial class logInMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(logInMenu));
            this.logInButton = new System.Windows.Forms.Button();
            this.textBoxNickName = new System.Windows.Forms.TextBox();
            this.labelNameGame = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // logInButton
            // 
            this.logInButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(173)))), ((int)(((byte)(121)))));
            this.logInButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logInButton.FlatAppearance.BorderSize = 0;
            this.logInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logInButton.Font = new System.Drawing.Font("Segoe UI Black", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logInButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(112)))), ((int)(((byte)(29)))));
            this.logInButton.Location = new System.Drawing.Point(0, 371);
            this.logInButton.Margin = new System.Windows.Forms.Padding(0);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(800, 269);
            this.logInButton.TabIndex = 0;
            this.logInButton.Text = "LogIn";
            this.logInButton.UseVisualStyleBackColor = false;
            this.logInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // textBoxNickName
            // 
            this.textBoxNickName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(198)))), ((int)(((byte)(135)))));
            this.textBoxNickName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNickName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxNickName.Font = new System.Drawing.Font("Segoe UI Black", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNickName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(112)))), ((int)(((byte)(29)))));
            this.textBoxNickName.Location = new System.Drawing.Point(0, 298);
            this.textBoxNickName.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxNickName.Name = "textBoxNickName";
            this.textBoxNickName.Size = new System.Drawing.Size(800, 73);
            this.textBoxNickName.TabIndex = 1;
            this.textBoxNickName.Text = "nickname";
            this.textBoxNickName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNickName.TextChanged += new System.EventHandler(this.nickName_TextChanged);
            this.textBoxNickName.Enter += new System.EventHandler(this.nickName_Enter);
            this.textBoxNickName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nickName_KeyPress);
            this.textBoxNickName.Leave += new System.EventHandler(this.nickName_Leave);
            // 
            // labelNameGame
            // 
            this.labelNameGame.BackColor = System.Drawing.Color.Transparent;
            this.labelNameGame.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelNameGame.Font = new System.Drawing.Font("Segoe UI Black", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(112)))), ((int)(((byte)(29)))));
            this.labelNameGame.Location = new System.Drawing.Point(0, 0);
            this.labelNameGame.Name = "labelNameGame";
            this.labelNameGame.Size = new System.Drawing.Size(800, 202);
            this.labelNameGame.TabIndex = 2;
            this.labelNameGame.Text = "SNAKE";
            this.labelNameGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logInMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(173)))), ((int)(((byte)(121)))));
            this.ClientSize = new System.Drawing.Size(800, 640);
            this.Controls.Add(this.labelNameGame);
            this.Controls.Add(this.textBoxNickName);
            this.Controls.Add(this.logInButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "logInMenu";
            this.Load += new System.EventHandler(this.logInMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logInButton;
        private System.Windows.Forms.TextBox textBoxNickName;
        private System.Windows.Forms.Label labelNameGame;
    }
}