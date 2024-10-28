namespace Chess
{
    partial class GameOverMenu
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
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.WinnerText = new System.Windows.Forms.Label();
            this.ReasonText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(63, 152);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 0;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(262, 152);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // WinnerText
            // 
            this.WinnerText.AutoSize = true;
            this.WinnerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.WinnerText.Location = new System.Drawing.Point(98, 24);
            this.WinnerText.Name = "WinnerText";
            this.WinnerText.Size = new System.Drawing.Size(200, 39);
            this.WinnerText.TabIndex = 2;
            this.WinnerText.Text = "Winner Text";
            // 
            // ReasonText
            // 
            this.ReasonText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ReasonText.Location = new System.Drawing.Point(30, 88);
            this.ReasonText.Name = "ReasonText";
            this.ReasonText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ReasonText.Size = new System.Drawing.Size(334, 25);
            this.ReasonText.TabIndex = 3;
            this.ReasonText.Text = "Reason Text";
            this.ReasonText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GameOverMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 216);
            this.Controls.Add(this.ReasonText);
            this.Controls.Add(this.WinnerText);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRestart);
            this.Name = "GameOverMenu";
            this.Text = "GameOverMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label WinnerText;
        private System.Windows.Forms.Label ReasonText;
    }
}