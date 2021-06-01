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
    public partial class resultControl : UserControl
    {
        private static resultControl _instance;
        private static String api_url = "http://111.198.4.119:5000/api/";
        public static string result_name;
        public static resultControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new resultControl();
                return _instance;
            }
        }
        public resultControl()
        {
            InitializeComponent();
            authStatus.AddItem("鉴定状态");
            authStatus.AddItem("未鉴定");
            authStatus.AddItem("已鉴定");
            authStatus.SelectedIndex = 0;
            waySelector.AddItem("鉴定方式");
            waySelector.AddItem("离线鉴定");
            waySelector.AddItem("在线鉴定");
            waySelector.SelectedIndex = 0;
            string res = HttpUtils.Get(api_url + "get_declares?username=" + result_name);
            showRecords(res);
        }

        private void showRecords(dynamic res)
        {
            dynamic ress = JsonConvert.DeserializeObject(res);
            resultsList.Rows.Clear();
            foreach (dynamic r in ress)
            {
                DSkin.Controls.DSkinGridListRow row = new DSkin.Controls.DSkinGridListRow();
                DSkin.Controls.DSkinGridListCell num = new DSkin.Controls.DSkinGridListCell();
                num.Value = r["num"];
                num.Tag = r["num"].ToString();
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
                DSkin.Controls.DSkinGridListCell stateCell = new DSkin.Controls.DSkinGridListCell();
                stateCell.Value = r["status"];
                stateCell.Tag = r["status"].ToString();
                row.Cells.Add(stateCell);
                DSkin.Controls.DSkinGridListCell resCell = new DSkin.Controls.DSkinGridListCell();
                if (r["status"].ToString() == "未鉴定") resCell.Value = "结果填写";
                else if (r["status"].ToString() == "已鉴定")
                {
                    resCell.Value = "结果查看";
                    resCell.Tag = r["res"];
                }   
                row.Cells.Add(resCell);
                resultsList.Rows.Add(row);
            }
        }

        private void resultsList_ItemClick(object sender, DSkin.Controls.DSkinGridListMouseEventArgs e)
        {
            string num = e.Item.Cells[0].Tag.ToString();
            string state = e.Item.Cells[9].Tag.ToString();
            object res = e.Item.Cells[10].Tag;
            if (e.CellIndex == 0)
            {
                string declare_info = HttpUtils.Get(api_url + "declare_info?num=" + num);
                dynamic info = JsonConvert.DeserializeObject(declare_info);
                var dc = new declareChange(result_name, state, info);
                dc.ShowDialog();
            }
            else if (e.CellIndex == 10)
            {
                if (state == "已鉴定")
                {
                    /*if (res.ToString() == "")
                    {
                        DialogResult dr = MessageBox.Show("数据库无此物种！", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    int type = 0;
                    if (e.Item.Cells[4].Value.ToString() == "杂草") type = 1;
                    string declare_res = HttpUtils.Get(api_url + "find_sample?num=" + res.ToString() + "&type=" + type.ToString());
                    dynamic ress = JsonConvert.DeserializeObject(declare_res);
                    foreach (dynamic r in ress)
                    {
                        if (r["phylum_cn"] == null)
                        {
                            DialogResult dr = MessageBox.Show("数据库无此物种！", "提示", MessageBoxButtons.OK);
                            return;
                        }
                    }
                    var declare_result = new declareResult(ress);
                    declare_result.ShowDialog();*/
                    var print = new printForm(num);
                    print.ShowDialog();
                }
                else
                {
                    var fillResults = new fillResult(num);
                    fillResults.ShowDialog();
                }
            }
            /*if (e.CellIndex == 10)
            {
                var print = new printForm();
                print.ShowDialog();
            }*/
        }

        private void resSearchBtn_Click(object sender, EventArgs e)
        {
            string url = api_url + "get_declare_records?username=" + result_name;
            if (resStart.Value <= resEnd.Value)
            {
                string start = resStart.Value.ToString().Split(' ')[0];
                string end = resEnd.Value.ToString().Split(' ')[0];
                string keyword = resKeyword.Text;
                string declare_detail_records;
                url = url + "&start=" + start + "&end=" + end;
                if (authStatus.SelectedIndex > 0)
                {
                    url = url + "&status=" + (authStatus.SelectedIndex - 1).ToString();
                }
                if (waySelector.SelectedIndex > 0)
                {
                    url = url + "&way=" + (waySelector.SelectedIndex - 1).ToString();
                }
                if (keyword.Length > 0)
                {
                    url = url + "&keyword=" + keyword;                   
                }
                declare_detail_records = HttpUtils.Get(url);                
                showRecords(declare_detail_records);
            }
            else
            {
                DialogResult dr = MessageBox.Show("起始日期不得大于截止日期", "提示", MessageBoxButtons.OK);
            }
        }
    }
}
