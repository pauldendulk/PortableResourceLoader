using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PortableResourceLoader
{
    public class ResourceLoader
    {
        public Stream Load(string path, Assembly assembly)
        {
            var fullName = assembly.GetName().Name + "." + path;
            var result = assembly.GetManifestResourceStream(fullName);
            if (result == null) throw new Exception(ConstructExceptionMessage(path, assembly));
            return result;
        }

        private static string ConstructExceptionMessage(string path, Assembly assembly)
        {
            const string format = "The resource name '{0}' was not found in assembly '{1}'.";
            var message = string.Format(format, path, assembly.GetName().Name);

            var resourceNames = assembly.GetManifestResourceNames();
            if (resourceNames.Length == 0) return message + " There are no resources in this assembly.";

            var similarNames = resourceNames.Where(name => path.ToLower().Split(new[] { '.' })
                .Any(name.ToLower().Contains)).ToArray();
            if (similarNames.Length > 0)
            {
                var nameLength = assembly.GetName().Name.Length;
                similarNames = similarNames.Select(fullName => fullName.Remove(0, nameLength + 1)).ToArray();
                return message + " Did you mean: " + string.Join(", ", similarNames.ToArray()) + ".";
            }

            return message;
        }
    }
}
