namespace quarantine_app
{
    partial class pictureWindow
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
            this.photo1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.photo1)).BeginInit();
            this.SuspendLayout();
            // 
            // photo1
            // 
            this.photo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.photo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.photo1.Location = new System.Drawing.Point(0, 0);
            this.photo1.Name = "photo1";
            this.photo1.Size = new System.Drawing.Size(200, 200);
            this.photo1.TabIndex = 0;
            this.photo1.TabStop = false;
            // 
            // pictureWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(204, 201);
            this.Controls.Add(this.photo1);
            this.Name = "pictureWindow";
            this.Text = "查看照片";
            this.Load += new System.EventHandler(this.pictureWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.photo1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox photo1;
    }
}