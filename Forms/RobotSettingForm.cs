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
        public RobotSettingForm()
        {
            InitializeComponent();
        }

        private void SelectConfigButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "yml文件(*.yml)|*.yml";
            if(dialog.ShowDialog() == DialogResult.OK )
            {
                ConfigFileText.Text = dialog.FileName;
            }
        }

        private void SelectGocqhttpButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "exe文件(*.exe)|*.exe";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                GocqhttpFileText.Text = dialog.FileName;
            }
        }
    }
}
