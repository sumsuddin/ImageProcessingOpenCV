# Communication between C++ OpenCv and C# bitmap

OpenCv is a great tool for image processing. Often times it's required to processe images using OpenCv while creating the user interface on c#. As C# does not support natively using OpenCv, we require using C++ dlls to make use of the opencv library for C#.

This repository is just a demo of showing how to accomplish that in an elegant manner.

I have seen some complecated [ways](https://stackoverflow.com/a/27467002/5330223) to do this, by extracting every pixels and then sending them as a byte array.

This sample shows a better way by using cv::imdecode() from c++ end and bitmap Save() method from c# end.

The idea is while saving an image to disk, images are compressed and then save as `jpg`, `bmp`, `png` or any other format. In C# instead of a file stream or writer use a memory stream (which is essentially a byte array of the file). Get a byte array from the stream and pass is to C++ dll. In C++ end this byte array can be converted to a `cv:Mat` by using `cv:imdecode()`.

# Code example

## C# ([Details](https://github.com/sumsuddin/ImageProcessingOpenCV/blob/master/ImageProcessingOpenCV/InterfacingNative/NativeCommunication.cs))
```c#
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
```

## C++ ([Details](https://github.com/sumsuddin/ImageProcessingOpenCV/blob/master/AlgorithmsCpp/AlgorithmsCpp.cpp)])
```c++
DllExport void convertToGray(unsigned char* data, int dataLen, ImageInfo & imInfo)
{
	vector<unsigned char> inputImageBytes(data, data + dataLen);
	Mat image = imdecode(inputImageBytes, CV_LOAD_IMAGE_COLOR);
	Mat processed;
	cvtColor(image, processed, CV_BGR2GRAY);
	vector<unsigned char> bytes;
	imencode(".png", processed, bytes);

	imInfo.size = bytes.size();
	imInfo.data = (unsigned char *)calloc(imInfo.size, sizeof(unsigned char));
	std::copy(bytes.begin(), bytes.end(), imInfo.data);
}
```

# Usage
    1. Select x64 or x86 on both project (make sure same).
    2. Select Releas configuration.
    3. Configure the OpenCv directories in `AlgorithmsCpp` project
    4. Build
