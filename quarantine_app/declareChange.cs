using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quarantine_app
{
    public partial class declareChange : Form
    {
        private string username = "";
        private String api_url = "http://111.198.4.119:5000/api/";
        private List<int> change_index = new List<int>();
        private string img_urls = "";
        private string img_str1 = "";
        private string img_str2 = "";
        private string img_str3 = "";
        public static String user_name;

        public declareChange(string name, string state, dynamic infos)
        {
            InitializeComponent();
            declare_img1.SizeMode = PictureBoxSizeMode.StretchImage;
            declare_img2.SizeMode = PictureBoxSizeMode.StretchImage;
            declare_img3.SizeMode = PictureBoxSizeMode.StretchImage;
            username = name;
            declare_num.Enabled = false;
            declare_person.Enabled = false;
            showInit(infos, state);
        }

        private void showInit(dynamic infos, string state)
        {
            foreach (dynamic info in infos)
            {
                declare_num.Text = info["num"];
                declare_person.Text = username;
                declare_type.SelectedIndex = info["type"];
                declare_country.Text = info["source"];
                if (info["remark"].ToString() != "") declare_remark.Text = info["remark"];
                string[] img_urls = info["imgs"].ToString().Split('~');
                declare_img1.LoadAsync(img_urls[0]);
                img_str1 = img_urls[0];
                if (img_urls.Length > 1)
                {
                    declare_img2.LoadAsync(img_urls[1]);
                    img_str2 = img_urls[1];
                }
                if (img_urls.Length > 2)
                {
                    declare_img3.LoadAsync(img_urls[2]);
                    img_str3 = img_urls[2];
                }
                if (img_urls.Length == 1)
                {
                    declare_img2.BackgroundImage = Properties.Resources.upload;
                }
                else if (img_urls.Length == 2)
                {
                    declare_img3.BackgroundImage = Properties.Resources.upload;
                }
                if (int.Parse(info["way"].ToString()) == 0) offline_way.Checked = true;
                else online_way.Checked = true;
                declare_department.Text = info["department"];
                declare_date.Value = info["date"];
                declare_cargo.Text = info["cargo"];
                declare_pos.Text = info["position"];
            }
            if (state == "已鉴定")
            {
                declare_type.Enabled = false;
                declare_country.Enabled = false;
                declare_remark.Enabled = false;
                declare_img1.Click -= new EventHandler(declare_img1_Click);
                declare_img2.Click -= new EventHandler(declare_img2_Click);
                if (declare_img2.BackgroundImage == Properties.Resources.upload)
                    declare_img2.BackgroundImage.Dispose();
                declare_img3.Click -= new EventHandler(declare_img3_Click);
                if (declare_img3.BackgroundImage == Properties.Resources.upload)
                    declare_img3.BackgroundImage.Dispose();
                offline_way.Enabled = false;
                online_way.Enabled = false;
                declare_department.Enabled = false;
                declare_date.Enabled = false;
                declare_cargo.Enabled = false;
                declare_pos.Enabled = false;
                submitUpdate.Visible = false;
            }
        }

        private void declare_img1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择上传的图片";
            ofd.Filter = "图片格式|*.jpg|*.png|*.jpeg";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = ofd.FileName;
                using (Stream stream = ofd.OpenFile())
                {
                    declare_img1.Image = null;
                    declare_img1.Invalidate();
                    declare_img1.BackgroundImage = Image.FromStream(stream);
                    if (filePath != img_str2 && filePath != img_str3)
                    {
                        img_str1 = filePath;
                        if (!change_index.Contains(0)) change_index.Add(0);
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("已上传过该图片！", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    if (img_str2 == "")
                    {
                        declare_img2.BackgroundImage = Properties.Resources.upload;
                        declare_img2.Click += new EventHandler(this.declare_img2_Click);
                    }
                }
            }
        }

        private void declare_img2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择上传的图片";
            ofd.Filter = "图片格式|*.jpg|*.png|*.jpeg";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = ofd.FileName;
                using (Stream stream = ofd.OpenFile())
                {
                    declare_img2.Image = null;
                    declare_img2.Invalidate();
                    declare_img2.BackgroundImage = Image.FromStream(stream);
                    if (filePath != img_str1 && filePath != img_str3)
                    {
                        img_str2 = filePath;
                        if (!change_index.Contains(0)) change_index.Add(1);
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("已上传过该图片！", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    if (img_str3 == "")
                    {
                        declare_img3.BackgroundImage = Properties.Resources.upload;
                        declare_img3.Click += new EventHandler(this.declare_img3_Click);
                    }
                }
            }
        }

        private void declare_img3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择上传的图片";
            ofd.Filter = "图片格式|*.jpg|*.png|*.jpeg";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = ofd.FileName;
                using (Stream stream = ofd.OpenFile())
                {
                    declare_img3.Image = null;
                    declare_img3.Invalidate();
                    declare_img3.BackgroundImage = Image.FromStream(stream);
                    if (filePath != img_str1 && filePath != img_str2)
                    {
                        img_str3 = filePath;
                        if (!change_index.Contains(0)) change_index.Add(2);
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("已上传过该图片！", "提示", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
        }

        private void submitUpdate_Click(object sender, EventArgs e)
        {
            string change = "";
            if (img_str3 != "")
            {
                img_urls = img_str1 + "~" + img_str2 + "~" + img_str3;
            }
            else if (img_str2 != "")
            {
                img_urls = img_str1 + "~" + img_str2;
            }
            else if (img_str1 != "")
            {
                img_urls = img_str1;
            }
            foreach (int index in change_index)
            {
                if (index == 0)
                {
                    if (change == "") change += "0";
                    else change = change + "+0";
                }
                else if (index == 1)
                {
                    if (change == "") change += "1";
                    else change = change + "+1";
                }
                else
                {
                    if (change == "") change += "2";
                    else change = change + "+2";
                }
            }
            string number = declare_num.Text;
            string person = declare_person.Text;
            int type = declare_type.SelectedIndex;
            string country = declare_country.Text;
            string remark = declare_remark.Text;
            int declare_way = -1;
            if (offline_way.Checked)
            {
                declare_way = 0;
            }
            else if (online_way.Checked)
            {
                declare_way = 1;
            }
            string department = declare_department.Text;
            string date = declare_date.Value.ToString().Split(' ')[0];
            string cargo = declare_cargo.Text;
            string pos = declare_pos.Text;
            string updateRes = "";
            if (person == "")
            {
                DialogResult dr = MessageBox.Show("请填写申请人！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (country == "")
            {
                DialogResult dr = MessageBox.Show("请填写来源国！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (department == "")
            {
                DialogResult dr = MessageBox.Show("请填写申请单位！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (cargo == "")
            {
                DialogResult dr = MessageBox.Show("请填写货物名称！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (pos == "")
            {
                DialogResult dr = MessageBox.Show("请填写截获地点！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (change != "")
            {
                var storeDic = new Dictionary<string, string>() {
                    {
                        "num", number
                    },
                    {
                        "type", type.ToString()
                    },
                    {
                        "country", country
                    },
                    {
                        "remark", remark
                    },
                    {
                        "way", declare_way.ToString()
                    },
                    {
                        "department", department
                    },
                    {
                        "date", date
                    },
                    {
                        "cargo", cargo
                    },
                    {
                        "pos", pos
                    },
                    {
                        "change_img", change
                    },
                    {
                        "img_url", img_urls
                    }
                    ,
                    {
                        "user_name", user_name
                    }
                };
                updateRes = HttpUtils.UploadImage(api_url + "update_declare", img_urls, storeDic);
            }
            else
            {
                Hashtable ht = new Hashtable();
                ht.Add("num", number);
                ht.Add("type", type.ToString());
                ht.Add("country", country);
                ht.Add("remark", remark);
                ht.Add("way", declare_way.ToString());
                ht.Add("department", department);
                ht.Add("date", date);
                ht.Add("cargo", cargo);
                ht.Add("pos", pos);
                ht.Add("img_url", img_urls);
                ht.Add("user_name", user_name);
                updateRes = HttpUtils.DoPost(api_url + "update_declare", ht);
            }

            if (updateRes.Contains("ok"))
            {
                DialogResult dr = MessageBox.Show("更新成功！", "提示", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    string declare_info = HttpUtils.Get(api_url + "declare_info?num=" + declare_num.Text);
                    dynamic info = JsonConvert.DeserializeObject(declare_info);
                    string s = "";
                    foreach (dynamic r in info)
                    {
                        s = r["state"].ToString();
                    }
                    showInit(info, s);
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("更新失败，请重试！", "提示", MessageBoxButtons.OK);
            }
        }
    }
}
