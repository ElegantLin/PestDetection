using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSkin;
using DSkin.Controls;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace quarantine_app
{
    public partial class index : Form
    {
        bool IsDragging = false;
        Point p = new Point(0, 0);
        Point offset = new Point(0, 0);
        String api_url = "http://111.198.4.119:5000/api/";
        Boolean sjzx_load = false;
        private string username;
        private int author;
        private Boolean[] first_load = new Boolean[6]{true, true, true, true, true, true};
        private String[] name_title = { "菜粉蝶/Pieris rapae", "琉璃灰蝶/Celastrina argiolus", "光肩星天牛/Anoplophora glabripennis" };
        private String[] details = {           
            "鳞翅目Lepidoptera，粉蝶科Pieridae，粉蝶属Pieris",
            "鳞翅目Lepidoptera，灰碟科Lycaenidae，琉璃灰蝶属Celastrina",
            "天牛科Cerambycidae，沟胫天牛亚科 Lamiinae，星天牛属Anoplophora",
        };
        private Image[] sources = { Properties.Resources.car2, Properties.Resources.car3, Properties.Resources.car1};
        private Image clicked = Properties.Resources.fill;
        private Image unclicked = Properties.Resources.empty;

        private Thread th = null;
        private DSkinPictureBox last;
        private DSkinPictureBox next;

        private int last_tab = 0;
        private delegate void FlushClient();
        private int count = 0;

        private Panel panel = new Panel();
        private double formWidth;//窗体原始宽度
        private double formHeight;//窗体原始高度
        private double scaleX;//水平缩放比例
        private double scaleY;//垂直缩放比例
        private Dictionary<string, string> ControlsInfo = new Dictionary<string, string>();//控件中心Left,Top,控件Width,控件Height,控件字体Size 

        private double windowWidth;
        private double windowHeight;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public index(string user_name, int auth)
        {
            InitializeComponent();
            /*panel.Dock = DockStyle.Fill;
            foreach (Control item in this.Controls)
            {
                if(item.Name.Trim() != "" && item != panel) item.Parent = panel;
            }
            this.Controls.Add(panel);*/

            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            username = user_name;
            author = auth;
            declareControl.user_name = username;
            declareChange.user_name = username;
            fillResult.user_name = username;
            recordControl.user_names = username;
            authControl.auth_name = username;
            accountInfo.acc_name = username;
            uploadDoc.upload_user = username;
            addLink.add_user = username;
            platManage.plat_user = username;
            resultControl.result_name = username;
            if (author == 0)
            {
                dSkinTabItem4.Visible = false;
                dSkinTabItem4.Enabled = false;
                dSkinTabItem5.Visible = false;
                dSkinTabItem5.Enabled = false;                
            }
            else
            {
                dSkinTabItem4.Visible = true;
                dSkinTabItem4.Enabled = true;
                dSkinTabItem5.Visible = true;
                dSkinTabItem5.Enabled = true;               
            }
            yhswIntro.Text = "    有害生物，是指在一定条件下，对人类的生活、生产甚至生存产生危害的生物；是由数量多而导致圈养动物和栽培作物、花卉、苗木受到重大损害的生物。\r\n    狭义上仅指动物，广义上包括动物、植物、微生物乃至病毒。\r\n    有害生物，包括危害植物的各种害虫、有害动物（蜗牛、螨类等）、病原微生物（真菌、细菌、放线菌病毒、类病毒、立克次体、类菌质体、线虫）和寄生性种子植物（菟丝子、槲寄生、桑寄生、列当）等。\r\n    田间杂草因具有对栽培植物的侵害性，往往也包括在内。";
            indexDisplay();
            //th = new Thread(CrossThreadFlush);
            //th.IsBackground = true;
            //th.Start();

            windowWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            windowHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void GetAllInitInfo(Control ctrlContainer)
        {
            if (ctrlContainer.Parent == this)//获取窗体的高度和宽度
            {
                formWidth = Convert.ToDouble(ctrlContainer.Width);
                formHeight = Convert.ToDouble(ctrlContainer.Height);
            }
            foreach (Control item in ctrlContainer.Controls)
            {
                if (item.Name.Trim() != "")
                {
                    //添加信息：键值：控件名，内容：据左边距离，距顶部距离，控件宽度，控件高度，控件字体。
                    ControlsInfo.Add(item.Name, (item.Left + item.Width / 2) + "," + (item.Top + item.Height / 2) + "," + item.Width + "," + item.Height + "," + item.Font.Size);
                }
                if ((item as UserControl) == null && item.Controls.Count > 0)
                {
                    GetAllInitInfo(item);
                }
            }

        }

        private void ControlsChangeInit(Control ctrlContainer)
        {
            scaleX = (Convert.ToDouble(ctrlContainer.Width) / formWidth);
            scaleY = (Convert.ToDouble(ctrlContainer.Height) / formHeight);
        }

        private void ControlsChange(Control ctrlContainer)
        {
            double[] pos = new double[5];//pos数组保存当前控件中心Left,Top,控件Width,控件Height,控件字体Size
            foreach (Control item in ctrlContainer.Controls)//遍历控件
            {
                if (item.Name.Trim() != "")//如果控件名不是空，则执行
                {
                    if ((item as UserControl) == null && item.Controls.Count > 0)//如果不是自定义控件
                    {
                        ControlsChange(item);//循环执行
                    }
                    if (ControlsInfo.ContainsKey(item.Name))
                    {
                        string[] strs = ControlsInfo[item.Name].Split(',');//从字典中查出的数据，以‘，’分割成字符串组

                        for (int i = 0; i < 5; i++)
                        {
                            pos[i] = Convert.ToDouble(strs[i]);//添加到临时数组
                        }
                        double itemWidth = pos[2] * scaleX;     //计算控件宽度，double类型
                        double itemHeight = pos[3] * scaleY;    //计算控件高度
                        item.Left = Convert.ToInt32(pos[0] * scaleX - itemWidth / 2);//计算控件距离左边距离
                        item.Top = Convert.ToInt32(pos[1] * scaleY - itemHeight / 2);//计算控件距离顶部距离
                        item.Width = Convert.ToInt32(itemWidth);//控件宽度，int类型
                        item.Height = Convert.ToInt32(itemHeight);//控件高度
                        item.Font = new Font(item.Font.Name, float.Parse((pos[4] * Math.Min(scaleX, scaleY)).ToString()));//字体
                    }                  
                }
            }

        }

        //private void CrossThreadFlush()
        //{
        //    while (true)
        //    {
        //        Thread.Sleep(2500);
        //        ChangeData();
        //    }
        //}

        //private void ChangeData()
        //{
        //    if (biologyPicture.InvokeRequired || nameLabel.InvokeRequired || desLabel.InvokeRequired)
        //    {
        //        FlushClient fc = new FlushClient(ChangeData);
        //        this.Invoke(fc);
        //    }
        //    else
        //    {
        //        biologyPicture.BackgroundImage = sources[count % 3];
        //        biologyPicture.BackgroundImageLayout = ImageLayout.Stretch;
        //        nLabel.Text = name_title[count % 3];
        //        dLabel.Text = details[count % 3];
        //        if (count % 3 == 0)
        //        {
        //            last = carouselBtno;
        //            next = carouselBtns;
        //        }
        //        else if (count % 3 == 1)
        //        {
        //            last = carouselBtns;
        //            next = carouselBtnt;
        //        }
        //        else
        //        {
        //            last = carouselBtnt;
        //            next = carouselBtno;
        //        }
        //        last.BackgroundImage = unclicked;
        //        last.BackgroundImageLayout = ImageLayout.Stretch;
        //        next.BackgroundImage = clicked;
        //        next.BackgroundImageLayout = ImageLayout.Stretch;
        //        count += 1;
        //    }
        //}

        private void indexDisplay()
        {
            string xwzx_files = HttpUtils.Get(api_url + "get_files?class=0");
            dynamic xwzx = JsonConvert.DeserializeObject(xwzx_files);
            indexXwzxModule(xwzx);

            string flfg_files = HttpUtils.Get(api_url + "get_files?class=2");
            dynamic flfg = JsonConvert.DeserializeObject(flfg_files);
            indexFlfgModule(flfg);

            string platform_info = HttpUtils.Get(api_url + "get_platform");
            dynamic plat = JsonConvert.DeserializeObject(platform_info);
            indexPlatformDyn(plat);
        }

        private void indexPlatformDyn(dynamic plat)
        {
            platformDyn.Rows.Clear();
            int num = 0; 
            foreach (dynamic r in plat)
            {
                DSkinGridListRow sample = new DSkinGridListRow();
                sample.Height = 19;
                DSkinGridListCell title = new DSkinGridListCell();
                title.Value = r["title"];
                title.Font = new Font(new FontFamily("幼圆"), 10, FontStyle.Regular);
                title.DockStyle = DockStyle.Left;
                sample.Cells.Add(title);
                DSkinGridListCell date = new DSkinGridListCell();
                date.Value = r["date"];
                date.Font = new Font(new FontFamily("幼圆"), 10, FontStyle.Regular);
                sample.Cells.Add(date);
                date.DockStyle = DockStyle.Right;
                platformDyn.Rows.Add(sample);
                num += 1;
                if (num == 2) break;
            }    
        }

        private void indexFlfgModule(dynamic flfg)
        {
            flfgIndexList.Rows.Clear();
            int num = 0;
            foreach (dynamic r in flfg)
            {
                DSkinGridListRow sample = new DSkinGridListRow();
                sample.Height = 19;
                DSkinGridListCell title = new DSkinGridListCell();
                int len = r["name"].ToString().Length > 25 ? 25: r["name"].ToString().Length;
                title.Value = r["name"].ToString().Substring(0, len) + "...";
                title.Font = new Font(new FontFamily("幼圆"), 10, FontStyle.Regular);
                title.DockStyle = DockStyle.Left;
                sample.Cells.Add(title);
                DSkinGridListCell date = new DSkinGridListCell();
                date.Value = r["date"].ToString();
                date.Font = new Font(new FontFamily("幼圆"), 10, FontStyle.Regular);
                title.Tag = r["url"];
                date.DockStyle = DockStyle.Right;
                sample.Cells.Add(date);
                flfgIndexList.Rows.Add(sample);
                num += 1;
                if (num == 5) break;
            }
        }

        private void indexXwzxModule(dynamic xwzx)
        {
            xwzxIndexList.Rows.Clear();
            int num = 0;
            foreach (dynamic r in xwzx)
            {
                DSkinGridListRow sample = new DSkinGridListRow();
                sample.Height = 19;
                DSkinGridListCell title = new DSkinGridListCell();
                int len = r["name"].ToString().Length > 25 ? 25 : r["name"].ToString().Length;
                title.Value = r["name"].ToString().Substring(0, len) + "...";
                title.Font = new Font(new FontFamily("幼圆"), 10, FontStyle.Regular);
                title.DockStyle = DockStyle.Left;
                sample.Cells.Add(title);
                DSkinGridListCell date = new DSkinGridListCell();
                date.Value = r["date"].ToString();
                date.Font = new Font(new FontFamily("幼圆"), 10, FontStyle.Regular);
                title.Tag = r["url"];
                date.DockStyle = DockStyle.Right;
                sample.Cells.Add(date);
                xwzxIndexList.Rows.Add(sample);
                num += 1;
                if (num == 5) break;
            }
        }

        private void indexMinBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maxSize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;               
            }
            else
            {
                this.WindowState = FormWindowState.Normal;              
            }
        }

        private void closeWin_Click(object sender, EventArgs e)
        {

            string[] file_types = { "jpg", "png", "jpeg", "pdf" };
            string current = Directory.GetCurrentDirectory();
            string[] files = Directory.GetFiles(current);
            foreach (string currentFile in files)
            {
                foreach (string type in file_types)
                {                
                    if (currentFile.Substring(currentFile.LastIndexOf(".") + 1) == type)
                    {
                        try {
                            File.Delete(currentFile);
                        }
                        catch (System.IO.IOException)
                        {
                            Console.WriteLine("Delete temp file failed");
                        }
                    }
                }
            }
            Application.Exit();
        }

        private void topPanel_MouseUp(object sender, MouseEventArgs e)
        {
            IsDragging = false;
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            IsDragging = true;
            p.X = e.X;
            p.Y = e.Y;
        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDragging)
            {           
                offset.X = e.X - p.X;
                offset.Y = e.Y - p.Y;          
                Location = PointToScreen(offset);
            }
        }

        private void authenList_NodeClick(object sender, DSkinTreeViewNodeClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                switch (e.Item.Tag.ToString())
                {
                    case "declare":                  
                        if (!treeP.Controls.Contains(declareControl.Instance))
                        {
                            treeP.Controls.Add(declareControl.Instance);
                            declareControl.Instance.Dock = DockStyle.Fill;
                            declareControl.Instance.BringToFront();
                        }
                        else
                        {
                            declareControl.Instance.BringToFront();
                        }
                        break;
                    case "authenticate":
                        if (!treeP.Controls.Contains(authControl.Instance))
                        {
                            treeP.Controls.Add(authControl.Instance);
                            authControl.Instance.Dock = DockStyle.Fill;
                            authControl.Instance.BringToFront();
                        }
                        else
                        {
                            authControl.Instance.BringToFront();
                        }
                        break;
                    case "result":
                        if (!treeP.Controls.Contains(resultControl.Instance))
                        {
                            treeP.Controls.Add(resultControl.Instance);
                            resultControl.Instance.Dock = DockStyle.Fill;
                            resultControl.Instance.BringToFront();
                        }
                        else
                        {
                            resultControl.Instance.BringToFront();
                        }
                        break;
                    case "record":
                        if (!treeP.Controls.Contains(recordControl.Instance))
                        {
                            treeP.Controls.Add(recordControl.Instance);
                            recordControl.Instance.Dock = DockStyle.Fill;
                            recordControl.Instance.BringToFront();
                        }
                        else
                        {
                            recordControl.Instance.BringToFront();
                        }
                        break;
                    case "identify":
                        if (!treeP.Controls.Contains(identifyControl.Instance))
                        {
                            treeP.Controls.Add(identifyControl.Instance);
                            identifyControl.Instance.Dock = DockStyle.Fill;
                            identifyControl.Instance.BringToFront();
                        }
                        else
                        {
                            identifyControl.Instance.BringToFront();
                        }
                        break;
                    case "species":
                        if (!treeP.Controls.Contains(speciesControl.Instance))
                        {
                            treeP.Controls.Add(speciesControl.Instance);
                            speciesControl.Instance.Dock = DockStyle.Fill;
                            speciesControl.Instance.BringToFront();
                        }
                        else
                        {
                            speciesControl.Instance.BringToFront();
                        }
                        break;                   
                    case "history":
                        if (!treeP.Controls.Contains(historyControl.Instance))
                        {
                            treeP.Controls.Add(historyControl.Instance);
                            historyControl.Instance.Dock = DockStyle.Fill;
                            historyControl.Instance.BringToFront();
                        }
                        else
                        {
                            historyControl.Instance.BringToFront();
                        }
                        break;                   
                }
            }
        }

        

        private void flfgIndexList_ItemClick(object sender, DSkinGridListMouseEventArgs e)
        {
            if (e.CellIndex == 0)
            {
                string url = e.Item.Cells[0].Tag.ToString();
                int typeIndex = url.LastIndexOf(".");
                string type = url.Substring(typeIndex + 1);
                if (type == "pdf")
                {
                    String fileName = HttpUtils.downloadFile(url, "pdf");
                    var fileView = new fileView(fileName);
                    fileView.ShowDialog();
                }
                else
                {
                    var linkWindow = new linkView(url);
                    linkWindow.ShowDialog();
                }
            }
        }

        private void xwzxIndexList_ItemClick(object sender, DSkinGridListMouseEventArgs e)
        {
            if (e.CellIndex == 0)
            {
                string url = e.Item.Cells[0].Tag.ToString();
                int typeIndex = url.LastIndexOf(".");
                string type = url.Substring(typeIndex + 1);
                if (type == "pdf")
                {
                    String fileName = HttpUtils.downloadFile(url, "pdf");
                    var fileView = new fileView(fileName);
                    fileView.ShowDialog();
                }
                else
                {
                    var linkWindow = new linkView(url);
                    linkWindow.ShowDialog();
                }
            }
        }

        private void xwzxIndexLabel_Click(object sender, EventArgs e)
        {
            var newsView = new newsWindow();
            newsView.ShowDialog();
        }

        private void flfgIndexLabel_Click(object sender, EventArgs e)
        {
            dSkinTabControl1.SelectedIndex = 3;
        }       

        private void dataCenterList_ItemClick(object sender, DSkinGridListMouseEventArgs e)
        {
            if (e.CellIndex == 1)
            {
                string url = e.Item.Cells[1].Tag.ToString();
                String fileName = HttpUtils.downloadFile(url, "pdf");
                var fileView = new fileView(fileName);
                fileView.ShowDialog();
            }
        }

        private void flfgDetailList_ItemClick(object sender, DSkinGridListMouseEventArgs e)
        {
            if (e.CellIndex == 1)
            {
                string url = e.Item.Cells[1].Tag.ToString();
                String fileName = HttpUtils.downloadFile(url, "pdf");
                var fileView = new fileView(fileName);
                fileView.ShowDialog();
            }
        }

        private void dataCenter_Reload(dynamic res)
        {
            dataCenterList.Rows.Clear();
            foreach (dynamic r in res)
            {
                DSkinGridListRow sample = new DSkinGridListRow();
                sample.Height = 60;
                DSkinGridListCell icon = new DSkinGridListCell();
                sample.Cells.Add(icon);
                //icon.BackgroundImage = Properties.Resources;
                DSkinGridListCell title = new DSkinGridListCell();
                title.Value = r["name"].ToString();
                title.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                title.DockStyle = DockStyle.Left;
                sample.Cells.Add(title);
                DSkinGridListCell date = new DSkinGridListCell();
                date.Value = r["date"].ToString();
                date.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                title.Tag = r["url"];
                date.DockStyle = DockStyle.Right;
                sample.Cells.Add(date);               
                dataCenterList.Rows.Add(sample);
            }
            dataCenterList.PageIndex = 1;
        }

        private void flfgData_Reload(dynamic res)
        {
            flfgDetailList.Rows.Clear();
            foreach (dynamic r in res)
            {
                DSkinGridListRow sample = new DSkinGridListRow();
                sample.Height = 60;
                DSkinGridListCell icon = new DSkinGridListCell();
                sample.Cells.Add(icon);
                //icon.BackgroundImage = Properties.Resources;
                DSkinGridListCell title = new DSkinGridListCell();
                title.Value = r["name"].ToString();
                title.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                title.DockStyle = DockStyle.Left;
                sample.Cells.Add(title);
                DSkinGridListCell date = new DSkinGridListCell();
                date.Value = r["date"].ToString();
                date.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                title.Tag = r["url"];
                date.DockStyle = DockStyle.Right;
                sample.Cells.Add(date);
                flfgDetailList.Rows.Add(sample);
            }
            flfgDetailList.PageIndex = 1;
        }

        private void jyclData_Reload(dynamic res)
        {
            quarDataList.Rows.Clear();
            foreach (dynamic r in res)
            {
                DSkinGridListRow sample = new DSkinGridListRow();
                sample.Height = 60;
                DSkinGridListCell icon = new DSkinGridListCell();
                sample.Cells.Add(icon);
                //icon.BackgroundImage = Properties.Resources;
                DSkinGridListCell title = new DSkinGridListCell();
                title.Value = r["name"].ToString();
                title.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                title.DockStyle = DockStyle.Left;
                sample.Cells.Add(title);
                DSkinGridListCell date = new DSkinGridListCell();
                date.Value = r["date"].ToString();
                date.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                title.Tag = r["url"];
                date.DockStyle = DockStyle.Right;
                sample.Cells.Add(date);
                quarDataList.Rows.Add(sample);
            }
            quarDataList.PageIndex = 1;
        }

        private void flfgSearch_Click(object sender, EventArgs e)
        {
            if (flfgStart.Value <= flfgEnd.Value)
            {
                string start_date = flfgStart.Value.ToString().Split(' ')[0];
                string end_date = flfgEnd.Value.ToString().Split(' ')[0];
                string keyword = flfgKeyword.Text;
                string flfg_detail_files;
                if (keyword.Length > 0)
                {
                    flfg_detail_files = HttpUtils.Get(api_url + "get_detail_files?class=2&start=" + start_date + "&end=" + end_date + "&keyword=" + keyword);
                }
                else
                {
                    flfg_detail_files = HttpUtils.Get(api_url + "get_detail_files?class=2&start=" + start_date + "&end=" + end_date);
                }
                dynamic flfg_detail = JsonConvert.DeserializeObject(flfg_detail_files);
                flfgData_Reload(flfg_detail);
            }
            else
            {
                DialogResult dr = MessageBox.Show("起始日期不得大于截止日期", "提示", MessageBoxButtons.OK);
            }
        }

        private void sjzxSearch_Click(object sender, EventArgs e)
        {
            if (sjzxStart.Value <= sjzxEnd.Value)
            {
                string start_date = sjzxStart.Value.ToString().Split(' ')[0];
                string end_date = sjzxEnd.Value.ToString().Split(' ')[0];
                string keyword = sjzxKeyword.Text;
                string sjzx_detail_files;
                if (keyword.Length > 0)
                {
                    sjzx_detail_files = HttpUtils.Get(api_url + "get_detail_files?class=1&start=" + start_date + "&end=" + end_date + "&keyword=" + keyword);
                }
                else
                {
                    sjzx_detail_files = HttpUtils.Get(api_url + "get_detail_files?class=1&start=" + start_date + "&end=" + end_date);
                }
                dynamic sjzx_detail = JsonConvert.DeserializeObject(sjzx_detail_files);
                dataCenter_Reload(sjzx_detail);
            }
            else
            {
                DialogResult dr = MessageBox.Show("起始日期不得大于截止日期", "提示", MessageBoxButtons.OK);
            }
        }

        private void setting_tree_NodeClick(object sender, DSkinTreeViewNodeClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                switch (e.Item.Tag.ToString())
                {
                    case "accinfo":
                        if (!settingP.Controls.Contains(accountInfo.Instance))
                        {
                            settingP.Controls.Add(accountInfo.Instance);
                            accountInfo.Instance.Dock = DockStyle.Fill;
                            accountInfo.Instance.BringToFront();
                        }
                        else
                        {
                            accountInfo.Instance.BringToFront();
                        }
                        break;
                    case "manage":
                        if (!settingP.Controls.Contains(accountManage.Instance))
                        {
                            settingP.Controls.Add(accountManage.Instance);
                            accountManage.Instance.Dock = DockStyle.Fill;
                            accountManage.Instance.BringToFront();
                        }
                        else
                        {
                            accountManage.Instance.BringToFront();
                        }
                        break;
                    case "upload":
                        if (!settingP.Controls.Contains(uploadDoc.Instance))
                        {
                            settingP.Controls.Add(uploadDoc.Instance);
                            uploadDoc.Instance.Dock = DockStyle.Fill;
                            uploadDoc.Instance.BringToFront();
                        }
                        else
                        {
                            uploadDoc.Instance.BringToFront();
                        }
                        break;
                    case "delete":
                        if (!settingP.Controls.Contains(deleteDoc.Instance))
                        {
                            settingP.Controls.Add(deleteDoc.Instance);
                            deleteDoc.Instance.Dock = DockStyle.Fill;
                            deleteDoc.Instance.BringToFront();
                        }
                        else
                        {
                            deleteDoc.Instance.BringToFront();
                        }
                        break;
                    case "addlink":
                        if (!settingP.Controls.Contains(addLink.Instance))
                        {
                            settingP.Controls.Add(addLink.Instance);
                            addLink.Instance.Dock = DockStyle.Fill;
                            addLink.Instance.BringToFront();
                        }
                        else
                        {
                            addLink.Instance.BringToFront();
                        }
                        break;
                    case "deletelink":
                        if (!settingP.Controls.Contains(deleteLink.Instance))
                        {
                            settingP.Controls.Add(deleteLink.Instance);
                            deleteLink.Instance.Dock = DockStyle.Fill;
                            deleteLink.Instance.BringToFront();
                        }
                        else
                        {
                            deleteLink.Instance.BringToFront();
                        }
                        break;
                    case "manageplat":
                        if (!settingP.Controls.Contains(platManage.Instance))
                        {
                            settingP.Controls.Add(platManage.Instance);
                            platManage.Instance.Dock = DockStyle.Fill;
                            platManage.Instance.BringToFront();
                        }
                        else
                        {
                            platManage.Instance.BringToFront();
                        }
                        break;
                }
            }
        }

        private void dSkinTabBar1_TabControlSelectedIndexChanged(object sender, DSkinTabBarEventArgs e)
        {
            if (last_tab == 0)
            {
                //th.Suspend();
            }
            if (e.DSkinTabItem.TabIndex == 0)
            {
                //indexDisplay();
                last_tab = 0;
                //th.Resume();
            }
            else if (e.DSkinTabItem.TabIndex == 1)
            {
                if (!treeP.Controls.Contains(declareControl.Instance))
                {
                    treeP.Controls.Add(declareControl.Instance);
                    declareControl.Instance.Dock = DockStyle.Fill;
                    declareControl.Instance.BringToFront();
                }
                else
                {
                    declareControl.Instance.BringToFront();
                }
                last_tab = 1;
            }
            else if (e.DSkinTabItem.TabIndex == 2)
            {                
                string sjzx_files = HttpUtils.Get(api_url + "get_files?class=1");
                dynamic sjzx = JsonConvert.DeserializeObject(sjzx_files);
                dataCenter_Reload(sjzx);
                last_tab = 2;
            }
            else if (e.DSkinTabItem.TabIndex == 3)
            {
                string flfg_files = HttpUtils.Get(api_url + "get_files?class=2");
                dynamic flfg = JsonConvert.DeserializeObject(flfg_files);
                flfgData_Reload(flfg);
                last_tab = 3;
            }
            else if (e.DSkinTabItem.TabIndex == 4)
            {
                string jycl_files = HttpUtils.Get(api_url + "get_files?class=3");
                dynamic jycl = JsonConvert.DeserializeObject(jycl_files);
                jyclData_Reload(jycl);
                last_tab = 4;
            }
            else if (e.DSkinTabItem.TabIndex == 5)
            {
                if (!settingP.Controls.Contains(accountInfo.Instance))
                {
                    settingP.Controls.Add(accountInfo.Instance);
                    accountInfo.Instance.Dock = DockStyle.Fill;
                    accountInfo.Instance.BringToFront();                   
                }
                else
                {
                    accountInfo.Instance.BringToFront();
                }
                if (first_load[e.DSkinTabItem.TabIndex])
                {
                    if (author == 0)
                    {
                        DSkinTreeViewNode setting = new DSkinTreeViewNode();
                        setting.Text = " 账号设置";
                        setting.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                        setting.Icon = ((System.Drawing.Image)(Properties.Resources.setting));
                        setting.Tag = "accinfo";
                        setting_tree.Nodes.Add(setting);
                        DSkinTreeViewNode info = new DSkinTreeViewNode();
                        info.Text = "账号信息";
                        info.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                        info.Icon = ((System.Drawing.Image)(Properties.Resources.blank2));
                        info.Tag = "accinfo";
                        setting_tree.Nodes[0].Nodes.Add(info);
                    }
                    else
                    {
                        DSkinTreeViewNode info = new DSkinTreeViewNode();
                        DSkinTreeViewNode setting = new DSkinTreeViewNode();
                        setting.Text = " 账号设置";
                        setting.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                        setting.Icon = ((System.Drawing.Image)(Properties.Resources.setting));
                        setting.Tag = "accinfo";
                        setting_tree.Nodes.Add(setting);
                        DSkinTreeViewNode document = new DSkinTreeViewNode();
                        document.Text = " 资料管理";
                        document.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                        document.Icon = ((System.Drawing.Image)(Properties.Resources.setting));
                        document.Tag = "upload";
                        setting_tree.Nodes.Add(document);
                        info.Text = "账号信息";
                        info.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                        info.Icon = ((System.Drawing.Image)(Properties.Resources.blank2));
                        info.Tag = "accinfo";
                        setting_tree.Nodes[0].Nodes.Add(info);
                        DSkinTreeViewNode manage = new DSkinTreeViewNode();
                        manage.Text = "管理账号";
                        manage.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                        manage.Icon = ((System.Drawing.Image)(Properties.Resources.blank2));
                        manage.Tag = "manage";
                        setting_tree.Nodes[0].Nodes.Add(manage);
                        DSkinTreeViewNode upload = new DSkinTreeViewNode();
                        upload.Text = "上传文件";
                        upload.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                        upload.Icon = ((System.Drawing.Image)(Properties.Resources.blank2));
                        upload.Tag = "upload";
                        setting_tree.Nodes[1].Nodes.Add(upload);
                        DSkinTreeViewNode delete = new DSkinTreeViewNode();
                        delete.Text = "删除文件";
                        delete.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                        delete.Icon = ((System.Drawing.Image)(Properties.Resources.blank2));
                        delete.Tag = "delete";
                        setting_tree.Nodes[1].Nodes.Add(delete);
                        DSkinTreeViewNode uploadLink = new DSkinTreeViewNode();
                        uploadLink.Text = "添加链接";
                        uploadLink.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                        uploadLink.Icon = ((System.Drawing.Image)(Properties.Resources.blank2));
                        uploadLink.Tag = "addlink";
                        setting_tree.Nodes[1].Nodes.Add(uploadLink);
                        DSkinTreeViewNode deleteLink = new DSkinTreeViewNode();
                        deleteLink.Text = "删除链接";
                        deleteLink.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                        deleteLink.Icon = ((System.Drawing.Image)(Properties.Resources.blank2));
                        deleteLink.Tag = "deletelink";
                        setting_tree.Nodes[1].Nodes.Add(deleteLink);
                        DSkinTreeViewNode platformManage = new DSkinTreeViewNode();
                        platformManage.Text = "管理动态";
                        platformManage.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                        platformManage.Icon = ((System.Drawing.Image)(Properties.Resources.blank2));
                        platformManage.Tag = "manageplat";
                        setting_tree.Nodes[1].Nodes.Add(platformManage);
                    }
                    first_load[e.DSkinTabItem.TabIndex] = false;
                }
                last_tab = 5;
            }
        }

        private String[] processTag(String tag)
        {
            int length = tag.Length;
            String[] res = new String[length];
            for (int i = 0; i < length; i++)
            {
                String temp = tag.Substring(i, 1);
                if (temp == "a") temp = "10";
                res[i] = temp;
            }
            return res;
        }

        private void dSkinTreeView2_NodeClick(object sender, DSkinTreeViewNodeClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                if (e.Item.Text.ToString().Contains("海南外来有害生物数据库"))
                {
                    linkView lk = new linkView("http://hniap.rdzw.net.cn/");
                    lk.ShowDialog();
                    return;
                }
                if (e.Item.Text.ToString().Contains("中国国家有害生物检疫信息平台"))
                {
                    linkView lk = new linkView("http://www.pestchina.com/pest/SitePages/PestInfoSearch.aspx");
                    lk.ShowDialog();
                    return;
                }
                String[] type = processTag(e.Item.Tag.ToString());
                String url = api_url + "get_files?class=1";
                if (type.Length == 3)
                {
                    url = url + "&level2=" + type[0] + "&level3=" + type[1] + "&level4=" + type[2];
                }
                else if (type.Length == 2)
                {
                    url = url + "&level2=" + type[0] + "&level3=" + type[1];
                }
                else
                {
                    url = url + "&level2=" + type[0];
                }
                string sjzx_files = HttpUtils.Get(url);
                dynamic sjzx = JsonConvert.DeserializeObject(sjzx_files);
                dataCenter_Reload(sjzx);
            }
        }

        private void dSkinTreeView3_NodeClick(object sender, DSkinTreeViewNodeClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                String[] type = processTag(e.Item.Tag.ToString());
                String url = api_url + "get_files?class=2";
                if (type.Length == 3)
                {
                    url = url + "&level2=" + type[0] + "&level3=" + type[1] + "&level4=" + type[2];
                }
                else if (type.Length == 2)
                {
                    url = url + "&level2=" + type[0] + "&level3=" + type[1];
                }
                else
                {
                    url = url + "&level2=" + type[0];
                }
                string flfg_files = HttpUtils.Get(url);
                dynamic flfg = JsonConvert.DeserializeObject(flfg_files);
                flfgData_Reload(flfg);
            }
        }

        private void quarSearchBtn_Click(object sender, EventArgs e)
        {
            if (quarStart.Value <= quarEnd.Value)
            {
                string start_date = quarStart.Value.ToString().Split(' ')[0];
                string end_date = quarEnd.Value.ToString().Split(' ')[0];
                string keyword = quarKeyword.Text;
                string quar_detail_files;
                if (keyword.Length > 0)
                {
                    quar_detail_files = HttpUtils.Get(api_url + "get_detail_files?class=3&start=" + start_date + "&end=" + end_date + "&keyword=" + keyword);
                }
                else
                {
                    quar_detail_files = HttpUtils.Get(api_url + "get_detail_files?class=3&start=" + start_date + "&end=" + end_date);
                }
                dynamic quar_detail = JsonConvert.DeserializeObject(quar_detail_files);
                jyclData_Reload(quar_detail);
            }
            else
            {
                DialogResult dr = MessageBox.Show("起始日期不得大于截止日期", "提示", MessageBoxButtons.OK);
            }
        }

        private void dSkinTreeView4_NodeClick(object sender, DSkinTreeViewNodeClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                String[] type = processTag(e.Item.Tag.ToString());
                String url = api_url + "get_files?class=3";
                if (type.Length == 3)
                {
                    url = url + "&level2=" + type[0] + "&level3=" + type[1] + "&level4=" + type[2];
                }
                else if (type.Length == 2)
                {
                    url = url + "&level2=" + type[0] + "&level3=" + type[1];
                }
                else
                {
                    url = url + "&level2=" + type[0];
                }
                string jycl_files = HttpUtils.Get(url);
                dynamic jycl = JsonConvert.DeserializeObject(jycl_files);
                jyclData_Reload(jycl);
            }
        }

        private void quarDataList_ItemClick(object sender, DSkinGridListMouseEventArgs e)
        {
            if (e.CellIndex == 1)
            {
                string url = e.Item.Cells[1].Tag.ToString();
                int typeIndex = url.LastIndexOf(".");
                string type = url.Substring(typeIndex + 1);
                if (type == "pdf")
                {
                    String fileName = HttpUtils.downloadFile(url, "pdf");
                    var fileView = new fileView(fileName);
                    fileView.ShowDialog();
                }
                else
                {
                    var linkWindow = new linkView(url);
                    linkWindow.ShowDialog();
                }
            }
        }

        private void yhswIndexLabel_Click(object sender, EventArgs e)
        {
            dSkinTabControl1.SelectedIndex = 2;
        }

        private void platformMore_Click(object sender, EventArgs e)
        {
            var platView = new platWindow();
            platView.ShowDialog();
        }

        private void yhswSearch_Click(object sender, EventArgs e)
        {
            string sample = yhswSearchBox.Text;
            if (sample == "")
            {
                dSkinTabControl1.SelectedIndex = 2;
                sjzxKeyword.Text = sample;
                sjzxSearch.PerformClick();
            }
            else
            {
                string yhsw = HttpUtils.Get(api_url + "search_sample?keyword=" + sample);
                Console.WriteLine(yhsw);
                if (yhsw == "[]")
                {
                    dSkinTabControl1.SelectedIndex = 2;
                    sjzxKeyword.Text = sample;
                    sjzxSearch.PerformClick();
                }
                else
                {
                    sampleSearch ss = new sampleSearch(yhsw);
                    ss.StartPosition = FormStartPosition.CenterParent;
                    ss.ShowDialog();
                }       
            }
        }

        private void index_SizeChanged(object sender, EventArgs e)
        {
            //ControlsChangeInit(topPanel);//表示pannel控件
            //ControlsChange(topPanel); 
            

        }

        private void index_Load(object sender, EventArgs e)
        {
            
        }

        private void dSkinTableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dSkinTableLayoutPanel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dSkinLabel21_Click(object sender, EventArgs e)
        {

        }
    }
}