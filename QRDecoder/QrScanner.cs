using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace QRDecoder
{
    public partial class QrScanner : Form
    {
        private FilterInfoCollection CaptureDevices;
        private VideoCaptureDevice videoSource;
        private string decodedQR;
        public QrScanner()
        {
            InitializeComponent();
        }

        public string DecodedQrCode
        {
            get;
            private set;
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                PbScanner.Image = (Image)eventArgs.Frame.Clone();
            }
            catch (Exception ex)
            {
                var a = ex;
            }
            
        }

        //This method is used to Start the Camera
        public void StartCam()
        {
            videoSource = new VideoCaptureDevice(CaptureDevices[CbAvailableCams.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
            videoSource.Start();
        }

        //This method is used to Exit the Camera
        private void ExitCam()
        {
            videoSource.SignalToStop();
            videoSource.NewFrame -= new NewFrameEventHandler(videoSource_NewFrame);
            videoSource = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WinApi.AnimateWindow(this.Handle, 400, WinApi.AW_CENTER);

            EllipseHelper.SetEllipse(PbScanner, 40);
            EllipseHelper.SetEllipse(this, 10);

            //This will fetch/load the available camera into our ComboBox "CbAvailableCams" 
            CaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevices)
            {
                CbAvailableCams.Items.Add(Device.Name);
            }
            if (!CbAvailableCams.Items.Equals(null))
            {
                CbAvailableCams.SelectedIndex = 0;
            }

            videoSource = new VideoCaptureDevice();

            //Start the Camera
            StartCam();

            //Start Scanning of QrCode
            TCapture.Start();

            pictureBox2.Parent = PbScanner;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        public void ShowQRScanner()
        {
            this.ShowDialog();
        }

        //Used to decode Qr
        private void TCapture_Tick(object sender, EventArgs e)
        {
            BarcodeReader Reader = new BarcodeReader();
            try
            {
                Result result = Reader.Decode((Bitmap)PbScanner.Image);
                decodedQR = result.ToString().Trim();
                this.Close();
            }
            catch (Exception ex)
            {
                var a = ex;
            }    
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoSource.SignalToStop();
            videoSource.NewFrame -= new NewFrameEventHandler(videoSource_NewFrame);
            videoSource = null;
            DecodedQrCode = decodedQR;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
