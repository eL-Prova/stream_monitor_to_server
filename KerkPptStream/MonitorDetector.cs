using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ImageToStream;

namespace KerkPptStream
{
    public class MonitorDetector
    {
        public static IEnumerable<Monitor> GetScreens()
        {
            return Screen.AllScreens.Select(screen => new Monitor
            {
                DeviceName = screen.DeviceName,
                WorkingArea = screen.WorkingArea,
                Bounds = screen.Bounds,
                IsPrimary = screen.Primary,
                Screen = screen
            });
        }

        public static Monitor GetPrimaryScreen()
        {
            return GetScreens().Single(x => x.IsPrimary);
        }
    }
}
