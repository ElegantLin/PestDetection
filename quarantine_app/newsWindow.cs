using DSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quarantine_app
{
    public partial class newsWindow : Form
    {
        String api_url = "http://111.198.4.119:5000/api/";
        public newsWindow()
        {
            InitializeComponent();
            string xwzx_files = HttpUtils.Get(api_url + "get_files?class=0");
            dynamic xwzx = JsonConvert.DeserializeObject(xwzx_files);
            news_Reload(xwzx);
        }

        private void news_Reload(dynamic res)
        {
            newsDetailList.Rows.Clear();
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
                newsDetailList.Rows.Add(sample);
            }
        }

        private void newsSearch_Click(object sender, EventArgs e)
        {
            if (newsStart.Value <= newsEnd.Value)
            {
                string start_date = newsStart.Value.ToString().Split(' ')[0];
                string end_date = newsEnd.Value.ToString().Split(' ')[0];
                string keyword = newsKeyword.Text;
                string news_detail_files;
                if (keyword.Length > 0)
                {
                    news_detail_files = HttpUtils.Get(api_url + "get_detail_files?class=0&start=" + start_date + "&end=" + end_date + "&keyword=" + keyword);
                }
                else
                {
                    news_detail_files = HttpUtils.Get(api_url + "get_detail_files?class=0&start=" + start_date + "&end=" + end_date);
                }
                dynamic news_detail = JsonConvert.DeserializeObject(news_detail_files);
                news_Reload(news_detail);
            }
            else
            {
                DialogResult dr = MessageBox.Show("起始日期不得大于截止日期", "提示", MessageBoxButtons.OK);
            }
        }

        private void newsDetailList_ItemClick(object sender, DSkinGridListMouseEventArgs e)
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
    }
}
