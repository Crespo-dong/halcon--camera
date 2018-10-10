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

            // 图像处理
            [DllImport("ImageFunc.dll", EntryPoint = "ImageProcess", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ImageProcess(IntPtr srcImg, int width, int height, IntPtr outImg);
        }


        public void Test()
        {
            visionAlgorithm.DLLTest();
        }

        public void ImageProcess(IntPtr srcImg, int width, int height, IntPtr outImg)
        {
            visionAlgorithm.ImageProcess(srcImg, width, height, outImg);
        }

    }
}
