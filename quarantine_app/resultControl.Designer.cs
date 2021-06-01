namespace quarantine_app
{
    partial class resultControl
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
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn10 = new DSkin.Controls.DSkinGridListColumn();
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn11 = new DSkin.Controls.DSkinGridListColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(resultControl));
            this.dSkinTableLayoutPanel1 = new DSkin.Controls.DSkinTableLayoutPanel();
            this.resultsList = new DSkin.Controls.DSkinGridList();
            this.dSkinPanel1 = new DSkin.Controls.DSkinPanel();
            this.dSkinTableLayoutPanel4 = new DSkin.Controls.DSkinTableLayoutPanel();
            this.waySelector = new DSkin.Controls.DSkinComboBox();
            this.authStatus = new DSkin.Controls.DSkinComboBox();
            this.dSkinTableLayoutPanel5 = new DSkin.Controls.DSkinTableLayoutPanel();
            this.resEnd = new DSkin.Controls.DSkinDateTimePicker();
            this.resStart = new DSkin.Controls.DSkinDateTimePicker();
            this.resKeyword = new DSkin.Controls.DSkinTextBox();
            this.resSearchBtn = new DSkin.Controls.DSkinButton();
            this.dSkinLabel1 = new DSkin.Controls.DSkinLabel();
            this.dSkinTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsList)).BeginInit();
            this.dSkinPanel1.SuspendLayout();
            this.dSkinTableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waySelector.InnerListBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authStatus.InnerListBox)).BeginInit();
            this.dSkinTableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dSkinTableLayoutPanel1
            // 
            this.dSkinTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.dSkinTableLayoutPanel1.BitmapCache = false;
            this.dSkinTableLayoutPanel1.ColumnCount = 1;
            this.dSkinTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dSkinTableLayoutPanel1.Controls.Add(this.resultsList, 0, 1);
            this.dSkinTableLayoutPanel1.Controls.Add(this.dSkinPanel1, 0, 0);
            this.dSkinTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dSkinTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.dSkinTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dSkinTableLayoutPanel1.Name = "dSkinTableLayoutPanel1";
            this.dSkinTableLayoutPanel1.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinTableLayoutPanel1.RightBottom")));
            this.dSkinTableLayoutPanel1.RowCount = 2;
            this.dSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dSkinTableLayoutPanel1.Size = new System.Drawing.Size(1051, 712);
            this.dSkinTableLayoutPanel1.TabIndex = 1;
            // 
            // resultsList
            // 
            // 
            // 
            // 
            this.resultsList.BackPageButton.AdaptImage = true;
            this.resultsList.BackPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.resultsList.BackPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.resultsList.BackPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resultsList.BackPageButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resultsList.BackPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.resultsList.BackPageButton.Location = new System.Drawing.Point(875, 4);
            this.resultsList.BackPageButton.Name = "BtnBackPage";
            this.resultsList.BackPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.resultsList.BackPageButton.Radius = 0;
            this.resultsList.BackPageButton.Size = new System.Drawing.Size(50, 24);
            this.resultsList.BackPageButton.Text = "上一页";
            this.resultsList.BackPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.resultsList.BackPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.resultsList.Borders.AllColor = System.Drawing.Color.Silver;
            this.resultsList.Borders.BottomColor = System.Drawing.Color.Silver;
            this.resultsList.Borders.LeftColor = System.Drawing.Color.Silver;
            this.resultsList.Borders.RightColor = System.Drawing.Color.Silver;
            this.resultsList.Borders.TopColor = System.Drawing.Color.Silver;
            this.resultsList.ColumnFill = true;
            this.resultsList.ColumnHeight = 30;
            dSkinGridListColumn1.Name = "鉴定编号";
            dSkinGridListColumn1.Visble = true;
            dSkinGridListColumn1.Width = 93;
            dSkinGridListColumn2.Name = "申请单位";
            dSkinGridListColumn2.Visble = true;
            dSkinGridListColumn2.Width = 93;
            dSkinGridListColumn3.Name = "申请人";
            dSkinGridListColumn3.Visble = true;
            dSkinGridListColumn3.Width = 93;
            dSkinGridListColumn4.Name = "申请日期";
            dSkinGridListColumn4.Visble = true;
            dSkinGridListColumn4.Width = 93;
            dSkinGridListColumn5.Name = "样品类别";
            dSkinGridListColumn5.Visble = true;
            dSkinGridListColumn5.Width = 93;
            dSkinGridListColumn6.Name = "货物";
            dSkinGridListColumn6.Visble = true;
            dSkinGridListColumn6.Width = 93;
            dSkinGridListColumn7.Name = "来源国";
            dSkinGridListColumn7.Visble = true;
            dSkinGridListColumn7.Width = 93;
            dSkinGridListColumn8.Name = "截获地点";
            dSkinGridListColumn8.Visble = true;
            dSkinGridListColumn8.Width = 93;
            dSkinGridListColumn9.Name = "鉴定方式";
            dSkinGridListColumn9.Visble = true;
            dSkinGridListColumn9.Width = 93;
            dSkinGridListColumn10.Name = "鉴定状态";
            dSkinGridListColumn10.Visble = true;
            dSkinGridListColumn10.Width = 93;
            dSkinGridListColumn11.Name = "鉴定结果";
            dSkinGridListColumn11.Visble = true;
            dSkinGridListColumn11.Width = 100;
            this.resultsList.Columns.AddRange(new DSkin.Controls.DSkinGridListColumn[] {
            dSkinGridListColumn1,
            dSkinGridListColumn2,
            dSkinGridListColumn3,
            dSkinGridListColumn4,
            dSkinGridListColumn5,
            dSkinGridListColumn6,
            dSkinGridListColumn7,
            dSkinGridListColumn8,
            dSkinGridListColumn9,
            dSkinGridListColumn10,
            dSkinGridListColumn11});
            this.resultsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsList.DoubleItemsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.resultsList.EnabledOrder = false;
            // 
            // 
            // 
            this.resultsList.FirstPageButton.AdaptImage = true;
            this.resultsList.FirstPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.resultsList.FirstPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.resultsList.FirstPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resultsList.FirstPageButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resultsList.FirstPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.resultsList.FirstPageButton.Location = new System.Drawing.Point(827, 4);
            this.resultsList.FirstPageButton.Name = "BtnFistPage";
            this.resultsList.FirstPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.resultsList.FirstPageButton.Radius = 0;
            this.resultsList.FirstPageButton.Size = new System.Drawing.Size(44, 24);
            this.resultsList.FirstPageButton.Text = "首页";
            this.resultsList.FirstPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.resultsList.FirstPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // 
            // 
            this.resultsList.GoPageButton.AdaptImage = true;
            this.resultsList.GoPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.resultsList.GoPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.resultsList.GoPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resultsList.GoPageButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resultsList.GoPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.resultsList.GoPageButton.Location = new System.Drawing.Point(348, 4);
            this.resultsList.GoPageButton.Name = "BtnGoPage";
            this.resultsList.GoPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.resultsList.GoPageButton.Radius = 0;
            this.resultsList.GoPageButton.Size = new System.Drawing.Size(44, 24);
            this.resultsList.GoPageButton.Text = "跳转";
            this.resultsList.GoPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.resultsList.GoPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.resultsList.GridLineColor = System.Drawing.Color.Silver;
            this.resultsList.HeaderFont = new System.Drawing.Font("Microsoft YaHei", 9F);
            // 
            // 
            // 
            this.resultsList.HScrollBar.AutoSize = false;
            this.resultsList.HScrollBar.Fillet = true;
            this.resultsList.HScrollBar.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resultsList.HScrollBar.Location = new System.Drawing.Point(0, 570);
            this.resultsList.HScrollBar.Maximum = 2;
            this.resultsList.HScrollBar.Name = "";
            this.resultsList.HScrollBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.resultsList.HScrollBar.ScrollBarLenght = 1005;
            this.resultsList.HScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.resultsList.HScrollBar.Size = new System.Drawing.Size(1031, 12);
            this.resultsList.HScrollBar.Visible = false;
            // 
            // 
            // 
            this.resultsList.LastPageButton.AdaptImage = true;
            this.resultsList.LastPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.resultsList.LastPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.resultsList.LastPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resultsList.LastPageButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resultsList.LastPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.resultsList.LastPageButton.Location = new System.Drawing.Point(983, 4);
            this.resultsList.LastPageButton.Name = "BtnLastPage";
            this.resultsList.LastPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.resultsList.LastPageButton.Radius = 0;
            this.resultsList.LastPageButton.Size = new System.Drawing.Size(44, 24);
            this.resultsList.LastPageButton.Text = "末页";
            this.resultsList.LastPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.resultsList.LastPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.resultsList.Location = new System.Drawing.Point(10, 93);
            this.resultsList.Margin = new System.Windows.Forms.Padding(10);
            this.resultsList.Name = "resultsList";
            // 
            // 
            // 
            this.resultsList.NextPageButton.AdaptImage = true;
            this.resultsList.NextPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.resultsList.NextPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.resultsList.NextPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resultsList.NextPageButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resultsList.NextPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.resultsList.NextPageButton.Location = new System.Drawing.Point(929, 4);
            this.resultsList.NextPageButton.Name = "BtnNextPage";
            this.resultsList.NextPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.resultsList.NextPageButton.Radius = 0;
            this.resultsList.NextPageButton.Size = new System.Drawing.Size(50, 24);
            this.resultsList.NextPageButton.Text = "下一页";
            this.resultsList.NextPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.resultsList.NextPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.resultsList.PageSize = 14;
            this.resultsList.SelectedItem = null;
            this.resultsList.Size = new System.Drawing.Size(1031, 614);
            this.resultsList.TabIndex = 1;
            this.resultsList.Text = "dSkinGridList1";
            // 
            // 
            // 
            this.resultsList.VScrollBar.AutoSize = false;
            this.resultsList.VScrollBar.BitmapCache = true;
            this.resultsList.VScrollBar.Fillet = true;
            this.resultsList.VScrollBar.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resultsList.VScrollBar.LargeChange = 1000;
            this.resultsList.VScrollBar.Location = new System.Drawing.Point(1018, 1);
            this.resultsList.VScrollBar.Margin = new System.Windows.Forms.Padding(1);
            this.resultsList.VScrollBar.Maximum = 10000;
            this.resultsList.VScrollBar.Name = "";
            this.resultsList.VScrollBar.ScrollBarLenght = 394;
            this.resultsList.VScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.resultsList.VScrollBar.Size = new System.Drawing.Size(12, 549);
            this.resultsList.VScrollBar.SmallChange = 500;
            this.resultsList.VScrollBar.Visible = false;
            this.resultsList.ItemClick += new System.EventHandler<DSkin.Controls.DSkinGridListMouseEventArgs>(this.resultsList_ItemClick);
            // 
            // dSkinPanel1
            // 
            this.dSkinPanel1.BackColor = System.Drawing.Color.White;
            this.dSkinPanel1.Controls.Add(this.dSkinTableLayoutPanel4);
            this.dSkinPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dSkinPanel1.DuiBackgroundRender.BorderColor = System.Drawing.Color.White;
            this.dSkinPanel1.DuiBackgroundRender.Radius = 20;
            this.dSkinPanel1.DuiBackgroundRender.RenderBorders = true;
            this.dSkinPanel1.Location = new System.Drawing.Point(4, 4);
            this.dSkinPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dSkinPanel1.Name = "dSkinPanel1";
            this.dSkinPanel1.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinPanel1.RightBottom")));
            this.dSkinPanel1.Size = new System.Drawing.Size(1043, 75);
            this.dSkinPanel1.TabIndex = 2;
            this.dSkinPanel1.Text = "dSkinPanel1";
            // 
            // dSkinTableLayoutPanel4
            // 
            this.dSkinTableLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
            this.dSkinTableLayoutPanel4.BitmapCache = false;
            this.dSkinTableLayoutPanel4.ColumnCount = 6;
            this.dSkinTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.81481F));
            this.dSkinTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.81481F));
            this.dSkinTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.259259F));
            this.dSkinTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.48148F));
            this.dSkinTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.dSkinTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.407407F));
            this.dSkinTableLayoutPanel4.Controls.Add(this.waySelector, 0, 0);
            this.dSkinTableLayoutPanel4.Controls.Add(this.authStatus, 0, 0);
            this.dSkinTableLayoutPanel4.Controls.Add(this.dSkinTableLayoutPanel5, 3, 0);
            this.dSkinTableLayoutPanel4.Controls.Add(this.resKeyword, 4, 0);
            this.dSkinTableLayoutPanel4.Controls.Add(this.resSearchBtn, 5, 0);
            this.dSkinTableLayoutPanel4.Controls.Add(this.dSkinLabel1, 2, 0);
            this.dSkinTableLayoutPanel4.Location = new System.Drawing.Point(4, 10);
            this.dSkinTableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 19, 4, 4);
            this.dSkinTableLayoutPanel4.Name = "dSkinTableLayoutPanel4";
            this.dSkinTableLayoutPanel4.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinTableLayoutPanel4.RightBottom")));
            this.dSkinTableLayoutPanel4.RowCount = 1;
            this.dSkinTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dSkinTableLayoutPanel4.Size = new System.Drawing.Size(1027, 61);
            this.dSkinTableLayoutPanel4.TabIndex = 1;
            // 
            // waySelector
            // 
            this.waySelector.AutoDrawSelecedItem = true;
            this.waySelector.ButtonBorderWidth = 1;
            this.waySelector.DialogResult = System.Windows.Forms.DialogResult.None;
            this.waySelector.DisplayMember = null;
            this.waySelector.Font = new System.Drawing.Font("YouYuan", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.waySelector.HoverColor = System.Drawing.Color.Empty;
            this.waySelector.HoverImage = null;
            // 
            // 
            // 
            this.waySelector.InnerListBox.BackColor = System.Drawing.Color.Transparent;
            this.waySelector.InnerListBox.Borders.AllColor = System.Drawing.Color.Silver;
            this.waySelector.InnerListBox.Borders.BottomColor = System.Drawing.Color.Silver;
            this.waySelector.InnerListBox.Borders.LeftColor = System.Drawing.Color.Silver;
            this.waySelector.InnerListBox.Borders.RightColor = System.Drawing.Color.Silver;
            this.waySelector.InnerListBox.Borders.TopColor = System.Drawing.Color.Silver;
            this.waySelector.InnerListBox.Location = new System.Drawing.Point(0, 0);
            this.waySelector.InnerListBox.Name = "";
            this.waySelector.InnerListBox.ScrollBarWidth = 12;
            this.waySelector.InnerListBox.TabIndex = 0;
            this.waySelector.InnerListBox.Value = 0D;
            this.waySelector.IsDrawText = false;
            this.waySelector.ItemHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.waySelector.Location = new System.Drawing.Point(165, 16);
            this.waySelector.Margin = new System.Windows.Forms.Padding(13, 16, 4, 4);
            this.waySelector.Name = "waySelector";
            this.waySelector.NormalImage = null;
            this.waySelector.PaddingLeft = 2;
            this.waySelector.PressColor = System.Drawing.Color.Empty;
            this.waySelector.PressedImage = null;
            this.waySelector.Radius = 0;
            this.waySelector.SelectedIndex = -1;
            this.waySelector.ShowArrow = true;
            this.waySelector.ShowButtonBorder = true;
            this.waySelector.Size = new System.Drawing.Size(133, 31);
            this.waySelector.TabIndex = 7;
            this.waySelector.Text = "dSkinComboBox2";
            this.waySelector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.waySelector.TextPadding = 3;
            // 
            // 
            // 
            this.waySelector.ToolStripDropDown.BorderColor = System.Drawing.Color.DarkGray;
            this.waySelector.ToolStripDropDown.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.waySelector.ToolStripDropDown.MinimumSize = new System.Drawing.Size(18, 18);
            this.waySelector.ToolStripDropDown.Name = "";
            this.waySelector.ToolStripDropDown.Padding = new System.Windows.Forms.Padding(0);
            this.waySelector.ToolStripDropDown.Resizable = false;
            this.waySelector.ToolStripDropDown.ResizeGridColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.waySelector.ToolStripDropDown.ResizeGridSize = new System.Drawing.Size(16, 16);
            this.waySelector.ToolStripDropDown.Size = new System.Drawing.Size(18, 18);
            this.waySelector.ToolStripDropDown.WhereIsResizeGrid = DSkin.ResizeGridLocation.BottomRight;
            this.waySelector.ValueMember = null;
            // 
            // authStatus
            // 
            this.authStatus.AutoDrawSelecedItem = true;
            this.authStatus.ButtonBorderWidth = 1;
            this.authStatus.DialogResult = System.Windows.Forms.DialogResult.None;
            this.authStatus.DisplayMember = null;
            this.authStatus.Font = new System.Drawing.Font("YouYuan", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.authStatus.HoverColor = System.Drawing.Color.Empty;
            this.authStatus.HoverImage = null;
            // 
            // 
            // 
            this.authStatus.InnerListBox.Location = new System.Drawing.Point(0, 0);
            this.authStatus.InnerListBox.Name = "";
            this.authStatus.InnerListBox.Size = new System.Drawing.Size(0, 25);
            this.authStatus.InnerListBox.TabIndex = 0;
            this.authStatus.InnerListBox.Value = 0D;
            this.authStatus.IsDrawText = false;
            this.authStatus.ItemHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.authStatus.Location = new System.Drawing.Point(13, 16);
            this.authStatus.Margin = new System.Windows.Forms.Padding(13, 16, 4, 4);
            this.authStatus.Name = "authStatus";
            this.authStatus.NormalImage = null;
            this.authStatus.PaddingLeft = 2;
            this.authStatus.PressColor = System.Drawing.Color.Empty;
            this.authStatus.PressedImage = null;
            this.authStatus.Radius = 0;
            this.authStatus.SelectedIndex = -1;
            this.authStatus.ShowArrow = true;
            this.authStatus.ShowButtonBorder = true;
            this.authStatus.Size = new System.Drawing.Size(133, 31);
            this.authStatus.TabIndex = 6;
            this.authStatus.Text = "dSkinComboBox1";
            this.authStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.authStatus.TextPadding = 3;
            // 
            // 
            // 
            this.authStatus.ToolStripDropDown.BorderColor = System.Drawing.Color.DarkGray;
            this.authStatus.ToolStripDropDown.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.authStatus.ToolStripDropDown.MinimumSize = new System.Drawing.Size(0, 0);
            this.authStatus.ToolStripDropDown.Name = "";
            this.authStatus.ToolStripDropDown.Resizable = false;
            this.authStatus.ToolStripDropDown.ResizeGridColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.authStatus.ToolStripDropDown.ResizeGridSize = new System.Drawing.Size(16, 16);
            this.authStatus.ToolStripDropDown.Size = new System.Drawing.Size(2, 25);
            this.authStatus.ToolStripDropDown.WhereIsResizeGrid = DSkin.ResizeGridLocation.BottomRight;
            this.authStatus.ValueMember = null;
            // 
            // dSkinTableLayoutPanel5
            // 
            this.dSkinTableLayoutPanel5.BackColor = System.Drawing.Color.Transparent;
            this.dSkinTableLayoutPanel5.BitmapCache = false;
            this.dSkinTableLayoutPanel5.ColumnCount = 2;
            this.dSkinTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dSkinTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dSkinTableLayoutPanel5.Controls.Add(this.resEnd, 1, 0);
            this.dSkinTableLayoutPanel5.Controls.Add(this.resStart, 0, 0);
            this.dSkinTableLayoutPanel5.Location = new System.Drawing.Point(403, 4);
            this.dSkinTableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dSkinTableLayoutPanel5.Name = "dSkinTableLayoutPanel5";
            this.dSkinTableLayoutPanel5.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinTableLayoutPanel5.RightBottom")));
            this.dSkinTableLayoutPanel5.RowCount = 1;
            this.dSkinTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dSkinTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.dSkinTableLayoutPanel5.Size = new System.Drawing.Size(315, 53);
            this.dSkinTableLayoutPanel5.TabIndex = 2;
            // 
            // resEnd
            // 
            this.resEnd.Font = new System.Drawing.Font("YouYuan", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resEnd.Location = new System.Drawing.Point(161, 12);
            this.resEnd.Margin = new System.Windows.Forms.Padding(4, 12, 0, 4);
            this.resEnd.Name = "resEnd";
            this.resEnd.Size = new System.Drawing.Size(151, 27);
            this.resEnd.TabIndex = 1;
            // 
            // resStart
            // 
            this.resStart.Font = new System.Drawing.Font("YouYuan", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resStart.Location = new System.Drawing.Point(4, 12);
            this.resStart.Margin = new System.Windows.Forms.Padding(4, 12, 0, 4);
            this.resStart.Name = "resStart";
            this.resStart.Size = new System.Drawing.Size(151, 27);
            this.resStart.TabIndex = 0;
            this.resStart.Value = new System.DateTime(2000, 1, 1, 14, 41, 0, 0);
            // 
            // resKeyword
            // 
            this.resKeyword.BitmapCache = false;
            this.resKeyword.Font = new System.Drawing.Font("YouYuan", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resKeyword.Location = new System.Drawing.Point(726, 16);
            this.resKeyword.Margin = new System.Windows.Forms.Padding(4, 16, 4, 4);
            this.resKeyword.Name = "resKeyword";
            this.resKeyword.Size = new System.Drawing.Size(219, 27);
            this.resKeyword.TabIndex = 3;
            this.resKeyword.TransparencyKey = System.Drawing.Color.Empty;
            this.resKeyword.WaterFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resKeyword.WaterText = "";
            this.resKeyword.WaterTextOffset = new System.Drawing.Point(0, 0);
            // 
            // resSearchBtn
            // 
            this.resSearchBtn.ButtonBorderWidth = 1;
            this.resSearchBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.resSearchBtn.Font = new System.Drawing.Font("YouYuan", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resSearchBtn.HoverColor = System.Drawing.Color.Empty;
            this.resSearchBtn.HoverImage = null;
            this.resSearchBtn.Location = new System.Drawing.Point(954, 15);
            this.resSearchBtn.Margin = new System.Windows.Forms.Padding(4, 15, 4, 4);
            this.resSearchBtn.Name = "resSearchBtn";
            this.resSearchBtn.NormalImage = null;
            this.resSearchBtn.PressColor = System.Drawing.Color.Empty;
            this.resSearchBtn.PressedImage = null;
            this.resSearchBtn.Radius = 10;
            this.resSearchBtn.ShowButtonBorder = true;
            this.resSearchBtn.Size = new System.Drawing.Size(69, 30);
            this.resSearchBtn.TabIndex = 4;
            this.resSearchBtn.Text = "查询";
            this.resSearchBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.resSearchBtn.TextPadding = 0;
            this.resSearchBtn.Click += new System.EventHandler(this.resSearchBtn_Click);
            // 
            // dSkinLabel1
            // 
            this.dSkinLabel1.AutoSize = false;
            this.dSkinLabel1.Font = new System.Drawing.Font("YouYuan", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel1.Location = new System.Drawing.Point(308, 19);
            this.dSkinLabel1.Margin = new System.Windows.Forms.Padding(4, 19, 4, 4);
            this.dSkinLabel1.Name = "dSkinLabel1";
            this.dSkinLabel1.Size = new System.Drawing.Size(87, 28);
            this.dSkinLabel1.TabIndex = 1;
            this.dSkinLabel1.Text = "申报时间";
            // 
            // resultControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dSkinTableLayoutPanel1);
            this.Location = new System.Drawing.Point(207, 10);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "resultControl";
            this.Size = new System.Drawing.Size(1051, 712);
            this.dSkinTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultsList)).EndInit();
            this.dSkinPanel1.ResumeLayout(false);
            this.dSkinTableLayoutPanel4.ResumeLayout(false);
            this.dSkinTableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waySelector.InnerListBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authStatus.InnerListBox)).EndInit();
            this.dSkinTableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DSkin.Controls.DSkinTableLayoutPanel dSkinTableLayoutPanel1;
        private DSkin.Controls.DSkinGridList resultsList;
        private DSkin.Controls.DSkinPanel dSkinPanel1;
        private DSkin.Controls.DSkinTableLayoutPanel dSkinTableLayoutPanel4;
        private DSkin.Controls.DSkinTableLayoutPanel dSkinTableLayoutPanel5;
        private DSkin.Controls.DSkinDateTimePicker resEnd;
        private DSkin.Controls.DSkinDateTimePicker resStart;
        private DSkin.Controls.DSkinTextBox resKeyword;
        private DSkin.Controls.DSkinButton resSearchBtn;
        private DSkin.Controls.DSkinLabel dSkinLabel1;
        private DSkin.Controls.DSkinComboBox waySelector;
        private DSkin.Controls.DSkinComboBox authStatus;
    }
}
