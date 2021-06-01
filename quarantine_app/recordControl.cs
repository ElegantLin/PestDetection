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
    public partial class recordControl : UserControl
    {
        private static recordControl _instance;
        private static String api_url = "http://111.198.4.119:5000/api/";
        public static string user_names;
        public static recordControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new recordControl();
                return _instance;
            }
        }
        public recordControl()
        {
            InitializeComponent();
            string res = HttpUtils.Get(api_url + "get_declares?username=" + user_names);
            showRecords(res);
        }

        private void showRecords(dynamic res)
        {
            dynamic ress = JsonConvert.DeserializeObject(res);
            declare_records.Rows.Clear();
            foreach (dynamic r in ress)
            {
                DSkin.Controls.DSkinGridListRow row = new DSkin.Controls.DSkinGridListRow();
                DSkin.Controls.DSkinGridListCell num = new DSkin.Controls.DSkinGridListCell();
                num.Value = r["num"];
                row.Cells.Add(num);
                DSkin.Controls.DSkinGridListCell depCell = new DSkin.Controls.DSkinGridListCell();
                depCell.Value = r["department"];
                row.Cells.Add(depCell);
                DSkin.Controls.DSkinGridListCell perCell = new DSkin.Controls.DSkinGridListCell();
                perCell.Value = r["person"];
                row.Cells.Add(perCell);
                DSkin.Controls.DSkinGridListCell dateCell = new DSkin.Controls.DSkinGridListCell();
                dateCell.Value = r["date"];
                row.Cells.Add(dateCell);
                DSkin.Controls.DSkinGridListCell typeCell = new DSkin.Controls.DSkinGridListCell();
                typeCell.Value = r["type"];
                row.Cells.Add(typeCell);
                DSkin.Controls.DSkinGridListCell carCell = new DSkin.Controls.DSkinGridListCell();
                carCell.Value = r["cargo"];
                row.Cells.Add(carCell);
                DSkin.Controls.DSkinGridListCell couCell = new DSkin.Controls.DSkinGridListCell();
                couCell.Value = r["country"];
                row.Cells.Add(couCell);
                DSkin.Controls.DSkinGridListCell posCell = new DSkin.Controls.DSkinGridListCell();
                posCell.Value = r["position"];
                row.Cells.Add(posCell);
                DSkin.Controls.DSkinGridListCell wayCell = new DSkin.Controls.DSkinGridListCell();
                wayCell.Value = r["way"];
                row.Cells.Add(wayCell);
                declare_records.Rows.Add(row);
            }
        }

        private void dSkinButton1_Click(object sender, EventArgs e)
        {
            if (declare_start.Value <= declare_end.Value)
            {
                string start = declare_start.Value.ToString().Split(' ')[0];
                string end = declare_end.Value.ToString().Split(' ')[0];
                string keyword = declare_keyword.Text;
                string declare_detail_records;
                if (keyword.Length > 0)
                {
                    declare_detail_records = HttpUtils.Get(api_url + "get_declare_records?username=" + user_names + "&start=" + start + "&end=" + end + "&keyword=" + keyword);
                }
                else
                {
                    declare_detail_records = HttpUtils.Get(api_url + "get_declare_records?username=" + user_names + "&start=" + start + "&end=" + end);
                }                
                showRecords(declare_detail_records);                             
            }
            else
            {
                DialogResult dr = MessageBox.Show("起始日期不得大于截止日期", "提示", MessageBoxButtons.OK);
            }
           
        }
    }
}
