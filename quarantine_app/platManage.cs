using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using DSkin.Controls;
using System.Collections;

namespace quarantine_app
{
    public partial class platManage : UserControl
    {
        private static platManage _instance;
        private static String api_url = "http://111.198.4.119:5000/api/";
        public static String plat_user;

        public static platManage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new platManage();
                return _instance;
            }
        }
        public platManage()
        {
            InitializeComponent();
            showPlatInfos();
        }
        private void showPlatInfos()
        {
            string keyword = platKeyword.Text;
            string url = api_url;
            string delete_plat = "";
            if (keyword == "")
            {
                delete_plat = HttpUtils.Get(api_url + "get_platform");
            }
            else
            {
                delete_plat = HttpUtils.Get(api_url + "get_platform?keyword=" + keyword);

            }
            dynamic del = JsonConvert.DeserializeObject(delete_plat);
            platformInfos.Rows.Clear();
            foreach (dynamic r in del)
            {
                DSkinGridListRow sample = new DSkinGridListRow();
                DSkinGridListCell title = new DSkinGridListCell();
                title.Value = r["title"];
                title.Font = new Font(new FontFamily("幼圆"), 10, FontStyle.Regular);
                sample.Cells.Add(title);
                DSkinGridListCell date = new DSkinGridListCell();
                date.Value = r["date"];
                date.Font = new Font(new FontFamily("幼圆"), 10, FontStyle.Regular);
                sample.Cells.Add(date);
                DSkinGridListCell oper = new DSkinGridListCell();
                oper.Value = "删除";
                oper.Tag = r["title"];
                oper.Font = new Font(new FontFamily("幼圆"), 10, FontStyle.Regular);
                sample.Cells.Add(oper);
                platformInfos.Rows.Add(sample);
            }
        }

        private void dSkinButton1_Click(object sender, EventArgs e)
        {  
            showPlatInfos();
        }

        private void platformInfos_ItemClick(object sender, DSkinGridListMouseEventArgs e)
        {
            if (e.CellIndex == 2)
            {
                DialogResult dr = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    string title = e.Item.Cells[2].Tag.ToString();                    
                    string delete_code = HttpUtils.Get(api_url + "delete_platform?title=" + title);
                    if (delete_code.Contains("ok"))
                    {
                        DialogResult d = MessageBox.Show("删除平台动态成功！", "提示", MessageBoxButtons.OK);
                        showPlatInfos();
                    }
                    else
                    {
                        DialogResult d = MessageBox.Show("删除平台动态失败，请重试！", "提示", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void uploadPlat_Click(object sender, EventArgs e)
        {
            string title = platformTitle.Text;
            if (title == "")
            {
                DialogResult dr = MessageBox.Show("请输入平台动态标题！", "提示", MessageBoxButtons.OK);
                return;
            }
            else
            {
                Hashtable ht = new Hashtable();
                ht.Add("title", title);
                ht.Add("owner", plat_user);
                string res = HttpUtils.DoPost(api_url + "upload_platform", ht);
                if (res.Contains("ok"))
                {
                    DialogResult dr = MessageBox.Show("添加动态成功！", "提示", MessageBoxButtons.OK);
                    showPlatInfos();
                }
                else
                {
                    DialogResult dr = MessageBox.Show("标题重复，请修改后重试！", "提示", MessageBoxButtons.OK);
                    return;
                }
            }
        }
    }
}
