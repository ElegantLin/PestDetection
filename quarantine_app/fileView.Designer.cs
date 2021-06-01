namespace quarantine_app
{
    partial class fileView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fileView));
            this.pdfLoader = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.pdfLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // pdfLoader
            // 
            this.pdfLoader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfLoader.Enabled = true;
            this.pdfLoader.Location = new System.Drawing.Point(0, 0);
            this.pdfLoader.Name = "pdfLoader";
            this.pdfLoader.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfLoader.OcxState")));
            this.pdfLoader.Size = new System.Drawing.Size(785, 560);
            this.pdfLoader.TabIndex = 0;
            // 
            // fileView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pdfLoader);
            this.Name = "fileView";
            this.Text = "查看文件";
            this.Load += new System.EventHandler(this.fileView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pdfLoader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF pdfLoader;
    }
}