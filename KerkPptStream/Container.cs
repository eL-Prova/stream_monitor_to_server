using System;
using System.Drawing;
using System.Linq;
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
            //_snapshotManager = _snapshotManager == null ? StreamSnapshotManager.Create(RegionSelector.GetTool(), RegionSelector.Monitor)
            _snapshotManager = _snapshotManager == null ? StreamSnapshotManager.Create(RegionSelector.GetTool())
                : StreamSnapshotManager.GetInstance();
            _snapshotManager.StreamEnabled = true;

            StreamServer = new StreamServer(_snapshotManager);
            StreamServer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //if (_snapshotManager != null)
            //{
            //    _snapshotManager.StreamEnabled = false;
            //}
            if (StreamServer != null && StreamServer.IsRunning)
            {
                StreamServer.Stop();
            }
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
}
