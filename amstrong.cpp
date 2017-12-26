#include "opencv2/highgui.hpp""
#include <iostream>
#include <stdio.h>
using namespace std;
using namespace cv;

int main(void) {
	VideoCapture capture;
	Mat frame;

	capture.open(0);
	if (!capture.isOpened()) {
		printf("Error opening video camera\n");
		return -1;
	}

	namedWindow("video", 1);

	for (;;) {
		capture >> frame;
		imshow("video", frame);
		if (waitKey(30) >= 0)
			break;
	}
}