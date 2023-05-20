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
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using System.IO;
using System.ComponentModel.Design.Serialization;
using System.Text.RegularExpressions;

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
            RobotNameText.Text = setting.RobotName;
            RobotPwdText.Text = setting.RobotPwd;
            RobotQQText.Text = setting.RobotID.ToString();
            SocketIPText.Text = setting.IP;
            SocketPortText.Text = setting.Port.ToString();
            #endregion
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            setting.RobotName = RobotNameText.Text;
            setting.RobotID = uint.Parse(RobotQQText.Text);
            setting.RobotPwd = RobotPwdText.Text;
            setting.IP = SocketIPText.Text;
            setting.Port = int.Parse(SocketPortText.Text);
            setting.Save();
            MessageBox.Show("已保存！");
        }
        private void LoadConfigButtton_Click(object sender, EventArgs e)
        {
            var configFile = new YamlStream();
            configFile.Load(File.OpenText(ConfigFileText.Text));
            var rootNode = (YamlMappingNode)configFile.Documents[0].RootNode;
            var account = rootNode["account"];
            var servers = rootNode["servers"][0]["ws"];
            RobotQQText.Text = account["uin"].ToString();
            RobotPwdText.Text = account["password"].ToString();
            SocketIPText.Text = Regex.Matches(servers["address"].ToString(), @"\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}")[0].Value.ToString();
            SocketPortText.Text = Regex.Matches(servers["address"].ToString(), @"\d{1,5}$")[0].Value.ToString();
        }
    }
}
