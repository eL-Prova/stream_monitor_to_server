using System.Drawing;
using System.Windows.Forms;

namespace KerkPptStream {
    public sealed partial class StreamSelectionForm : Form {

        private readonly Pen _pen;
        private Rectangle _rectangle;
        public StreamSelectionForm(Pen pen, Size pictureBoxSize) {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Cursor = Cursors.Cross;
            _pen = pen;
            StreamSelectionContent.Size = pictureBoxSize;
        }

        public void UpdateRectangle(Rectangle rectangle) {
            _rectangle = rectangle;
        }

        private void StreamSelectionPaint(object sender, PaintEventArgs e) {
            e.Graphics.DrawRectangle(_pen, _rectangle);
        }
    }
}
