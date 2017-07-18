using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingOpenCV.InterfacingNative
{
    public struct ImageInfo
    {
        public IntPtr data;
        public int size;
    }
    public class NativeCommunication
    {
        class AlgorithmCpp
        {
            [DllImport("AlgorithmsCpp.dll", EntryPoint = "convertToGray", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
            public static extern void convertToGray(byte[] data, int dataLen, ref ImageInfo imTemplate);

            [DllImport("AlgorithmsCpp.dll", EntryPoint = "ReleaseMemoryFromC", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
            public static extern void ReleaseMemoryFromC(IntPtr buf);
        }

        public Image ConvertImage(Image image)
        {
            MemoryStream convertedImageMemoryStream;
            using (MemoryStream sourceImageStream = new MemoryStream())
            {
                image.Save(sourceImageStream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] sourceImagePixels = sourceImageStream.ToArray();
                ImageInfo imInfo = new ImageInfo();
                AlgorithmCpp.convertToGray(sourceImagePixels, sourceImagePixels.Count(), ref imInfo);

                byte[] imagePixels = new byte[imInfo.size];
                Marshal.Copy(imInfo.data, imagePixels, 0, imInfo.size);
                if (imInfo.data != IntPtr.Zero)
                    AlgorithmCpp.ReleaseMemoryFromC(imInfo.data);
                convertedImageMemoryStream = new MemoryStream(imagePixels);
            }
            Image processed = new Bitmap(convertedImageMemoryStream);
            return processed;
        }
    }
}
