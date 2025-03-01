namespace gocqhttp_CSharp.Forms
{
    partial class RobotSettingForm
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
            label1 = new Label();
            label2 = new Label();
            ConfigFileText = new TextBox();
            GocqhttpFileText = new TextBox();
            SelectConfigButton = new Button();
            SelectGocqhttpButton = new Button();
            groupBox1 = new GroupBox();
            SocketIPText = new TextBox();
            SocketPortText = new TextBox();
            RobotPwdText = new TextBox();
            RobotQQText = new TextBox();
            RobotNameText = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            LoadConfigButtton = new Button();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 11);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(136, 24);
            label1.TabIndex = 0;
            label1.Text = "config.yml文件";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 48);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(75, 24);
            label2.TabIndex = 1;
            label2.Text = "API文件";
            // 
            // ConfigFileText
            // 
            ConfigFileText.AllowDrop = true;
            ConfigFileText.BorderStyle = BorderStyle.FixedSingle;
            ConfigFileText.Location = new Point(191, 7);
            ConfigFileText.Margin = new Padding(4, 4, 4, 4);
            ConfigFileText.Name = "ConfigFileText";
            ConfigFileText.ReadOnly = true;
            ConfigFileText.Size = new Size(652, 30);
            ConfigFileText.TabIndex = 2;
            // 
            // GocqhttpFileText
            // 
            GocqhttpFileText.AllowDrop = true;
            GocqhttpFileText.BorderStyle = BorderStyle.FixedSingle;
            GocqhttpFileText.Location = new Point(191, 48);
            GocqhttpFileText.Margin = new Padding(4, 4, 4, 4);
            GocqhttpFileText.Name = "GocqhttpFileText";
            GocqhttpFileText.ReadOnly = true;
            GocqhttpFileText.Size = new Size(652, 30);
            GocqhttpFileText.TabIndex = 3;
            // 
            // SelectConfigButton
            // 
            SelectConfigButton.Location = new Point(848, 7);
            SelectConfigButton.Margin = new Padding(4, 4, 4, 4);
            SelectConfigButton.Name = "SelectConfigButton";
            SelectConfigButton.Size = new Size(115, 32);
            SelectConfigButton.TabIndex = 4;
            SelectConfigButton.Text = "选择文件";
            SelectConfigButton.UseVisualStyleBackColor = true;
            SelectConfigButton.Click += SelectConfigButton_Click;
            // 
            // SelectGocqhttpButton
            // 
            SelectGocqhttpButton.Location = new Point(848, 47);
            SelectGocqhttpButton.Margin = new Padding(4, 4, 4, 4);
            SelectGocqhttpButton.Name = "SelectGocqhttpButton";
            SelectGocqhttpButton.Size = new Size(115, 32);
            SelectGocqhttpButton.TabIndex = 5;
            SelectGocqhttpButton.Text = "选择文件";
            SelectGocqhttpButton.UseVisualStyleBackColor = true;
            SelectGocqhttpButton.Click += SelectGocqhttpButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(SocketIPText);
            groupBox1.Controls.Add(SocketPortText);
            groupBox1.Controls.Add(RobotPwdText);
            groupBox1.Controls.Add(RobotQQText);
            groupBox1.Controls.Add(RobotNameText);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(LoadConfigButtton);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(15, 108);
            groupBox1.Margin = new Padding(4, 4, 4, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 4, 4, 4);
            groupBox1.Size = new Size(948, 338);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "基本信息";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // SocketIPText
            // 
            SocketIPText.Location = new Point(248, 221);
            SocketIPText.Margin = new Padding(4, 4, 4, 4);
            SocketIPText.Name = "SocketIPText";
            SocketIPText.Size = new Size(237, 30);
            SocketIPText.TabIndex = 10;
            // 
            // SocketPortText
            // 
            SocketPortText.Location = new Point(656, 221);
            SocketPortText.Margin = new Padding(4, 4, 4, 4);
            SocketPortText.Name = "SocketPortText";
            SocketPortText.Size = new Size(113, 30);
            SocketPortText.TabIndex = 9;
            // 
            // RobotPwdText
            // 
            RobotPwdText.Location = new Point(638, 122);
            RobotPwdText.Margin = new Padding(4, 4, 4, 4);
            RobotPwdText.Name = "RobotPwdText";
            RobotPwdText.Size = new Size(264, 30);
            RobotPwdText.TabIndex = 8;
            // 
            // RobotQQText
            // 
            RobotQQText.Location = new Point(248, 126);
            RobotQQText.Margin = new Padding(4, 4, 4, 4);
            RobotQQText.Name = "RobotQQText";
            RobotQQText.Size = new Size(237, 30);
            RobotQQText.TabIndex = 7;
            // 
            // RobotNameText
            // 
            RobotNameText.Location = new Point(385, 31);
            RobotNameText.Margin = new Padding(4, 4, 4, 4);
            RobotNameText.Name = "RobotNameText";
            RobotNameText.Size = new Size(272, 30);
            RobotNameText.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(494, 224);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(148, 24);
            label7.TabIndex = 5;
            label7.Text = "WebSocket 端口";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(56, 224);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(164, 24);
            label6.TabIndex = 4;
            label6.Text = "WebSocket IP地址";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(494, 126);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(130, 24);
            label5.TabIndex = 3;
            label5.Text = "机器人QQ密码";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(114, 126);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(112, 24);
            label4.TabIndex = 2;
            label4.Text = "机器人QQ号";
            // 
            // LoadConfigButtton
            // 
            LoadConfigButtton.Location = new Point(385, 283);
            LoadConfigButtton.Margin = new Padding(4, 4, 4, 4);
            LoadConfigButtton.Name = "LoadConfigButtton";
            LoadConfigButtton.Size = new Size(203, 48);
            LoadConfigButtton.TabIndex = 1;
            LoadConfigButtton.Text = "从配置文件中获取";
            LoadConfigButtton.UseVisualStyleBackColor = true;
            LoadConfigButtton.Click += LoadConfigButtton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(275, 35);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 24);
            label3.TabIndex = 0;
            label3.Text = "机器人呢称";
            // 
            // button1
            // 
            button1.Location = new Point(566, 454);
            button1.Margin = new Padding(4, 4, 4, 4);
            button1.Name = "button1";
            button1.Size = new Size(175, 72);
            button1.TabIndex = 1;
            button1.Text = "保存";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(296, 454);
            button2.Margin = new Padding(4, 4, 4, 4);
            button2.Name = "button2";
            button2.Size = new Size(175, 72);
            button2.TabIndex = 7;
            button2.Text = "取消";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // RobotSettingForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 540);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(SelectGocqhttpButton);
            Controls.Add(SelectConfigButton);
            Controls.Add(GocqhttpFileText);
            Controls.Add(ConfigFileText);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "RobotSettingForm";
            Text = "机器人设置";
            Load += RobotSettingForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox ConfigFileText;
        private TextBox GocqhttpFileText;
        private Button SelectConfigButton;
        private Button SelectGocqhttpButton;
        private GroupBox groupBox1;
        private Label label3;
        private Button button1;
        private Button LoadConfigButtton;
        private Button button2;
        private TextBox SocketIPText;
        private TextBox SocketPortText;
        private TextBox RobotPwdText;
        private TextBox RobotQQText;
        private TextBox RobotNameText;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
    }
}