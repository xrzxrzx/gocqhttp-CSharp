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
            this.ConfigFileText.Location = new System.Drawing.Point(156, 6);
            this.ConfigFileText.Name = "ConfigFileText";
            this.ConfigFileText.Size = new System.Drawing.Size(534, 27);
            this.ConfigFileText.TabIndex = 2;
            // 
            // GocqhttpFileText
            // 
            this.GocqhttpFileText.Location = new System.Drawing.Point(156, 40);
            this.GocqhttpFileText.Name = "GocqhttpFileText";
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
            // RobotSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SelectGocqhttpButton);
            this.Controls.Add(this.SelectConfigButton);
            this.Controls.Add(this.GocqhttpFileText);
            this.Controls.Add(this.ConfigFileText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RobotSettingForm";
            this.Text = "RobotSettingForm";
            this.Load += new System.EventHandler(this.RobotSettingForm_Load);
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
    }
}