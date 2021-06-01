namespace quarantine_app
{
    partial class sampleSearch
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
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn1 = new DSkin.Controls.DSkinGridListColumn();
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn2 = new DSkin.Controls.DSkinGridListColumn();
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn3 = new DSkin.Controls.DSkinGridListColumn();
            this.sampleList = new DSkin.Controls.DSkinGridList();
            ((System.ComponentModel.ISupportInitialize)(this.sampleList)).BeginInit();
            this.SuspendLayout();
            // 
            // sampleList
            // 
            // 
            // 
            // 
            this.sampleList.BackPageButton.AdaptImage = true;
            this.sampleList.BackPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.sampleList.BackPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.sampleList.BackPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sampleList.BackPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sampleList.BackPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.sampleList.BackPageButton.Location = new System.Drawing.Point(396, 4);
            this.sampleList.BackPageButton.Name = "BtnBackPage";
            this.sampleList.BackPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.sampleList.BackPageButton.Radius = 0;
            this.sampleList.BackPageButton.Size = new System.Drawing.Size(50, 24);
            this.sampleList.BackPageButton.Text = "上一页";
            this.sampleList.BackPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sampleList.BackPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.sampleList.Borders.AllColor = System.Drawing.Color.Silver;
            this.sampleList.Borders.BottomColor = System.Drawing.Color.Silver;
            this.sampleList.Borders.LeftColor = System.Drawing.Color.Silver;
            this.sampleList.Borders.RightColor = System.Drawing.Color.Silver;
            this.sampleList.Borders.TopColor = System.Drawing.Color.Silver;
            this.sampleList.ColumnHeight = 30;
            dSkinGridListColumn1.Name = "最终编号";
            dSkinGridListColumn1.Visble = true;
            dSkinGridListColumn1.Width = 250;
            dSkinGridListColumn2.Name = "种名";
            dSkinGridListColumn2.Visble = true;
            dSkinGridListColumn2.Width = 220;
            dSkinGridListColumn3.Name = "操作";
            dSkinGridListColumn3.Visble = true;
            dSkinGridListColumn3.Width = 80;
            this.sampleList.Columns.AddRange(new DSkin.Controls.DSkinGridListColumn[] {
            dSkinGridListColumn1,
            dSkinGridListColumn2,
            dSkinGridListColumn3});
            this.sampleList.DoubleItemsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.sampleList.EnabledOrder = false;
            // 
            // 
            // 
            this.sampleList.FirstPageButton.AdaptImage = true;
            this.sampleList.FirstPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.sampleList.FirstPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.sampleList.FirstPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sampleList.FirstPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sampleList.FirstPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.sampleList.FirstPageButton.Location = new System.Drawing.Point(348, 4);
            this.sampleList.FirstPageButton.Name = "BtnFistPage";
            this.sampleList.FirstPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.sampleList.FirstPageButton.Radius = 0;
            this.sampleList.FirstPageButton.Size = new System.Drawing.Size(44, 24);
            this.sampleList.FirstPageButton.Text = "首页";
            this.sampleList.FirstPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sampleList.FirstPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // 
            // 
            this.sampleList.GoPageButton.AdaptImage = true;
            this.sampleList.GoPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.sampleList.GoPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sampleList.GoPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sampleList.GoPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sampleList.GoPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.sampleList.GoPageButton.Location = new System.Drawing.Point(290, 4);
            this.sampleList.GoPageButton.Name = "BtnGoPage";
            this.sampleList.GoPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.sampleList.GoPageButton.Radius = 0;
            this.sampleList.GoPageButton.Size = new System.Drawing.Size(44, 24);
            this.sampleList.GoPageButton.Text = "跳转";
            this.sampleList.GoPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sampleList.GoPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.sampleList.GridLineColor = System.Drawing.Color.Silver;
            this.sampleList.HeaderFont = new System.Drawing.Font("微软雅黑", 9F);
            // 
            // 
            // 
            this.sampleList.HScrollBar.AutoSize = false;
            this.sampleList.HScrollBar.Fillet = true;
            this.sampleList.HScrollBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sampleList.HScrollBar.Location = new System.Drawing.Point(0, 56);
            this.sampleList.HScrollBar.Name = "";
            this.sampleList.HScrollBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.sampleList.HScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.sampleList.HScrollBar.Size = new System.Drawing.Size(552, 12);
            this.sampleList.HScrollBar.Visible = false;
            // 
            // 
            // 
            this.sampleList.LastPageButton.AdaptImage = true;
            this.sampleList.LastPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.sampleList.LastPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.sampleList.LastPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sampleList.LastPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sampleList.LastPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.sampleList.LastPageButton.Location = new System.Drawing.Point(504, 4);
            this.sampleList.LastPageButton.Name = "BtnLastPage";
            this.sampleList.LastPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.sampleList.LastPageButton.Radius = 0;
            this.sampleList.LastPageButton.Size = new System.Drawing.Size(44, 24);
            this.sampleList.LastPageButton.Text = "末页";
            this.sampleList.LastPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sampleList.LastPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.sampleList.Location = new System.Drawing.Point(0, 0);
            this.sampleList.Name = "sampleList";
            // 
            // 
            // 
            this.sampleList.NextPageButton.AdaptImage = true;
            this.sampleList.NextPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.sampleList.NextPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.sampleList.NextPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sampleList.NextPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sampleList.NextPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.sampleList.NextPageButton.Location = new System.Drawing.Point(450, 4);
            this.sampleList.NextPageButton.Name = "BtnNextPage";
            this.sampleList.NextPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.sampleList.NextPageButton.Radius = 0;
            this.sampleList.NextPageButton.Size = new System.Drawing.Size(50, 24);
            this.sampleList.NextPageButton.Text = "下一页";
            this.sampleList.NextPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sampleList.NextPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.sampleList.PageSize = 12;
            this.sampleList.SelectedItem = null;
            this.sampleList.Size = new System.Drawing.Size(552, 432);
            this.sampleList.TabIndex = 0;
            this.sampleList.Text = "dSkinGridList1";
            // 
            // 
            // 
            this.sampleList.VScrollBar.AutoSize = false;
            this.sampleList.VScrollBar.BitmapCache = true;
            this.sampleList.VScrollBar.Fillet = true;
            this.sampleList.VScrollBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sampleList.VScrollBar.LargeChange = 1000;
            this.sampleList.VScrollBar.Location = new System.Drawing.Point(539, 1);
            this.sampleList.VScrollBar.Margin = new System.Windows.Forms.Padding(1);
            this.sampleList.VScrollBar.Maximum = 10000;
            this.sampleList.VScrollBar.Name = "";
            this.sampleList.VScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.sampleList.VScrollBar.Size = new System.Drawing.Size(12, 367);
            this.sampleList.VScrollBar.SmallChange = 500;
            this.sampleList.VScrollBar.Visible = false;
            this.sampleList.ItemClick += new System.EventHandler<DSkin.Controls.DSkinGridListMouseEventArgs>(this.sampleList_ItemClick);
            // 
            // sampleSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 428);
            this.Controls.Add(this.sampleList);
            this.Name = "sampleSearch";
            this.Text = "搜索物种";
            ((System.ComponentModel.ISupportInitialize)(this.sampleList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DSkin.Controls.DSkinGridList sampleList;
    }
}