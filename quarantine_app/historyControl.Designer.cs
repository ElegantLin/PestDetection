namespace quarantine_app
{
    partial class historyControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(historyControl));
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn1 = new DSkin.Controls.DSkinGridListColumn();
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn2 = new DSkin.Controls.DSkinGridListColumn();
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn3 = new DSkin.Controls.DSkinGridListColumn();
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn4 = new DSkin.Controls.DSkinGridListColumn();
            this.dSkinTableLayoutPanel1 = new DSkin.Controls.DSkinTableLayoutPanel();
            this.dSkinTableLayoutPanel2 = new DSkin.Controls.DSkinTableLayoutPanel();
            this.historyTime = new DSkin.Controls.DSkinDateTimePicker();
            this.searchHistory = new DSkin.Controls.DSkinButton();
            this.dSkinTableLayoutPanel3 = new DSkin.Controls.DSkinTableLayoutPanel();
            this.historyData = new DSkin.Controls.DSkinGridList();
            this.dSkinTableLayoutPanel1.SuspendLayout();
            this.dSkinTableLayoutPanel2.SuspendLayout();
            this.dSkinTableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.historyData)).BeginInit();
            this.SuspendLayout();
            // 
            // dSkinTableLayoutPanel1
            // 
            this.dSkinTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.dSkinTableLayoutPanel1.BitmapCache = false;
            this.dSkinTableLayoutPanel1.ColumnCount = 1;
            this.dSkinTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dSkinTableLayoutPanel1.Controls.Add(this.dSkinTableLayoutPanel2, 0, 1);
            this.dSkinTableLayoutPanel1.Controls.Add(this.dSkinTableLayoutPanel3, 0, 3);
            this.dSkinTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dSkinTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.dSkinTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dSkinTableLayoutPanel1.Name = "dSkinTableLayoutPanel1";
            this.dSkinTableLayoutPanel1.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinTableLayoutPanel1.RightBottom")));
            this.dSkinTableLayoutPanel1.RowCount = 4;
            this.dSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dSkinTableLayoutPanel1.Size = new System.Drawing.Size(1051, 712);
            this.dSkinTableLayoutPanel1.TabIndex = 0;
            // 
            // dSkinTableLayoutPanel2
            // 
            this.dSkinTableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.dSkinTableLayoutPanel2.BitmapCache = false;
            this.dSkinTableLayoutPanel2.ColumnCount = 4;
            this.dSkinTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.dSkinTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.dSkinTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.dSkinTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dSkinTableLayoutPanel2.Controls.Add(this.historyTime, 1, 0);
            this.dSkinTableLayoutPanel2.Controls.Add(this.searchHistory, 3, 0);
            this.dSkinTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dSkinTableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.dSkinTableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dSkinTableLayoutPanel2.Name = "dSkinTableLayoutPanel2";
            this.dSkinTableLayoutPanel2.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinTableLayoutPanel2.RightBottom")));
            this.dSkinTableLayoutPanel2.RowCount = 1;
            this.dSkinTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dSkinTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.dSkinTableLayoutPanel2.Size = new System.Drawing.Size(1043, 62);
            this.dSkinTableLayoutPanel2.TabIndex = 0;
            // 
            // historyTime
            // 
            this.historyTime.Font = new System.Drawing.Font("YouYuan", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.historyTime.Location = new System.Drawing.Point(108, 16);
            this.historyTime.Margin = new System.Windows.Forms.Padding(4, 16, 4, 4);
            this.historyTime.Name = "historyTime";
            this.historyTime.Size = new System.Drawing.Size(300, 27);
            this.historyTime.TabIndex = 0;
            // 
            // searchHistory
            // 
            this.searchHistory.ButtonBorderWidth = 1;
            this.searchHistory.DialogResult = System.Windows.Forms.DialogResult.None;
            this.searchHistory.Font = new System.Drawing.Font("YouYuan", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.searchHistory.HoverColor = System.Drawing.Color.Empty;
            this.searchHistory.HoverImage = null;
            this.searchHistory.Location = new System.Drawing.Point(524, 11);
            this.searchHistory.Margin = new System.Windows.Forms.Padding(4, 11, 4, 4);
            this.searchHistory.Name = "searchHistory";
            this.searchHistory.NormalImage = null;
            this.searchHistory.PressColor = System.Drawing.Color.Empty;
            this.searchHistory.PressedImage = null;
            this.searchHistory.Radius = 10;
            this.searchHistory.ShowButtonBorder = true;
            this.searchHistory.Size = new System.Drawing.Size(95, 38);
            this.searchHistory.TabIndex = 1;
            this.searchHistory.Text = "查 询";
            this.searchHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.searchHistory.TextPadding = 0;
            this.searchHistory.Click += new System.EventHandler(this.searchHistory_Click);
            // 
            // dSkinTableLayoutPanel3
            // 
            this.dSkinTableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.dSkinTableLayoutPanel3.BitmapCache = false;
            this.dSkinTableLayoutPanel3.ColumnCount = 3;
            this.dSkinTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.dSkinTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.dSkinTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.dSkinTableLayoutPanel3.Controls.Add(this.historyData, 1, 0);
            this.dSkinTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dSkinTableLayoutPanel3.Location = new System.Drawing.Point(4, 74);
            this.dSkinTableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dSkinTableLayoutPanel3.Name = "dSkinTableLayoutPanel3";
            this.dSkinTableLayoutPanel3.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinTableLayoutPanel3.RightBottom")));
            this.dSkinTableLayoutPanel3.RowCount = 1;
            this.dSkinTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dSkinTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 488F));
            this.dSkinTableLayoutPanel3.Size = new System.Drawing.Size(1043, 634);
            this.dSkinTableLayoutPanel3.TabIndex = 1;
            // 
            // historyData
            // 
            // 
            // 
            // 
            this.historyData.BackPageButton.AdaptImage = true;
            this.historyData.BackPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.historyData.BackPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.historyData.BackPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.historyData.BackPageButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.historyData.BackPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.historyData.BackPageButton.Location = new System.Drawing.Point(670, 4);
            this.historyData.BackPageButton.Name = "BtnBackPage";
            this.historyData.BackPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.historyData.BackPageButton.Radius = 0;
            this.historyData.BackPageButton.Size = new System.Drawing.Size(50, 24);
            this.historyData.BackPageButton.Text = "上一页";
            this.historyData.BackPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.historyData.BackPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.historyData.Borders.AllColor = System.Drawing.Color.Silver;
            this.historyData.Borders.BottomColor = System.Drawing.Color.Silver;
            this.historyData.Borders.LeftColor = System.Drawing.Color.Silver;
            this.historyData.Borders.RightColor = System.Drawing.Color.Silver;
            this.historyData.Borders.TopColor = System.Drawing.Color.Silver;
            this.historyData.ColumnFill = true;
            this.historyData.ColumnHeight = 30;
            dSkinGridListColumn1.Name = "鉴定编号";
            dSkinGridListColumn1.Visble = true;
            dSkinGridListColumn1.Width = 206;
            dSkinGridListColumn2.Name = "鉴定日期";
            dSkinGridListColumn2.Visble = true;
            dSkinGridListColumn2.Width = 206;
            dSkinGridListColumn3.Name = "鉴定图片";
            dSkinGridListColumn3.Visble = true;
            dSkinGridListColumn3.Width = 206;
            dSkinGridListColumn4.Name = "鉴定结果";
            dSkinGridListColumn4.Visble = true;
            dSkinGridListColumn4.Width = 207;
            this.historyData.Columns.AddRange(new DSkin.Controls.DSkinGridListColumn[] {
            dSkinGridListColumn1,
            dSkinGridListColumn2,
            dSkinGridListColumn3,
            dSkinGridListColumn4});
            this.historyData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyData.DoubleItemsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.historyData.EnabledOrder = false;
            // 
            // 
            // 
            this.historyData.FirstPageButton.AdaptImage = true;
            this.historyData.FirstPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.historyData.FirstPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.historyData.FirstPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.historyData.FirstPageButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.historyData.FirstPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.historyData.FirstPageButton.Location = new System.Drawing.Point(622, 4);
            this.historyData.FirstPageButton.Name = "BtnFistPage";
            this.historyData.FirstPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.historyData.FirstPageButton.Radius = 0;
            this.historyData.FirstPageButton.Size = new System.Drawing.Size(44, 24);
            this.historyData.FirstPageButton.Text = "首页";
            this.historyData.FirstPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.historyData.FirstPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // 
            // 
            this.historyData.GoPageButton.AdaptImage = true;
            this.historyData.GoPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.historyData.GoPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.historyData.GoPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.historyData.GoPageButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.historyData.GoPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.historyData.GoPageButton.Location = new System.Drawing.Point(348, 4);
            this.historyData.GoPageButton.Name = "BtnGoPage";
            this.historyData.GoPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.historyData.GoPageButton.Radius = 0;
            this.historyData.GoPageButton.Size = new System.Drawing.Size(44, 24);
            this.historyData.GoPageButton.Text = "跳转";
            this.historyData.GoPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.historyData.GoPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.historyData.GridLineColor = System.Drawing.Color.Silver;
            this.historyData.HeaderFont = new System.Drawing.Font("Microsoft YaHei", 9F);
            // 
            // 
            // 
            this.historyData.HScrollBar.AutoSize = false;
            this.historyData.HScrollBar.Fillet = true;
            this.historyData.HScrollBar.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.historyData.HScrollBar.Location = new System.Drawing.Point(0, 320);
            this.historyData.HScrollBar.Maximum = 136;
            this.historyData.HScrollBar.Name = "";
            this.historyData.HScrollBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.historyData.HScrollBar.ScrollBarLenght = 10;
            this.historyData.HScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.historyData.HScrollBar.Size = new System.Drawing.Size(826, 12);
            this.historyData.HScrollBar.Visible = false;
            // 
            // 
            // 
            this.historyData.LastPageButton.AdaptImage = true;
            this.historyData.LastPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.historyData.LastPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.historyData.LastPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.historyData.LastPageButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.historyData.LastPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.historyData.LastPageButton.Location = new System.Drawing.Point(778, 4);
            this.historyData.LastPageButton.Name = "BtnLastPage";
            this.historyData.LastPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.historyData.LastPageButton.Radius = 0;
            this.historyData.LastPageButton.Size = new System.Drawing.Size(44, 24);
            this.historyData.LastPageButton.Text = "末页";
            this.historyData.LastPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.historyData.LastPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.historyData.Location = new System.Drawing.Point(108, 4);
            this.historyData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.historyData.Name = "historyData";
            // 
            // 
            // 
            this.historyData.NextPageButton.AdaptImage = true;
            this.historyData.NextPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.historyData.NextPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.historyData.NextPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.historyData.NextPageButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.historyData.NextPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.historyData.NextPageButton.Location = new System.Drawing.Point(724, 4);
            this.historyData.NextPageButton.Name = "BtnNextPage";
            this.historyData.NextPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.historyData.NextPageButton.Radius = 0;
            this.historyData.NextPageButton.Size = new System.Drawing.Size(50, 24);
            this.historyData.NextPageButton.Text = "下一页";
            this.historyData.NextPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.historyData.NextPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.historyData.PageSize = 10;
            this.historyData.SelectedItem = null;
            this.historyData.Size = new System.Drawing.Size(826, 626);
            this.historyData.TabIndex = 0;
            this.historyData.Text = "dSkinGridList1";
            // 
            // 
            // 
            this.historyData.VScrollBar.AutoSize = false;
            this.historyData.VScrollBar.BitmapCache = true;
            this.historyData.VScrollBar.Fillet = true;
            this.historyData.VScrollBar.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.historyData.VScrollBar.LargeChange = 1000;
            this.historyData.VScrollBar.Location = new System.Drawing.Point(813, 1);
            this.historyData.VScrollBar.Margin = new System.Windows.Forms.Padding(1);
            this.historyData.VScrollBar.Maximum = 10000;
            this.historyData.VScrollBar.Name = "";
            this.historyData.VScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.historyData.VScrollBar.Size = new System.Drawing.Size(12, 561);
            this.historyData.VScrollBar.SmallChange = 500;
            this.historyData.VScrollBar.Visible = false;
            this.historyData.ItemClick += new System.EventHandler<DSkin.Controls.DSkinGridListMouseEventArgs>(this.historyData_ItemClick);
            // 
            // historyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dSkinTableLayoutPanel1);
            this.Location = new System.Drawing.Point(207, 10);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "historyControl";
            this.Size = new System.Drawing.Size(1051, 712);
            this.dSkinTableLayoutPanel1.ResumeLayout(false);
            this.dSkinTableLayoutPanel2.ResumeLayout(false);
            this.dSkinTableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.historyData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DSkin.Controls.DSkinTableLayoutPanel dSkinTableLayoutPanel1;
        private DSkin.Controls.DSkinTableLayoutPanel dSkinTableLayoutPanel2;
        private DSkin.Controls.DSkinDateTimePicker historyTime;
        private DSkin.Controls.DSkinButton searchHistory;
        private DSkin.Controls.DSkinTableLayoutPanel dSkinTableLayoutPanel3;
        private DSkin.Controls.DSkinGridList historyData;
    }
}
