using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quarantine_app
{
    public partial class loginForm : Form // to do: resize and move window
    {
        bool IsDragging = false;
        Point p = new Point(0, 0);
        Point offset = new Point(0, 0);
        String api_url = "http://111.198.4.119:5000/api/";
        public int auth = 0;
        public string user_name = "";

        private double formWidth;//窗体原始宽度
        private double formHeight;//窗体原始高度
        private double scaleX;//水平缩放比例
        private double scaleY;//垂直缩放比例
        private Dictionary<string, string> ControlsInfo = new Dictionary<string, string>();//控件中心Left,Top,控件Width,控件Height,控件字体Size       

        public loginForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            GetAllInitInfo(loginBgPanel);
        }

        private void GetAllInitInfo(Control ctrlContainer)
        {
            if (ctrlContainer.Parent == this)//获取窗体的高度和宽度
            {
                formWidth = Convert.ToDouble(ctrlContainer.Width);
                formHeight = Convert.ToDouble(ctrlContainer.Height);
            }
            foreach (Control item in ctrlContainer.Controls)
            {
                if (item.Name.Trim() != "")
                {
                    //添加信息：键值：控件名，内容：据左边距离，距顶部距离，控件宽度，控件高度，控件字体。
                    ControlsInfo.Add(item.Name, (item.Left + item.Width / 2) + "," + (item.Top + item.Height / 2) + "," + item.Width + "," + item.Height + "," + item.Font.Size);
                }
                if ((item as UserControl) == null && item.Controls.Count > 0)
                {
                    GetAllInitInfo(item);
                }
            }

        }

        private void ControlsChangeInit(Control ctrlContainer)
        {
            scaleX = (Convert.ToDouble(ctrlContainer.Width) / formWidth);
            scaleY = (Convert.ToDouble(ctrlContainer.Height) / formHeight);
        }

        private void ControlsChange(Control ctrlContainer)
        {
            double[] pos = new double[5];//pos数组保存当前控件中心Left,Top,控件Width,控件Height,控件字体Size
            foreach (Control item in ctrlContainer.Controls)//遍历控件
            {
                if (item.Name.Trim() != "")//如果控件名不是空，则执行
                {
                    if ((item as UserControl) == null && item.Controls.Count > 0)//如果不是自定义控件
                    {
                        ControlsChange(item);//循环执行
                    }
                    string[] strs = ControlsInfo[item.Name].Split(',');//从字典中查出的数据，以‘，’分割成字符串组

                    for (int i = 0; i < 5; i++)
                    {
                        pos[i] = Convert.ToDouble(strs[i]);//添加到临时数组
                    }
                    double itemWidth = pos[2] * scaleX;     //计算控件宽度，double类型
                    double itemHeight = pos[3] * scaleY;    //计算控件高度
                    item.Left = Convert.ToInt32(pos[0] * scaleX - itemWidth / 2);//计算控件距离左边距离
                    item.Top = Convert.ToInt32(pos[1] * scaleY - itemHeight / 2);//计算控件距离顶部距离
                    item.Width = Convert.ToInt32(itemWidth);//控件宽度，int类型
                    item.Height = Convert.ToInt32(itemHeight);//控件高度
                    item.Font = new Font(item.Font.Name, float.Parse((pos[4] * Math.Min(scaleX, scaleY)).ToString()));//字体

                }
            }

        }

    /*
    private void setTag(Control cons)
    {
        foreach (Control con in cons.Controls)
        {
            con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
            if (con.Controls.Count > 0)
            {
                setTag(con);
            }
        }
    }

    private void setControls(float newx, float newy, Control cons)
    {
        //遍历窗体中的控件，重新设置控件的值
        foreach (Control con in cons.Controls)
        {
            if (con.Tag != null)
            {
                string[] mytag = con.Tag.ToString().Split(new char[] { ';' });//获取控件的Tag属性值，并分割后存储字符串数组
                float a = System.Convert.ToSingle(mytag[0]) * newx;//根据窗体缩放比例确定控件的值，宽度
                con.Width = (int)a;//宽度
                a = System.Convert.ToSingle(mytag[1]) * newy;//高度
                con.Height = (int)(a);
                a = System.Convert.ToSingle(mytag[2]) * newx;//左边距离
                con.Left = (int)(a);
                a = System.Convert.ToSingle(mytag[3]) * newy;//上边缘距离
                con.Top = (int)(a);
                Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字体大小
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }
        }
    }
    */

    private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            //当前为拖曳状态
            IsDragging = true;
            p.X = e.X;  //记录坐标X，Y
            p.Y = e.Y;
        }

        private void topPanel_MouseUp(object sender, MouseEventArgs e)
        {
            //当前为不拖曳状态
            IsDragging = false;
        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDragging)
            {
                //距离计算：移动的坐标-鼠标按下记录的坐标
                offset.X = e.X - p.X;
                offset.Y = e.Y - p.Y;
                //控件位置
                Location = PointToScreen(offset);
            }
        }

        private void minSize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maxSize_Click(object sender, EventArgs e) //To do: maxsize icon transform
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void closeWin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void loginBtn_Click_1(object sender, EventArgs e)
        {
            string username = userName.Text;
            string pwd = password.Text;
            Hashtable ht = new Hashtable();
            ht.Add("username", username);
            ht.Add("pwd", pwd);
            string aa = HttpUtils.DoPost(api_url + "login", ht);
            if (aa.Contains("match"))
            {
                if (aa.Contains("0"))
                {
                    auth = 0;
                }
                else
                {
                    auth = 1;
                }
                Console.WriteLine(aa);
                Console.WriteLine(auth);
                Console.WriteLine("Login!");
                user_name = username;
                this.DialogResult = DialogResult.OK;
                this.Dispose();
                this.Close();
            }
            else
            {
                if (aa.Contains("invalid"))
                {
                    DialogResult invalid = MessageBox.Show("无此用户！", "提示", MessageBoxButtons.OK);
                    return;
                }
                else if (aa.Contains("error"))
                {
                    DialogResult invalid = MessageBox.Show("密码错误！", "提示", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private void regLink_Click(object sender, EventArgs e)
        {
            var regwin = new registerForm();
            regwin.ShowDialog();
        }

        private void forgetLink_Click(object sender, EventArgs e)
        {
            string username = userName.Text;
            if (username == "")
            {
                DialogResult user = MessageBox.Show("请输入用户名！", "提示", MessageBoxButtons.OK);
                return;
            }
            else
            {                
                string reset_info = HttpUtils.Get(api_url + "reset_password?username=" + username);
                if (reset_info.Contains("email"))
                {
                    DialogResult invalid = MessageBox.Show("该用户未填写邮箱，请联系管理员！", "提示", MessageBoxButtons.OK);
                    return;
                }
                else if (reset_info.Contains("user"))
                {
                    DialogResult invalid = MessageBox.Show("无此用户！", "提示", MessageBoxButtons.OK);
                    return;
                }
                else if (reset_info.Contains("failed"))
                {
                    DialogResult invalid = MessageBox.Show("重置失败，请重试！", "提示", MessageBoxButtons.OK);
                    return;
                }
                DialogResult send = MessageBox.Show("密码重置邮件已发送至邮箱！", "提示", MessageBoxButtons.OK);
                return;
            }
        }

        private void panel1_DoubleClick(object sender, PaintEventArgs e)
        {

        }

        private void loginForm_SizeChanged(object sender, EventArgs e)
        {
            if (ControlsInfo.Count > 0)//如果字典中有数据，即窗体改变
            {
                ControlsChangeInit(loginBgPanel);//表示pannel控件
                ControlsChange(loginBgPanel);

            }
        }

        /*
        private void loginForm_Load(object sender, EventArgs e)
        {
            x = this.Width;
            y = this.Height;
            setTag(this);
        }

        private void loginForm_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / x;
            float newy = (this.Height) / y;
            setControls(newx, newy, this);
        }*/

        /*
        private void setRadius_picBox(TableLayoutPanel picBox, int d)
        {
            Rectangle r = new Rectangle(0, 0, picBox.Width, picBox.Height);
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddArc(r.X, r.Y, d, d, 180, 90);
            gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);
            gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);
            picBox.Region = new Region(gp);
        }*/

    }
}
