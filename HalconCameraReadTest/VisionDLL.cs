using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace HalconCameraReadTest
{
    class VisionDLL
    {
        /// <summary>
        ///   C++算法库DLL接口声明
        /// </summary>
        private class visionAlgorithm
        {
            // DLL 测试
            [DllImport("ImageFunc.dll", EntryPoint = "DLLTest", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
            public static extern void DLLTest();

            // 图像处理彩色图
            [DllImport("ImageFunc.dll", EntryPoint = "ImageProcessRGB", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ImageProcessRGB(IntPtr srcImg, int width, int height, IntPtr outImg);

            // 图像处理灰度图
            [DllImport("ImageFunc.dll", EntryPoint = "ImageProcessGray", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ImageProcessGray(IntPtr srcImg, int width, int height, IntPtr outImg);
        }


        public void Test()
        {
            visionAlgorithm.DLLTest();
        }

        public void ImageProcessRGB(IntPtr srcImg, int width, int height, IntPtr outImg)
        {
            visionAlgorithm.ImageProcessRGB(srcImg, width, height, outImg);
        }


        public void ImageProcessGray(IntPtr srcImg, int width, int height, IntPtr outImg)
        {
            visionAlgorithm.ImageProcessGray(srcImg, width, height, outImg);
        }

    }
}
