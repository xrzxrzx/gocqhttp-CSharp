using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gocqhttp_CSharp.gocqhttp;
using gocqhttp_CSharp.Forms;
using gocqhttp_CSharp.common;
using static System.Net.Mime.MediaTypeNames;

namespace gocqhttp_CSharp.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void gocqhttp设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RobotSettingForm robotSettingForm = new RobotSettingForm();
            TextLog.Info("打开前");
            robotSettingForm.ShowDialog();
            TextLog.Info("打开后");
        }
        /// <summary>
        /// 修改用于输出的文本域（可跨线程）
        /// </summary>
        /// <param name="text"></param>
        public void UpdateText(string text)
        {
            if (richTextBox1.InvokeRequired == true)
            {
                lock (richTextBox1)
                {
                    Invoke(new Action(() => { richTextBox1.Text += text; }));
                }
            }
            else
            {
                lock (richTextBox1)
                {
                    richTextBox1.Text += text;
                }
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Gocqhttp.Start();
            TextLog.Info("已开启");
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Gocqhttp.Stop();
            TextLog.Info("已关闭");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Gocqhttp.Stop();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            lock (richTextBox1)
            {
                richTextBox1.Text = string.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                var data = Gocqhttp.Send("send_private_msg", 3406515483, "test");
                TextLog.Info($"{data?.ToString()}");
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                var data = Gocqhttp.Send("send_group_msg", 434807438, "test");
                TextLog.Info($"{data?.ToString()}");
            });
        }
    }
}
