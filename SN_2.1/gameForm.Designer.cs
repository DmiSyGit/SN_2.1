namespace SN_1._0
{
    partial class gameForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gameForm));
            this.timerGameTick = new System.Windows.Forms.Timer(this.components);
            this.timerEat = new System.Windows.Forms.Timer(this.components);
            this.labelGameOver = new System.Windows.Forms.Label();
            this.timerGameOver = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.labelHealthSnake = new System.Windows.Forms.Label();
            this.labelScoreSnake = new System.Windows.Forms.Label();
            this.pictureBoxFooter = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelGameOver
            // 
            this.labelGameOver.AutoSize = true;
            this.labelGameOver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(173)))), ((int)(((byte)(121)))));
            this.labelGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGameOver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(112)))), ((int)(((byte)(29)))));
            this.labelGameOver.Location = new System.Drawing.Point(94, 260);
            this.labelGameOver.Margin = new System.Windows.Forms.Padding(100);
            this.labelGameOver.Name = "labelGameOver";
            this.labelGameOver.Size = new System.Drawing.Size(0, 46);
            this.labelGameOver.TabIndex = 0;
            this.labelGameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelGameOver.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(598, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 1;
            // 
            // labelHealthSnake
            // 
            this.labelHealthSnake.AutoSize = true;
            this.labelHealthSnake.BackColor = System.Drawing.Color.Transparent;
            this.labelHealthSnake.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(112)))), ((int)(((byte)(29)))));
            this.labelHealthSnake.Location = new System.Drawing.Point(62, 648);
            this.labelHealthSnake.Name = "labelHealthSnake";
            this.labelHealthSnake.Size = new System.Drawing.Size(13, 13);
            this.labelHealthSnake.TabIndex = 2;
            this.labelHealthSnake.Text = "0";
            // 
            // labelScoreSnake
            // 
            this.labelScoreSnake.AutoSize = true;
            this.labelScoreSnake.BackColor = System.Drawing.Color.Transparent;
            this.labelScoreSnake.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(112)))), ((int)(((byte)(29)))));
            this.labelScoreSnake.Location = new System.Drawing.Point(275, 648);
            this.labelScoreSnake.Name = "labelScoreSnake";
            this.labelScoreSnake.Size = new System.Drawing.Size(45, 13);
            this.labelScoreSnake.TabIndex = 3;
            this.labelScoreSnake.Text = "score: 0";
            // 
            // pictureBoxFooter
            // 
            this.pictureBoxFooter.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxFooter.BackgroundImage = global::SN_1._0.Properties.Resources.snake_dirt_footor;
            this.pictureBoxFooter.Location = new System.Drawing.Point(0, 640);
            this.pictureBoxFooter.Name = "pictureBoxFooter";
            this.pictureBoxFooter.Size = new System.Drawing.Size(800, 55);
            this.pictureBoxFooter.TabIndex = 4;
            this.pictureBoxFooter.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::SN_1._0.Properties.Resources.snake_dirt;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(800, 640);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.field_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(173)))), ((int)(((byte)(121)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 640);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // gameForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::SN_1._0.Properties.Resources.snake_dirt;
            this.ClientSize = new System.Drawing.Size(800, 695);
            this.Controls.Add(this.labelScoreSnake);
            this.Controls.Add(this.labelHealthSnake);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelGameOver);
            this.Controls.Add(this.pictureBoxFooter);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "gameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Snake Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGame_Closing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGame_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_DownF1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerGameTick;
        private System.Windows.Forms.Timer timerEat;
        private System.Windows.Forms.Label labelGameOver;
        private System.Windows.Forms.Timer timerGameOver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelHealthSnake;
        private System.Windows.Forms.Label labelScoreSnake;
        private System.Windows.Forms.PictureBox pictureBoxFooter;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

