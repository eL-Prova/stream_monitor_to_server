using ImageToStream;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KerkPptStream {
    public class RegionSelector {

        private const int SnippetDelay = 200;

        private RegionSelectionDTO _regionSelectionDTO;
        private PictureBox _pictureBoxContainer;
        private StreamSelectionForm _form;
        private readonly Container _parent;
        private bool _isDrawing;
        private Bitmap _bmpImage;
        private int _screenWidth, _screenHeight;
        private readonly Monitor _monitor;

        public Pen Pen => new Pen(Color.Gray, 3) { DashStyle = DashStyle.Solid };
        public Monitor Monitor => _monitor;

        public RegionSelector(Container parent, Monitor monitor = null) {
            _parent = parent;
            _monitor = monitor ?? MonitorDetector.GetPrimaryScreen();
        }

        private void SubscribeMouseEvents() {
            _pictureBoxContainer.MouseDown += HandleMouseDown;
            _pictureBoxContainer.MouseUp += HandleMouseUp;
            _pictureBoxContainer.MouseMove += HandleMove;
        }

        private void UnsubscribeMouseEvents() {
            _pictureBoxContainer.MouseDown -= HandleMouseDown;
            _pictureBoxContainer.MouseUp -= HandleMouseUp;
            _pictureBoxContainer.MouseMove -= HandleMove;
        }

        public void CreateRegionWindow() {
            _regionSelectionDTO = new RegionSelectionDTO();
            _parent.Visible = false;
            _screenWidth = _monitor.Bounds.Width;
            _screenHeight = _monitor.Bounds.Height;
            _form = new StreamSelectionForm(Pen, new Size(_screenWidth, _screenHeight));
            _pictureBoxContainer = _form.StreamSelectionContent;
            Task.Delay(SnippetDelay).GetAwaiter().GetResult();
            SubscribeMouseEvents();
            _form.Show();
            BuildScreen();
        }

        private void BuildScreen() {
            var screenLeft = _monitor.Bounds.Left;
            var screenTop = _monitor.Bounds.Top;

            using (var g = Graphics.FromImage(BmpImage))
                g.CopyFromScreen(screenLeft, screenTop, 0, 0, BmpImage.Size);
            using (var stream = new MemoryStream()) {
                BmpImage.Save(stream, ImageFormat.Png);
                _pictureBoxContainer.Image = BmpImage;
            }
        }

        private Bitmap BmpImage => _bmpImage ?? (_bmpImage = new Bitmap(_screenWidth, _screenHeight));

        private void HandleMove(object sender, MouseEventArgs e) {
            if (!_isDrawing) return;
            _pictureBoxContainer.Refresh();
            _regionSelectionDTO.XEnd = e.X;
            _regionSelectionDTO.YEnd = e.Y;
            _form.UpdateRectangle(_regionSelectionDTO.ToRectangle());
            _pictureBoxContainer.Invalidate();
        }

        public RegionSelectionDTO GetTool() => _regionSelectionDTO;

        private void HandleMouseUp(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left || !_isDrawing) return;
            _isDrawing = false;
            _regionSelectionDTO.XEnd = e.X;
            _regionSelectionDTO.YEnd = e.Y;
            Complete();
        }

        private void HandleMouseDown(object sender, MouseEventArgs e) {
            if (_isDrawing || e.Button != MouseButtons.Left) return;
            _isDrawing = true;
            _regionSelectionDTO.XStart = e.X;
            _regionSelectionDTO.XEnd = e.X;
            _regionSelectionDTO.YStart = e.Y;
            _regionSelectionDTO.YEnd = e.Y;
            _form.UpdateRectangle(_regionSelectionDTO.ToRectangle());
            _pictureBoxContainer.Invalidate();
        }

        private void Complete() {
            UnsubscribeMouseEvents();
            _form.Dispose();
            _parent.Show();
            _parent.SetBounds(_regionSelectionDTO);
        }
    }
}
