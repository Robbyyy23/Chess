namespace Chess
{
    partial class PromotionMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PromotionMenu));
            this.pieceLabel = new System.Windows.Forms.Label();
            this.pbQueen = new System.Windows.Forms.PictureBox();
            this.pbBishop = new System.Windows.Forms.PictureBox();
            this.pbKnight = new System.Windows.Forms.PictureBox();
            this.pbRook = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbQueen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBishop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRook)).BeginInit();
            this.SuspendLayout();
            // 
            // pieceLabel
            // 
            this.pieceLabel.AutoSize = true;
            this.pieceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.pieceLabel.Location = new System.Drawing.Point(143, 39);
            this.pieceLabel.Name = "pieceLabel";
            this.pieceLabel.Size = new System.Drawing.Size(224, 39);
            this.pieceLabel.TabIndex = 0;
            this.pieceLabel.Text = "Alege o piesa";
            // 
            // pbQueen
            // 
            this.pbQueen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbQueen.BackgroundImage")));
            this.pbQueen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbQueen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbQueen.Location = new System.Drawing.Point(12, 125);
            this.pbQueen.Name = "pbQueen";
            this.pbQueen.Size = new System.Drawing.Size(118, 109);
            this.pbQueen.TabIndex = 1;
            this.pbQueen.TabStop = false;
            this.pbQueen.Click += new System.EventHandler(this.pbQueen_Click);
            // 
            // pbBishop
            // 
            this.pbBishop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbBishop.BackgroundImage")));
            this.pbBishop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbBishop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBishop.Location = new System.Drawing.Point(136, 125);
            this.pbBishop.Name = "pbBishop";
            this.pbBishop.Size = new System.Drawing.Size(118, 109);
            this.pbBishop.TabIndex = 2;
            this.pbBishop.TabStop = false;
            this.pbBishop.Click += new System.EventHandler(this.pbBishop_Click);
            // 
            // pbKnight
            // 
            this.pbKnight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbKnight.BackgroundImage")));
            this.pbKnight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbKnight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbKnight.Location = new System.Drawing.Point(384, 125);
            this.pbKnight.Name = "pbKnight";
            this.pbKnight.Size = new System.Drawing.Size(118, 109);
            this.pbKnight.TabIndex = 3;
            this.pbKnight.TabStop = false;
            this.pbKnight.Click += new System.EventHandler(this.pbKnight_Click);
            // 
            // pbRook
            // 
            this.pbRook.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbRook.BackgroundImage")));
            this.pbRook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbRook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbRook.Location = new System.Drawing.Point(260, 125);
            this.pbRook.Name = "pbRook";
            this.pbRook.Size = new System.Drawing.Size(118, 109);
            this.pbRook.TabIndex = 4;
            this.pbRook.TabStop = false;
            this.pbRook.Click += new System.EventHandler(this.pbRook_Click);
            // 
            // PromotionMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 243);
            this.Controls.Add(this.pbRook);
            this.Controls.Add(this.pbKnight);
            this.Controls.Add(this.pbBishop);
            this.Controls.Add(this.pbQueen);
            this.Controls.Add(this.pieceLabel);
            this.Name = "PromotionMenu";
            this.Text = "PromotionMenu";
            ((System.ComponentModel.ISupportInitialize)(this.pbQueen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBishop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pieceLabel;
        private System.Windows.Forms.PictureBox pbQueen;
        private System.Windows.Forms.PictureBox pbBishop;
        private System.Windows.Forms.PictureBox pbKnight;
        private System.Windows.Forms.PictureBox pbRook;
    }
}