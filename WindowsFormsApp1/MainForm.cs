using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private VideoCapture _capture;
        private Timer _frameTimer;
        public MainForm()
        {
            InitializeComponent();

            _capture = new VideoCapture(0);
            _capture.ImageGrabbed += ProcessFrame; 
            _capture.Start();
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            using (Mat frame = new Mat())
            {
                _capture.Retrieve(frame, 0);  
                if (frame != null && !frame.IsEmpty)
                {
                    DisplayImage(frame, pictureBoxRaw);

                    DisplayThresholded(frame, pictureBoxThreshold);
                }
            }
        }

        private void DisplayImage(Mat image, PictureBox pictureBox)
        {
            double ratio = Math.Min(pictureBox.Width / (double)image.Width, pictureBox.Height / (double)image.Height);
            Size newSize = new Size((int)(image.Width * ratio), (int)(image.Height * ratio));
            Mat resizedImage = new Mat();
            CvInvoke.Resize(image, resizedImage, newSize);

            pictureBox.Image?.Dispose();  
            pictureBox.Image = resizedImage.ToBitmap();  
        }

        private void DisplayThresholded(Mat image, PictureBox pictureBox)
        {
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(image, grayImage, ColorConversion.Bgr2Gray);

            Mat thresholdedImage = new Mat();
            CvInvoke.Threshold(grayImage, thresholdedImage, 100, 255, ThresholdType.Binary);

            DisplayImage(thresholdedImage, pictureBox);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_capture != null)
            {
                _capture.Stop();
                _capture.Dispose();
            }
            base.OnFormClosing(e);
        }

        private void pictureBoxThreshold_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}