namespace Chess
{
    partial class fMain
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
            this.btnLocal = new System.Windows.Forms.Button();
            this.btnMulti = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.listBoxTimeOptions = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnLocal
            // 
            this.btnLocal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnLocal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLocal.Location = new System.Drawing.Point(231, 134);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(135, 45);
            this.btnLocal.TabIndex = 1;
            this.btnLocal.Text = "Local";
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnSingle_Click);
            // 
            // btnMulti
            // 
            this.btnMulti.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMulti.Enabled = false;
            this.btnMulti.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnMulti.Location = new System.Drawing.Point(231, 248);
            this.btnMulti.Name = "btnMulti";
            this.btnMulti.Size = new System.Drawing.Size(135, 45);
            this.btnMulti.TabIndex = 2;
            this.btnMulti.Text = "Multiplayer";
            this.btnMulti.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnExit.Location = new System.Drawing.Point(231, 352);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(135, 45);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Quit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // listBoxTimeOptions
            // 
            this.listBoxTimeOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.listBoxTimeOptions.FormattingEnabled = true;
            this.listBoxTimeOptions.ItemHeight = 20;
            this.listBoxTimeOptions.Location = new System.Drawing.Point(430, 134);
            this.listBoxTimeOptions.Name = "listBoxTimeOptions";
            this.listBoxTimeOptions.Size = new System.Drawing.Size(220, 264);
            this.listBoxTimeOptions.TabIndex = 5;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(679, 580);
            this.Controls.Add(this.listBoxTimeOptions);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMulti);
            this.Controls.Add(this.btnLocal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.Text = "Chess";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.Button btnMulti;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox listBoxTimeOptions;
    }
}

