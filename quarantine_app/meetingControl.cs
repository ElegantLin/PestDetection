using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quarantine_app
{
    public partial class meetingControl : UserControl
    {
        private static meetingControl _instance;
        public static meetingControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new meetingControl();
                return _instance;
            }
        }
        public meetingControl()
        {
            InitializeComponent();
        }
    }
}
