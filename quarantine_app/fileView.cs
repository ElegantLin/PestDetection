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
    public partial class fileView : Form
    {
        private string url;
        public fileView(string file_url)
        {
            InitializeComponent();
            url = file_url;
        }

        private void fileView_Load(object sender, EventArgs e)
        {
            pdfLoader.LoadFile(url);
        }
    }
}
