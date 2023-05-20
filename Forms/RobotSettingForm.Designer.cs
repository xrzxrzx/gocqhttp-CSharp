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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ConfigFileText = new System.Windows.Forms.TextBox();
            this.GocqhttpFileText = new System.Windows.Forms.TextBox();
            this.SelectConfigButton = new System.Windows.Forms.Button();
            this.SelectGocqhttpButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SocketIPText = new System.Windows.Forms.TextBox();
            this.SocketPortText = new System.Windows.Forms.TextBox();
            this.RobotPwdText = new System.Windows.Forms.TextBox();
            this.RobotQQText = new System.Windows.Forms.TextBox();
            this.RobotNameText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LoadConfigButtton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "config.yml文件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "gocqhttp.exe文件";
            // 
            // ConfigFileText
            // 
            this.ConfigFileText.AllowDrop = true;
            this.ConfigFileText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfigFileText.Location = new System.Drawing.Point(156, 6);
            this.ConfigFileText.Name = "ConfigFileText";
            this.ConfigFileText.ReadOnly = true;
            this.ConfigFileText.Size = new System.Drawing.Size(534, 27);
            this.ConfigFileText.TabIndex = 2;
            // 
            // GocqhttpFileText
            // 
            this.GocqhttpFileText.AllowDrop = true;
            this.GocqhttpFileText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GocqhttpFileText.Location = new System.Drawing.Point(156, 40);
            this.GocqhttpFileText.Name = "GocqhttpFileText";
            this.GocqhttpFileText.ReadOnly = true;
            this.GocqhttpFileText.Size = new System.Drawing.Size(534, 27);
            this.GocqhttpFileText.TabIndex = 3;
            // 
            // SelectConfigButton
            // 
            this.SelectConfigButton.Location = new System.Drawing.Point(694, 6);
            this.SelectConfigButton.Name = "SelectConfigButton";
            this.SelectConfigButton.Size = new System.Drawing.Size(94, 27);
            this.SelectConfigButton.TabIndex = 4;
            this.SelectConfigButton.Text = "选择文件";
            this.SelectConfigButton.UseVisualStyleBackColor = true;
            this.SelectConfigButton.Click += new System.EventHandler(this.SelectConfigButton_Click);
            // 
            // SelectGocqhttpButton
            // 
            this.SelectGocqhttpButton.Location = new System.Drawing.Point(694, 39);
            this.SelectGocqhttpButton.Name = "SelectGocqhttpButton";
            this.SelectGocqhttpButton.Size = new System.Drawing.Size(94, 27);
            this.SelectGocqhttpButton.TabIndex = 5;
            this.SelectGocqhttpButton.Text = "选择文件";
            this.SelectGocqhttpButton.UseVisualStyleBackColor = true;
            this.SelectGocqhttpButton.Click += new System.EventHandler(this.SelectGocqhttpButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SocketIPText);
            this.groupBox1.Controls.Add(this.SocketPortText);
            this.groupBox1.Controls.Add(this.RobotPwdText);
            this.groupBox1.Controls.Add(this.RobotQQText);
            this.groupBox1.Controls.Add(this.RobotNameText);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.LoadConfigButtton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 282);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // SocketIPText
            // 
            this.SocketIPText.Location = new System.Drawing.Point(203, 184);
            this.SocketIPText.Name = "SocketIPText";
            this.SocketIPText.Size = new System.Drawing.Size(195, 27);
            this.SocketIPText.TabIndex = 10;
            // 
            // SocketPortText
            // 
            this.SocketPortText.Location = new System.Drawing.Point(537, 184);
            this.SocketPortText.Name = "SocketPortText";
            this.SocketPortText.Size = new System.Drawing.Size(93, 27);
            this.SocketPortText.TabIndex = 9;
            // 
            // RobotPwdText
            // 
            this.RobotPwdText.Location = new System.Drawing.Point(522, 102);
            this.RobotPwdText.Name = "RobotPwdText";
            this.RobotPwdText.Size = new System.Drawing.Size(217, 27);
            this.RobotPwdText.TabIndex = 8;
            // 
            // RobotQQText
            // 
            this.RobotQQText.Location = new System.Drawing.Point(203, 105);
            this.RobotQQText.Name = "RobotQQText";
            this.RobotQQText.Size = new System.Drawing.Size(195, 27);
            this.RobotQQText.TabIndex = 7;
            // 
            // RobotNameText
            // 
            this.RobotNameText.Location = new System.Drawing.Point(315, 26);
            this.RobotNameText.Name = "RobotNameText";
            this.RobotNameText.Size = new System.Drawing.Size(223, 27);
            this.RobotNameText.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(404, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "WebSocket 端口";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "WebSocket IP地址";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(404, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "机器人QQ密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "机器人QQ号";
            // 
            // LoadConfigButtton
            // 
            this.LoadConfigButtton.Location = new System.Drawing.Point(315, 236);
            this.LoadConfigButtton.Name = "LoadConfigButtton";
            this.LoadConfigButtton.Size = new System.Drawing.Size(166, 40);
            this.LoadConfigButtton.TabIndex = 1;
            this.LoadConfigButtton.Text = "从配置文件中获取";
            this.LoadConfigButtton.UseVisualStyleBackColor = true;
            this.LoadConfigButtton.Click += new System.EventHandler(this.LoadConfigButtton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "机器人呢称";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(463, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 60);
            this.button1.TabIndex = 1;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(242, 378);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 60);
            this.button2.TabIndex = 7;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RobotSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SelectGocqhttpButton);
            this.Controls.Add(this.SelectConfigButton);
            this.Controls.Add(this.GocqhttpFileText);
            this.Controls.Add(this.ConfigFileText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RobotSettingForm";
            this.Text = "机器人设置";
            this.Load += new System.EventHandler(this.RobotSettingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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