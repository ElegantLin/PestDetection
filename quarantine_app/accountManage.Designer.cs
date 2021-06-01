namespace quarantine_app
{
    partial class accountManage
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
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn1 = new DSkin.Controls.DSkinGridListColumn();
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn2 = new DSkin.Controls.DSkinGridListColumn();
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn3 = new DSkin.Controls.DSkinGridListColumn();
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn4 = new DSkin.Controls.DSkinGridListColumn();
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn5 = new DSkin.Controls.DSkinGridListColumn();
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn6 = new DSkin.Controls.DSkinGridListColumn();
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn7 = new DSkin.Controls.DSkinGridListColumn();
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn8 = new DSkin.Controls.DSkinGridListColumn();
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn9 = new DSkin.Controls.DSkinGridListColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(accountManage));
            this.dSkinTableLayoutPanel1 = new DSkin.Controls.DSkinTableLayoutPanel();
            this.accountLists = new DSkin.Controls.DSkinGridList();
            this.dSkinTableLayoutPanel2 = new DSkin.Controls.DSkinTableLayoutPanel();
            this.searchAccBtn = new DSkin.Controls.DSkinButton();
            this.accKeyword = new System.Windows.Forms.TextBox();
            this.accUpdate = new DSkin.Controls.DSkinButton();
            this.dSkinTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountLists)).BeginInit();
            this.dSkinTableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dSkinTableLayoutPanel1
            // 
            this.dSkinTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.dSkinTableLayoutPanel1.BitmapCache = false;
            this.dSkinTableLayoutPanel1.ColumnCount = 1;
            this.dSkinTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dSkinTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.dSkinTableLayoutPanel1.Controls.Add(this.accountLists, 0, 1);
            this.dSkinTableLayoutPanel1.Controls.Add(this.dSkinTableLayoutPanel2, 0, 0);
            this.dSkinTableLayoutPanel1.Location = new System.Drawing.Point(19, 17);
            this.dSkinTableLayoutPanel1.Name = "dSkinTableLayoutPanel1";
            this.dSkinTableLayoutPanel1.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinTableLayoutPanel1.RightBottom")));
            this.dSkinTableLayoutPanel1.RowCount = 2;
            this.dSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.dSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.dSkinTableLayoutPanel1.Size = new System.Drawing.Size(750, 531);
            this.dSkinTableLayoutPanel1.TabIndex = 0;
            // 
            // accountLists
            // 
            // 
            // 
            // 
            this.accountLists.BackPageButton.AdaptImage = true;
            this.accountLists.BackPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.accountLists.BackPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.accountLists.BackPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.accountLists.BackPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.accountLists.BackPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.accountLists.BackPageButton.Location = new System.Drawing.Point(571, 4);
            this.accountLists.BackPageButton.Name = "BtnBackPage";
            this.accountLists.BackPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.accountLists.BackPageButton.Radius = 0;
            this.accountLists.BackPageButton.Size = new System.Drawing.Size(50, 24);
            this.accountLists.BackPageButton.Text = "上一页";
            this.accountLists.BackPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.accountLists.BackPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.accountLists.Borders.AllColor = System.Drawing.Color.Silver;
            this.accountLists.Borders.BottomColor = System.Drawing.Color.Silver;
            this.accountLists.Borders.LeftColor = System.Drawing.Color.Silver;
            this.accountLists.Borders.RightColor = System.Drawing.Color.Silver;
            this.accountLists.Borders.TopColor = System.Drawing.Color.Silver;
            this.accountLists.ColumnHeight = 30;
            dSkinGridListColumn1.Name = "用户名";
            dSkinGridListColumn1.Visble = true;
            dSkinGridListColumn1.Width = 60;
            dSkinGridListColumn2.Name = "密码";
            dSkinGridListColumn2.Visble = true;
            dSkinGridListColumn2.Width = 90;
            dSkinGridListColumn3.Name = "人员类别";
            dSkinGridListColumn3.Visble = true;
            dSkinGridListColumn3.Width = 80;
            dSkinGridListColumn4.Name = "人员姓名";
            dSkinGridListColumn4.Visble = true;
            dSkinGridListColumn4.Width = 80;
            dSkinGridListColumn5.Name = "单位";
            dSkinGridListColumn5.Visble = true;
            dSkinGridListColumn5.Width = 120;
            dSkinGridListColumn6.Name = "擅长领域";
            dSkinGridListColumn6.Visble = true;
            dSkinGridListColumn6.Width = 80;
            dSkinGridListColumn7.Name = "从业年限";
            dSkinGridListColumn7.Visble = true;
            dSkinGridListColumn7.Width = 75;
            dSkinGridListColumn8.Name = "职称";
            dSkinGridListColumn8.Visble = true;
            dSkinGridListColumn8.Width = 80;
            dSkinGridListColumn9.Name = "角色";
            dSkinGridListColumn9.Visble = true;
            dSkinGridListColumn9.Width = 60;
            this.accountLists.Columns.AddRange(new DSkin.Controls.DSkinGridListColumn[] {
            dSkinGridListColumn1,
            dSkinGridListColumn2,
            dSkinGridListColumn3,
            dSkinGridListColumn4,
            dSkinGridListColumn5,
            dSkinGridListColumn6,
            dSkinGridListColumn7,
            dSkinGridListColumn8,
            dSkinGridListColumn9});
            this.accountLists.DoubleItemsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.accountLists.EnabledOrder = false;
            // 
            // 
            // 
            this.accountLists.FirstPageButton.AdaptImage = true;
            this.accountLists.FirstPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.accountLists.FirstPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.accountLists.FirstPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.accountLists.FirstPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.accountLists.FirstPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.accountLists.FirstPageButton.Location = new System.Drawing.Point(523, 4);
            this.accountLists.FirstPageButton.Name = "BtnFistPage";
            this.accountLists.FirstPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.accountLists.FirstPageButton.Radius = 0;
            this.accountLists.FirstPageButton.Size = new System.Drawing.Size(44, 24);
            this.accountLists.FirstPageButton.Text = "首页";
            this.accountLists.FirstPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.accountLists.FirstPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // 
            // 
            this.accountLists.GoPageButton.AdaptImage = true;
            this.accountLists.GoPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.accountLists.GoPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.accountLists.GoPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.accountLists.GoPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.accountLists.GoPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.accountLists.GoPageButton.Location = new System.Drawing.Point(290, 4);
            this.accountLists.GoPageButton.Name = "BtnGoPage";
            this.accountLists.GoPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.accountLists.GoPageButton.Radius = 0;
            this.accountLists.GoPageButton.Size = new System.Drawing.Size(44, 24);
            this.accountLists.GoPageButton.Text = "跳转";
            this.accountLists.GoPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.accountLists.GoPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.accountLists.GridLineColor = System.Drawing.Color.Silver;
            this.accountLists.HeaderFont = new System.Drawing.Font("微软雅黑", 9F);
            // 
            // 
            // 
            this.accountLists.HScrollBar.AutoSize = false;
            this.accountLists.HScrollBar.Fillet = true;
            this.accountLists.HScrollBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.accountLists.HScrollBar.Location = new System.Drawing.Point(0, 409);
            this.accountLists.HScrollBar.Maximum = 19;
            this.accountLists.HScrollBar.Name = "";
            this.accountLists.HScrollBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.accountLists.HScrollBar.ScrollBarLenght = 684;
            this.accountLists.HScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.accountLists.HScrollBar.Size = new System.Drawing.Size(727, 12);
            this.accountLists.HScrollBar.Visible = false;
            // 
            // 
            // 
            this.accountLists.LastPageButton.AdaptImage = true;
            this.accountLists.LastPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.accountLists.LastPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.accountLists.LastPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.accountLists.LastPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.accountLists.LastPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.accountLists.LastPageButton.Location = new System.Drawing.Point(679, 4);
            this.accountLists.LastPageButton.Name = "BtnLastPage";
            this.accountLists.LastPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.accountLists.LastPageButton.Radius = 0;
            this.accountLists.LastPageButton.Size = new System.Drawing.Size(44, 24);
            this.accountLists.LastPageButton.Text = "末页";
            this.accountLists.LastPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.accountLists.LastPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.accountLists.Location = new System.Drawing.Point(20, 73);
            this.accountLists.Margin = new System.Windows.Forms.Padding(20, 20, 3, 3);
            this.accountLists.Name = "accountLists";
            // 
            // 
            // 
            this.accountLists.NextPageButton.AdaptImage = true;
            this.accountLists.NextPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.accountLists.NextPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.accountLists.NextPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.accountLists.NextPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.accountLists.NextPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.accountLists.NextPageButton.Location = new System.Drawing.Point(625, 4);
            this.accountLists.NextPageButton.Name = "BtnNextPage";
            this.accountLists.NextPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.accountLists.NextPageButton.Radius = 0;
            this.accountLists.NextPageButton.Size = new System.Drawing.Size(50, 24);
            this.accountLists.NextPageButton.Text = "下一页";
            this.accountLists.NextPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.accountLists.NextPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.accountLists.PageSize = 13;
            this.accountLists.SelectedItem = null;
            this.accountLists.Size = new System.Drawing.Size(727, 453);
            this.accountLists.TabIndex = 1;
            this.accountLists.Text = "dSkinGridList1";
            // 
            // 
            // 
            this.accountLists.VScrollBar.AutoSize = false;
            this.accountLists.VScrollBar.BitmapCache = true;
            this.accountLists.VScrollBar.Fillet = true;
            this.accountLists.VScrollBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.accountLists.VScrollBar.LargeChange = 1000;
            this.accountLists.VScrollBar.Location = new System.Drawing.Point(714, 1);
            this.accountLists.VScrollBar.Margin = new System.Windows.Forms.Padding(1);
            this.accountLists.VScrollBar.Maximum = 10000;
            this.accountLists.VScrollBar.Name = "";
            this.accountLists.VScrollBar.ScrollBarLenght = 360;
            this.accountLists.VScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.accountLists.VScrollBar.Size = new System.Drawing.Size(12, 388);
            this.accountLists.VScrollBar.SmallChange = 500;
            this.accountLists.VScrollBar.Visible = false;
            this.accountLists.ItemDoubleClick += new System.EventHandler<DSkin.Controls.DSkinGridListMouseEventArgs>(this.accountLists_ItemDoubleClick);
            // 
            // dSkinTableLayoutPanel2
            // 
            this.dSkinTableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.dSkinTableLayoutPanel2.BitmapCache = false;
            this.dSkinTableLayoutPanel2.ColumnCount = 3;
            this.dSkinTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dSkinTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.30536F));
            this.dSkinTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.76341F));
            this.dSkinTableLayoutPanel2.Controls.Add(this.searchAccBtn, 0, 0);
            this.dSkinTableLayoutPanel2.Controls.Add(this.accKeyword, 0, 0);
            this.dSkinTableLayoutPanel2.Controls.Add(this.accUpdate, 1, 0);
            this.dSkinTableLayoutPanel2.Location = new System.Drawing.Point(20, 3);
            this.dSkinTableLayoutPanel2.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.dSkinTableLayoutPanel2.Name = "dSkinTableLayoutPanel2";
            this.dSkinTableLayoutPanel2.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinTableLayoutPanel2.RightBottom")));
            this.dSkinTableLayoutPanel2.RowCount = 1;
            this.dSkinTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dSkinTableLayoutPanel2.Size = new System.Drawing.Size(727, 47);
            this.dSkinTableLayoutPanel2.TabIndex = 2;
            // 
            // searchAccBtn
            // 
            this.searchAccBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchAccBtn.ButtonBorderWidth = 1;
            this.searchAccBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.searchAccBtn.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.searchAccBtn.HoverColor = System.Drawing.Color.Empty;
            this.searchAccBtn.HoverImage = null;
            this.searchAccBtn.Location = new System.Drawing.Point(383, 18);
            this.searchAccBtn.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.searchAccBtn.Name = "searchAccBtn";
            this.searchAccBtn.NormalImage = null;
            this.searchAccBtn.PressColor = System.Drawing.Color.Empty;
            this.searchAccBtn.PressedImage = null;
            this.searchAccBtn.Radius = 10;
            this.searchAccBtn.ShowButtonBorder = true;
            this.searchAccBtn.Size = new System.Drawing.Size(80, 26);
            this.searchAccBtn.TabIndex = 2;
            this.searchAccBtn.Text = "查 询";
            this.searchAccBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.searchAccBtn.TextPadding = 0;
            this.searchAccBtn.Click += new System.EventHandler(this.searchAccBtn_Click);
            // 
            // accKeyword
            // 
            this.accKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.accKeyword.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.accKeyword.Location = new System.Drawing.Point(3, 19);
            this.accKeyword.Name = "accKeyword";
            this.accKeyword.Size = new System.Drawing.Size(357, 25);
            this.accKeyword.TabIndex = 0;
            // 
            // accUpdate
            // 
            this.accUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.accUpdate.ButtonBorderWidth = 1;
            this.accUpdate.DialogResult = System.Windows.Forms.DialogResult.None;
            this.accUpdate.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.accUpdate.HoverColor = System.Drawing.Color.Empty;
            this.accUpdate.HoverImage = null;
            this.accUpdate.Location = new System.Drawing.Point(486, 18);
            this.accUpdate.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.accUpdate.Name = "accUpdate";
            this.accUpdate.NormalImage = null;
            this.accUpdate.PressColor = System.Drawing.Color.Empty;
            this.accUpdate.PressedImage = null;
            this.accUpdate.Radius = 10;
            this.accUpdate.ShowButtonBorder = true;
            this.accUpdate.Size = new System.Drawing.Size(80, 26);
            this.accUpdate.TabIndex = 1;
            this.accUpdate.Text = "更 新";
            this.accUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.accUpdate.TextPadding = 0;
            this.accUpdate.Click += new System.EventHandler(this.accUpdate_Click);
            // 
            // accountManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dSkinTableLayoutPanel1);
            this.Location = new System.Drawing.Point(207, 10);
            this.Name = "accountManage";
            this.Size = new System.Drawing.Size(788, 570);
            this.dSkinTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accountLists)).EndInit();
            this.dSkinTableLayoutPanel2.ResumeLayout(false);
            this.dSkinTableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DSkin.Controls.DSkinTableLayoutPanel dSkinTableLayoutPanel1;
        private DSkin.Controls.DSkinGridList accountLists;
        private DSkin.Controls.DSkinTableLayoutPanel dSkinTableLayoutPanel2;
        private System.Windows.Forms.TextBox accKeyword;
        private DSkin.Controls.DSkinButton accUpdate;
        private DSkin.Controls.DSkinButton searchAccBtn;
    }
}
