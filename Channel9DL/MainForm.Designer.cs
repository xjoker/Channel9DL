namespace Channel9DL
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxVideoDownList = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labVideoCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labVideoProgress = new System.Windows.Forms.Label();
            this.tbxLogBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxVideoDownList
            // 
            this.tbxVideoDownList.Location = new System.Drawing.Point(256, 77);
            this.tbxVideoDownList.Multiline = true;
            this.tbxVideoDownList.Name = "tbxVideoDownList";
            this.tbxVideoDownList.Size = new System.Drawing.Size(406, 280);
            this.tbxVideoDownList.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(107, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(555, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "课程网页";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.label2.Location = new System.Drawing.Point(393, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "视频下载列表";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "视频总数：";
            // 
            // labVideoCount
            // 
            this.labVideoCount.AutoSize = true;
            this.labVideoCount.Location = new System.Drawing.Point(101, 78);
            this.labVideoCount.Name = "labVideoCount";
            this.labVideoCount.Size = new System.Drawing.Size(0, 12);
            this.labVideoCount.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "当前进度：";
            // 
            // labVideoProgress
            // 
            this.labVideoProgress.AutoSize = true;
            this.labVideoProgress.Location = new System.Drawing.Point(101, 107);
            this.labVideoProgress.Name = "labVideoProgress";
            this.labVideoProgress.Size = new System.Drawing.Size(0, 12);
            this.labVideoProgress.TabIndex = 8;
            // 
            // tbxLogBox
            // 
            this.tbxLogBox.Location = new System.Drawing.Point(18, 149);
            this.tbxLogBox.Multiline = true;
            this.tbxLogBox.Name = "tbxLogBox";
            this.tbxLogBox.ReadOnly = true;
            this.tbxLogBox.Size = new System.Drawing.Size(228, 168);
            this.tbxLogBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10F);
            this.label6.Location = new System.Drawing.Point(100, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "日志";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(121, 334);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 380);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxLogBox);
            this.Controls.Add(this.labVideoProgress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labVideoCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tbxVideoDownList);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Channel9视频字幕下载器";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxVideoDownList;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labVideoCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labVideoProgress;
        private System.Windows.Forms.TextBox tbxLogBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
    }
}

