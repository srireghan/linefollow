using System;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

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
            _frameTimer = new Timer { Interval = 100 };  
            _frameTimer.Tick += FrameTimer_Tick;
            _frameTimer.Start();
            thresholdTrackBar.ValueChanged += ThresholdTrackBar_ValueChanged;
        }

        private void FrameTimer_Tick(object sender, EventArgs e)
        {
            Mat frame = _capture.QueryFrame();
            CvInvoke.Flip(frame, frame, FlipType.Horizontal);
            if (frame != null && !frame.IsEmpty)
            {
                DisplayImage(frame, pictureBoxRaw);  
                ApplyThresholdingAndSlicing(frame);  
            }
        }

        private void DisplayImage(Mat image, PictureBox pictureBox)
        {
            Image<Bgr, Byte> resizedImage = image.ToImage<Bgr, Byte>().Resize(pictureBox.Width, pictureBox.Height, Inter.Linear);
            pictureBox.Image?.Dispose();
            pictureBox.Image = resizedImage.ToBitmap();
        }

       

        private void UpdateLabel(int sliceIndex, int count)
        {
            this.Invoke(new Action(() =>
            {
                switch (sliceIndex)
                {
                    case 0:
                        label1.Text = $"Slice 1: {count}";
                        break;
                    case 1:
                        label2.Text = $"Slice 2: {count}";
                        break;
                    case 2:
                        label3.Text = $"Slice 3: {count}";
                        break;
                    case 3:
                        label4.Text = $"Slice 4: {count}";
                        break;
                    case 4:
                        label5.Text = $"Slice 5: {count}";
                        break;
                }
            }));
        }

        private void ApplyThresholdingAndSlicing(Mat frame)
        {
            Image<Gray, Byte> grayImage = frame.ToImage<Bgr, Byte>().Convert<Gray, Byte>();
            Image<Gray, Byte> thresholdImage = grayImage.ThresholdBinary(new Gray(thresholdTrackBar.Value), new Gray(255));
            pictureBoxThreshold.Image = thresholdImage.ToBitmap();

            int sliceWidth = thresholdImage.Width / 5;
            int[] whiteCounts = new int[5];
            for (int i = 0; i < 5; i++)
            {
                Rectangle sliceRect = new Rectangle(i * sliceWidth, 0, sliceWidth, thresholdImage.Height);
                Image<Gray, Byte> slice = thresholdImage.GetSubRect(sliceRect);
                whiteCounts[i] = CvInvoke.CountNonZero(slice);
                UpdateLabel(i, whiteCounts[i]);
            }

            DetermineDirection(whiteCounts);
        }

        private void DetermineDirection(int[] whiteCounts)
        {
            
            int maxIndex = Array.IndexOf(whiteCounts, whiteCounts.Max());

            string direction = "Straight";
            switch (maxIndex)
            {
                case 0:
                    direction = "Sharp Left";
                    break;
                case 1:
                    direction = "Mild Left";
                    break;
                case 2:
                    direction = "Straight";
                    break;
                case 3:
                    direction = "Mild Right";
                    break;
                case 4:
                    direction = "Sharp Right";
                    break;
            }

            UpdateDirectionLabel(direction);
        }

        private void UpdateDirectionLabel(string direction)
        {
            this.Invoke(new Action(() =>
            {
                directionLabel.Text = $"Direction: {direction}";
            }));
        }


        private void ThresholdTrackBar_ValueChanged(object sender, EventArgs e)
        {
        }

        private void pictureBoxThreshold_Click(object sender, EventArgs e)
        {

        }

        private void directionLabel_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}