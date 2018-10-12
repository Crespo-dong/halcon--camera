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
        HDevelopExport HD_RGB = new HDevelopExport();
        HDevelopExport HD_Gray= new HDevelopExport();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            /// "WebCam"
            /// "IndusCamRGB"
            /// "IndusCamGray"
            /// "LogiTechCam"
            HD_RGB.InitCamera(hWindowControlRGB.HalconWindow, "WebCam");
            HD_Gray.InitCamera(hWindowControlGray.HalconWindow, "LogiTechCam");

            timer.Enabled = true; // 开始定时拍照、显示
        }

        // 定时器触发显示视频
        private void timer_Tick(object sender, EventArgs e)
        {
            Bitmap SrcImgRGB;
            Bitmap SrcImgGray;

            if (true)  // 修改true/false，执行不同的语句
            {
                // 获取摄像头数据  
                HD_RGB.GrabFrame(out SrcImgRGB);          
                HD_Gray.GrabFrame(out SrcImgGray);
            }
            else
            {
                // 用Halcon窗体显示
                HD_RGB.GrabFrameAndDisplay();     
                HD_Gray.GrabFrameAndDisplay();
                return; // 不捕获图像，显示在Halcon窗体然后返回即可
            }



            // 处理数据
            //pictureBoxRGB.Image = SrcImgRGB;         // 此处 用PictureBox显示
            //pictureBoxGray.Image = SrcImgGray;

            watch.Reset();
            watch.Start();

            // 此处进行交互，目前这种方式可能会卡C#程序
            // TODO:注意灰度图交互时的数据长度

            // 将Bitmap锁定到系统内存中
            BitmapData bmpDataRGB = SrcImgRGB.LockBits(new Rectangle(0, 0, SrcImgRGB.Width, SrcImgRGB.Height), ImageLockMode.ReadWrite, SrcImgRGB.PixelFormat);
            // 创建新图用以接收返回
            Bitmap outIMGRGB = new Bitmap(SrcImgRGB.Width, SrcImgRGB.Height);
            // 锁定返回图像内存
            BitmapData bmpDataOutRGB = outIMGRGB.LockBits(new Rectangle(0, 0, outIMGRGB.Width, outIMGRGB.Height), ImageLockMode.ReadWrite, outIMGRGB.PixelFormat);
            // 此处调用DLL函数处理图像
            vision.ImageProcessRGB(bmpDataRGB.Scan0, SrcImgRGB.Width, SrcImgRGB.Height, bmpDataOutRGB.Scan0);
            // 从系统内存解锁此bitmap
            SrcImgRGB.UnlockBits(bmpDataRGB);
            outIMGRGB.UnlockBits(bmpDataOutRGB);


            // 将Bitmap锁定到系统内存中
            BitmapData bmpDataGray = SrcImgGray.LockBits(new Rectangle(0, 0, SrcImgGray.Width, SrcImgGray.Height), ImageLockMode.ReadWrite, SrcImgGray.PixelFormat);
            // 创建新图用以接收返回
            Bitmap outIMGGray = new Bitmap(SrcImgGray.Width, SrcImgGray.Height);
            // 锁定返回图像内存
            BitmapData bmpDataOutGray = outIMGGray.LockBits(new Rectangle(0, 0, outIMGGray.Width, outIMGGray.Height), ImageLockMode.ReadWrite, outIMGGray.PixelFormat);
            // 此处调用DLL函数处理图像
            vision.ImageProcessGray(bmpDataGray.Scan0, SrcImgGray.Width, SrcImgGray.Height, bmpDataOutGray.Scan0);
            // 从系统内存解锁此bitmap
            SrcImgGray.UnlockBits(bmpDataGray);
            outIMGGray.UnlockBits(bmpDataOutGray);

            pictureBoxRGB.Image = outIMGRGB;
            pictureBoxGray.Image = outIMGGray;

            //// 主动清理内存
            GC.Collect();   // 清理内存



            watch.Stop();
            Console.WriteLine("运行时间：" + watch.Elapsed);
        }

        // 关闭相机
        private void buttonClose_Click(object sender, EventArgs e)
        {
            timer.Enabled = false; // 停止拍照

            HD_RGB.closeCamera();

            HD_Gray.closeCamera();
        }
    }
}
