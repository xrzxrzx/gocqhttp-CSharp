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
            Log.Info("打开前");
            robotSettingForm.ShowDialog();
            Log.Info("打开后");
        }
        /// <summary>
        /// 修改用于输出的文本域（可跨线程）
        /// </summary>
        /// <param name="text"></param>
        public void UpdateText(string text)
        {
            if(richTextBox1.InvokeRequired == true)
            {
                lock(richTextBox1)
                {
                    Invoke(new Action(() => { richTextBox1.Text += text; }));
                }
            }
            else
            {
                lock(richTextBox1)
                {
                    richTextBox1.Text += text;
                }
            }
        }
    }
}
