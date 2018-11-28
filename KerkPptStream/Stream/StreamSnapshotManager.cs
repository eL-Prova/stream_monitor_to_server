using ImageToStream;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KerkPptStream.Stream
{
    public class StreamSnapshotManager
    {
        private static StreamSnapshotManager _instance;

        private RegionSelectionDTO _regionSelection;
        private int _width, _height;

        public bool StreamEnabled { get; set; }
        public Monitor Monitor { get; private set; }

        private StreamSnapshotManager(RegionSelectionDTO selection)
        {
            _regionSelection = selection;
            _width = selection.Width;
            _height = selection.Height;
        }

        public IEnumerable<Image> GenerateSnapshots()
        {
            var size = new Size(Monitor.Screen.Bounds.Width, Monitor.Screen.Bounds.Height);

            var srcImage = new Bitmap(size.Width, size.Height);
            var srcGraphics = Graphics.FromImage(srcImage);
            var scaled = (_width != size.Width || _height != size.Height);

            var dstImage = srcImage;
            var dstGraphics = srcGraphics;

            if (scaled)
            {
                dstImage = new Bitmap(_width, _height);
                dstGraphics = Graphics.FromImage(dstImage);
            }

            var src = new Rectangle(0, 0, _width, _height);
            var dst = new Rectangle(0, 0, _width, _height);
            var curSize = new Size(32, 32);

            while (StreamEnabled)
            {
                srcGraphics.CopyFromScreen(
                    _regionSelection.XStart, _regionSelection.YStart,
                    0, 0,
                    size);


                //Tekent cursor, kunnen we evt. configurable maken
                Cursors.Default.Draw(srcGraphics, new Rectangle(Cursor.Position, curSize));

                if (scaled)
                    dstGraphics.DrawImage(srcImage, dst, src, GraphicsUnit.Pixel);

                yield return dstImage;
            }
        }

        public Image CreateSnapshot()
        {
            var size = new Size(Monitor.Screen.Bounds.Width, Monitor.Screen.Bounds.Height);

            var srcImage = new Bitmap(size.Width, size.Height);
            var srcGraphics = Graphics.FromImage(srcImage);
            var scaled = (_width != size.Width || _height != size.Height);

            var dstImage = srcImage;
            var dstGraphics = srcGraphics;

            if (scaled)
            {
                dstImage = new Bitmap(_width, _height);
                dstGraphics = Graphics.FromImage(dstImage);
            }

            var src = new Rectangle(0, 0, _width, _height);
            var dst = new Rectangle(0, 0, _width, _height);
            var curSize = new Size(32, 32);

            srcGraphics.CopyFromScreen(
                _regionSelection.XStart, _regionSelection.YStart,
                0, 0,
                size);

            //Tekent cursor, kunnen we evt. configurable maken
            Cursors.Default.Draw(srcGraphics, new Rectangle(Cursor.Position, curSize));

            if (scaled)
                dstGraphics.DrawImage(srcImage, dst, src, GraphicsUnit.Pixel);

            return dstImage;
        }

        public static StreamSnapshotManager Create(RegionSelectionDTO regionSelection, Monitor monitor = null)
        {
            _instance = new StreamSnapshotManager(regionSelection)
            {
                Monitor = monitor ?? MonitorDetector.GetPrimaryScreen()
            };

            return _instance;
        }

        public static StreamSnapshotManager GetInstance() => _instance;



    }
}
