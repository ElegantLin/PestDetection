using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace quarantine_app
{
    public partial class addLink : UserControl
    {
        private static addLink _instance;
        private static String api_url = "http://111.198.4.119:5000/api/";
        public static String add_user;
        private static String[] level_one = { "新闻资讯", "数据中心", "法律法规", "检疫处理" };
        private static String[][] level_two = new String[4][];
        private static String[][][] level_three = new String[2][][];
        private static String[][][][] level_four = new String[2][][][];

        public static addLink Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new addLink();
                return _instance;
            }
        }
        public addLink()
        {
            InitializeComponent();
            level_two[1] = new String[5] { "有害生物", "动物疫病", "植检标准", "动检标准", "平台链接" };
            level_two[2] = new String[3] { "动植检法律", "动植检法规", "法规在线查看" };
            level_two[3] = new string[3] { "植物检疫规程及指标", "动物检疫规程及指标", "无害化处理" };
            level_three[0] = new String[1][];
            level_three[1] = new String[5][];
            level_three[1][0] = new String[7] { "昆虫", "杂草", "软体动物", "线虫", "真菌", "原核生物", "病毒/类病毒" };
            level_three[1][1] = new String[2] { "水生动物疫病", "陆生动物疫病" };
            level_three[1][2] = new String[11] {
                "检验检疫规程", "标准编写方法", "风险分析方法", "转基因检测方法", "种质资源鉴定方法", "品质检验方法",
                "检疫处理及监测方法", "检测鉴定方法", "水果及其病虫害防治、检疫处理", "国际标准", "其他"
            };
            level_three[1][3] = new String[6] { "通用及监督管理标准", "动物产品检验检疫", "饲料检验检疫", "陆生动物检验检疫",
            "水生动物检验检疫", "其他"};
            level_three[1][4] = new String[2] { "海南外来有害生物数据库", "中国国家有害生物检疫信息平台" };
            level_four[1] = new String[5][][];
            level_four[1][2] = new String[2][];
            level_four[1][2][1] = new String[5] { "反刍动物疫病", "禽疫病", "马属动物疫病", "猪疫病", "野生动物疫病" };
            level_four[1] = new String[5][][];
            level_four[1][2] = new String[11][];
            level_four[1][2][7] = new String[9] { "检疫鉴定通用标准", "昆虫检测鉴定方法", "细菌检测鉴定方法", "杂草检测鉴定方法", "软体动物检测鉴定方法", "真菌检测鉴定方法", "线虫检测鉴定方法", "病毒检测检测方法", "其他检测、鉴定" };
            int num = 0;
            foreach (String i in level_one)
            {
                llevel1.Items.Add(i);
            }
            llevel1.SelectedIndex = 0;
            llevel2.Visible = false;
            llevel4.Visible = false;
        }       

        private void loadLinkLabel_Click(object sender, EventArgs e)
        {
            String url = linkPath.Text;
            linkShow.Url = new System.Uri(url);
        }

        private void llevel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (llevel1.SelectedIndex == 0)
            {
                llevel2.Visible = false;
                llevel3.Visible = false;
                llevel4.Visible = false;
            }
            else if (llevel1.SelectedIndex == 2 || llevel1.SelectedIndex == 3)
            {
                llevel2.Visible = true;
                llevel3.Visible = false;
                llevel4.Visible = false;
                llevel2.Items.Clear();
                foreach (String s in level_two[llevel1.SelectedIndex])
                {
                    llevel2.Items.Add(s);
                }
                llevel2.SelectedIndex = 0;
            }
            else
            {
                llevel2.Visible = true;
                llevel3.Visible = true;
                llevel2.Items.Clear();
                foreach (String s in level_two[llevel1.SelectedIndex])
                {
                    llevel2.Items.Add(s);
                }
                llevel2.SelectedIndex = 0;
            }
        }

        private void llevel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (llevel1.SelectedIndex == 1)
            {
                llevel3.Items.Clear();
                foreach (String s in level_three[llevel1.SelectedIndex][llevel2.SelectedIndex])
                {
                    llevel3.Items.Add(s);
                }
                llevel3.SelectedIndex = 0;
            }
        }

        private void llevel3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tag1 = llevel1.SelectedIndex;
            int tag2 = llevel2.SelectedIndex;
            int tag3 = llevel3.SelectedIndex;
            if ((tag2 == 1 && tag3 == 1) || (tag2 == 2 && tag3 == 7))
            {
                llevel4.Items.Clear();
                foreach (string t in level_four[tag1][tag2][tag3])
                {
                    llevel4.Items.Add(t);
                }
                llevel4.SelectedIndex = 0;
            }
            else
            {
                llevel4.Visible = false;
            }
        }

        private void addLinkLabel_Click(object sender, EventArgs e)
        {
            String link_title = linkTitle.Text;
            String link_url = linkPath.Text;
            if (link_title == "")
            {
                DialogResult dr = MessageBox.Show("请输入链接标题！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (link_url == "")
            {
                DialogResult dr = MessageBox.Show("请输入链接地址！", "提示", MessageBoxButtons.OK);
                return;
            }
            addLinkLabel.Text = "添加中";
            this.Refresh();
            int index1 = llevel1.SelectedIndex;
            Hashtable ht = new Hashtable();
            ht.Add("title", link_title);
            ht.Add("type", "html");
            ht.Add("owner", add_user);
            ht.Add("url", link_url);
            ht.Add("level1", index1.ToString());
            if (llevel2.Visible)
            {
                int index2 = llevel2.SelectedIndex;
                if (llevel3.Visible)
                {
                    int index3 = llevel3.SelectedIndex;
                    if (llevel4.Visible)
                    {
                        int index4 = llevel4.SelectedIndex;
                        ht.Add("level2", index2.ToString());
                        ht.Add("level3", index3.ToString());
                        ht.Add("level4", index4.ToString());
                    }
                    else
                    {
                        ht.Add("level2", index2.ToString());
                        ht.Add("level3", index3.ToString());
                    }
                }
                else
                {
                    ht.Add("level2", index2.ToString());
                }
            }
            string res = HttpUtils.DoPost(api_url + "upload_link", ht);
            if (res.Contains("ok"))
            {
                DialogResult dr = MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK);
            }
            else if (res.Contains("title"))
            {
                DialogResult dr = MessageBox.Show("链接标题重复，请修改后上传！", "提示", MessageBoxButtons.OK);
            }
            else if (res.Contains("name"))
            {
                DialogResult dr = MessageBox.Show("已添加过该链接！", "提示", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult dr = MessageBox.Show("添加失败，请重试！", "提示", MessageBoxButtons.OK);
            }
            addLinkLabel.Text = "添加链接";
            this.Refresh();
        }
    }
}
