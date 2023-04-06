﻿using System;
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

namespace gocqhttp_CSharp.Forms
{
    public partial class MainForm : Form
    {
        Gocqhttp gocqhttp;   
        public MainForm()
        {
            InitializeComponent();
            gocqhttp = new Gocqhttp();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void gocqhttp设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RobotSettingForm robotSettingForm = new RobotSettingForm();
            robotSettingForm.ShowDialog();
        }
    }
}
