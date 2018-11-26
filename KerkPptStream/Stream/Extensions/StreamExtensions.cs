using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace KerkPptStream.Stream
{
    public static class StreamExtensions
    {

        public static IEnumerable<MemoryStream> GenerateMemoryStream(this IEnumerable<Image> source)
        {
            var ms = new MemoryStream();

            foreach (var img in source)
            {
                ms.SetLength(0);
                img.Save(ms, ImageFormat.Jpeg);
                yield return ms;
            }

            ms.Close();
        }
    }
}
