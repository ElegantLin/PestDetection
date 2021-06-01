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
    public partial class authControl : UserControl
    {
        private static authControl _instance;
        private String api_url = "http://111.198.4.119:5000/api/";
        public static string auth_name;
        public static authControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new authControl();
                return _instance;
            }
        }
        public authControl()
        {
            InitializeComponent();
            string res = HttpUtils.Get(api_url + "get_declares?username=" + auth_name + "&way=1");
            showAuthRecords(res);
            string ress = HttpUtils.Get(api_url + "get_users?type=分类学专家");
            showUsers(ress);
            userTypeSelect.Items.Add("分类学专家");
            /*string types = HttpUtils.Get(api_url + "get_user_types");
            dynamic type_res = JsonConvert.DeserializeObject(types);
            foreach (dynamic t in type_res)
            {
                userTypeSelect.Items.Add(t.ToString());
            }*/
            userTypeSelect.SelectedIndex = 0;
        }

        private void showAuthRecords(dynamic res)
        {
            dynamic ress = JsonConvert.DeserializeObject(res);
            auth_record_list.Rows.Clear();
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
                DSkin.Controls.DSkinGridListCell stateCell = new DSkin.Controls.DSkinGridListCell();
                stateCell.Value = "未鉴定";
                row.Cells.Add(stateCell);
                DSkin.Controls.DSkinGridListCell launchCell = new DSkin.Controls.DSkinGridListCell();
                launchCell.Value = "启动";
                row.Cells.Add(launchCell);
                auth_record_list.Rows.Add(row);
            }
        }

        private void showUsers(dynamic res)
        {
            dynamic ress = JsonConvert.DeserializeObject(res);
            userDataList.Rows.Clear();
            foreach (dynamic r in ress)
            {
                DSkin.Controls.DSkinGridListRow row = new DSkin.Controls.DSkinGridListRow();
                DSkin.Controls.DSkinGridListCell type = new DSkin.Controls.DSkinGridListCell();
                type.Value = r["type"];
                row.Cells.Add(type);
                DSkin.Controls.DSkinGridListCell name = new DSkin.Controls.DSkinGridListCell();
                name.Value = r["acname"];
                row.Cells.Add(name);
                DSkin.Controls.DSkinGridListCell department = new DSkin.Controls.DSkinGridListCell();
                department.Value = r["department"];
                row.Cells.Add(department);
                DSkin.Controls.DSkinGridListCell region = new DSkin.Controls.DSkinGridListCell();
                region.Value = r["region"];
                row.Cells.Add(region);
                DSkin.Controls.DSkinGridListCell year = new DSkin.Controls.DSkinGridListCell();
                year.Value = r["work_year"];
                row.Cells.Add(year);
                DSkin.Controls.DSkinGridListCell title = new DSkin.Controls.DSkinGridListCell();
                title.Value = r["user_title"];
                row.Cells.Add(title);             
                userDataList.Rows.Add(row);
            }
        }

        private void dSkinButton1_Click(object sender, EventArgs e)
        {
            if (online_start.Value <= online_end.Value)
            {
                string start = online_start.Value.ToString().Split(' ')[0];
                string end = online_end.Value.ToString().Split(' ')[0];
                string keyword = online_keyword.Text;
                string declare_detail_records;
                if (keyword.Length > 0)
                {
                    declare_detail_records = HttpUtils.Get(api_url + "get_declare_records?username=" + auth_name + "&way=1&start=" + start + "&end=" + end + "&keyword=" + keyword);
                }
                else
                {
                    declare_detail_records = HttpUtils.Get(api_url + "get_declare_records?username=" + auth_name + "&way=1&start=" + start + "&end=" + end);
                }
                showAuthRecords(declare_detail_records);
            }
            else
            {
                DialogResult dr = MessageBox.Show("起始日期不得大于截止日期", "提示", MessageBoxButtons.OK);
            }
        }

        private void auth_record_list_ItemClick(object sender, DSkin.Controls.DSkinGridListMouseEventArgs e)
        {
            if (e.CellIndex == 10)
            {
                if (!this.Parent.Controls.Contains(meetingControl.Instance))
                {
                    this.Parent.Controls.Add(meetingControl.Instance);
                    meetingControl.Instance.Dock = DockStyle.Fill;
                    meetingControl.Instance.BringToFront();
                }
                else
                {
                    meetingControl.Instance.BringToFront();
                }
            }
        }

        private void searchUserBtn_Click(object sender, EventArgs e)
        {
            int index = userTypeSelect.SelectedIndex;
            String type = userTypeSelect.Items[index].ToString();
            String keyword = userSearchKeyword.Text;
            String user_data = "";
            if (index == 0)
            {
                if (keyword == "")
                {
                    user_data = HttpUtils.Get(api_url + "get_users?type=分类学专家");
                }
                else
                {
                    user_data = HttpUtils.Get(api_url + "get_users?type=分类学专家&keyword=" + keyword);
                }
            }
            else
            {
                if (keyword == "")
                {
                    user_data = HttpUtils.Get(api_url + "get_users?type=" + type);
                }
                else
                {
                    user_data = HttpUtils.Get(api_url + "get_users?type=" + type + "&keyword=" + keyword);
                }
            }
            showUsers(user_data);
        }
    }
}
