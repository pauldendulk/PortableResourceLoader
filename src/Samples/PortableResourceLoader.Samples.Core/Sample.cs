using System.IO;
using System.Reflection;

namespace PortableResourceLoader.Samples.Core
{
    public class LoadSample
    {
        public static Stream LoadBitmapAsStream()
        {
            const string path = "Images.checkered.png";

            var loader = new ResourceLoader();
            return loader.Load(path, Assembly.GetExecutingAssembly());
        }
    }
}
