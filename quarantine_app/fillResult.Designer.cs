namespace quarantine_app
{
    partial class fillResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fillResult));
            this.dSkinTableLayoutPanel1 = new DSkin.Controls.DSkinTableLayoutPanel();
            this.dSkinLabel1 = new DSkin.Controls.DSkinLabel();
            this.numText = new DSkin.Controls.DSkinTextBox();
            this.fillNum = new DSkin.Controls.DSkinButton();
            this.dSkinTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dSkinTableLayoutPanel1
            // 
            this.dSkinTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.dSkinTableLayoutPanel1.BitmapCache = false;
            this.dSkinTableLayoutPanel1.ColumnCount = 3;
            this.dSkinTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.dSkinTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.15789F));
            this.dSkinTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.63158F));
            this.dSkinTableLayoutPanel1.Controls.Add(this.dSkinLabel1, 0, 0);
            this.dSkinTableLayoutPanel1.Controls.Add(this.numText, 1, 0);
            this.dSkinTableLayoutPanel1.Controls.Add(this.fillNum, 2, 0);
            this.dSkinTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.dSkinTableLayoutPanel1.Name = "dSkinTableLayoutPanel1";
            this.dSkinTableLayoutPanel1.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinTableLayoutPanel1.RightBottom")));
            this.dSkinTableLayoutPanel1.RowCount = 1;
            this.dSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dSkinTableLayoutPanel1.Size = new System.Drawing.Size(475, 58);
            this.dSkinTableLayoutPanel1.TabIndex = 0;
            // 
            // dSkinLabel1
            // 
            this.dSkinLabel1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel1.Location = new System.Drawing.Point(20, 20);
            this.dSkinLabel1.Margin = new System.Windows.Forms.Padding(20, 20, 3, 3);
            this.dSkinLabel1.Name = "dSkinLabel1";
            this.dSkinLabel1.Size = new System.Drawing.Size(121, 20);
            this.dSkinLabel1.TabIndex = 0;
            this.dSkinLabel1.Text = "请填写最终编号";
            // 
            // numText
            // 
            this.numText.BitmapCache = false;
            this.numText.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numText.Location = new System.Drawing.Point(170, 18);
            this.numText.Margin = new System.Windows.Forms.Padding(18, 18, 3, 3);
            this.numText.Name = "numText";
            this.numText.Size = new System.Drawing.Size(202, 25);
            this.numText.TabIndex = 1;
            this.numText.TransparencyKey = System.Drawing.Color.Empty;
            this.numText.WaterFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numText.WaterText = "";
            this.numText.WaterTextOffset = new System.Drawing.Point(0, 0);
            // 
            // fillNum
            // 
            this.fillNum.BaseColor = System.Drawing.Color.SkyBlue;
            this.fillNum.ButtonBorderColor = System.Drawing.Color.SkyBlue;
            this.fillNum.ButtonBorderWidth = 1;
            this.fillNum.DialogResult = System.Windows.Forms.DialogResult.None;
            this.fillNum.ForeColor = System.Drawing.Color.White;
            this.fillNum.HoverColor = System.Drawing.Color.Empty;
            this.fillNum.HoverImage = null;
            this.fillNum.Location = new System.Drawing.Point(398, 14);
            this.fillNum.Margin = new System.Windows.Forms.Padding(3, 14, 3, 3);
            this.fillNum.Name = "fillNum";
            this.fillNum.NormalImage = null;
            this.fillNum.PressColor = System.Drawing.Color.Empty;
            this.fillNum.PressedImage = null;
            this.fillNum.Radius = 10;
            this.fillNum.ShowButtonBorder = true;
            this.fillNum.Size = new System.Drawing.Size(65, 30);
            this.fillNum.TabIndex = 2;
            this.fillNum.Text = "保 存";
            this.fillNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fillNum.TextPadding = 0;
            this.fillNum.Click += new System.EventHandler(this.fillNum_Click);
            // 
            // fillResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(474, 58);
            this.Controls.Add(this.dSkinTableLayoutPanel1);
            this.Name = "fillResult";
            this.Text = "fillResult";
            this.dSkinTableLayoutPanel1.ResumeLayout(false);
            this.dSkinTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DSkin.Controls.DSkinTableLayoutPanel dSkinTableLayoutPanel1;
        private DSkin.Controls.DSkinLabel dSkinLabel1;
        private DSkin.Controls.DSkinTextBox numText;
        private DSkin.Controls.DSkinButton fillNum;
    }
}