using System.Diagnostics;

namespace PortableResourceLoader.Samples.Core
{
    public class LoadSample
    {
        public static void LoadBitmap()
        {
            const string path = "Images/gps3.png";

            var loader = new ResourceLoader();
            var stream = loader.Load(path, "PortableResourceLoader.Samples.Core");
            Debug.WriteLine(stream.Length);
        }
    }
}
