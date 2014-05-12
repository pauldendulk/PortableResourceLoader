using System.IO;

namespace PortableResourceLoader
{
    public class ResourceLoader
    {
        public Stream Load(string path, string assembly)
        {
            return new FileStream(path, FileMode.Open, FileAccess.Read);
        }
    }
}
