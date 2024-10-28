namespace Chess
{
    partial class fChessB
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
            this.pbChessB = new System.Windows.Forms.PictureBox();
            this.lBlackTimer = new System.Windows.Forms.Label();
            this.lWhiteTimer = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbChessB)).BeginInit();
            this.SuspendLayout();
            // 
            // pbChessB
            // 
            this.pbChessB.BackgroundImage = global::Chess.Properties.Resources.Board;
            this.pbChessB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbChessB.Location = new System.Drawing.Point(58, 52);
            this.pbChessB.Name = "pbChessB";
            this.pbChessB.Size = new System.Drawing.Size(480, 480);
            this.pbChessB.TabIndex = 0;
            this.pbChessB.TabStop = false;
            // 
            // lBlackTimer
            // 
            this.lBlackTimer.AutoSize = true;
            this.lBlackTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lBlackTimer.Location = new System.Drawing.Point(596, 52);
            this.lBlackTimer.Name = "lBlackTimer";
            this.lBlackTimer.Size = new System.Drawing.Size(64, 25);
            this.lBlackTimer.TabIndex = 1;
            this.lBlackTimer.Text = "label1";
            // 
            // lWhiteTimer
            // 
            this.lWhiteTimer.AutoSize = true;
            this.lWhiteTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lWhiteTimer.Location = new System.Drawing.Point(596, 507);
            this.lWhiteTimer.Name = "lWhiteTimer";
            this.lWhiteTimer.Size = new System.Drawing.Size(64, 25);
            this.lWhiteTimer.TabIndex = 2;
            this.lWhiteTimer.Text = "label2";
            // 
            // btnPause
            // 
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnPause.Location = new System.Drawing.Point(601, 257);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(110, 43);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnRestart.Location = new System.Drawing.Point(601, 340);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(110, 42);
            this.btnRestart.TabIndex = 4;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnStart.Location = new System.Drawing.Point(601, 179);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(110, 43);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // fChessB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 555);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.lWhiteTimer);
            this.Controls.Add(this.lBlackTimer);
            this.Controls.Add(this.pbChessB);
            this.Name = "fChessB";
            this.Text = "ChessForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbChessB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbChessB;
        private System.Windows.Forms.Label lBlackTimer;
        private System.Windows.Forms.Label lWhiteTimer;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnStart;
    }
}