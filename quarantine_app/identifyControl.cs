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
using System.Drawing.Imaging;
using Newtonsoft.Json;
using DSkin.Controls;

namespace quarantine_app
{
    public partial class identifyControl : UserControl
    {
        private static identifyControl _instance;
        private String api_url = "http://111.198.4.119:5000/api/";
        private String file_path = null;
        private Rectangle m_Rect;
        private int mouseStartLocationX = 0;
        private int mouseStartLocationY = 0;
        private int mouseEndLocationX = 0;
        private int mouseEndLocationY = 0;
        private Boolean select_tag = false;
        private Boolean tips = false;
        private Boolean draw = false;
        
       
        public static identifyControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new identifyControl();
                return _instance;
            }
        }
        public identifyControl()
        {
            InitializeComponent();
            typeSelect.Items.Insert(0, "类别选择");
            typeSelect.SelectedIndex = 0;
            typeSelect.Items.Insert(1, "昆虫");
            typeSelect.Items.Insert(2, "杂草");
            identifyData.Visible = false;
            sameClass1.SizeMode = PictureBoxSizeMode.StretchImage;
            sameClass2.SizeMode = PictureBoxSizeMode.StretchImage;
            sameClass3.SizeMode = PictureBoxSizeMode.StretchImage;
            sameClass4.SizeMode = PictureBoxSizeMode.StretchImage;
            sameClassLabel.Visible = false;
        }

        private void dSkinLabel3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择上传的图片";
            ofd.Filter = "图片格式|*.jpg|*.png|*.jpeg";
            ofd.Multiselect = false;
            Random random = new Random();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = ofd.FileName;
                imgPath.Items.Insert(0, filePath);
                imgPath.SelectedIndex = 0;
                int position = filePath.LastIndexOf("\\");
                string fileName = filePath.Substring(position + 1).Split('.')[0] + random.Next().ToString() + ".";
                string fileType = filePath.Substring(position + 1).Split('.')[1];
                fileName += fileType;
                using (Stream stream = ofd.OpenFile())
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.CreateNew))
                    {
                        stream.CopyTo(fs);
                        fs.Flush();
                    }
                    pbShow.BackgroundImage = Image.FromFile(fileName);
                    file_path = fileName;
                }
            }
        }

        private void dSkinLabel5_Click(object sender, EventArgs e)
        {
            if (typeSelect.SelectedIndex < 1)
            {
                DialogResult dr = MessageBox.Show("请先选择类别！", "提示", MessageBoxButtons.OK);
                return;
            }
            dSkinLabel5.Text = "识别中";
            this.Refresh();
            Console.WriteLine(typeSelect.SelectedIndex);
            int index = typeSelect.SelectedIndex - 1;
            var dic = new Dictionary<string, string>() {
                    {"type",index.ToString() },
            };
            string res = HttpUtils.UploadImage(api_url + "identify", file_path, dic);
            dynamic info = JsonConvert.DeserializeObject(res);
            Console.WriteLine(info);
            processRes(info);

            dSkinLabel5.Text = "开始识别";
            draw = false;
            this.Refresh();
        }

        private void processRes(dynamic tmp)
        {
            if (tmp["status"] == "ok")
            {
                if (tmp["name"] == "识别失败")
                {
                    DialogResult dr = MessageBox.Show("数据库中无此物种！", "提示", MessageBoxButtons.OK);
                    return;
                }
                string sample_num = tmp["num"];
                string resStr = tmp["name"];
                int index = typeSelect.SelectedIndex - 1;
                string res = HttpUtils.Get(api_url + "find_sample?num=" + sample_num + "&type=" + index.ToString());
                dynamic info = JsonConvert.DeserializeObject(res);
                showResult(info);
                var storeDic = new Dictionary<string, string>() {
                    {"res",resStr },
                };
                string storeRes = HttpUtils.UploadImage(api_url + "store", file_path, storeDic);              
            }
        }        

        private void showResult(dynamic res)
        {
            sameClassLabel.Visible = true;
            foreach (dynamic r in res)
            {                                
                identifyData.Visible = true;
                DSkinGridListRow row = new DSkinGridListRow();
                DSkinGridListCell nameCell = new DSkinGridListCell();
                nameCell.Value = "中文名";
                row.Cells.Add(nameCell);
                DSkinGridListCell pcCell = new DSkinGridListCell();
                pcCell.Value = r["phylum_cn"];
                row.Cells.Add(pcCell);
                DSkinGridListCell ccCell = new DSkinGridListCell();
                ccCell.Value = r["class_cn"];
                row.Cells.Add(ccCell);
                DSkinGridListCell ocCell = new DSkinGridListCell();
                ocCell.Value = r["order_cn"];
                row.Cells.Add(ocCell);
                DSkinGridListCell fcCell = new DSkinGridListCell();
                fcCell.Value = r["family_cn"];
                row.Cells.Add(fcCell);
                DSkinGridListCell gcCell = new DSkinGridListCell();
                gcCell.Value = r["genus_cn"];
                row.Cells.Add(gcCell);
                DSkinGridListCell scCell = new DSkinGridListCell();
                scCell.Value = r["species_cn"];
                row.Cells.Add(scCell);
                DSkinGridListCell qcCell = new DSkinGridListCell();
                qcCell.Value = r["quar"];
                row.Cells.Add(qcCell);
                identifyData.Rows.Add(row);

                DSkinGridListRow srow = new DSkinGridListRow();
                srow.Height = 50;
                DSkinGridListCell nCell = new DSkinGridListCell();
                nCell.Value = "拉丁名";
                srow.Cells.Add(nCell);
                DSkinGridListCell peCell = new DSkinGridListCell();
                peCell.Value = r["phylum_latin"];
                srow.Cells.Add(peCell);
                DSkinGridListCell ceCell = new DSkinGridListCell();
                ceCell.Value = r["class_latin"];
                srow.Cells.Add(ceCell);
                DSkinGridListCell oeCell = new DSkinGridListCell();
                oeCell.Value = r["order_latin"];
                srow.Cells.Add(oeCell);
                DSkinGridListCell feCell = new DSkinGridListCell();
                feCell.Value = r["family_latin"];
                srow.Cells.Add(feCell);
                DSkinGridListCell geCell = new DSkinGridListCell();
                geCell.Value = r["genus_latin"];
                srow.Cells.Add(geCell);
                DSkinGridListCell seCell = new DSkinGridListCell();
                seCell.Value = r["species_latin"];
                srow.Cells.Add(seCell);
                DSkinGridListCell qeCell = new DSkinGridListCell();
                qeCell.Value = r["quar_en"];
                srow.Cells.Add(qeCell);
                identifyData.Rows.Add(srow);

                identifyDetail.Visible = true;
                if (r["des"].ToString() == "")
                {
                    identifyDetail.Text = "暂无说明";
                }
                else identifyDetail.Text = r["des"];

                List<string> content = r["img_urls"].ToObject<List<string>>();
                for (int i = 0; i < content.Count; i++)
                {
                    if (i == 0)
                    {
                        sameClass1.LoadAsync(content[i]);                    
                    }
                    else if (i == 1)
                    {
                        sameClass2.LoadAsync(content[i]);
                    }
                    else if (i == 2)
                    {
                        sameClass3.LoadAsync(content[i]);
                    }
                    else if (i == 3)
                    {
                        sameClass4.LoadAsync(content[i]);
                    }
                }
            }           
        }

        private void pbShow_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择上传的图片";
            ofd.Filter = "图片格式|*.jpg|*.png|*.jpeg";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = ofd.FileName;
                imgPath.Items.Insert(0, filePath);
                imgPath.SelectedIndex = 0;               
                using (Stream stream = ofd.OpenFile())
                {                    
                    pbShow.BackgroundImage = Image.FromStream(stream);
                    file_path = filePath;
                }
            }
        }

        public static Bitmap KiCut(Bitmap b, int StartX, int StartY, int iWidth, int iHeight)
        {
            if (b == null)
            {
                return null;
            }

            int w = b.Width;
            int h = b.Height;
            if (StartX >= w || StartY >= h)
            {
                return null;
            }

            if (StartX + iWidth > w)
            {
                iWidth = w - StartX;
            }

            if (StartY + iHeight > h)
            {
                iHeight = h - StartY;
            }
            try
            {
                Bitmap bmpOut = new Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(bmpOut);
                g.DrawImage(b, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(StartX, StartY, iWidth, iHeight), GraphicsUnit.Pixel);
                g.Dispose();
                return bmpOut;
            }
            catch
            {
                return null;
            }
        }

        private void pbShow_MouseUp(object sender, MouseEventArgs e)
        {
            if (select_tag)
            {
                mouseEndLocationX = e.X;
                mouseEndLocationY = e.Y;
                m_Rect = new Rectangle();
                m_Rect.X = mouseStartLocationX < mouseEndLocationX ? mouseStartLocationX : mouseEndLocationX;
                m_Rect.Y = mouseStartLocationY < mouseEndLocationY ? mouseStartLocationY : mouseEndLocationY;
                m_Rect.Width = Math.Abs(mouseEndLocationX - mouseStartLocationX);
                m_Rect.Height = Math.Abs(mouseEndLocationY - mouseStartLocationY);
                draw = true;
                this.Refresh();  
            }
        }

        private void pbShow_MouseDown(object sender, MouseEventArgs e)
        {
            if (select_tag)
            {
                mouseStartLocationX = e.X;
                mouseStartLocationY = e.Y;
            }
        }

        private void dSkinLabel4_Click(object sender, EventArgs e)
        {
            if (!select_tag)
            {
                if (!tips)
                {
                    DialogResult dr = MessageBox.Show("点击选取范围后请在缩略图中按住鼠标拉取矩形截取图片的部分，最终再确定选择范围，确定后点击确定选区按钮后再开始识别", "提示", MessageBoxButtons.OK);
                    tips = true;
                }
                select_tag = true;
                pbShow.Click -= new EventHandler(this.pbShow_Click);
                dSkinLabel4.Text = "确定选区";
                this.Refresh();
            }
            else
            {
                if (m_Rect.Width > 0 && m_Rect.Height > 0)
                {
                    Bitmap map = new Bitmap(pbShow.BackgroundImage);
                    map = KiCut(map, m_Rect.X * map.Width / pbShow.Width, m_Rect.Y * map.Height / pbShow.Height,
                        map.Width * m_Rect.Width / pbShow.Width, map.Height * m_Rect.Height / pbShow.Height);
                    this.Refresh();
                    //Random random = new Random();
                    //String filename = "resize" + random.Next().ToString() + ".jpg";
                    //map.Save(filename, ImageFormat.Jpeg);
                    //file_path = filename;
                    //pbShow.BackgroundImage = Image.FromFile(filename);
                    pbShow.Click += new EventHandler(this.pbShow_Click);
                    dSkinLabel4.Text = "选取范围";
                    select_tag = false;
                    this.Refresh();
                }
                else
                {
                    DialogResult dr = MessageBox.Show("选区无效，请重新按住选取选区！", "提示", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private void pbShow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if(draw)
                g.DrawRectangle(new Pen(new SolidBrush(Color.Red), 2), this.m_Rect);
        }
    }
}
