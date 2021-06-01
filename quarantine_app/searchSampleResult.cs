using DSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quarantine_app
{
    public partial class searchSampleResult : Form
    {
        public searchSampleResult(dynamic result)
        {
            InitializeComponent();
            sameClass1.SizeMode = PictureBoxSizeMode.StretchImage;
            sameClass2.SizeMode = PictureBoxSizeMode.StretchImage;
            sameClass3.SizeMode = PictureBoxSizeMode.StretchImage;
            sameClass4.SizeMode = PictureBoxSizeMode.StretchImage;
            sameClass5.SizeMode = PictureBoxSizeMode.StretchImage;
            sameClass6.SizeMode = PictureBoxSizeMode.StretchImage;
            sameClass7.SizeMode = PictureBoxSizeMode.StretchImage;
            sameClass8.SizeMode = PictureBoxSizeMode.StretchImage;
            showResult(result);
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
                    else if (i == 4)
                    {
                        sameClass5.LoadAsync(content[i]);
                    }
                    else if (i == 5)
                    {
                        sameClass6.LoadAsync(content[i]);
                    }
                    else if (i == 6)
                    {
                        sameClass7.LoadAsync(content[i]);
                    }
                    else if (i == 7)
                    {
                        sameClass8.LoadAsync(content[i]);
                    }
                }
            }
        }
    }
}
