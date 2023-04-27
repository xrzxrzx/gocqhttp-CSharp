using gocqhttp_CSharp.common;
using gocqhttp_CSharp.gocqhttp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gocqhttp_CSharp.Forms
{
    public partial class RobotSettingForm : Form
    {
        AppSetting setting;
        public RobotSettingForm()
        {
            InitializeComponent();
            setting = new AppSetting();
        }

        private void SelectConfigButton_Click(object sender, EventArgs e)
        {
            setting.Reload();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "config.yml文件(*.yml)|config.yml";
            if(dialog.ShowDialog() == DialogResult.OK )
            {
                ConfigFileText.Text = dialog.FileName;
                setting.ConfigFilePath= dialog.FileName;
            }
            setting.Save();
        }

        private void SelectGocqhttpButton_Click(object sender, EventArgs e)
        {
            setting.Reload();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "go-cqhttp.exe文件(*.exe)|go-cqhttp.exe";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                GocqhttpFileText.Text = dialog.FileName;
                setting.GocqhttpFilePath= dialog.FileName;
            }
            setting.Save();
        }

        private void RobotSettingForm_Load(object sender, EventArgs e)
        {
            setting.Reload();
            #region 控件初始化
            ConfigFileText.Text = setting.ConfigFilePath;
            GocqhttpFileText.Text= setting.GocqhttpFilePath;
            #endregion
        }
    }
}
