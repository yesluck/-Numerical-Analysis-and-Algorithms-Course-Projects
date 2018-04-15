namespace Image_Warping
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
            this.selectButton = new System.Windows.Forms.Button();
            this.disposeButton = new System.Windows.Forms.Button();
            this.warpBox = new System.Windows.Forms.GroupBox();
            this.tpsButton = new System.Windows.Forms.RadioButton();
            this.distortButton = new System.Windows.Forms.RadioButton();
            this.rotateButton = new System.Windows.Forms.RadioButton();
            this.interpositionBox = new System.Windows.Forms.GroupBox();
            this.bicubicButton = new System.Windows.Forms.RadioButton();
            this.nearestNeighborButton = new System.Windows.Forms.RadioButton();
            this.bilinearButton = new System.Windows.Forms.RadioButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.rotateParameterBox = new System.Windows.Forms.GroupBox();
            this.rotateAngleLabel = new System.Windows.Forms.Label();
            this.rotateAngleBox = new System.Windows.Forms.NumericUpDown();
            this.maxRLabel = new System.Windows.Forms.Label();
            this.maxRBox = new System.Windows.Forms.NumericUpDown();
            this.originPicLabel = new System.Windows.Forms.Label();
            this.transedPicLabel = new System.Windows.Forms.Label();
            this.LINZikun = new System.Windows.Forms.Label();
            this.picPropertyLabel = new System.Windows.Forms.Label();
            this.picCenterLabel = new System.Windows.Forms.Label();
            this.distortParameterBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.distortBox = new System.Windows.Forms.NumericUpDown();
            this.concaveButton = new System.Windows.Forms.RadioButton();
            this.convexButton = new System.Windows.Forms.RadioButton();
            this.tpsParameterBox = new System.Windows.Forms.GroupBox();
            this.clearTPS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tpsPointLabel = new System.Windows.Forms.Label();
            this.tpsPointBox = new System.Windows.Forms.NumericUpDown();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveButton = new System.Windows.Forms.Button();
            this.warpBox.SuspendLayout();
            this.interpositionBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.rotateParameterBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rotateAngleBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRBox)).BeginInit();
            this.distortParameterBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distortBox)).BeginInit();
            this.tpsParameterBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tpsPointBox)).BeginInit();
            this.SuspendLayout();
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(52, 20);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(75, 23);
            this.selectButton.TabIndex = 0;
            this.selectButton.Text = "选择图片";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // disposeButton
            // 
            this.disposeButton.Location = new System.Drawing.Point(52, 416);
            this.disposeButton.Name = "disposeButton";
            this.disposeButton.Size = new System.Drawing.Size(75, 23);
            this.disposeButton.TabIndex = 1;
            this.disposeButton.Text = "处理图片";
            this.disposeButton.UseVisualStyleBackColor = true;
            this.disposeButton.Click += new System.EventHandler(this.disposeButton_Click);
            // 
            // warpBox
            // 
            this.warpBox.Controls.Add(this.tpsButton);
            this.warpBox.Controls.Add(this.distortButton);
            this.warpBox.Controls.Add(this.rotateButton);
            this.warpBox.Location = new System.Drawing.Point(29, 63);
            this.warpBox.Name = "warpBox";
            this.warpBox.Size = new System.Drawing.Size(125, 90);
            this.warpBox.TabIndex = 2;
            this.warpBox.TabStop = false;
            this.warpBox.Text = "扭曲变形方式";
            // 
            // tpsButton
            // 
            this.tpsButton.AutoSize = true;
            this.tpsButton.Location = new System.Drawing.Point(19, 64);
            this.tpsButton.Name = "tpsButton";
            this.tpsButton.Size = new System.Drawing.Size(89, 16);
            this.tpsButton.TabIndex = 2;
            this.tpsButton.Text = "TPS网格变形";
            this.tpsButton.UseVisualStyleBackColor = true;
            this.tpsButton.CheckedChanged += new System.EventHandler(this.tpsButton_CheckedChanged);
            // 
            // distortButton
            // 
            this.distortButton.AutoSize = true;
            this.distortButton.Location = new System.Drawing.Point(19, 42);
            this.distortButton.Name = "distortButton";
            this.distortButton.Size = new System.Drawing.Size(71, 16);
            this.distortButton.TabIndex = 1;
            this.distortButton.Text = "图像畸变";
            this.distortButton.UseVisualStyleBackColor = true;
            this.distortButton.CheckedChanged += new System.EventHandler(this.distortButton_CheckedChanged);
            // 
            // rotateButton
            // 
            this.rotateButton.AutoSize = true;
            this.rotateButton.Checked = true;
            this.rotateButton.Location = new System.Drawing.Point(19, 20);
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.Size = new System.Drawing.Size(71, 16);
            this.rotateButton.TabIndex = 0;
            this.rotateButton.TabStop = true;
            this.rotateButton.Text = "旋转扭曲";
            this.rotateButton.UseVisualStyleBackColor = true;
            this.rotateButton.CheckedChanged += new System.EventHandler(this.rotateButton_CheckedChanged);
            // 
            // interpositionBox
            // 
            this.interpositionBox.Controls.Add(this.bicubicButton);
            this.interpositionBox.Controls.Add(this.nearestNeighborButton);
            this.interpositionBox.Controls.Add(this.bilinearButton);
            this.interpositionBox.Location = new System.Drawing.Point(29, 314);
            this.interpositionBox.Name = "interpositionBox";
            this.interpositionBox.Size = new System.Drawing.Size(125, 90);
            this.interpositionBox.TabIndex = 3;
            this.interpositionBox.TabStop = false;
            this.interpositionBox.Text = "插值方法";
            // 
            // bicubicButton
            // 
            this.bicubicButton.AutoSize = true;
            this.bicubicButton.Location = new System.Drawing.Point(19, 65);
            this.bicubicButton.Name = "bicubicButton";
            this.bicubicButton.Size = new System.Drawing.Size(83, 16);
            this.bicubicButton.TabIndex = 6;
            this.bicubicButton.Text = "双三次插值";
            this.bicubicButton.UseVisualStyleBackColor = true;
            // 
            // nearestNeighborButton
            // 
            this.nearestNeighborButton.AutoSize = true;
            this.nearestNeighborButton.Checked = true;
            this.nearestNeighborButton.Location = new System.Drawing.Point(19, 21);
            this.nearestNeighborButton.Name = "nearestNeighborButton";
            this.nearestNeighborButton.Size = new System.Drawing.Size(83, 16);
            this.nearestNeighborButton.TabIndex = 4;
            this.nearestNeighborButton.TabStop = true;
            this.nearestNeighborButton.Text = "最近邻插值";
            this.nearestNeighborButton.UseVisualStyleBackColor = true;
            // 
            // bilinearButton
            // 
            this.bilinearButton.AutoSize = true;
            this.bilinearButton.Location = new System.Drawing.Point(19, 43);
            this.bilinearButton.Name = "bilinearButton";
            this.bilinearButton.Size = new System.Drawing.Size(83, 16);
            this.bilinearButton.TabIndex = 5;
            this.bilinearButton.Text = "双线性插值";
            this.bilinearButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(182, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(375, 375);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(585, 29);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(375, 375);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // rotateParameterBox
            // 
            this.rotateParameterBox.Controls.Add(this.rotateAngleLabel);
            this.rotateParameterBox.Controls.Add(this.rotateAngleBox);
            this.rotateParameterBox.Controls.Add(this.maxRLabel);
            this.rotateParameterBox.Controls.Add(this.maxRBox);
            this.rotateParameterBox.Location = new System.Drawing.Point(29, 168);
            this.rotateParameterBox.Name = "rotateParameterBox";
            this.rotateParameterBox.Size = new System.Drawing.Size(125, 131);
            this.rotateParameterBox.TabIndex = 3;
            this.rotateParameterBox.TabStop = false;
            this.rotateParameterBox.Text = "旋转扭曲参数";
            // 
            // rotateAngleLabel
            // 
            this.rotateAngleLabel.AutoSize = true;
            this.rotateAngleLabel.Location = new System.Drawing.Point(6, 78);
            this.rotateAngleLabel.Name = "rotateAngleLabel";
            this.rotateAngleLabel.Size = new System.Drawing.Size(53, 12);
            this.rotateAngleLabel.TabIndex = 3;
            this.rotateAngleLabel.Text = "旋转角度";
            // 
            // rotateAngleBox
            // 
            this.rotateAngleBox.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.rotateAngleBox.Location = new System.Drawing.Point(24, 98);
            this.rotateAngleBox.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.rotateAngleBox.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.rotateAngleBox.Name = "rotateAngleBox";
            this.rotateAngleBox.Size = new System.Drawing.Size(84, 21);
            this.rotateAngleBox.TabIndex = 2;
            // 
            // maxRLabel
            // 
            this.maxRLabel.AutoSize = true;
            this.maxRLabel.Location = new System.Drawing.Point(6, 28);
            this.maxRLabel.Name = "maxRLabel";
            this.maxRLabel.Size = new System.Drawing.Size(77, 12);
            this.maxRLabel.TabIndex = 1;
            this.maxRLabel.Text = "最大旋转半径";
            // 
            // maxRBox
            // 
            this.maxRBox.Location = new System.Drawing.Point(24, 48);
            this.maxRBox.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.maxRBox.Name = "maxRBox";
            this.maxRBox.Size = new System.Drawing.Size(84, 21);
            this.maxRBox.TabIndex = 0;
            // 
            // originPicLabel
            // 
            this.originPicLabel.AutoSize = true;
            this.originPicLabel.Location = new System.Drawing.Point(343, 421);
            this.originPicLabel.Name = "originPicLabel";
            this.originPicLabel.Size = new System.Drawing.Size(53, 12);
            this.originPicLabel.TabIndex = 6;
            this.originPicLabel.Text = "原始图像";
            // 
            // transedPicLabel
            // 
            this.transedPicLabel.AutoSize = true;
            this.transedPicLabel.Location = new System.Drawing.Point(740, 421);
            this.transedPicLabel.Name = "transedPicLabel";
            this.transedPicLabel.Size = new System.Drawing.Size(65, 12);
            this.transedPicLabel.TabIndex = 7;
            this.transedPicLabel.Text = "变换后图像";
            // 
            // LINZikun
            // 
            this.LINZikun.AutoSize = true;
            this.LINZikun.Location = new System.Drawing.Point(835, 461);
            this.LINZikun.Name = "LINZikun";
            this.LINZikun.Size = new System.Drawing.Size(137, 12);
            this.LINZikun.TabIndex = 8;
            this.LINZikun.Text = "自45 林子坤 2014011541";
            // 
            // picPropertyLabel
            // 
            this.picPropertyLabel.AutoSize = true;
            this.picPropertyLabel.Location = new System.Drawing.Point(274, 441);
            this.picPropertyLabel.Name = "picPropertyLabel";
            this.picPropertyLabel.Size = new System.Drawing.Size(0, 12);
            this.picPropertyLabel.TabIndex = 9;
            this.picPropertyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCenterLabel
            // 
            this.picCenterLabel.AutoSize = true;
            this.picCenterLabel.Location = new System.Drawing.Point(274, 461);
            this.picCenterLabel.Name = "picCenterLabel";
            this.picCenterLabel.Size = new System.Drawing.Size(0, 12);
            this.picCenterLabel.TabIndex = 10;
            this.picCenterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // distortParameterBox
            // 
            this.distortParameterBox.Controls.Add(this.label2);
            this.distortParameterBox.Controls.Add(this.distortBox);
            this.distortParameterBox.Controls.Add(this.concaveButton);
            this.distortParameterBox.Controls.Add(this.convexButton);
            this.distortParameterBox.Location = new System.Drawing.Point(197, 168);
            this.distortParameterBox.Name = "distortParameterBox";
            this.distortParameterBox.Size = new System.Drawing.Size(125, 131);
            this.distortParameterBox.TabIndex = 4;
            this.distortParameterBox.TabStop = false;
            this.distortParameterBox.Text = "图像畸变属性";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "畸变程度";
            // 
            // distortBox
            // 
            this.distortBox.Location = new System.Drawing.Point(24, 98);
            this.distortBox.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.distortBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.distortBox.Name = "distortBox";
            this.distortBox.Size = new System.Drawing.Size(84, 21);
            this.distortBox.TabIndex = 4;
            this.distortBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // concaveButton
            // 
            this.concaveButton.AutoSize = true;
            this.concaveButton.Location = new System.Drawing.Point(19, 48);
            this.concaveButton.Name = "concaveButton";
            this.concaveButton.Size = new System.Drawing.Size(71, 16);
            this.concaveButton.TabIndex = 1;
            this.concaveButton.Text = "中心内凹";
            this.concaveButton.UseVisualStyleBackColor = true;
            // 
            // convexButton
            // 
            this.convexButton.AutoSize = true;
            this.convexButton.Checked = true;
            this.convexButton.Location = new System.Drawing.Point(19, 24);
            this.convexButton.Name = "convexButton";
            this.convexButton.Size = new System.Drawing.Size(71, 16);
            this.convexButton.TabIndex = 0;
            this.convexButton.TabStop = true;
            this.convexButton.Text = "中心外凸";
            this.convexButton.UseVisualStyleBackColor = true;
            // 
            // tpsParameterBox
            // 
            this.tpsParameterBox.Controls.Add(this.clearTPS);
            this.tpsParameterBox.Controls.Add(this.label1);
            this.tpsParameterBox.Controls.Add(this.tpsPointLabel);
            this.tpsParameterBox.Controls.Add(this.tpsPointBox);
            this.tpsParameterBox.Location = new System.Drawing.Point(345, 168);
            this.tpsParameterBox.Name = "tpsParameterBox";
            this.tpsParameterBox.Size = new System.Drawing.Size(125, 131);
            this.tpsParameterBox.TabIndex = 5;
            this.tpsParameterBox.TabStop = false;
            this.tpsParameterBox.Text = "TPS网格变形属性";
            // 
            // clearTPS
            // 
            this.clearTPS.Location = new System.Drawing.Point(23, 102);
            this.clearTPS.Name = "clearTPS";
            this.clearTPS.Size = new System.Drawing.Size(75, 23);
            this.clearTPS.TabIndex = 5;
            this.clearTPS.Text = "清除特征点";
            this.clearTPS.UseVisualStyleBackColor = true;
            this.clearTPS.Click += new System.EventHandler(this.clearTPS_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "提示：请依次选择\r\n各组控制点与目标点";
            // 
            // tpsPointLabel
            // 
            this.tpsPointLabel.AutoSize = true;
            this.tpsPointLabel.Location = new System.Drawing.Point(6, 25);
            this.tpsPointLabel.Name = "tpsPointLabel";
            this.tpsPointLabel.Size = new System.Drawing.Size(65, 12);
            this.tpsPointLabel.TabIndex = 3;
            this.tpsPointLabel.Text = "控制点组数";
            // 
            // tpsPointBox
            // 
            this.tpsPointBox.Location = new System.Drawing.Point(21, 45);
            this.tpsPointBox.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.tpsPointBox.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.tpsPointBox.Name = "tpsPointBox";
            this.tpsPointBox.Size = new System.Drawing.Size(84, 21);
            this.tpsPointBox.TabIndex = 2;
            this.tpsPointBox.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.tpsPointBox.ValueChanged += new System.EventHandler(this.tpsPointBox_ValueChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(52, 450);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "保存图片";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 482);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picCenterLabel);
            this.Controls.Add(this.picPropertyLabel);
            this.Controls.Add(this.LINZikun);
            this.Controls.Add(this.transedPicLabel);
            this.Controls.Add(this.originPicLabel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.interpositionBox);
            this.Controls.Add(this.warpBox);
            this.Controls.Add(this.disposeButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.distortParameterBox);
            this.Controls.Add(this.tpsParameterBox);
            this.Controls.Add(this.rotateParameterBox);
            this.MaximumSize = new System.Drawing.Size(1000, 520);
            this.MinimumSize = new System.Drawing.Size(1000, 520);
            this.Name = "Form1";
            this.Text = "图像扭曲变形";
            this.warpBox.ResumeLayout(false);
            this.warpBox.PerformLayout();
            this.interpositionBox.ResumeLayout(false);
            this.interpositionBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.rotateParameterBox.ResumeLayout(false);
            this.rotateParameterBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rotateAngleBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRBox)).EndInit();
            this.distortParameterBox.ResumeLayout(false);
            this.distortParameterBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distortBox)).EndInit();
            this.tpsParameterBox.ResumeLayout(false);
            this.tpsParameterBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tpsPointBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button disposeButton;
        private System.Windows.Forms.GroupBox warpBox;
        private System.Windows.Forms.RadioButton tpsButton;
        private System.Windows.Forms.RadioButton distortButton;
        private System.Windows.Forms.RadioButton rotateButton;
        private System.Windows.Forms.GroupBox interpositionBox;
        private System.Windows.Forms.RadioButton bicubicButton;
        private System.Windows.Forms.RadioButton nearestNeighborButton;
        private System.Windows.Forms.RadioButton bilinearButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox rotateParameterBox;
        private System.Windows.Forms.Label rotateAngleLabel;
        private System.Windows.Forms.NumericUpDown rotateAngleBox;
        private System.Windows.Forms.Label maxRLabel;
        private System.Windows.Forms.NumericUpDown maxRBox;
        private System.Windows.Forms.Label originPicLabel;
        private System.Windows.Forms.Label transedPicLabel;
        private System.Windows.Forms.Label LINZikun;
        private System.Windows.Forms.Label picPropertyLabel;
        private System.Windows.Forms.Label picCenterLabel;
        private System.Windows.Forms.GroupBox distortParameterBox;
        private System.Windows.Forms.RadioButton concaveButton;
        private System.Windows.Forms.RadioButton convexButton;
        private System.Windows.Forms.GroupBox tpsParameterBox;
        private System.Windows.Forms.Label tpsPointLabel;
        private System.Windows.Forms.NumericUpDown tpsPointBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown distortBox;
        private System.Windows.Forms.Button clearTPS;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button saveButton;
    }
}

