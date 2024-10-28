using System;

namespace Chess
{
    partial class fChessBEx
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
            this.components = new System.ComponentModel.Container();
            this.btnQuitEx = new System.Windows.Forms.Button();
            this.btnStartEx = new System.Windows.Forms.Button();
            this.pbChessEx = new System.Windows.Forms.PictureBox();
            this.textPBEx = new System.Windows.Forms.TextBox();
            this.textPWEx = new System.Windows.Forms.TextBox();
            this.timePWEx = new System.Windows.Forms.TextBox();
            this.timePBEx = new System.Windows.Forms.TextBox();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbChessEx)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuitEx
            // 
            this.btnQuitEx.Location = new System.Drawing.Point(621, 526);
            this.btnQuitEx.Name = "btnQuitEx";
            this.btnQuitEx.Size = new System.Drawing.Size(117, 23);
            this.btnQuitEx.TabIndex = 1;
            this.btnQuitEx.Text = "Quit to Main Menu";
            this.btnQuitEx.UseVisualStyleBackColor = true;
            this.btnQuitEx.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnStartEx
            // 
            this.btnStartEx.Location = new System.Drawing.Point(621, 336);
            this.btnStartEx.Name = "btnStartEx";
            this.btnStartEx.Size = new System.Drawing.Size(117, 23);
            this.btnStartEx.TabIndex = 3;
            this.btnStartEx.Text = "Start";
            this.btnStartEx.UseVisualStyleBackColor = true;
            this.btnStartEx.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pbChessEx
            // 
            this.pbChessEx.BackgroundImage = global::Chess.Properties.Resources.Board;
            this.pbChessEx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbChessEx.Location = new System.Drawing.Point(60, 70);
            this.pbChessEx.Name = "pbChessEx";
            this.pbChessEx.Size = new System.Drawing.Size(480, 480);
            this.pbChessEx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbChessEx.TabIndex = 4;
            this.pbChessEx.TabStop = false;
            // 
            // textPBEx
            // 
            this.textPBEx.Location = new System.Drawing.Point(60, 31);
            this.textPBEx.Name = "textPBEx";
            this.textPBEx.Size = new System.Drawing.Size(100, 20);
            this.textPBEx.TabIndex = 6;
            // 
            // textPWEx
            // 
            this.textPWEx.Location = new System.Drawing.Point(60, 617);
            this.textPWEx.Name = "textPWEx";
            this.textPWEx.Size = new System.Drawing.Size(100, 20);
            this.textPWEx.TabIndex = 7;
            // 
            // timePWEx
            // 
            this.timePWEx.Location = new System.Drawing.Point(621, 617);
            this.timePWEx.Name = "timePWEx";
            this.timePWEx.Size = new System.Drawing.Size(117, 20);
            this.timePWEx.TabIndex = 8;
            // 
            // timePBEx
            // 
            this.timePBEx.Location = new System.Drawing.Point(621, 31);
            this.timePBEx.Name = "timePBEx";
            this.timePBEx.Size = new System.Drawing.Size(117, 20);
            this.timePBEx.TabIndex = 9;
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 1000;
            // 
            // fChessBEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(791, 688);
            this.Controls.Add(this.timePBEx);
            this.Controls.Add(this.timePWEx);
            this.Controls.Add(this.textPWEx);
            this.Controls.Add(this.textPBEx);
            this.Controls.Add(this.pbChessEx);
            this.Controls.Add(this.btnStartEx);
            this.Controls.Add(this.btnQuitEx);
            this.MaximizeBox = false;
            this.Name = "fChessBEx";
            this.Text = "ChessBoard";
            ((System.ComponentModel.ISupportInitialize)(this.pbChessEx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnQuitEx;
        private System.Windows.Forms.Button btnStartEx;
        private System.Windows.Forms.PictureBox pbChessEx;
        private System.Windows.Forms.TextBox textPBEx;
        private System.Windows.Forms.TextBox textPWEx;
        private System.Windows.Forms.TextBox timePWEx;
        private System.Windows.Forms.TextBox timePBEx;
        private System.Windows.Forms.Timer MainTimer;
    }
}