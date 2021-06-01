namespace quarantine_app
{
    partial class platWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(platWindow));
            this.dSkinTableLayoutPanel1 = new DSkin.Controls.DSkinTableLayoutPanel();
            this.platDetailList = new DSkin.Controls.DSkinGridList();
            this.dSkinTableLayoutPanel11 = new DSkin.Controls.DSkinTableLayoutPanel();
            this.platEnd = new DSkin.Controls.DSkinDateTimePicker();
            this.platStart = new DSkin.Controls.DSkinDateTimePicker();
            this.platKeyword = new DSkin.Controls.DSkinNewTextBox();
            this.platSearch = new DSkin.Controls.DSkinButton();
            this.dSkinLabel3 = new DSkin.Controls.DSkinLabel();
            this.dSkinTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.platDetailList)).BeginInit();
            this.dSkinTableLayoutPanel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // dSkinTableLayoutPanel1
            // 
            this.dSkinTableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.dSkinTableLayoutPanel1.BitmapCache = false;
            this.dSkinTableLayoutPanel1.ColumnCount = 1;
            this.dSkinTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dSkinTableLayoutPanel1.Controls.Add(this.platDetailList, 0, 1);
            this.dSkinTableLayoutPanel1.Controls.Add(this.dSkinTableLayoutPanel11, 0, 0);
            this.dSkinTableLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.dSkinTableLayoutPanel1.Name = "dSkinTableLayoutPanel1";
            this.dSkinTableLayoutPanel1.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinTableLayoutPanel1.RightBottom")));
            this.dSkinTableLayoutPanel1.RowCount = 2;
            this.dSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.dSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.dSkinTableLayoutPanel1.Size = new System.Drawing.Size(793, 552);
            this.dSkinTableLayoutPanel1.TabIndex = 1;
            // 
            // platDetailList
            // 
            // 
            // 
            // 
            this.platDetailList.BackPageButton.AdaptImage = true;
            this.platDetailList.BackPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.platDetailList.BackPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.platDetailList.BackPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.platDetailList.BackPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.platDetailList.BackPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.platDetailList.BackPageButton.Location = new System.Drawing.Point(631, 4);
            this.platDetailList.BackPageButton.Name = "BtnBackPage";
            this.platDetailList.BackPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.platDetailList.BackPageButton.Radius = 0;
            this.platDetailList.BackPageButton.Size = new System.Drawing.Size(50, 24);
            this.platDetailList.BackPageButton.Text = "上一页";
            this.platDetailList.BackPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.platDetailList.BackPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.platDetailList.Borders.AllColor = System.Drawing.Color.Silver;
            this.platDetailList.Borders.BottomColor = System.Drawing.Color.Silver;
            this.platDetailList.Borders.LeftColor = System.Drawing.Color.Silver;
            this.platDetailList.Borders.RightColor = System.Drawing.Color.Silver;
            this.platDetailList.Borders.TopColor = System.Drawing.Color.Silver;
            this.platDetailList.ColumnHeadersVisible = false;
            this.platDetailList.ColumnHeight = 30;
            dSkinGridListColumn1.Name = "Icon";
            dSkinGridListColumn1.Visble = true;
            dSkinGridListColumn1.Width = 60;
            dSkinGridListColumn2.Name = "Column";
            dSkinGridListColumn2.Visble = true;
            dSkinGridListColumn2.Width = 600;
            dSkinGridListColumn3.Name = "Column";
            dSkinGridListColumn3.Visble = true;
            dSkinGridListColumn3.Width = 100;
            this.platDetailList.Columns.AddRange(new DSkin.Controls.DSkinGridListColumn[] {
            dSkinGridListColumn1,
            dSkinGridListColumn2,
            dSkinGridListColumn3});
            this.platDetailList.DoubleItemsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.platDetailList.EnabledOrder = false;
            // 
            // 
            // 
            this.platDetailList.FirstPageButton.AdaptImage = true;
            this.platDetailList.FirstPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.platDetailList.FirstPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.platDetailList.FirstPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.platDetailList.FirstPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.platDetailList.FirstPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.platDetailList.FirstPageButton.Location = new System.Drawing.Point(583, 4);
            this.platDetailList.FirstPageButton.Name = "BtnFistPage";
            this.platDetailList.FirstPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.platDetailList.FirstPageButton.Radius = 0;
            this.platDetailList.FirstPageButton.Size = new System.Drawing.Size(44, 24);
            this.platDetailList.FirstPageButton.Text = "首页";
            this.platDetailList.FirstPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.platDetailList.FirstPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // 
            // 
            this.platDetailList.GoPageButton.AdaptImage = true;
            this.platDetailList.GoPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.platDetailList.GoPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.platDetailList.GoPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.platDetailList.GoPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.platDetailList.GoPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.platDetailList.GoPageButton.Location = new System.Drawing.Point(290, 4);
            this.platDetailList.GoPageButton.Name = "BtnGoPage";
            this.platDetailList.GoPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.platDetailList.GoPageButton.Radius = 0;
            this.platDetailList.GoPageButton.Size = new System.Drawing.Size(44, 24);
            this.platDetailList.GoPageButton.Text = "跳转";
            this.platDetailList.GoPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.platDetailList.GoPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.platDetailList.GridLineColor = System.Drawing.Color.Silver;
            this.platDetailList.GridLineShowMode = DSkin.Controls.GridLineShowModes.Horizontal;
            this.platDetailList.HeaderFont = new System.Drawing.Font("微软雅黑", 9F);
            this.platDetailList.HoverItemsBackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.platDetailList.HScrollBar.AutoSize = false;
            this.platDetailList.HScrollBar.Fillet = true;
            this.platDetailList.HScrollBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.platDetailList.HScrollBar.Location = new System.Drawing.Point(0, 422);
            this.platDetailList.HScrollBar.Maximum = 74;
            this.platDetailList.HScrollBar.Name = "";
            this.platDetailList.HScrollBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.platDetailList.HScrollBar.ScrollBarLenght = 695;
            this.platDetailList.HScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.platDetailList.HScrollBar.Size = new System.Drawing.Size(787, 12);
            this.platDetailList.HScrollBar.Visible = false;
            // 
            // 
            // 
            this.platDetailList.LastPageButton.AdaptImage = true;
            this.platDetailList.LastPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.platDetailList.LastPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.platDetailList.LastPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.platDetailList.LastPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.platDetailList.LastPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.platDetailList.LastPageButton.Location = new System.Drawing.Point(739, 4);
            this.platDetailList.LastPageButton.Name = "BtnLastPage";
            this.platDetailList.LastPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.platDetailList.LastPageButton.Radius = 0;
            this.platDetailList.LastPageButton.Size = new System.Drawing.Size(44, 24);
            this.platDetailList.LastPageButton.Text = "末页";
            this.platDetailList.LastPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.platDetailList.LastPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.platDetailList.Location = new System.Drawing.Point(3, 85);
            this.platDetailList.Name = "platDetailList";
            // 
            // 
            // 
            this.platDetailList.NextPageButton.AdaptImage = true;
            this.platDetailList.NextPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.platDetailList.NextPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.platDetailList.NextPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.platDetailList.NextPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.platDetailList.NextPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.platDetailList.NextPageButton.Location = new System.Drawing.Point(685, 4);
            this.platDetailList.NextPageButton.Name = "BtnNextPage";
            this.platDetailList.NextPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.platDetailList.NextPageButton.Radius = 0;
            this.platDetailList.NextPageButton.Size = new System.Drawing.Size(50, 24);
            this.platDetailList.NextPageButton.Text = "下一页";
            this.platDetailList.NextPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.platDetailList.NextPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.platDetailList.PageSize = 7;
            this.platDetailList.RowHeight = 60;
            this.platDetailList.SelectedItem = null;
            this.platDetailList.SelectedItemsBackColor = System.Drawing.Color.White;
            this.platDetailList.Size = new System.Drawing.Size(787, 459);
            this.platDetailList.TabIndex = 9;
            this.platDetailList.Text = "dSkinGridList1";
            // 
            // 
            // 
            this.platDetailList.VScrollBar.AutoSize = false;
            this.platDetailList.VScrollBar.BitmapCache = true;
            this.platDetailList.VScrollBar.Fillet = true;
            this.platDetailList.VScrollBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.platDetailList.VScrollBar.LargeChange = 1000;
            this.platDetailList.VScrollBar.Location = new System.Drawing.Point(774, 1);
            this.platDetailList.VScrollBar.Margin = new System.Windows.Forms.Padding(1);
            this.platDetailList.VScrollBar.Maximum = 10000;
            this.platDetailList.VScrollBar.Name = "";
            this.platDetailList.VScrollBar.ScrollBarLenght = 500;
            this.platDetailList.VScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.platDetailList.VScrollBar.Size = new System.Drawing.Size(12, 423);
            this.platDetailList.VScrollBar.SmallChange = 500;
            this.platDetailList.VScrollBar.Visible = false;
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
            this.dSkinTableLayoutPanel11.Controls.Add(this.platEnd, 2, 0);
            this.dSkinTableLayoutPanel11.Controls.Add(this.platStart, 0, 0);
            this.dSkinTableLayoutPanel11.Controls.Add(this.platKeyword, 3, 0);
            this.dSkinTableLayoutPanel11.Controls.Add(this.platSearch, 4, 0);
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
            // platEnd
            // 
            this.platEnd.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.platEnd.Location = new System.Drawing.Point(175, 10);
            this.platEnd.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.platEnd.Name = "platEnd";
            this.platEnd.Size = new System.Drawing.Size(122, 23);
            this.platEnd.TabIndex = 1;
            // 
            // platStart
            // 
            this.platStart.CustomFormat = "";
            this.platStart.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.platStart.Location = new System.Drawing.Point(10, 10);
            this.platStart.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.platStart.Name = "platStart";
            this.platStart.Size = new System.Drawing.Size(122, 23);
            this.platStart.TabIndex = 0;
            this.platStart.Value = new System.DateTime(2000, 1, 1, 15, 27, 0, 0);
            // 
            // platKeyword
            // 
            this.platKeyword.BackColor = System.Drawing.Color.White;
            this.platKeyword.Borders.AllColor = System.Drawing.Color.Black;
            this.platKeyword.Borders.BottomColor = System.Drawing.Color.Black;
            this.platKeyword.Borders.LeftColor = System.Drawing.Color.Black;
            this.platKeyword.Borders.RightColor = System.Drawing.Color.Black;
            this.platKeyword.Borders.TopColor = System.Drawing.Color.Black;
            this.platKeyword.FocusedBorderColor = System.Drawing.Color.Empty;
            this.platKeyword.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // 
            // 
            this.platKeyword.InnerScrollBar.AutoSize = false;
            this.platKeyword.InnerScrollBar.DesignModeCanMove = false;
            this.platKeyword.InnerScrollBar.DesignModeCanResize = false;
            this.platKeyword.InnerScrollBar.DesignModeCanSelect = false;
            this.platKeyword.InnerScrollBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.platKeyword.InnerScrollBar.KeyChangeValue = false;
            this.platKeyword.InnerScrollBar.Location = new System.Drawing.Point(353, 0);
            this.platKeyword.InnerScrollBar.Name = "";
            this.platKeyword.InnerScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.platKeyword.InnerScrollBar.Size = new System.Drawing.Size(10, 23);
            this.platKeyword.InnerScrollBar.SmallChange = 5;
            this.platKeyword.InnerScrollBar.Visible = false;
            this.platKeyword.Location = new System.Drawing.Point(310, 10);
            this.platKeyword.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.platKeyword.Name = "platKeyword";
            this.platKeyword.Size = new System.Drawing.Size(363, 23);
            this.platKeyword.TabIndex = 2;
            this.platKeyword.WaterFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.platKeyword.WaterText = "";
            this.platKeyword.WaterTextOffset = new System.Drawing.Point(0, 0);
            // 
            // platSearch
            // 
            this.platSearch.ButtonBorderWidth = 1;
            this.platSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.platSearch.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.platSearch.HoverColor = System.Drawing.Color.Empty;
            this.platSearch.HoverImage = null;
            this.platSearch.Location = new System.Drawing.Point(686, 10);
            this.platSearch.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.platSearch.Name = "platSearch";
            this.platSearch.NormalImage = null;
            this.platSearch.PressColor = System.Drawing.Color.Empty;
            this.platSearch.PressedImage = null;
            this.platSearch.Radius = 10;
            this.platSearch.ShowButtonBorder = true;
            this.platSearch.Size = new System.Drawing.Size(59, 23);
            this.platSearch.TabIndex = 3;
            this.platSearch.Text = "搜索";
            this.platSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.platSearch.TextPadding = 0;
            this.platSearch.Click += new System.EventHandler(this.platSearch_Click);
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
            // platWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(799, 552);
            this.Controls.Add(this.dSkinTableLayoutPanel1);
            this.Name = "platWindow";
            this.Text = "平台动态";
            this.dSkinTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.platDetailList)).EndInit();
            this.dSkinTableLayoutPanel11.ResumeLayout(false);
            this.dSkinTableLayoutPanel11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DSkin.Controls.DSkinTableLayoutPanel dSkinTableLayoutPanel1;
        private DSkin.Controls.DSkinGridList platDetailList;
        private DSkin.Controls.DSkinTableLayoutPanel dSkinTableLayoutPanel11;
        private DSkin.Controls.DSkinDateTimePicker platEnd;
        private DSkin.Controls.DSkinDateTimePicker platStart;
        private DSkin.Controls.DSkinNewTextBox platKeyword;
        private DSkin.Controls.DSkinButton platSearch;
        private DSkin.Controls.DSkinLabel dSkinLabel3;
    }
}