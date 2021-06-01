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
    public partial class sampleSearch : Form
    {
        private static String api_url = "http://111.198.4.119:5000/api/";
        public sampleSearch(dynamic res)
        {
            InitializeComponent();
            showRecords(res);
        }

        private void showRecords(dynamic res)
        {
            dynamic ress = JsonConvert.DeserializeObject(res);
            sampleList.Rows.Clear();
            foreach (dynamic r in ress)
            {
                DSkin.Controls.DSkinGridListRow row = new DSkin.Controls.DSkinGridListRow();
                DSkin.Controls.DSkinGridListCell num = new DSkin.Controls.DSkinGridListCell();
                num.Value = r["num"];
                num.Tag = r["num"].ToString();
                row.Cells.Add(num);
                DSkin.Controls.DSkinGridListCell nameCell = new DSkin.Controls.DSkinGridListCell();
                nameCell.Value = r["species_cn"];
                row.Cells.Add(nameCell);
                DSkin.Controls.DSkinGridListCell operCell = new DSkin.Controls.DSkinGridListCell();
                operCell.Value = "查看详情";
                operCell.Tag = r["type"];
                row.Cells.Add(operCell);
                sampleList.Rows.Add(row);
            }
        }

        private void sampleList_ItemClick(object sender, DSkin.Controls.DSkinGridListMouseEventArgs e)
        {
            string num = e.Item.Cells[0].Tag.ToString();
            string type = e.Item.Cells[2].Tag.ToString();
            if (e.CellIndex == 2)
            {
                string declare_res = HttpUtils.Get(api_url + "find_sample?num=" + num + "&type=" + type.ToString());
                dynamic ress = JsonConvert.DeserializeObject(declare_res);
                searchSampleResult ssr = new searchSampleResult(ress);
                ssr.ShowDialog();
            }
        }
    }
}
