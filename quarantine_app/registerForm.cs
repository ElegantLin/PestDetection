using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quarantine_app
{
    public partial class registerForm : Form
    {
        private static String api_url = "http://111.198.4.119:5000/api/";
        private int seconds = 60;
        private Thread thread;
        private delegate void FlushClient();
        private string code = "";
        public registerForm()
        {
            InitializeComponent();
            thread = new Thread(CrossThreadFlush);
            thread.IsBackground = true;
        }

        private void CrossThreadFlush()
        {
            while (true)
            {
                Thread.Sleep(1000);
                ChangeData();
            }
        }

        private void ChangeData()
        {
            if (submitAuth.InvokeRequired)
            {
                FlushClient fc = new FlushClient(ChangeData);
                this.Invoke(fc);
            }
            else
            {
                submitAuth.Text = seconds.ToString();
                seconds -= 1;
                if (seconds == -1)
                {
                    submitAuth.Text = "发 送";
                    thread.Suspend();
                }
            }
        }

        private bool IsEmail(string emailStr)
        {
            return Regex.IsMatch(emailStr, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            if (regUser.Text == "")
            {
                DialogResult dr = MessageBox.Show("请输入用户名！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (regPwd.Text == "")
            {
                DialogResult dr = MessageBox.Show("请输入登录密码！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (confirmPwd.Text == "")
            {
                DialogResult dr = MessageBox.Show("请输入确认密码！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (regEmail.Text == "")
            {
                DialogResult dr = MessageBox.Show("请输入邮箱地址！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (IsEmail(regEmail.Text) == false)
            {
                DialogResult dr = MessageBox.Show("请输入正确格式的邮箱地址！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (confirmPwd.Text != regPwd.Text)
            {
                DialogResult dr = MessageBox.Show("两次密码必须输入一致！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (authCode.Text == "")
            {
                DialogResult dr = MessageBox.Show("请输入注册授权码！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (authCode.Text != code)
            {
                DialogResult dr = MessageBox.Show("注册授权码输入有误！", "提示", MessageBoxButtons.OK);
                return;
            }
            Hashtable ht = new Hashtable();
            ht.Add("username", regUser.Text);
            ht.Add("pwd", regPwd.Text);
            ht.Add("email", regEmail.Text);
            string res = HttpUtils.DoPost(api_url + "register", ht);
            Console.WriteLine(res);
            if (res.Contains("ok"))
            {
                DialogResult dr = MessageBox.Show("注册成功！", "提示", MessageBoxButtons.OK);
                try
                {
                    thread.Abort();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Thread Error!");
                }
                this.Dispose();
                this.Close();
                return;
            }
            else if (res.Contains("user"))
            {
                DialogResult dr = MessageBox.Show("该用户名已被注册！", "提示", MessageBoxButtons.OK);
                return;
            }
            else
            {
                DialogResult dr = MessageBox.Show("注册失败，请重试！", "提示", MessageBoxButtons.OK);
                return;
            }
        }

        private void submitAuth_Click(object sender, EventArgs e)
        {
            if (seconds != -1 && seconds != 60) return;
            string address = regEmail.Text;
            if (regUser.Text == "")
            {
                DialogResult dr = MessageBox.Show("请输入用户名！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (regPwd.Text == "")
            {
                DialogResult dr = MessageBox.Show("请输入登录密码！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (confirmPwd.Text == "")
            {
                DialogResult dr = MessageBox.Show("请输入确认密码！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (regEmail.Text == "")
            {
                DialogResult dr = MessageBox.Show("请输入邮箱地址！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (IsEmail(regEmail.Text) == false)
            {
                DialogResult dr = MessageBox.Show("请输入正确格式的邮箱地址！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (confirmPwd.Text != regPwd.Text)
            {
                DialogResult dr = MessageBox.Show("两次密码必须输入一致！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (IsEmail(address))
            {
                List<string> macs = GetLocalMac();
                string macs_json = macs.Count > 0 ? JsonConvert.SerializeObject(macs).ToString() : "";
                string full_url = String.Format("{0}register_code?email={1}&mac={2}", api_url, address, macs_json);
                //string res = HttpUtils.Get(api_url + "register_code?email=" + address);
                string res = HttpUtils.Get(full_url);
                if (res.Contains("ok"))
                {
                    DialogResult dr = MessageBox.Show("注册授权码已发送至邮箱，请填写完成注册！", "提示", MessageBoxButtons.OK);
                    seconds = 60;
                    if (thread.ThreadState != ThreadState.Suspended)
                    {
                        try { thread.Start(); }
                        catch (Exception ex)
                        { Console.WriteLine("Thread error"); }
                    }
                    else thread.Resume();
                    dynamic ress = JsonConvert.DeserializeObject(res);
                    code = ress["code"].ToString();
                    return;
                }
                else
                {
                    DialogResult dr = MessageBox.Show("发送注册授权码失败，请重试！", "提示", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("请输入正确的邮箱地址！", "提示", MessageBoxButtons.OK);
                return;
            }
        }

        private static List<string> GetLocalMac()
        {
            List<string> macs = new List<string>();
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                string mac = ni.GetPhysicalAddress().ToString();
                if (mac.Trim() != "")
                {
                    macs.Add(mac);
                }
            }
            return macs;
        }
    }
}
