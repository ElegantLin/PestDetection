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
    public partial class accountInfo : UserControl
    {
        private static accountInfo _instance;
        private static String api_url = "http://111.198.4.119:5000/api/";
        public static string acc_name;
        public static accountInfo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new accountInfo();
                return _instance;
            }
        }

        public accountInfo()
        {
            InitializeComponent();
            nameInput.Text = acc_name;
            string user_info = HttpUtils.Get(api_url + "get_user_info?username=" + acc_name);
            dynamic info = JsonConvert.DeserializeObject(user_info);
            showDefault(info);
        }

        private void showDefault(dynamic res)
        {
            foreach (dynamic r in res)
            {
                personType.Text = r["type"];
                personName.Text = r["name"];
                departmentInput.Text = r["department"];
                region.Text = r["region"];
                workYear.Text = r["work_year"];
                personTitle.Text = r["user_title"];
            }
        }

        private void updateInfo_Click(object sender, EventArgs e)
        {
            string original = originalPwd.Text;
            string current = currentPwd.Text;
            string confirm = confirmPwd.Text;
            string type = personType.Text;
            string name = personName.Text;
            string department = departmentInput.Text;
            string regionText = region.Text;
            string work_year = workYear.Text;
            string title = personTitle.Text;
            if (currentPwd.Text != "")
            {              
                if (confirm == "")
                {
                    DialogResult dr = MessageBox.Show("请输入输入密码", "提示", MessageBoxButtons.OK);
                    return;
                }
                else if (current != confirm)
                {
                    DialogResult dr = MessageBox.Show("确认密码必须输入相同的密码", "提示", MessageBoxButtons.OK);
                    return;
                }
            }
            int year = 0;
            if (work_year.Contains("年"))
            {
                try
                {
                    year = Int32.Parse(work_year.Substring(0, work_year.Length - 1));
                }
                catch (FormatException)
                {
                    DialogResult dr = MessageBox.Show("请输入正确格式的从业年限，限整数", "提示", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                try
                {
                    year = Int32.Parse(work_year.Substring(0, work_year.Length - 1));
                }
                catch (FormatException)
                {
                    DialogResult dr = MessageBox.Show("请输入正确格式的从业年限，限整数", "提示", MessageBoxButtons.OK);
                    return;
                }
            }
            Hashtable ht = new Hashtable();
            ht.Add("username", acc_name);
            ht.Add("oripwd", original);
            ht.Add("curpwd", current);
            ht.Add("type", type);
            ht.Add("name", name);
            ht.Add("department", department);
            ht.Add("region", regionText);
            ht.Add("year", year.ToString());
            ht.Add("title", title);
            string res = HttpUtils.DoPost(api_url + "update_account", ht);
            if (res.Contains("ok"))
            {
                DialogResult dr = MessageBox.Show("更新成功", "提示", MessageBoxButtons.OK);
                return;
            }
            else if (res.Contains("pwd error"))
            {
                DialogResult dr = MessageBox.Show("密码输入错误", "提示", MessageBoxButtons.OK);
                return;
            }
            else
            {
                DialogResult dr = MessageBox.Show("更新失败，请重试", "提示", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
