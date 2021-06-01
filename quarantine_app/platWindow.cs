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
    public partial class platWindow : Form
    {
        String api_url = "http://111.198.4.119:5000/api/";
        public platWindow()
        {
            InitializeComponent();
            string plat_files = HttpUtils.Get(api_url + "get_platform");
            dynamic plat = JsonConvert.DeserializeObject(plat_files);
            plat_Reload(plat);
        }

        private void plat_Reload(dynamic res)
        {
            platDetailList.Rows.Clear();
            foreach (dynamic r in res)
            {
                DSkinGridListRow sample = new DSkinGridListRow();
                sample.Height = 60;
                DSkinGridListCell icon = new DSkinGridListCell();
                sample.Cells.Add(icon);
                //icon.BackgroundImage = Properties.Resources;
                DSkinGridListCell title = new DSkinGridListCell();
                title.Value = r["title"].ToString();
                title.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                title.DockStyle = DockStyle.Left;
                sample.Cells.Add(title);
                DSkinGridListCell date = new DSkinGridListCell();
                date.Value = r["date"].ToString();
                date.Font = new Font(new FontFamily("幼圆"), 12, FontStyle.Regular);
                date.DockStyle = DockStyle.Right;
                sample.Cells.Add(date);
                platDetailList.Rows.Add(sample);
            }
        }

        private void platSearch_Click(object sender, EventArgs e)
        {
            if (platStart.Value <= platEnd.Value)
            {
                string start_date = platStart.Value.ToString().Split(' ')[0];
                string end_date = platEnd.Value.ToString().Split(' ')[0];
                string keyword = platKeyword.Text;
                string plat_detail_files;
                if (keyword.Length > 0)
                {
                    plat_detail_files = HttpUtils.Get(api_url + "get_platform?start=" + start_date + "&end=" + end_date + "&keyword=" + keyword);
                }
                else
                {
                    plat_detail_files = HttpUtils.Get(api_url + "get_platform?start=" + start_date + "&end=" + end_date);
                }
                dynamic plat_detail = JsonConvert.DeserializeObject(plat_detail_files);
                plat_Reload(plat_detail);
            }
            else
            {
                DialogResult dr = MessageBox.Show("起始日期不得大于截止日期", "提示", MessageBoxButtons.OK);
            }
        }
    }
}
