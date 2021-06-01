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
using System.Collections;

namespace quarantine_app
{
    public partial class accountManage : UserControl
    {
        private static accountManage _instance;
        private String api_url = "http://111.198.4.119:5000/api/";
        private Dictionary<string, List<int>> index_change = new Dictionary<string, List<int>>();
        private List<int> row_num = new List<int>();
        private Dictionary<string, List<string>> value_change = new Dictionary<string, List<string>>();
        public static accountManage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new accountManage();
                return _instance;
            }
        }
        public accountManage()
        {
            InitializeComponent();
            string users_info = HttpUtils.Get(api_url + "get_users");
            dynamic info = JsonConvert.DeserializeObject(users_info);
            usersDefault(info);
        }

        private void usersDefault(dynamic res)
        {
            accountLists.Rows.Clear();
            int num = 0;
            foreach (dynamic r in res)
            {
                DSkin.Controls.DSkinGridListRow row = new DSkin.Controls.DSkinGridListRow();
                DSkin.Controls.DSkinGridListCell name = new DSkin.Controls.DSkinGridListCell();
                name.Value = r["name"];
                row.Cells.Add(name);
                DSkin.Controls.DSkinGridListCell pwd = new DSkin.Controls.DSkinGridListCell();
                pwd.Value = r["pwd"];
                row.Cells.Add(pwd);                
                DSkin.Controls.DSkinGridListCell type = new DSkin.Controls.DSkinGridListCell();
                type.Value = r["type"];
                row.Cells.Add(type);
                DSkin.Controls.DSkinGridListCell acname = new DSkin.Controls.DSkinGridListCell();
                acname.Value = r["acname"];
                row.Cells.Add(acname);
                DSkin.Controls.DSkinGridListCell department = new DSkin.Controls.DSkinGridListCell();
                department.Value = r["department"];
                row.Cells.Add(department);
                DSkin.Controls.DSkinGridListCell region = new DSkin.Controls.DSkinGridListCell();
                region.Value = r["region"];
                row.Cells.Add(region);
                DSkin.Controls.DSkinGridListCell workyear = new DSkin.Controls.DSkinGridListCell();
                workyear.Value = r["work_year"];
                row.Cells.Add(workyear);
                DSkin.Controls.DSkinGridListCell title = new DSkin.Controls.DSkinGridListCell();
                title.Value = r["user_title"];
                row.Cells.Add(title);
                DSkin.Controls.DSkinGridListCell auth = new DSkin.Controls.DSkinGridListCell();
                auth.Value = r["auth"];
                row.Cells.Add(auth);
                row.Tag = num;
                num += 1;
                accountLists.Rows.Add(row);
            }
        }

        private void searchAccBtn_Click(object sender, EventArgs e)
        {
            string keyword = accKeyword.Text;
            string users_info = "";
            if (keyword == "")
            {
                users_info = HttpUtils.Get(api_url + "get_users");                
            }
            else
            {
                users_info = HttpUtils.Get(api_url + "get_users?keyword=" + keyword);                
            }
            dynamic info = JsonConvert.DeserializeObject(users_info);
            usersDefault(info);
        }

        private void accountLists_ItemDoubleClick(object sender, DSkin.Controls.DSkinGridListMouseEventArgs e)
        {
            if (e.CellIndex > 0)
            {
                string a = e.Item.Cells[e.CellIndex].Value.ToString();
                e.Item.Cells.Remove(e.Item.Cells[e.CellIndex]);
                DSkin.Controls.DSkinGridListCell cell = new DSkin.Controls.DSkinGridListCell();
                cell.ItemType = DSkin.Controls.ControlType.DuiTextBox;
                cell.Value = a;              
                e.Item.Cells.Insert(e.CellIndex, cell);
                string user = e.Item.Cells[0].Value.ToString();
                if (index_change.ContainsKey(user))
                {
                    index_change[user].Add(e.CellIndex);
                }
                else
                {
                    List <int> list = new List<int>();
                    list.Add(e.CellIndex);
                    index_change.Add(user, list);
                    row_num.Add(int.Parse(e.Item.Tag.ToString()));
                }
            }
        }

        private void accUpdate_Click(object sender, EventArgs e)
        {
            string change_index = "";
            string change_value = "";
            int index = 0;
            foreach (KeyValuePair<string, List<int>> kvp in index_change)
            {
                string username = kvp.Key;
                change_index += username;               
                foreach (int i in kvp.Value)
                {
                    if (value_change.ContainsKey(username))
                    {
                        value_change[username].Add(accountLists.Rows[row_num[index]].Cells[i].Text);
                    }
                    else
                    {
                        List<string> list = new List<string>();
                        if (i == 6)
                        {
                            int tag = 0;
                            string work_year = accountLists.Rows[row_num[index]].Cells[i].Text;
                            if (work_year.Contains("年"))
                            {
                                if (work_year.IndexOf("年") != work_year.Length - 1) tag = 1;
                                else
                                {
                                    work_year = work_year.Substring(0, work_year.Length - 1);
                                    try
                                    {
                                        int year = int.Parse(work_year);
                                        list.Add(year.ToString());
                                    }
                                    catch (Exception)
                                    {
                                        tag = 1;
                                    }
                                }
                            }
                            else
                            {
                                try
                                {
                                    int year = int.Parse(work_year);
                                    list.Add(year.ToString());
                                }
                                catch (Exception)
                                {
                                    tag = 1;
                                }
                            }
                            if (tag == 1)
                            {
                                DialogResult error = MessageBox.Show("从业年限格式有误！", "提示", MessageBoxButtons.OK);
                                return;
                            }
                        }
                        else if (i == 8)
                        {
                            string role = accountLists.Rows[row_num[index]].Cells[i].Text;
                            if (role != "普通" && role != "管理员")
                            {
                                DialogResult error = MessageBox.Show("请输入普通或管理员", "提示", MessageBoxButtons.OK);
                                return;
                            }
                            else list.Add(role);
                        }
                        else list.Add(accountLists.Rows[row_num[index]].Cells[i].Text);
                        value_change.Add(username, list);
                    }                    
                }
                String indexes = String.Join(",", kvp.Value);
                change_index = change_index + "<" + indexes;
                change_index += "+";
                index += 1;
            }
            change_index = change_index.Substring(0, change_index.Length - 1);
            foreach (KeyValuePair<string, List<string>> kvp in value_change)
            {
                string username = kvp.Key;
                change_value += username;              
                String indexes = String.Join(",", kvp.Value);
                change_value = change_value + "<" + indexes;
                change_value += "+";
            }
            change_value = change_value.Substring(0, change_value.Length - 1);

            Hashtable ht = new Hashtable();
            ht.Add("index", change_index);
            ht.Add("value", change_value);
            string res = HttpUtils.DoPost(api_url + "update_multi_users", ht);
            if (res.Contains("ok"))
            {
                DialogResult success = MessageBox.Show("更新成功！", "提示", MessageBoxButtons.OK);
                return;
            }
            else
            {
                DialogResult fail = MessageBox.Show("更新失败，请重试！", "提示", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
