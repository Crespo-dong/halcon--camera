namespace HalconCameraReadTest
{
    partial class MainWindow
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.hWindowControlRGB = new HalconDotNet.HWindowControl();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonClose = new System.Windows.Forms.Button();
            this.pictureBoxRGB = new System.Windows.Forms.PictureBox();
            this.pictureBoxGray = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hWindowControlGray = new HalconDotNet.HWindowControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGray)).BeginInit();
            this.SuspendLayout();
            // 
            // hWindowControlRGB
            // 
            this.hWindowControlRGB.BackColor = System.Drawing.Color.Black;
            this.hWindowControlRGB.BorderColor = System.Drawing.Color.Black;
            this.hWindowControlRGB.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControlRGB.Location = new System.Drawing.Point(12, 128);
            this.hWindowControlRGB.Name = "hWindowControlRGB";
            this.hWindowControlRGB.Size = new System.Drawing.Size(316, 219);
            this.hWindowControlRGB.TabIndex = 0;
            this.hWindowControlRGB.WindowSize = new System.Drawing.Size(316, 219);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(14, 12);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(117, 56);
            this.buttonOpen.TabIndex = 1;
            this.buttonOpen.Text = "打开相机";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // timer
            // 
            this.timer.Interval = 30;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(172, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(114, 56);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "关闭相机";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // pictureBoxRGB
            // 
            this.pictureBoxRGB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxRGB.Location = new System.Drawing.Point(12, 382);
            this.pictureBoxRGB.Name = "pictureBoxRGB";
            this.pictureBoxRGB.Size = new System.Drawing.Size(316, 233);
            this.pictureBoxRGB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRGB.TabIndex = 2;
            this.pictureBoxRGB.TabStop = false;
            // 
            // pictureBoxGray
            // 
            this.pictureBoxGray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxGray.Location = new System.Drawing.Point(438, 382);
            this.pictureBoxGray.Name = "pictureBoxGray";
            this.pictureBoxGray.Size = new System.Drawing.Size(316, 233);
            this.pictureBoxGray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGray.TabIndex = 3;
            this.pictureBoxGray.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Halcon窗体一：彩色";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(436, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Halcon窗体一：灰度";
            // 
            // hWindowControlGray
            // 
            this.hWindowControlGray.BackColor = System.Drawing.Color.Black;
            this.hWindowControlGray.BorderColor = System.Drawing.Color.Black;
            this.hWindowControlGray.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControlGray.Location = new System.Drawing.Point(438, 128);
            this.hWindowControlGray.Name = "hWindowControlGray";
            this.hWindowControlGray.Size = new System.Drawing.Size(316, 219);
            this.hWindowControlGray.TabIndex = 0;
            this.hWindowControlGray.WindowSize = new System.Drawing.Size(316, 219);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "PictureBox窗体一：彩色";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(436, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "PictureBox窗体一：灰度";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 631);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxGray);
            this.Controls.Add(this.pictureBoxRGB);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.hWindowControlGray);
            this.Controls.Add(this.hWindowControlRGB);
            this.Name = "MainWindow";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGray)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HalconDotNet.HWindowControl hWindowControlRGB;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.PictureBox pictureBoxRGB;
        private System.Windows.Forms.PictureBox pictureBoxGray;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private HalconDotNet.HWindowControl hWindowControlGray;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

