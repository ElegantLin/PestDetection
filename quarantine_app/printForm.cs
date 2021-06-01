using FastReport;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace quarantine_app
{
    public partial class printForm : Form
    {
        private Report pReport;
        private string declare_num;
        public printForm(string num)
        {
            InitializeComponent();
            declare_num = num;
        }

        private void printForm_Load(object sender, EventArgs e)
        {
            string conStr = "server=111.198.4.119;port=3336;user=root;password=x745DzjBackend;database=dzjDB;SslMode=none;";
            try
            {
                //连接mysql，查出打印内容
                MySqlConnection con = new MySqlConnection(conStr);
                con.Open();
                //上半部分内容
                string sql = @"select declare_table.declare_num, declare_table.declare_department, declare_table.declare_date, user.user_name, declare_table.declare_type," +
                            "declare_table.declare_cargo, declare_table.declare_country, declare_table.declare_position, declare_table.declare_imgs, declare_table.declare_remark, " +
                            "declare_table.expert_id,declare_table.res_num,declare_table.eval_date from declare_table left join user on declare_table.user_id = user.user_id where declare_num= '" + declare_num + "'";
                MySqlCommand sqlcmd = new MySqlCommand(sql, con);
                MySqlDataReader sdr = sqlcmd.ExecuteReader();
                String declare_department = "";
                String apply_date = "";
                String user_id = "";
                String declare_type = "";
                String declare_cargo = "";
                String declare_country = "";
                String declare_position = "";
                String declare_remark = "";
                String expert_id = "";
                String res_num = "";
                String eval_time = "";
                if (sdr.Read())
                {
                    declare_department = sdr[1].ToString();
                    apply_date = sdr[2].ToString();
                    user_id = sdr[3].ToString();
                    declare_type = sdr[4].ToString() == "0" ? "昆虫" : "杂草";
                    declare_cargo = sdr[5].ToString();
                    declare_country = sdr[6].ToString();
                    declare_position = sdr[7].ToString();
                    //把图片下载后保存到本地C:\Users\Public\1.jpg、2.jpg、3.jpg
                    String img_url_str = sdr[8].ToString();
                    String[] img_urls = img_url_str.Split('~');
                    for(int i = 0;i < img_urls.Length;i++)
                    {
                        String img_url = img_urls[i];
                        String url = "http://111.198.4.119:8089" + img_url;
                        WebRequest imgRequest = WebRequest.Create(url);
                        HttpWebResponse res;
                        try
                        {
                            res = (HttpWebResponse)imgRequest.GetResponse();
                        }
                        catch (WebException ex)
                        {

                            res = (HttpWebResponse)ex.Response;
                        }
                        String savePath = "C:\\Users\\Public\\Pictures";
                        if (res.StatusCode.ToString() == "OK")
                        {
                            System.Drawing.Image downImage = System.Drawing.Image.FromStream(imgRequest.GetResponse().GetResponseStream());
                            if (!System.IO.Directory.Exists(savePath))
                            {
                                System.IO.Directory.CreateDirectory(savePath);
                            }
                            downImage.Save(savePath + "\\"+ (i+1) + ".jpg");
                            downImage.Dispose();
                        }
                    }
                    
                    declare_remark = sdr[9].ToString();
                    expert_id = sdr[10].ToString();
                    res_num = sdr[11].ToString();
                    eval_time = sdr[12].ToString();
                }

                //下半部分内容
                sql = @"select user_name,user_title,department from user where user_name = '" + expert_id + "'";
                sqlcmd = new MySqlCommand(sql, con);
                sdr.Close();
                sdr = sqlcmd.ExecuteReader();
                String eval_apartment = "";
                String eval_expert = "";
                String expert_info = "";
                if (sdr.Read())
                {
                    eval_expert = sdr[0].ToString();
                    expert_info = sdr[1].ToString();
                    eval_apartment = sdr[2].ToString();
                }

                sql = @"select genus_cn,genus_latin,description  from sample_table  where number = '" + res_num + "'";
                sqlcmd = new MySqlCommand(sql, con);
                sdr.Close();
                sdr = sqlcmd.ExecuteReader();
                String chinese_name = "";
                String latin_name = "";
                String remark_explain = "";
                if (sdr.Read())
                {
                    chinese_name = sdr[0].ToString();
                    latin_name = sdr[1].ToString();
                    remark_explain = sdr[2].ToString();
                }


                //将打印内容封装
                DataSet ds = new DataSet();
                DataTable table = new DataTable();
                table.TableName = "declare";
                table.Columns.Add("declare_num", typeof(string));
                table.Columns.Add("declare_department", typeof(string));
                table.Columns.Add("apply_date", typeof(string));
                table.Columns.Add("user_id", typeof(string));
                table.Columns.Add("declare_type", typeof(string));
                table.Columns.Add("declare_cargo", typeof(string));
                table.Columns.Add("declare_country", typeof(string));
                table.Columns.Add("declare_position", typeof(string));
                table.Columns.Add("declare_remark", typeof(string));
                table.Columns.Add("eval_apartment", typeof(string));
                table.Columns.Add("eval_expert", typeof(string));
                table.Columns.Add("chinese_name", typeof(string));
                table.Columns.Add("eval_time", typeof(string));
                table.Columns.Add("expert_info", typeof(string));
                table.Columns.Add("latin_name", typeof(string));
                table.Columns.Add("remark_explain", typeof(string));



             
                table.Rows.Add(declare_num, declare_department, apply_date, user_id, declare_type, declare_cargo, declare_country, declare_position, declare_remark, eval_apartment,
                    eval_expert, chinese_name, eval_time, expert_info, latin_name, remark_explain);
                ds.Tables.Add(table);

                pReport = new Report();
                String reportFile = "Report/report.frx";
                pReport.Load(reportFile);
                pReport.Preview = previewControl1;
                pReport.RegisterData(ds);


                pReport.Prepare();
                pReport.ShowPrepared();

                //删去图片
                string fileName = @"C:\\Users\\Public\\Pictures\\1.jpg";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                fileName = @"C:\\Users\\Public\\Pictures\\2.jpg";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                fileName = @"C:\\Users\\Public\\Pictures\\3.jpg";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
