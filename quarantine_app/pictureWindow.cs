using System;
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
    public partial class pictureWindow : Form
    {
        private string img_data;        

        public pictureWindow(string data)
        {
            InitializeComponent();
            img_data = data;
        }

        private Image ConvertBase64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                ms.Write(imageBytes, 0, imageBytes.Length);
                return Image.FromStream(ms, true);
            }
        }

        private void pictureWindow_Load(object sender, EventArgs e)
        {
            photo1.BackgroundImage = ConvertBase64ToImage(img_data);            
        }       
    }
}
