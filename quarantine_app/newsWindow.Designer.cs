namespace quarantine_app
{
    partial class newsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newsWindow));
            this.dSkinTableLayoutPanel1 = new DSkin.Controls.DSkinTableLayoutPanel();
            this.newsDetailList = new DSkin.Controls.DSkinGridList();
            this.dSkinTableLayoutPanel11 = new DSkin.Controls.DSkinTableLayoutPanel();
            this.newsEnd = new DSkin.Controls.DSkinDateTimePicker();
            this.newsStart = new DSkin.Controls.DSkinDateTimePicker();
            this.newsKeyword = new DSkin.Controls.DSkinNewTextBox();
            this.newsSearch = new DSkin.Controls.DSkinButton();
            this.dSkinLabel3 = new DSkin.Controls.DSkinLabel();
            this.dSkinTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newsDetailList)).BeginInit();
            this.dSkinTableLayoutPanel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // dSkinTableLayoutPanel1
            // 
            this.dSkinTableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.dSkinTableLayoutPanel1.BitmapCache = false;
            this.dSkinTableLayoutPanel1.ColumnCount = 1;
            this.dSkinTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dSkinTableLayoutPanel1.Controls.Add(this.newsDetailList, 0, 1);
            this.dSkinTableLayoutPanel1.Controls.Add(this.dSkinTableLayoutPanel11, 0, 0);
            this.dSkinTableLayoutPanel1.Location = new System.Drawing.Point(3, 1);
            this.dSkinTableLayoutPanel1.Name = "dSkinTableLayoutPanel1";
            this.dSkinTableLayoutPanel1.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinTableLayoutPanel1.RightBottom")));
            this.dSkinTableLayoutPanel1.RowCount = 2;
            this.dSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.dSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.dSkinTableLayoutPanel1.Size = new System.Drawing.Size(793, 552);
            this.dSkinTableLayoutPanel1.TabIndex = 0;
            // 
            // newsDetailList
            // 
            // 
            // 
            // 
            this.newsDetailList.BackPageButton.AdaptImage = true;
            this.newsDetailList.BackPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.newsDetailList.BackPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.newsDetailList.BackPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newsDetailList.BackPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newsDetailList.BackPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.newsDetailList.BackPageButton.Location = new System.Drawing.Point(631, 4);
            this.newsDetailList.BackPageButton.Name = "BtnBackPage";
            this.newsDetailList.BackPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.newsDetailList.BackPageButton.Radius = 0;
            this.newsDetailList.BackPageButton.Size = new System.Drawing.Size(50, 24);
            this.newsDetailList.BackPageButton.Text = "上一页";
            this.newsDetailList.BackPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newsDetailList.BackPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.newsDetailList.Borders.AllColor = System.Drawing.Color.Silver;
            this.newsDetailList.Borders.BottomColor = System.Drawing.Color.Silver;
            this.newsDetailList.Borders.LeftColor = System.Drawing.Color.Silver;
            this.newsDetailList.Borders.RightColor = System.Drawing.Color.Silver;
            this.newsDetailList.Borders.TopColor = System.Drawing.Color.Silver;
            this.newsDetailList.ColumnHeadersVisible = false;
            this.newsDetailList.ColumnHeight = 30;
            dSkinGridListColumn1.Name = "Icon";
            dSkinGridListColumn1.Visble = true;
            dSkinGridListColumn1.Width = 60;
            dSkinGridListColumn2.Name = "Column";
            dSkinGridListColumn2.Visble = true;
            dSkinGridListColumn2.Width = 600;
            dSkinGridListColumn3.Name = "Column";
            dSkinGridListColumn3.Visble = true;
            dSkinGridListColumn3.Width = 100;
            this.newsDetailList.Columns.AddRange(new DSkin.Controls.DSkinGridListColumn[] {
            dSkinGridListColumn1,
            dSkinGridListColumn2,
            dSkinGridListColumn3});
            this.newsDetailList.DoubleItemsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.newsDetailList.EnabledOrder = false;
            // 
            // 
            // 
            this.newsDetailList.FirstPageButton.AdaptImage = true;
            this.newsDetailList.FirstPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.newsDetailList.FirstPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.newsDetailList.FirstPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newsDetailList.FirstPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newsDetailList.FirstPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.newsDetailList.FirstPageButton.Location = new System.Drawing.Point(583, 4);
            this.newsDetailList.FirstPageButton.Name = "BtnFistPage";
            this.newsDetailList.FirstPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.newsDetailList.FirstPageButton.Radius = 0;
            this.newsDetailList.FirstPageButton.Size = new System.Drawing.Size(44, 24);
            this.newsDetailList.FirstPageButton.Text = "首页";
            this.newsDetailList.FirstPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newsDetailList.FirstPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // 
            // 
            this.newsDetailList.GoPageButton.AdaptImage = true;
            this.newsDetailList.GoPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.newsDetailList.GoPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.newsDetailList.GoPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newsDetailList.GoPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newsDetailList.GoPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.newsDetailList.GoPageButton.Location = new System.Drawing.Point(290, 4);
            this.newsDetailList.GoPageButton.Name = "BtnGoPage";
            this.newsDetailList.GoPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.newsDetailList.GoPageButton.Radius = 0;
            this.newsDetailList.GoPageButton.Size = new System.Drawing.Size(44, 24);
            this.newsDetailList.GoPageButton.Text = "跳转";
            this.newsDetailList.GoPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newsDetailList.GoPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.newsDetailList.GridLineColor = System.Drawing.Color.Silver;
            this.newsDetailList.GridLineShowMode = DSkin.Controls.GridLineShowModes.Horizontal;
            this.newsDetailList.HeaderFont = new System.Drawing.Font("微软雅黑", 9F);
            this.newsDetailList.HoverItemsBackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.newsDetailList.HScrollBar.AutoSize = false;
            this.newsDetailList.HScrollBar.Fillet = true;
            this.newsDetailList.HScrollBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newsDetailList.HScrollBar.Location = new System.Drawing.Point(0, 422);
            this.newsDetailList.HScrollBar.Maximum = 74;
            this.newsDetailList.HScrollBar.Name = "";
            this.newsDetailList.HScrollBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.newsDetailList.HScrollBar.ScrollBarLenght = 695;
            this.newsDetailList.HScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.newsDetailList.HScrollBar.Size = new System.Drawing.Size(787, 12);
            this.newsDetailList.HScrollBar.Visible = false;
            // 
            // 
            // 
            this.newsDetailList.LastPageButton.AdaptImage = true;
            this.newsDetailList.LastPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.newsDetailList.LastPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.newsDetailList.LastPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newsDetailList.LastPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newsDetailList.LastPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.newsDetailList.LastPageButton.Location = new System.Drawing.Point(739, 4);
            this.newsDetailList.LastPageButton.Name = "BtnLastPage";
            this.newsDetailList.LastPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.newsDetailList.LastPageButton.Radius = 0;
            this.newsDetailList.LastPageButton.Size = new System.Drawing.Size(44, 24);
            this.newsDetailList.LastPageButton.Text = "末页";
            this.newsDetailList.LastPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newsDetailList.LastPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.newsDetailList.Location = new System.Drawing.Point(3, 85);
            this.newsDetailList.Name = "newsDetailList";
            // 
            // 
            // 
            this.newsDetailList.NextPageButton.AdaptImage = true;
            this.newsDetailList.NextPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.newsDetailList.NextPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.newsDetailList.NextPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newsDetailList.NextPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newsDetailList.NextPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.newsDetailList.NextPageButton.Location = new System.Drawing.Point(685, 4);
            this.newsDetailList.NextPageButton.Name = "BtnNextPage";
            this.newsDetailList.NextPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.newsDetailList.NextPageButton.Radius = 0;
            this.newsDetailList.NextPageButton.Size = new System.Drawing.Size(50, 24);
            this.newsDetailList.NextPageButton.Text = "下一页";
            this.newsDetailList.NextPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newsDetailList.NextPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.newsDetailList.PageSize = 7;
            this.newsDetailList.RowHeight = 60;
            this.newsDetailList.SelectedItem = null;
            this.newsDetailList.SelectedItemsBackColor = System.Drawing.Color.White;
            this.newsDetailList.Size = new System.Drawing.Size(787, 459);
            this.newsDetailList.TabIndex = 9;
            this.newsDetailList.Text = "dSkinGridList1";
            // 
            // 
            // 
            this.newsDetailList.VScrollBar.AutoSize = false;
            this.newsDetailList.VScrollBar.BitmapCache = true;
            this.newsDetailList.VScrollBar.Fillet = true;
            this.newsDetailList.VScrollBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newsDetailList.VScrollBar.LargeChange = 1000;
            this.newsDetailList.VScrollBar.Location = new System.Drawing.Point(774, 1);
            this.newsDetailList.VScrollBar.Margin = new System.Windows.Forms.Padding(1);
            this.newsDetailList.VScrollBar.Maximum = 10000;
            this.newsDetailList.VScrollBar.Name = "";
            this.newsDetailList.VScrollBar.ScrollBarLenght = 500;
            this.newsDetailList.VScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.newsDetailList.VScrollBar.Size = new System.Drawing.Size(12, 423);
            this.newsDetailList.VScrollBar.SmallChange = 500;
            this.newsDetailList.VScrollBar.Visible = false;
            this.newsDetailList.ItemClick += new System.EventHandler<DSkin.Controls.DSkinGridListMouseEventArgs>(this.newsDetailList_ItemClick);
            // 
            // dSkinTableLayoutPanel11
            // 
            this.dSkinTableLayoutPanel11.BackColor = System.Drawing.Color.White;
            this.dSkinTableLayoutPanel11.BitmapCache = false;
            this.dSkinTableLayoutPanel11.ColumnCount = 5;
            this.dSkinTableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.dSkinTableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.dSkinTableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.dSkinTableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dSkinTableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.dSkinTableLayoutPanel11.Controls.Add(this.newsEnd, 2, 0);
            this.dSkinTableLayoutPanel11.Controls.Add(this.newsStart, 0, 0);
            this.dSkinTableLayoutPanel11.Controls.Add(this.newsKeyword, 3, 0);
            this.dSkinTableLayoutPanel11.Controls.Add(this.newsSearch, 4, 0);
            this.dSkinTableLayoutPanel11.Controls.Add(this.dSkinLabel3, 1, 0);
            this.dSkinTableLayoutPanel11.Location = new System.Drawing.Point(20, 20);
            this.dSkinTableLayoutPanel11.Margin = new System.Windows.Forms.Padding(20, 20, 20, 3);
            this.dSkinTableLayoutPanel11.Name = "dSkinTableLayoutPanel11";
            this.dSkinTableLayoutPanel11.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinTableLayoutPanel11.RightBottom")));
            this.dSkinTableLayoutPanel11.RowCount = 1;
            this.dSkinTableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dSkinTableLayoutPanel11.Size = new System.Drawing.Size(753, 41);
            this.dSkinTableLayoutPanel11.TabIndex = 5;
            // 
            // newsEnd
            // 
            this.newsEnd.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newsEnd.Location = new System.Drawing.Point(175, 10);
            this.newsEnd.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.newsEnd.Name = "newsEnd";
            this.newsEnd.Size = new System.Drawing.Size(122, 23);
            this.newsEnd.TabIndex = 1;
            // 
            // newsStart
            // 
            this.newsStart.CustomFormat = "";
            this.newsStart.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newsStart.Location = new System.Drawing.Point(10, 10);
            this.newsStart.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.newsStart.Name = "newsStart";
            this.newsStart.Size = new System.Drawing.Size(122, 23);
            this.newsStart.TabIndex = 0;
            this.newsStart.Value = new System.DateTime(2000, 5, 21, 15, 28, 0, 0);
            // 
            // newsKeyword
            // 
            this.newsKeyword.BackColor = System.Drawing.Color.White;
            this.newsKeyword.Borders.AllColor = System.Drawing.Color.Black;
            this.newsKeyword.Borders.BottomColor = System.Drawing.Color.Black;
            this.newsKeyword.Borders.LeftColor = System.Drawing.Color.Black;
            this.newsKeyword.Borders.RightColor = System.Drawing.Color.Black;
            this.newsKeyword.Borders.TopColor = System.Drawing.Color.Black;
            this.newsKeyword.FocusedBorderColor = System.Drawing.Color.Empty;
            this.newsKeyword.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // 
            // 
            this.newsKeyword.InnerScrollBar.AutoSize = false;
            this.newsKeyword.InnerScrollBar.DesignModeCanMove = false;
            this.newsKeyword.InnerScrollBar.DesignModeCanResize = false;
            this.newsKeyword.InnerScrollBar.DesignModeCanSelect = false;
            this.newsKeyword.InnerScrollBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newsKeyword.InnerScrollBar.KeyChangeValue = false;
            this.newsKeyword.InnerScrollBar.Location = new System.Drawing.Point(353, 0);
            this.newsKeyword.InnerScrollBar.Name = "";
            this.newsKeyword.InnerScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.newsKeyword.InnerScrollBar.Size = new System.Drawing.Size(10, 23);
            this.newsKeyword.InnerScrollBar.SmallChange = 5;
            this.newsKeyword.InnerScrollBar.Visible = false;
            this.newsKeyword.Location = new System.Drawing.Point(310, 10);
            this.newsKeyword.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.newsKeyword.Name = "newsKeyword";
            this.newsKeyword.Size = new System.Drawing.Size(363, 23);
            this.newsKeyword.TabIndex = 2;
            this.newsKeyword.WaterFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newsKeyword.WaterText = "";
            this.newsKeyword.WaterTextOffset = new System.Drawing.Point(0, 0);
            // 
            // newsSearch
            // 
            this.newsSearch.ButtonBorderWidth = 1;
            this.newsSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.newsSearch.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newsSearch.HoverColor = System.Drawing.Color.Empty;
            this.newsSearch.HoverImage = null;
            this.newsSearch.Location = new System.Drawing.Point(686, 10);
            this.newsSearch.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.newsSearch.Name = "newsSearch";
            this.newsSearch.NormalImage = null;
            this.newsSearch.PressColor = System.Drawing.Color.Empty;
            this.newsSearch.PressedImage = null;
            this.newsSearch.Radius = 10;
            this.newsSearch.ShowButtonBorder = true;
            this.newsSearch.Size = new System.Drawing.Size(59, 23);
            this.newsSearch.TabIndex = 3;
            this.newsSearch.Text = "搜索";
            this.newsSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newsSearch.TextPadding = 0;
            this.newsSearch.Click += new System.EventHandler(this.newsSearch_Click);
            // 
            // dSkinLabel3
            // 
            this.dSkinLabel3.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel3.Location = new System.Drawing.Point(145, 10);
            this.dSkinLabel3.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.dSkinLabel3.Name = "dSkinLabel3";
            this.dSkinLabel3.Size = new System.Drawing.Size(17, 20);
            this.dSkinLabel3.TabIndex = 4;
            this.dSkinLabel3.Text = "至";
            // 
            // newsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 552);
            this.Controls.Add(this.dSkinTableLayoutPanel1);
            this.Name = "newsWindow";
            this.Text = "新闻资讯";
            this.dSkinTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.newsDetailList)).EndInit();
            this.dSkinTableLayoutPanel11.ResumeLayout(false);
            this.dSkinTableLayoutPanel11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DSkin.Controls.DSkinTableLayoutPanel dSkinTableLayoutPanel1;
        private DSkin.Controls.DSkinTableLayoutPanel dSkinTableLayoutPanel11;
        private DSkin.Controls.DSkinDateTimePicker newsEnd;
        private DSkin.Controls.DSkinDateTimePicker newsStart;
        private DSkin.Controls.DSkinNewTextBox newsKeyword;
        private DSkin.Controls.DSkinButton newsSearch;
        private DSkin.Controls.DSkinLabel dSkinLabel3;
        private DSkin.Controls.DSkinGridList newsDetailList;
    }
}