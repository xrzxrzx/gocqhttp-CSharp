namespace gocqhttp_CSharp.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            功能ToolStripMenuItem = new ToolStripMenuItem();
            gocqhttp设置ToolStripMenuItem = new ToolStripMenuItem();
            关于ToolStripMenuItem = new ToolStripMenuItem();
            关于软件ToolStripMenuItem = new ToolStripMenuItem();
            关于作者ToolStripMenuItem = new ToolStripMenuItem();
            richTextBox1 = new RichTextBox();
            TabControl = new TabControl();
            FunctionPage = new TabPage();
            button2 = new Button();
            button1 = new Button();
            QQPage = new TabPage();
            RobotPage = new TabPage();
            label1 = new Label();
            StartButton = new Button();
            CloseButton = new Button();
            clearButton = new Button();
            menuStrip1.SuspendLayout();
            TabControl.SuspendLayout();
            FunctionPage.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 功能ToolStripMenuItem, 关于ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1121, 32);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 功能ToolStripMenuItem
            // 
            功能ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gocqhttp设置ToolStripMenuItem });
            功能ToolStripMenuItem.Name = "功能ToolStripMenuItem";
            功能ToolStripMenuItem.Size = new Size(62, 28);
            功能ToolStripMenuItem.Text = "功能";
            // 
            // gocqhttp设置ToolStripMenuItem
            // 
            gocqhttp设置ToolStripMenuItem.Name = "gocqhttp设置ToolStripMenuItem";
            gocqhttp设置ToolStripMenuItem.Size = new Size(200, 34);
            gocqhttp设置ToolStripMenuItem.Text = "机器人设置";
            gocqhttp设置ToolStripMenuItem.Click += gocqhttp设置ToolStripMenuItem_Click;
            // 
            // 关于ToolStripMenuItem
            // 
            关于ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 关于软件ToolStripMenuItem, 关于作者ToolStripMenuItem });
            关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            关于ToolStripMenuItem.Size = new Size(62, 28);
            关于ToolStripMenuItem.Text = "关于";
            // 
            // 关于软件ToolStripMenuItem
            // 
            关于软件ToolStripMenuItem.Name = "关于软件ToolStripMenuItem";
            关于软件ToolStripMenuItem.Size = new Size(182, 34);
            关于软件ToolStripMenuItem.Text = "关于软件";
            // 
            // 关于作者ToolStripMenuItem
            // 
            关于作者ToolStripMenuItem.Name = "关于作者ToolStripMenuItem";
            关于作者ToolStripMenuItem.Size = new Size(182, 34);
            关于作者ToolStripMenuItem.Text = "关于作者";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(15, 72);
            richTextBox1.Margin = new Padding(4);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(795, 508);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // TabControl
            // 
            TabControl.Controls.Add(FunctionPage);
            TabControl.Controls.Add(QQPage);
            TabControl.Controls.Add(RobotPage);
            TabControl.Location = new Point(818, 52);
            TabControl.Margin = new Padding(4);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(288, 613);
            TabControl.TabIndex = 2;
            // 
            // FunctionPage
            // 
            FunctionPage.Controls.Add(button2);
            FunctionPage.Controls.Add(button1);
            FunctionPage.Location = new Point(4, 33);
            FunctionPage.Margin = new Padding(4);
            FunctionPage.Name = "FunctionPage";
            FunctionPage.Padding = new Padding(4);
            FunctionPage.Size = new Size(280, 576);
            FunctionPage.TabIndex = 0;
            FunctionPage.Text = "基本功能";
            FunctionPage.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(154, 17);
            button2.Name = "button2";
            button2.Size = new Size(100, 50);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(23, 17);
            button1.Name = "button1";
            button1.Size = new Size(100, 50);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // QQPage
            // 
            QQPage.Location = new Point(4, 33);
            QQPage.Margin = new Padding(4);
            QQPage.Name = "QQPage";
            QQPage.Padding = new Padding(4);
            QQPage.Size = new Size(280, 576);
            QQPage.TabIndex = 1;
            QQPage.Text = "QQ功能";
            QQPage.UseVisualStyleBackColor = true;
            // 
            // RobotPage
            // 
            RobotPage.Location = new Point(4, 33);
            RobotPage.Margin = new Padding(4);
            RobotPage.Name = "RobotPage";
            RobotPage.Size = new Size(280, 576);
            RobotPage.TabIndex = 2;
            RobotPage.Text = "机器人功能";
            RobotPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 34);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 3;
            label1.Text = "日志输出";
            // 
            // StartButton
            // 
            StartButton.Location = new Point(78, 594);
            StartButton.Margin = new Padding(4);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(167, 72);
            StartButton.TabIndex = 4;
            StartButton.Text = "开启";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(533, 594);
            CloseButton.Margin = new Padding(4);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(167, 72);
            CloseButton.TabIndex = 5;
            CloseButton.Text = "关闭";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(305, 594);
            clearButton.Margin = new Padding(4);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(167, 72);
            clearButton.TabIndex = 6;
            clearButton.Text = "清屏";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1121, 679);
            Controls.Add(clearButton);
            Controls.Add(CloseButton);
            Controls.Add(StartButton);
            Controls.Add(label1);
            Controls.Add(TabControl);
            Controls.Add(richTextBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "QQ机器人管理器";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            TabControl.ResumeLayout(false);
            FunctionPage.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 功能ToolStripMenuItem;
        private ToolStripMenuItem 关于ToolStripMenuItem;
        private ToolStripMenuItem gocqhttp设置ToolStripMenuItem;
        private ToolStripMenuItem 关于软件ToolStripMenuItem;
        private ToolStripMenuItem 关于作者ToolStripMenuItem;
        private RichTextBox richTextBox1;
        private TabControl TabControl;
        private TabPage FunctionPage;
        private TabPage QQPage;
        private Label label1;
        private TabPage RobotPage;
        private Button StartButton;
        private Button CloseButton;
        private Button clearButton;
        private Button button1;
        private Button button2;
    }
}