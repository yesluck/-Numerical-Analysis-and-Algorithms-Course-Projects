namespace LnX
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.xBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.precisionBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.taylorBox = new System.Windows.Forms.GroupBox();
            this.taylorStartButton = new System.Windows.Forms.Button();
            this.taylorTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.taylorResult = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.simpsonBox = new System.Windows.Forms.GroupBox();
            this.simpsonStartButton = new System.Windows.Forms.Button();
            this.simpsonTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.simpsonResult = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rombergBox = new System.Windows.Forms.GroupBox();
            this.rombergStartButton = new System.Windows.Forms.Button();
            this.rombergTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rombergResult = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lagrangeBox = new System.Windows.Forms.GroupBox();
            this.lagrangeStartButton = new System.Windows.Forms.Button();
            this.lagrangeTime = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lagrangeResult = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.precisionBox)).BeginInit();
            this.taylorBox.SuspendLayout();
            this.simpsonBox.SuspendLayout();
            this.rombergBox.SuspendLayout();
            this.lagrangeBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "X=";
            // 
            // xBox
            // 
            this.xBox.Location = new System.Drawing.Point(107, 20);
            this.xBox.Name = "xBox";
            this.xBox.Size = new System.Drawing.Size(100, 21);
            this.xBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "所需精度：";
            // 
            // precisionBox
            // 
            this.precisionBox.Location = new System.Drawing.Point(290, 21);
            this.precisionBox.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.precisionBox.Name = "precisionBox";
            this.precisionBox.Size = new System.Drawing.Size(42, 21);
            this.precisionBox.TabIndex = 3;
            this.precisionBox.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "位";
            // 
            // taylorBox
            // 
            this.taylorBox.Controls.Add(this.taylorStartButton);
            this.taylorBox.Controls.Add(this.taylorTime);
            this.taylorBox.Controls.Add(this.label5);
            this.taylorBox.Controls.Add(this.taylorResult);
            this.taylorBox.Controls.Add(this.label4);
            this.taylorBox.Location = new System.Drawing.Point(38, 59);
            this.taylorBox.Name = "taylorBox";
            this.taylorBox.Size = new System.Drawing.Size(360, 90);
            this.taylorBox.TabIndex = 5;
            this.taylorBox.TabStop = false;
            this.taylorBox.Text = "Taylor展开求解";
            // 
            // taylorStartButton
            // 
            this.taylorStartButton.Location = new System.Drawing.Point(145, 61);
            this.taylorStartButton.Name = "taylorStartButton";
            this.taylorStartButton.Size = new System.Drawing.Size(75, 23);
            this.taylorStartButton.TabIndex = 10;
            this.taylorStartButton.Text = "开始计算";
            this.taylorStartButton.UseVisualStyleBackColor = true;
            this.taylorStartButton.Click += new System.EventHandler(this.taylorStartButton_Click);
            // 
            // taylorTime
            // 
            this.taylorTime.Location = new System.Drawing.Point(79, 39);
            this.taylorTime.Name = "taylorTime";
            this.taylorTime.Size = new System.Drawing.Size(260, 21);
            this.taylorTime.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "计算耗时：";
            // 
            // taylorResult
            // 
            this.taylorResult.Location = new System.Drawing.Point(79, 18);
            this.taylorResult.Name = "taylorResult";
            this.taylorResult.Size = new System.Drawing.Size(260, 21);
            this.taylorResult.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "计算结果：";
            // 
            // simpsonBox
            // 
            this.simpsonBox.Controls.Add(this.simpsonStartButton);
            this.simpsonBox.Controls.Add(this.simpsonTime);
            this.simpsonBox.Controls.Add(this.label6);
            this.simpsonBox.Controls.Add(this.simpsonResult);
            this.simpsonBox.Controls.Add(this.label7);
            this.simpsonBox.Location = new System.Drawing.Point(38, 157);
            this.simpsonBox.Name = "simpsonBox";
            this.simpsonBox.Size = new System.Drawing.Size(360, 90);
            this.simpsonBox.TabIndex = 6;
            this.simpsonBox.TabStop = false;
            this.simpsonBox.Text = "数值积分(复化辛普生公式)求解";
            // 
            // simpsonStartButton
            // 
            this.simpsonStartButton.Location = new System.Drawing.Point(145, 61);
            this.simpsonStartButton.Name = "simpsonStartButton";
            this.simpsonStartButton.Size = new System.Drawing.Size(75, 23);
            this.simpsonStartButton.TabIndex = 11;
            this.simpsonStartButton.Text = "开始计算";
            this.simpsonStartButton.UseVisualStyleBackColor = true;
            this.simpsonStartButton.Click += new System.EventHandler(this.simpsonStartButton_Click);
            // 
            // simpsonTime
            // 
            this.simpsonTime.Location = new System.Drawing.Point(79, 39);
            this.simpsonTime.Name = "simpsonTime";
            this.simpsonTime.Size = new System.Drawing.Size(260, 21);
            this.simpsonTime.TabIndex = 7;
            this.simpsonTime.Text = "该方法所需时间可能将超过1分钟。";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "计算耗时：";
            // 
            // simpsonResult
            // 
            this.simpsonResult.Location = new System.Drawing.Point(79, 18);
            this.simpsonResult.Name = "simpsonResult";
            this.simpsonResult.Size = new System.Drawing.Size(260, 21);
            this.simpsonResult.TabIndex = 6;
            this.simpsonResult.Text = "注意：当所需精度为21位或更高时，";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "计算结果：";
            // 
            // rombergBox
            // 
            this.rombergBox.Controls.Add(this.rombergStartButton);
            this.rombergBox.Controls.Add(this.rombergTime);
            this.rombergBox.Controls.Add(this.label8);
            this.rombergBox.Controls.Add(this.rombergResult);
            this.rombergBox.Controls.Add(this.label9);
            this.rombergBox.Location = new System.Drawing.Point(38, 257);
            this.rombergBox.Name = "rombergBox";
            this.rombergBox.Size = new System.Drawing.Size(360, 90);
            this.rombergBox.TabIndex = 7;
            this.rombergBox.TabStop = false;
            this.rombergBox.Text = "数值积分(龙贝格算法)求解";
            // 
            // rombergStartButton
            // 
            this.rombergStartButton.Location = new System.Drawing.Point(145, 61);
            this.rombergStartButton.Name = "rombergStartButton";
            this.rombergStartButton.Size = new System.Drawing.Size(75, 23);
            this.rombergStartButton.TabIndex = 12;
            this.rombergStartButton.Text = "开始计算";
            this.rombergStartButton.UseVisualStyleBackColor = true;
            this.rombergStartButton.Click += new System.EventHandler(this.rombergStartButton_Click);
            // 
            // rombergTime
            // 
            this.rombergTime.Location = new System.Drawing.Point(79, 39);
            this.rombergTime.Name = "rombergTime";
            this.rombergTime.Size = new System.Drawing.Size(260, 21);
            this.rombergTime.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "计算耗时：";
            // 
            // rombergResult
            // 
            this.rombergResult.Location = new System.Drawing.Point(79, 18);
            this.rombergResult.Name = "rombergResult";
            this.rombergResult.Size = new System.Drawing.Size(260, 21);
            this.rombergResult.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "计算结果：";
            // 
            // lagrangeBox
            // 
            this.lagrangeBox.Controls.Add(this.lagrangeStartButton);
            this.lagrangeBox.Controls.Add(this.lagrangeTime);
            this.lagrangeBox.Controls.Add(this.label10);
            this.lagrangeBox.Controls.Add(this.lagrangeResult);
            this.lagrangeBox.Controls.Add(this.label11);
            this.lagrangeBox.Location = new System.Drawing.Point(38, 356);
            this.lagrangeBox.Name = "lagrangeBox";
            this.lagrangeBox.Size = new System.Drawing.Size(360, 90);
            this.lagrangeBox.TabIndex = 8;
            this.lagrangeBox.TabStop = false;
            this.lagrangeBox.Text = "拉格朗日插值多项式逼近求解";
            // 
            // lagrangeStartButton
            // 
            this.lagrangeStartButton.Location = new System.Drawing.Point(145, 61);
            this.lagrangeStartButton.Name = "lagrangeStartButton";
            this.lagrangeStartButton.Size = new System.Drawing.Size(75, 23);
            this.lagrangeStartButton.TabIndex = 13;
            this.lagrangeStartButton.Text = "开始计算";
            this.lagrangeStartButton.UseVisualStyleBackColor = true;
            this.lagrangeStartButton.Click += new System.EventHandler(this.lagrangeStartButton_Click);
            // 
            // lagrangeTime
            // 
            this.lagrangeTime.Location = new System.Drawing.Point(79, 39);
            this.lagrangeTime.Name = "lagrangeTime";
            this.lagrangeTime.Size = new System.Drawing.Size(260, 21);
            this.lagrangeTime.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "计算耗时：";
            // 
            // lagrangeResult
            // 
            this.lagrangeResult.Location = new System.Drawing.Point(79, 18);
            this.lagrangeResult.Name = "lagrangeResult";
            this.lagrangeResult.Size = new System.Drawing.Size(260, 21);
            this.lagrangeResult.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "计算结果：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 462);
            this.Controls.Add(this.lagrangeBox);
            this.Controls.Add(this.rombergBox);
            this.Controls.Add(this.simpsonBox);
            this.Controls.Add(this.taylorBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.precisionBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.xBox);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(450, 500);
            this.MinimumSize = new System.Drawing.Size(450, 500);
            this.Name = "Form1";
            this.Text = "求取LnX";
            ((System.ComponentModel.ISupportInitialize)(this.precisionBox)).EndInit();
            this.taylorBox.ResumeLayout(false);
            this.taylorBox.PerformLayout();
            this.simpsonBox.ResumeLayout(false);
            this.simpsonBox.PerformLayout();
            this.rombergBox.ResumeLayout(false);
            this.rombergBox.PerformLayout();
            this.lagrangeBox.ResumeLayout(false);
            this.lagrangeBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox xBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown precisionBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox taylorBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox taylorTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox taylorResult;
        private System.Windows.Forms.GroupBox simpsonBox;
        private System.Windows.Forms.TextBox simpsonTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox simpsonResult;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox rombergBox;
        private System.Windows.Forms.TextBox rombergTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox rombergResult;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox lagrangeBox;
        private System.Windows.Forms.TextBox lagrangeTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox lagrangeResult;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button taylorStartButton;
        private System.Windows.Forms.Button simpsonStartButton;
        private System.Windows.Forms.Button rombergStartButton;
        private System.Windows.Forms.Button lagrangeStartButton;
    }
}

