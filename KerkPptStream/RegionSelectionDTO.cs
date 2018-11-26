using System;
using System.Drawing;

namespace KerkPptStream {

    public struct RegionSelectionDTO {

        public int XStart { get; set; }
        public int XEnd { get; set; }
        public int YStart { get; set; }
        public int YEnd { get; set; }

        public int Width => Math.Abs(XEnd - XStart);
        public int Height => Math.Abs(YEnd - YStart);

        public Pen Pen { get; set; }

        public Rectangle ToRectangle() {
            return new Rectangle(
                Math.Min(XStart, XEnd),
                Math.Min(YStart, YEnd),
                Width,
                Height);
        }
    }
}
