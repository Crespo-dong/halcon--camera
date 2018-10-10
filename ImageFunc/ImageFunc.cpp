// ImageFunc.cpp : ���� DLL Ӧ�ó���ĵ���������
//

//���嵼��DLL��д
#define DllExport extern "C" __declspec(dllexport)


#include "stdafx.h"

#include <iostream>
using namespace std;

#include <opencv2/opencv.hpp>
using namespace cv;

// DLL����
DllExport void DLLTest()
{
	cout << "Hello,DLL" << endl;
}


// ͼ����
DllExport void ImageProcess(unsigned char* Srcimg, int width, int height, unsigned char* outImg)
{
	Mat frame(Size(width, height), CV_8UC4, Srcimg);

	Mat frameDest;
	cvtColor(frame, frameDest, CV_RGBA2BGRA);
	//cvtColor(frame, frameDest, CV_RGBA2GRAY);
	//frameDest.convertTo(frameDest, CV_16UC1,  65535.0 / 255);

	memcpy((void*)outImg, (void*)frameDest.data, frameDest.cols * frameDest.rows * frameDest.channels());

}