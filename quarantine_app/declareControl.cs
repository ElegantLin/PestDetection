using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace quarantine_app
{
    public partial class declareControl : UserControl
    {
        private static declareControl _instance;
        private String api_url = "http://111.198.4.119:5000/api/";
        private int img_num;
        private string img_urls = "";
        private string img_str1 = "";
        private string img_str2 = "";
        private string img_str3 = "";
        public static string user_name;
        private Image original;
        private Image blank;
        public static declareControl Instance{
            get {
                if (_instance == null)
                    _instance = new declareControl();
                return _instance;
            }
        }
        public declareControl()
        {
            InitializeComponent();
            generateNum();
            original = declare_img1.BackgroundImage;
            blank = declare_img2.BackgroundImage;
            declare_img2.Click -= new EventHandler(this.declare_img2_Click);
            declare_img3.Click -= new EventHandler(this.declare_img3_Click);
        }

        private void generateNum()
        {
            Random random = new Random();
            int number = random.Next();
            string today = DateTime.Now.ToString("yyyyMMdd");
            declare_num.Text = today + number.ToString();
            declare_type.SelectedIndex = 0;
            declare_person.Text = user_name;
        }

        private void dSkinTextBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == 13)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void dSkinButton1_Click(object sender, EventArgs e)
        {
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
            if (img_urls == "")
            {
                DialogResult dr = MessageBox.Show("请上传样例图片！", "提示", MessageBoxButtons.OK);
                return;
            }
            var storeDic = new Dictionary<string, string>() {
                {
                    "username", user_name
                },
                {
                    "num", declare_num.Text
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
                }
            };
            //try
            //{
            string storeRes = HttpUtils.UploadImage(api_url + "submit_declare", img_urls, storeDic);
            //}
            Console.WriteLine(storeRes);
            if (storeRes.Contains("ok"))
            {
                DialogResult dr = MessageBox.Show("申报成功！", "提示", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    generateNum();
                    declare_country.Text = "";
                    declare_remark.Text = "";
                    offline_way.Checked = true;
                    declare_department.Text = "";
                    declare_cargo.Text = "";
                    declare_pos.Text = "";
                    declare_img1.BackgroundImage = original;
                    declare_img2.BackgroundImage = blank;
                    declare_img3.BackgroundImage = blank;
                }
            }
            else if(storeRes.Contains("ok"))
            {
                DialogResult dr = MessageBox.Show("申报成功！", "提示", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    generateNum();
                    declare_country.Text = "";
                    declare_remark.Text = "";
                    offline_way.Checked = true;
                    declare_department.Text = "";
                    declare_cargo.Text = "";
                    declare_pos.Text = "";
                    declare_img1.BackgroundImage = original;
                    declare_img2.BackgroundImage = blank;
                    declare_img3.BackgroundImage = blank;
                }
            }
        }

        private void dSkinPictureBox2_Click(object sender, EventArgs e)
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
                    declare_img1.BackgroundImage = Image.FromStream(stream);
                    if (filePath != img_str2 && filePath != img_str3)
                    {
                        img_str1 = filePath;
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
                    declare_img2.BackgroundImage = Image.FromStream(stream);
                    if (filePath != img_str1 && filePath != img_str3)
                    {
                        img_str2 = filePath;
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
                    declare_img3.BackgroundImage = Image.FromStream(stream);
                    if (filePath != img_str1 && filePath != img_str2)
                    {
                        img_str3 = filePath;
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("已上传过该图片！", "提示", MessageBoxButtons.OK);
                        return;
                    }               
                }
            }
        }
    }
}
