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
    public partial class uploadDoc : UserControl
    {
        private static uploadDoc _instance;
        private static String api_url = "http://111.198.4.119:5000/api/";
        public static String upload_user;
        private static String[] level_one = { "新闻资讯", "数据中心", "法律法规", "检疫处理"};
        private static String[][] level_two = new String[4][];
        private static String[][][] level_three = new String[2][][];
        private static String[][][][] level_four = new String[2][][][];

        public static uploadDoc Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uploadDoc();
                return _instance;
            }
        }
        public uploadDoc()
        {
            InitializeComponent();
            level_two[1] = new String[5] { "有害生物", "动物疫病", "植检标准", "动检标准", "平台链接"};
            level_two[2] = new String[3] {"动植检法律", "动植检法规", "法规在线查看"};
            level_two[3] = new string[3] { "植物检疫规程及指标", "动物检疫规程及指标", "无害化处理" };
            level_three[0] = new String[1][];
            level_three[1] = new String[5][];
            level_three[1][0] = new String[7] { "昆虫", "杂草", "软体动物", "线虫", "真菌", "原核生物", "病毒/类病毒" };
            level_three[1][1] = new String[2] { "水生动物疫病", "陆生动物疫病" };
            level_three[1][2] = new String[11] {
                "检验检疫规程", "标准编写方法", "风险分析方法", "转基因检测方法", "种质资源鉴定方法", "品质检验方法",
                "检疫处理及监测方法", "检测鉴定方法", "水果及其病虫害防治、检疫处理", "国际标准", "其他"
            };
            level_three[1][3] = new String[6] { "通用及监督管理标准", "动物产品检验检疫", "饲料检验检疫", "陆生动物检验检疫",
            "水生动物检验检疫", "其他"};
            level_three[1][4] = new String[2] { "海南外来有害生物数据库", "中国国家有害生物检疫信息平台" };
            level_four[1] = new String[5][][];
            level_four[1][1] = new String[2][];
            level_four[1][1][1] = new String[5] { "反刍动物疫病", "禽疫病", "马属动物疫病", "猪疫病", "野生动物疫病"};
            level_four[1][2] = new String[11][];
            level_four[1][2][7] = new String[9] { "检疫鉴定通用标准", "昆虫检测鉴定方法","细菌检测鉴定方法", "杂草检测鉴定方法", "软体动物检测鉴定方法", "真菌检测鉴定方法", "线虫检测鉴定方法", "病毒检测检测方法", "其他检测、鉴定" };
            foreach (String i in level_one)
            {
                level1.Items.Add(i);
            }
            level1.SelectedIndex = 0;
            level2.Visible = false;
            level3.Visible = false;
            level4.Visible = false;
        }

        private void dSkinLabel3_Click(object sender, EventArgs e)
        {          
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择上传的文件";
            ofd.Filter = "文件选择|*.pdf";
            ofd.Multiselect = false;
            
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = ofd.FileName;
                uploadPDF.LoadFile(filePath);
                docPath.Text = filePath;                                                          
            }
        }

        private void level1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (level1.SelectedIndex == 0)
            {
                level2.Visible = false;
                level3.Visible = false;
                level4.Visible = false;
            }
            else if (level1.SelectedIndex == 2 || level1.SelectedIndex == 3)
            {
                level2.Visible = true;
                level3.Visible = false;
                level4.Visible = false;
                level2.Items.Clear();
                foreach (String s in level_two[level1.SelectedIndex])
                {
                    level2.Items.Add(s);
                }
                level2.SelectedIndex = 0;
            }
            else
            {
                level2.Visible = true;
                level3.Visible = true;
                level2.Items.Clear();
                foreach (String s in level_two[level1.SelectedIndex])
                {
                    level2.Items.Add(s);
                }
                level2.SelectedIndex = 0;
            }
        }

        private void level2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (level1.SelectedIndex == 1)
            {
                level3.Items.Clear();
                foreach (String s in level_three[level1.SelectedIndex][level2.SelectedIndex])
                {
                    level3.Items.Add(s);
                }
                level3.SelectedIndex = 0;
            }
        }

        private void level3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tag1 = level1.SelectedIndex;
            int tag2 = level2.SelectedIndex;
            int tag3 = level3.SelectedIndex;
            if ((tag1 == 1 && tag2 == 1 && tag3 == 1) || (tag1 == 1 && tag2 == 2 && tag3 == 7))
            {
                level4.Visible = true;
                level4.Items.Clear();
                foreach (string t in level_four[tag1][tag2][tag3])
                {
                    level4.Items.Add(t);
                }
                level4.SelectedIndex = 0;
            }
            else
            {
                level4.Visible = false;
            }
        }

        private void dSkinLabel4_Click(object sender, EventArgs e)
        {
            String file_title = docTitle.Text;
            if (file_title == "")
            {
                DialogResult dr = MessageBox.Show("请输入文件标题！", "提示", MessageBoxButtons.OK);
                return;
            }
            Random random = new Random();
            String filePath = docPath.Text;
            int position = filePath.LastIndexOf("\\");
            int next = filePath.LastIndexOf(".");
            string fileName = filePath.Substring(position + 1, next - position - 1) + ".";
            string fileType = filePath.Substring(position + 1).Split('.')[1];
            fileName += fileType;
            dSkinLabel4.Text = "上传中";
            this.Refresh();
            int index1 = level1.SelectedIndex;
            Dictionary<string, string> dict;
            dict = new Dictionary<string, string>() {
                    {
                        "owner",upload_user
                    },
                    {
                        "name",fileName
                    },
                    {
                        "type",fileType
                    },
                    {
                        "title",file_title
                    },
                    {
                        "level1",index1.ToString()
                    },
                };
            if (level2.Visible)
            {
                int index2 = level2.SelectedIndex;
                if (level3.Visible)
                {
                    int index3 = level3.SelectedIndex;
                    if (level4.Visible)
                    {
                        int index4 = level4.SelectedIndex;
                        dict = new Dictionary<string, string>() {
                                {
                                    "owner",upload_user
                                },
                                {
                                    "name",fileName
                                },
                                {
                                    "type",fileType
                                },
                                {
                                    "title",file_title
                                },
                                {
                                    "level1",index1.ToString()
                                },
                                {
                                    "level2",index2.ToString()
                                },
                                {
                                    "level3",index3.ToString()
                                },
                                {
                                    "level4",index4.ToString()
                                },
                            };
                    }
                    else
                    {
                        dict = new Dictionary<string, string>() {
                                {
                                    "owner",upload_user
                                },
                                {
                                    "name",fileName
                                },
                                {
                                    "type",fileType
                                },
                                {
                                    "title",file_title
                                },
                                {
                                    "level1",index1.ToString()
                                },
                                {
                                    "level2",index2.ToString()
                                },
                                {
                                    "level3",index3.ToString()
                                },
                            };
                    }
                }
                else
                {
                    dict = new Dictionary<string, string>() {
                            {
                                "owner",upload_user
                            },
                            {
                                "name",fileName
                            },
                            {
                                "type",fileType
                            },
                            {
                                "title",file_title
                            },
                            {
                                "level1",index1.ToString()
                            },
                            {
                                "level2",index2.ToString()
                            },
                        };
                }
            }
            string res = HttpUtils.UploadImage(api_url + "upload_file", filePath, dict);
            if (res.Contains("ok"))
            {
                DialogResult dr = MessageBox.Show("上传成功！", "提示", MessageBoxButtons.OK);
            }
            else if (res.Contains("title"))
            {
                DialogResult dr = MessageBox.Show("文件标题重复，请修改后上传！", "提示", MessageBoxButtons.OK);
            }
            else if (res.Contains("name"))
            {
                DialogResult dr = MessageBox.Show("已上传过该文件！", "提示", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult dr = MessageBox.Show("上传失败，请重试！", "提示", MessageBoxButtons.OK);
            }
            dSkinLabel4.Text = "上传文件";
            this.Refresh();
        }
    }
}
