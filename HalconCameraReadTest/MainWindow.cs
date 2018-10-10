using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HalconCameraReadTest
{
    public partial class MainWindow : Form
    {
        Stopwatch watch = new Stopwatch();

        VisionDLL vision = new VisionDLL();

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
            Bitmap SrcImg;
            if (true)
            {
                HD.GrabFrame(out SrcImg);          // 获取摄像头数据  
            }
            else
            {
                HD.GrabFrameAndDisplay();     // 用Halcon窗体显示
            }



            // 处理数据
            pictureBox.Image = SrcImg;         // 此处 用PictureBox显示

            watch.Reset();
            watch.Start();

            // 此处进行交互，目前这种方式可能会卡C#程序

            // 将Bitmap锁定到系统内存中
            
            BitmapData bmpData = SrcImg.LockBits(new Rectangle(0, 0, SrcImg.Width, SrcImg.Height), ImageLockMode.ReadWrite, SrcImg.PixelFormat);

            // 创建新图用以接收返回
            Bitmap outIMG = new Bitmap(SrcImg.Width, SrcImg.Height,PixelFormat.Format16bppGrayScale);
            // 锁定返回图像内存
            BitmapData bmpDataOut = outIMG.LockBits(new Rectangle(0, 0, outIMG.Width, outIMG.Height), ImageLockMode.ReadWrite, outIMG.PixelFormat);

            // 此处调用DLL函数处理图像
            vision.ImageProcess(bmpData.Scan0, SrcImg.Width, SrcImg.Height, bmpDataOut.Scan0);

           
            // 从系统内存解锁此bitmap
            SrcImg.UnlockBits(bmpData);
            outIMG.UnlockBits(bmpDataOut);

            pictureBoxResult.Image = outIMG;

            // 主动清理内存
            GC.Collect();   // 清理内存



            watch.Stop();
            Console.WriteLine("运行时间：" + watch.Elapsed);
        }

        // 关闭相机
        private void buttonClose_Click(object sender, EventArgs e)
        {
            timer.Enabled = false; // 停止拍照

            HD.closeCamera();
        }
    }
}
