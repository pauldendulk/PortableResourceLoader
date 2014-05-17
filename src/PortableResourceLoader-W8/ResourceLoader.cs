using System.IO;
using System.Reflection;

namespace PortableResourceLoader
{
    public class ResourceLoader
    {
        public Stream Load(string path, Assembly assembly)
        {
            return assembly.GetManifestResourceStream(assembly.GetName().Name + "." + path);
        }
    }
}
