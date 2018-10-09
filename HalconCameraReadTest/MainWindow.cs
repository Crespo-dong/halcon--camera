using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HalconCameraReadTest
{
    public partial class MainWindow : Form
    {
        // 实例化HDevelopExport类
        HDevelopExport HD = new HDevelopExport();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            HD.InitCamera(hWindowControl.HalconWindow);
            timer.Enabled = true; // 开始定时拍照、显示
        }

        // 定时器触发显示视频
        private void timer_Tick(object sender, EventArgs e)
        {
            Image img;
            if (true)
            {
                HD.GrabFrame(out img);          // 获取摄像头数据  
            }
            else
            {
                HD.GrabFrameAndDisplay();     // 用Halcon窗体显示
            }


            // 处理数据
            pictureBox.Image = img;         // 此处 用PictureBox显示

        }

        // 关闭相机
        private void buttonClose_Click(object sender, EventArgs e)
        {
            timer.Enabled = false; // 停止拍照

            HD.closeCamera();
        }
    }
}
