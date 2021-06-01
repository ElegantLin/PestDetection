using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace quarantine_app
{
    public partial class deleteLink : UserControl
    {
        private static deleteLink _instance;
        private static String api_url = "http://111.198.4.119:5000/api/";
        private static String[] level_one = { "新闻资讯", "数据中心", "法律法规", "检疫处理" };
        private static String[][] level_two = new String[4][];
        private static String[][][] level_three = new String[2][][];
        private static String[][][][] level_four = new String[2][][][];
        private static int oper = 0;

        public static deleteLink Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new deleteLink();
                return _instance;
            }
        }
        public deleteLink()
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
            level_four[1][1] = new String[2][];
            level_four[1][1][1] = new String[5] { "反刍动物疫病", "禽疫病", "马属动物疫病", "猪疫病", "野生动物疫病" };
            level_four[1][2] = new String[11][];
            level_four[1][2][7] = new String[9] { "检疫鉴定通用标准", "昆虫检测鉴定方法", "细菌检测鉴定方法", "杂草检测鉴定方法", "软体动物检测鉴定方法", "真菌检测鉴定方法", "线虫检测鉴定方法", "病毒检测检测方法", "其他检测、鉴定" };
            foreach (String i in level_one)
            {
                dllevel1.Items.Add(i);
            }
            dllevel1.SelectedIndex = 0;
            dllevel2.Visible = false;
            dllevel3.Visible = false;
            dllevel4.Visible = false;
        }

        private void loadContent()
        {
            int tag1 = dllevel1.SelectedIndex;
            int tag2 = dllevel2.Visible ? dllevel2.SelectedIndex : -1;
            int tag3 = dllevel3.Visible ? dllevel3.SelectedIndex : -1;
            int tag4 = dllevel4.Visible ? dllevel4.SelectedIndex : -1;
            String url = api_url + "get_files?type=html&class=" + tag1.ToString();
            if (tag4 != -1)
            {
                url = api_url + "get_files?class=" + tag1.ToString() + "&level2=" + tag2.ToString()
                    + "&level3=" + tag3.ToString() + "&level4=" + tag4.ToString();
            }
            else if (tag3 != -1)
            {
                url = api_url + "get_files?class=" + tag1.ToString() + "&level2=" + tag2.ToString()
                    + "&level3=" + tag3.ToString();
            }
            else if (tag2 != -1)
            {
                url = api_url + "get_files?class=" + tag1.ToString() + "&level2=" + tag2.ToString();
            }
            string delete_links = HttpUtils.Get(url);
            dynamic del = JsonConvert.DeserializeObject(delete_links);
            showDeleteLinks(del);
            oper = 1;
        }

        private void showDeleteLinks(dynamic tmp)
        {
            deleteLinkList.Rows.Clear();
            foreach (dynamic r in tmp)
            {
                DSkin.Controls.DSkinGridListRow row = new DSkin.Controls.DSkinGridListRow();
                DSkin.Controls.DSkinGridListCell filename = new DSkin.Controls.DSkinGridListCell();
                filename.Value = r["name"];
                filename.Tag = r["url"];
                row.Cells.Add(filename);
                DSkin.Controls.DSkinGridListCell oper = new DSkin.Controls.DSkinGridListCell();
                oper.Value = "删除";
                row.Cells.Add(oper);
                deleteLinkList.Rows.Add(row);
            }
            deleteLinkList.PageIndex = 1;
        }

        private void loadKeyword()
        {
            String keyword = deleteLinkKeyword.Text;

            if (keyword != "")
            {
                String url = api_url + "get_detail_files?type=html&keyword=" + keyword;
                string delete_files = HttpUtils.Get(url);
                dynamic del = JsonConvert.DeserializeObject(delete_files);
                showDeleteLinks(del);
                oper = 0;
            }
            else
            {
                DialogResult d = MessageBox.Show("请输入关键词！", "提示", MessageBoxButtons.OK);
            }
        }

        private void seachLinkLabel_Click(object sender, EventArgs e)
        {
            loadKeyword();
        }

        private void dllevel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dllevel1.SelectedIndex == 0)
            {
                dllevel2.Visible = false;
                dllevel3.Visible = false;
                dllevel4.Visible = false;
            }
            else if (dllevel1.SelectedIndex == 2 || dllevel1.SelectedIndex == 3)
            {
                dllevel2.Visible = true;
                dllevel3.Visible = false;
                dllevel4.Visible = false;
                dllevel2.Items.Clear();
                foreach (String s in level_two[dllevel1.SelectedIndex])
                {
                    dllevel2.Items.Add(s);
                }
                dllevel2.SelectedIndex = 0;
            }
            else
            {
                dllevel2.Visible = true;
                dllevel3.Visible = true;
                dllevel2.Items.Clear();
                foreach (String s in level_two[dllevel1.SelectedIndex])
                {
                    dllevel2.Items.Add(s);
                }
                dllevel2.SelectedIndex = 0;
            }
        }

        private void dllevel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dllevel1.SelectedIndex == 1)
            {
                dllevel3.Items.Clear();
                foreach (String s in level_three[dllevel1.SelectedIndex][dllevel2.SelectedIndex])
                {
                    dllevel3.Items.Add(s);
                }
                dllevel3.SelectedIndex = 0;
            }
        }

        private void dllevel3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tag1 = dllevel1.SelectedIndex;
            int tag2 = dllevel2.SelectedIndex;
            int tag3 = dllevel3.SelectedIndex;
            if ((tag1 == 1 && tag2 == 1 && tag3 == 1) || (tag1 == 1 && tag2 == 2 && tag3 == 7))
            {
                dllevel4.Visible = true;
                dllevel4.Items.Clear();
                foreach (string t in level_four[tag1][tag2][tag3])
                {
                    dllevel4.Items.Add(t);
                }
                dllevel4.SelectedIndex = 0;
            }
            else
            {
                dllevel4.Visible = false;
            }
        }

        private void deleteLinkList_ItemClick(object sender, DSkin.Controls.DSkinGridListMouseEventArgs e)
        {
            if (e.CellIndex == 0)
            {
                string url = e.Item.Cells[0].Tag.ToString();
                deleteLinkShow.Url = new System.Uri(url);
            }
            else if (e.CellIndex == 1)
            {
                DialogResult dr = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    string url = e.Item.Cells[0].Tag.ToString();
                    Console.WriteLine(url);
                    string delete_code = HttpUtils.Get(api_url + "delete_files?url=" + url);
                    if (delete_code.Contains("ok"))
                    {
                        DialogResult d = MessageBox.Show("删除链接成功！", "提示", MessageBoxButtons.OK);
                        if (oper == 0) loadKeyword();
                        else loadContent();
                    }
                    else
                    {
                        DialogResult d = MessageBox.Show("删除链接失败，请重试！", "提示", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void deleteLinkLabel_Click(object sender, EventArgs e)
        {
            deleteLinkLabel.Text = "加载中";
            this.Refresh();
            loadContent();
            deleteLinkLabel.Text = "加载目录";
            this.Refresh();
        }
    }
}
