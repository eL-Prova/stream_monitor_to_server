using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using ImageToStream;
using KerkPptStream.Stream;

namespace KerkPptStream
{

    public partial class Container : Form
    {

        public static StreamServer StreamServer { get; set; }
        private StreamSnapshotManager _snapshotManager;
        private Rectangle _rectangle;
        private TcpClient _client;
        private NetworkStream _nwStream;
        private bool _recording = false;

        public Container()
        {
            InitializeComponent();
            SetupDetectionMonitors();
        }

        private void SetupDetectionMonitors()
        {
            var screens = MonitorDetector.GetScreens();

            DdlScreens.Items.Clear();
            DdlScreens.Items.AddRange(screens?.ToArray());
            DdlScreens.SelectedIndex = 0;
        }

        private void RegionSelectClick(object sender, EventArgs e)
        {
            RegionSelector.CreateRegionWindow();
        }

        public void SetBounds(RegionSelectionDTO tool)
        {
            SetTextboxValues(tool.ToRectangle());
        }

        private void SetTextboxValues(Rectangle rectangle)
        {
            _rectangle = rectangle;
            TextboxBoundsHeight.Text = _rectangle.Height.ToString();
            TextboxBoundsWidth.Text = _rectangle.Width.ToString();
            TextboxBoundsX.Text = _rectangle.X.ToString();
            TextboxBoundsY.Text = _rectangle.Y.ToString();
        }

        private RegionSelector _regionSelector;
        private RegionSelector RegionSelector
        {
            get { return _regionSelector ?? (_regionSelector = new RegionSelector(this)); }
        }

        private void DdlScreens_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddlScreen = sender as ComboBox;
            var selectedItem = ddlScreen?.SelectedItem as Monitor;

            if (selectedItem == null)
                return;

            var rectangle = selectedItem.Bounds;

            SetTextboxValues(rectangle);
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            _snapshotManager = _snapshotManager == null ? StreamSnapshotManager.Create(RegionSelector.GetTool())
                : StreamSnapshotManager.GetInstance();
            _snapshotManager.StreamEnabled = true;

            //StreamServer = new StreamServer(_snapshotManager);
            //StreamServer.Start();



            //------------------------------------------------------------------------------------------------//
            //string textToSend = DateTime.Now.ToString();

            //---create a TCPClient object at the IP and port no.---
            _client = new TcpClient("127.0.0.1", 5000);
            _client.NoDelay = true;
            _nwStream = _client.GetStream();
            //byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

            while (_snapshotManager.StreamEnabled)
            {
                var imageIn = _snapshotManager.CreateSnapshot();
                var bytesToSend = imageIn.imageToByteArray();

                _nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                imageIn.Dispose();
            }
            //---send the text---
            //Console.WriteLine("Sending : " + textToSend);

            //---read back the text---
            //byte[] bytesToRead = new byte[_client.ReceiveBufferSize];
            //int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            //Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            //Console.ReadLine();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //if (_snapshotManager != null)
            //{
            //    _snapshotManager.StreamEnabled = false;
            //}
            //if (StreamServer != null && StreamServer.IsRunning)
            //{
            //    StreamServer.Stop();
            //}

            _nwStream.Close();
            _client.Close();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (_snapshotManager == null) return;

            var button = sender as Button;
            var paused = !_snapshotManager.StreamEnabled;

            // ReSharper disable once PossibleNullReferenceException
            button.Text = paused ? "Unpause" : "Pause";
            _snapshotManager.StreamEnabled = paused;
        }
    }

    public static class ImageExtensions
    {
        public static byte[] imageToByteArray(this Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
    }
}
