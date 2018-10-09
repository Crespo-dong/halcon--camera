using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace HalconCameraReadTest
{
    class Utils
    {
        /// <summary>
        /// Halcon 图像 转换为 .NET Bitmap
        /// 会报错，不知咋回事
        /// </summary>
        /// <param name="halconImage"></param>
        /// <param name="isColor"></param>
        /// <returns></returns>
        /// refer link： https://github.com/Joncash/HanboAOMClassLibrary/blob/master/Hanbo.Helper/ImageConventer.cs
        public static Bitmap ConvertHalconImageToBitmap(HObject halconImage, bool isColor)
        {
            // 判空
            if (halconImage == null)
            {
                throw new ArgumentNullException("halconImage");
            }

            // 图像信息和三色通道地址
            HTuple hRed = null;
            HTuple hGreen = null;
            HTuple hBlue = null;
            HTuple type;
            HTuple width;
            HTuple height;

            // 根据是否为彩图，确认bitmap格式
            var pixelFormat = (isColor) ? PixelFormat.Format32bppRgb : PixelFormat.Format8bppIndexed;

            // 彩图则指定三色通道的指针，否则将hblue作为灰度图像的指针
            if (isColor)
                HOperatorSet.GetImagePointer3(halconImage, out hRed, out hGreen, out hBlue, out type, out width, out height);
            else
                HOperatorSet.GetImagePointer1(halconImage, out hBlue, out type, out width, out height);

            // 定义新bitmap
            Bitmap bitmap = new Bitmap((Int32)width, (Int32)height, pixelFormat);

            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            

            int bytes = Math.Abs(bmpData.Stride) * bitmap.Height;   // 图像byte序列长度
            byte[] rgbValues = new byte[bytes]; // 图像byte序列

            // 根据Htuple指针获取Intptr指针
            IntPtr ptrB = new IntPtr(hBlue);
            IntPtr ptrG = IntPtr.Zero;
            IntPtr ptrR = IntPtr.Zero;
            if (hGreen != null) ptrG = new IntPtr(hGreen);
            if (hRed != null) ptrR = new IntPtr(hRed);
            int channels = (isColor) ? 3 : 1;   // 确认通道

            // Stride
            // 根据步长获取三色数据，拷贝到图像字节数组中
            int strideTotal = Math.Abs(bmpData.Stride);
            int unmapByes = strideTotal - ((int)width * channels);

            for (int i = 0, offset = 0; i < bytes; i += channels, offset++)
            {
                if ((offset + 1) % width == 0)
                {
                    i += unmapByes;
                }

                rgbValues[i] = Marshal.ReadByte(ptrB, offset);
                if (isColor)
                {
                    rgbValues[i + 1] = Marshal.ReadByte(ptrG, offset);
                    rgbValues[i + 2] = Marshal.ReadByte(ptrR, offset);
                }

            }

            // 将字节数据拷贝到bitmap中
            Marshal.Copy(rgbValues, 0, bmpData.Scan0, bytes);
            bitmap.UnlockBits(bmpData);
            return bitmap;
        }



        /// <summary>
		/// 轉換  HalconImage to Byte Array
		/// </summary>
		/// <param name="halconImage"></param>
		/// <returns></returns>
		public static byte[] ConvertBitmapToByteArray(Bitmap bitmap)
        {
            byte[] result = null;
            if (bitmap != null)
            {
                MemoryStream stream = new MemoryStream();
                bitmap.Save(stream, ImageFormat.Tiff);
                result = stream.ToArray();
            }
            return result;
        }

    }
}
