#include "stdafx.h"

#include "opencv2/highgui/highgui.hpp"
#include "opencv2/imgproc/imgproc.hpp"
#include <Windows.h>

using namespace cv;
using namespace std;

#define DllExport extern "C" __declspec(dllexport)

struct ImageInfo
{
	unsigned char *data;
	int size;
};

//release memory
DllExport bool ReleaseMemoryFromC(unsigned char* buf)
{
	if (buf == NULL)
		return false;

	free(buf);
	return true;
}

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
