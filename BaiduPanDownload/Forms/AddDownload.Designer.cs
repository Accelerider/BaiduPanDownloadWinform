namespace BaiduPanDownload.Forms
{
    partial class AddDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDownload));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.FileName_Lab = new System.Windows.Forms.Label();
            this.FileSize_Lab = new System.Windows.Forms.Label();
            this.DriveSpace_Lab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "下载到：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(67, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(350, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "D:\\BaiduYunDownload";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(423, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(383, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 21);
            this.button2.TabIndex = 3;
            this.button2.Text = "添加下载";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 106);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(132, 16);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "设置为默认下载路径";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FileName_Lab
            // 
            this.FileName_Lab.AutoSize = true;
            this.FileName_Lab.Location = new System.Drawing.Point(8, 9);
            this.FileName_Lab.Name = "FileName_Lab";
            this.FileName_Lab.Size = new System.Drawing.Size(41, 12);
            this.FileName_Lab.TabIndex = 5;
            this.FileName_Lab.Text = "label2";
            // 
            // FileSize_Lab
            // 
            this.FileSize_Lab.AutoSize = true;
            this.FileSize_Lab.Location = new System.Drawing.Point(8, 31);
            this.FileSize_Lab.Name = "FileSize_Lab";
            this.FileSize_Lab.Size = new System.Drawing.Size(41, 12);
            this.FileSize_Lab.TabIndex = 6;
            this.FileSize_Lab.Text = "label2";
            // 
            // DriveSpace_Lab
            // 
            this.DriveSpace_Lab.AutoSize = true;
            this.DriveSpace_Lab.Location = new System.Drawing.Point(8, 81);
            this.DriveSpace_Lab.Name = "DriveSpace_Lab";
            this.DriveSpace_Lab.Size = new System.Drawing.Size(41, 12);
            this.DriveSpace_Lab.TabIndex = 7;
            this.DriveSpace_Lab.Text = "label2";
            // 
            // AddDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 127);
            this.Controls.Add(this.DriveSpace_Lab);
            this.Controls.Add(this.FileSize_Lab);
            this.Controls.Add(this.FileName_Lab);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建下载任务";
            this.Load += new System.EventHandler(this.AddDownload_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label FileName_Lab;
        private System.Windows.Forms.Label FileSize_Lab;
        private System.Windows.Forms.Label DriveSpace_Lab;
    }
}