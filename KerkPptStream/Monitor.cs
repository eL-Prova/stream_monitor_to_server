using System.Drawing;
using System.Windows.Forms;

namespace ImageToStream
{
    public class Monitor
    {
        private string _deviceName;
        public string DeviceName
        {
            get { return _deviceName; }
            set { _deviceName = value.Replace("\\", "").Replace(".", ""); }
        }

        public Screen Screen { get; set; }
        public Rectangle Bounds { get; set; }
        public Rectangle WorkingArea { get; set; }
        public bool IsPrimary { get; set; }

        public override string ToString()
        {
            var isPrimaryText = string.Empty;
            if (IsPrimary)
                isPrimaryText = " (Primair)";
            return $"{DeviceName} - {WorkingArea}{isPrimaryText}";
        }
    }
}
