using System;
using System.Diagnostics;
using System.Reflection;

namespace PortableResourceLoader.Samples.Core
{
    public class LoadSample
    {
        public static void LoadBitmap()
        {
            const string path = "Images.gps3.png";

            var loader = new ResourceLoader();
            var stream = loader.Load(path, Assembly.GetExecutingAssembly());
            Debug.WriteLine(stream.Length);
        }
    }
}
