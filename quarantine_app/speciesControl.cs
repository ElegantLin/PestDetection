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
using DSkin.Controls;

namespace quarantine_app
{
    public partial class speciesControl : UserControl
    {
        private int page = 0;
        private int type = 0;
        private string keyword = "";
        private int total = 0;
        private static speciesControl _instance;
        private static String api_url = "http://111.198.4.119:5000/api/";
        private string url = "";
        private List<PictureBox> pbs;
        private List<DSkinLabel> resName;
        private List<DSkinLabel> resLatin;
        private List<DSkinLabel> resFamily;
        private List<DSkinLabel> resFamilyLatin;
        private List<DSkinLabel> quarantine;
        public static speciesControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new speciesControl();
                return _instance;
            }
        }
        public speciesControl()
        {
            InitializeComponent();
            pbs = new List<PictureBox> {pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8};
            resName = new List<DSkinLabel> { resNameLabel1, resNameLabel2, resNameLabel3, resNameLabel4, resNameLabel5, resNameLabel6, resNameLabel7, resNameLabel8 };
            resLatin = new List<DSkinLabel> { resLatinLabel1, resLatinLabel2, resLatinLabel3, resLatinLabel4, resLatinLabel5, resLatinLabel6, resLatinLabel7, resLatinLabel8 };
            resFamily = new List<DSkinLabel> { resFamilyLabel1, resFamilyLabel2, resFamilyLabel3, resFamilyLabel4, resFamilyLabel5, resFamilyLabel6, resFamilyLabel7, resFamilyLabel8 };
            resFamilyLatin = new List<DSkinLabel> { resFamilyLatinLabel1, resFamilyLatinLabel2, resFamilyLatinLabel3, resFamilyLatinLabel4, resFamilyLatinLabel5, resFamilyLatinLabel6, resFamilyLatinLabel7, resFamilyLatinLabel8 };
            quarantine = new List<DSkinLabel> { quarantineLabel1, quarantineLabel2, quarantineLabel3, quarantineLabel4, quarantineLabel5, quarantineLabel6, quarantineLabel7, quarantineLabel8 };
            for (int i = 0; i < pbs.Count; i++)
            {
                pbs[i].SizeMode = PictureBoxSizeMode.StretchImage;
                resName[i].Font = new Font(new FontFamily("幼圆"), 10, FontStyle.Regular);
                resLatin[i].Font = new Font(new FontFamily("幼圆"), 10, FontStyle.Regular);
                resFamily[i].Font = new Font(new FontFamily("幼圆"), 10, FontStyle.Regular);
                resFamilyLatin[i].Font = new Font(new FontFamily("幼圆"), 10, FontStyle.Regular);
                quarantine[i].Font = new Font(new FontFamily("幼圆"), 10, FontStyle.Regular);
            } 
            speciesSelector.Items.Add("全部");
            speciesSelector.Items.Add("昆虫");
            speciesSelector.Items.Add("杂草");
            speciesSelector.SelectedIndex = 0;
            page = 0;
            type = speciesSelector.SelectedIndex - 1;
            keyword = speciesKeyword.Text;
            changePageIndex();
        }

        private void changePageIndex()
        { 
            url = api_url + "search_species?page=" + page.ToString();
            if (type > -1)
            {
                url = url + "&type=" + type.ToString();
            }
            if (keyword != "")
            {
                url = url + "&keyword=" + keyword;
            }
            string res = HttpUtils.Get(url);
            showResults(res);
        }

        private void searchSpecies_Click(object sender, EventArgs e)
        {
            //page = 0;
            //type = speciesSelector.SelectedIndex - 1;
            //keyword = speciesKeyword.Text;
            //changePageIndex();

            string sample = speciesKeyword.Text;
            if (sample == "")
            {
                //dSkinTabControl1.SelectedIndex = 2;
                //sjzxKeyword.Text = sample;
                //sjzxSearch.PerformClick();
            }
            else
            {
                string yhsw = HttpUtils.Get(api_url + "search_sample?keyword=" + sample);
                Console.WriteLine(yhsw);
                if (yhsw == "[]")
                {
                    //dSkinTabControl1.SelectedIndex = 2;
                    //sjzxKeyword.Text = sample;
                    //sjzxSearch.PerformClick();
                }
                else
                {
                    sampleSearch ss = new sampleSearch(yhsw);
                    ss.StartPosition = FormStartPosition.CenterParent;
                    ss.ShowDialog();
                }
            }
        }

        private void showResults(dynamic res)
        {
            dynamic ress = JsonConvert.DeserializeObject(res);
            int count = 0;
            foreach (dynamic r in ress)
            {  
                pageSizeLabel.Text = "第" + (page + 1).ToString() + "/" + r["page_count"] + "页";
                total = r["page_count"];
                if (count == pbs.Count) break;
                pbs[count].LoadAsync(r["img_url"].ToString());
                pbs[count].Tag = r["final_num"].ToString() + "~" + r["type"].ToString();
                resName[count].Text = r["species_cn"];
                resLatin[count].Text = r["species_latin"];
                resFamily[count].Text = r["family_cn"];
                resFamilyLatin[count].Text = r["family_latin"];
                quarantine[count].Text = "检疫性: " + r["isquar"].ToString();
                count += 1;
            }
            if (count < 8)
            {
                for (int i = count; i < 8; i++)
                {
                    pbs[count].Image = null;
                    pbs[count].Invalidate();
                    resName[count].Text = "";
                    resLatin[count].Text = "";
                    resFamily[count].Text = "";
                    resFamilyLatin[count].Text = "";
                    quarantine[count].Text = "";
                }
            }          
        }

        private void prevPage_Click(object sender, EventArgs e)
        {
            if (page == 0)
            {
                DialogResult dr = MessageBox.Show("已到第一页！", "提示", MessageBoxButtons.OK);
                return;
            }
            else
            {
                page -= 1;
                changePageIndex();
            }
        }

        private void nextPage_Click(object sender, EventArgs e)
        {
            if (page == total - 1)
            {
                DialogResult dr = MessageBox.Show("已到最后一页！", "提示", MessageBoxButtons.OK);
                return;
            }
            else
            {
                page += 1;
                changePageIndex();
            }
        }

        private void firstPage_Click(object sender, EventArgs e)
        {
            page = 0;
            changePageIndex();
        }

        private void lastPage_Click(object sender, EventArgs e)
        {
            page = total - 1;
            changePageIndex();
        }

        private void showDetails(string res)
        {
            dynamic ress = JsonConvert.DeserializeObject(res);
            searchSampleResult ssr = new searchSampleResult(ress);
            ssr.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string[] temp = pictureBox1.Tag.ToString().Split('~');
            string declare_res = HttpUtils.Get(api_url + "find_sample?num=" + temp[0] + "&type=" + temp[1]);
            showDetails(declare_res);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string[] temp = pictureBox2.Tag.ToString().Split('~');
            string declare_res = HttpUtils.Get(api_url + "find_sample?num=" + temp[0] + "&type=" + temp[1]);
            showDetails(declare_res);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string[] temp = pictureBox3.Tag.ToString().Split('~');
            string declare_res = HttpUtils.Get(api_url + "find_sample?num=" + temp[0] + "&type=" + temp[1]);
            showDetails(declare_res);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string[] temp = pictureBox4.Tag.ToString().Split('~');
            string declare_res = HttpUtils.Get(api_url + "find_sample?num=" + temp[0] + "&type=" + temp[1]);
            showDetails(declare_res);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            string[] temp = pictureBox5.Tag.ToString().Split('~');
            string declare_res = HttpUtils.Get(api_url + "find_sample?num=" + temp[0] + "&type=" + temp[1]);
            showDetails(declare_res);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string[] temp = pictureBox6.Tag.ToString().Split('~');
            string declare_res = HttpUtils.Get(api_url + "find_sample?num=" + temp[0] + "&type=" + temp[1]);
            showDetails(declare_res);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            string[] temp = pictureBox7.Tag.ToString().Split('~');
            string declare_res = HttpUtils.Get(api_url + "find_sample?num=" + temp[0] + "&type=" + temp[1]);
            showDetails(declare_res);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            string[] temp = pictureBox8.Tag.ToString().Split('~');
            string declare_res = HttpUtils.Get(api_url + "find_sample?num=" + temp[0] + "&type=" + temp[1]);
            showDetails(declare_res);
        }
    }
}
