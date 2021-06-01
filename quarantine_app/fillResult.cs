using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quarantine_app
{
    public partial class fillResult : Form
    {
        private static String api_url = "http://111.198.4.119:5000/api/";
        private dynamic temp;
        public static String user_name;

        public fillResult(string num)
        {
            InitializeComponent();
            string declare_info = HttpUtils.Get(api_url + "declare_info?num=" + num);
            temp = JsonConvert.DeserializeObject(declare_info);
        }

        public static bool isNum(string input)
        {
            string pattern = @"^[0-9]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }

        private void fillNum_Click(object sender, EventArgs e)
        {
            string number = numText.Text;
            if (!isNum(number))
            {
                DialogResult dr = MessageBox.Show("请输入正确的最终编号的格式！", "提示", MessageBoxButtons.OK);
                return;
            }
            Hashtable ht = new Hashtable();
            foreach (dynamic t in temp)
            {
                ht.Add("num", t["num"].ToString());
                ht.Add("type", t["type"].ToString());
                ht.Add("country", t["source"].ToString());
                ht.Add("remark", t["remark"].ToString());
                ht.Add("way", t["way"].ToString());
                ht.Add("department", t["department"].ToString());
                ht.Add("date", t["date"].ToString());
                ht.Add("cargo", t["cargo"].ToString());
                ht.Add("pos", t["position"].ToString());
                ht.Add("img_url", t["imgs"].ToString());
            }
            ht.Add("status", "1");
            ht.Add("res", number);
            ht.Add("user_name", user_name);
            dynamic updateRes = HttpUtils.DoPost(api_url + "update_declare", ht);
            if (updateRes.Contains("ok"))
            {
                DialogResult dr = MessageBox.Show("更新成功！", "提示", MessageBoxButtons.OK);
                this.Dispose();
                this.Close();
            }
            else
            {
                DialogResult dr = MessageBox.Show("更新失败，请重试！", "提示", MessageBoxButtons.OK);
            }
        }
    }
}
