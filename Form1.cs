using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace WebcamTracker
{
    public partial class Form1 : Form
    {
        private Capture capWebcam;
        private bool blnCapturingInProcess = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            capWebcam = new Capture(CaptureType.Any);
            try
            {
                capWebcam = new Capture();
            }
            catch (Exception ex)
            {
                MessageBox.Show("unable to read from webcam, error: " + Environment.NewLine + Environment.NewLine +
                               ex.Message + Environment.NewLine + Environment.NewLine +
                               "exiting program");
                Environment.Exit(0);
                return;
            }
            
            Application.Idle += processFrameAndUpdateGUI;
            blnCapturingInProcess = true;
        }


        private void processFrameAndUpdateGUI(object sender, EventArgs arg)
        {
            Mat imgOriginal;

            imgOriginal = capWebcam.QueryFrame();

            if (imgOriginal == null)
            {
                MessageBox.Show("unable to read from webcam" + Environment.NewLine + Environment.NewLine +
                                "exiting program");
                Environment.Exit(0);
                return;
            }

            Mat imgHSV = new Mat(imgOriginal.Size, DepthType.Cv8U, 3);

            Mat imgThreshLow = new Mat(imgOriginal.Size, DepthType.Cv8U, 1);
            Mat imgThreshHigh = new Mat(imgOriginal.Size, DepthType.Cv8U, 1);

            Mat imgThresh = new Mat(imgOriginal.Size, DepthType.Cv8U, 1);

            //convert the color configs in imgOriginal and store new image to imgHSV
            CvInvoke.CvtColor(imgOriginal, imgHSV, ColorConversion.Bgr2Hsv);

            //put data that lies within the threshhold from imgHSV to imgThreshLow
            CvInvoke.InRange(imgHSV, new ScalarArray(new MCvScalar(0, 155, 155)), new ScalarArray(new MCvScalar(18, 255, 255)), imgThreshLow);
            CvInvoke.InRange(imgHSV, new ScalarArray(new MCvScalar(165, 155, 155)), new ScalarArray(new MCvScalar(179, 255, 255)), imgThreshHigh);

            //add images together and put into imgThresh
            CvInvoke.Add(imgThreshLow, imgThreshHigh, imgThresh);
            
            //add Gaussian blue to imgThresh to reduce noice
            CvInvoke.GaussianBlur(imgThresh, imgThresh, new Size(3, 3), 0);

            //size -1 -1 means anchor is at center 
            Mat structuringElement = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));

            //reduce noise around the object
            CvInvoke.Dilate(imgThresh, imgThresh, structuringElement, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(0, 0, 0));
            CvInvoke.Erode(imgThresh, imgThresh, structuringElement, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(0, 0, 0));

            //
            CircleF[] circles = CvInvoke.HoughCircles(imgThresh, HoughType.Gradient, 2.0, imgThresh.Rows / 4, 100, 50, 10, 400);

            foreach (CircleF circle in circles)
            {
                if (txtXYRadius.Text != "")
                {                         // if we are not on the first line in the text box
                    txtXYRadius.AppendText(Environment.NewLine);         // then insert a new line char
                }

                txtXYRadius.AppendText("ball position x = " + circle.Center.X.ToString().PadLeft(4) + ", y = " + circle.Center.Y.ToString().PadLeft(4) + ", radius = " + circle.Radius.ToString("###.000").PadLeft(7));
                txtXYRadius.ScrollToCaret();             // scroll down in text box so most recent line added (at the bottom) will be shown

                CvInvoke.Circle(imgOriginal, new Point((int)circle.Center.X, (int)circle.Center.Y), (int)circle.Radius, new MCvScalar(0, 0, 255), 2);
                CvInvoke.Circle(imgOriginal, new Point((int)circle.Center.X, (int)circle.Center.Y), 3, new MCvScalar(0, 255, 0), -1);
            }

            IBOriginal.Image = imgOriginal;
            IBProccessed.Image = imgThresh;
        }

       

        //private void imageBox1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
