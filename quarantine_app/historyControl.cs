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
using System.IO;

namespace quarantine_app
{
    public partial class historyControl : UserControl
    {
        private static historyControl _instance;
        private static String api_url = "http://111.198.4.119:5000/api/";
        private static String file_path = null;
        public static historyControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new historyControl();
                return _instance;
            }
        }
        public historyControl()
        {
            InitializeComponent();
        }

        private void showHistory(string date)
        {
            string res = HttpUtils.Get(api_url + "search_history?date=" + date);
            dynamic ress = JsonConvert.DeserializeObject(res);
            historyData.Rows.Clear();
            foreach (dynamic r in ress)
            {
                DSkin.Controls.DSkinGridListRow row = new DSkin.Controls.DSkinGridListRow();
                DSkin.Controls.DSkinGridListCell num = new DSkin.Controls.DSkinGridListCell();
                num.Value = r["num"];
                row.Cells.Add(num);
                DSkin.Controls.DSkinGridListCell dateCell = new DSkin.Controls.DSkinGridListCell();
                dateCell.Value = r["date"];
                row.Cells.Add(dateCell);
                DSkin.Controls.DSkinGridListCell detail = new DSkin.Controls.DSkinGridListCell();
                detail.Value = "查看";
                detail.Tag = r["img"];
                row.Cells.Add(detail);
                DSkin.Controls.DSkinGridListCell resCell = new DSkin.Controls.DSkinGridListCell();
                resCell.Value = r["res"];
                row.Cells.Add(resCell);
                historyData.Rows.Add(row);
            }
        }

        private void searchHistory_Click(object sender, EventArgs e)
        {
            string date = historyTime.Value.ToString();
            date = date.Split(' ')[0];
            showHistory(date);
        }

        private void historyData_ItemClick(object sender, DSkin.Controls.DSkinGridListMouseEventArgs e)
        {
            if (e.CellIndex == 2)
            {
                Console.WriteLine(e.Item.Cells[2].Tag.ToString());
                string byteImage = e.Item.Cells[2].Tag.ToString();
                var pictureWindow = new pictureWindow(byteImage);                              
                pictureWindow.ShowDialog();               
            }        
        }
    }
}
