using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PortableResourceLoader
{
    public static class ResourceLoader
    {
        public static Stream Load(string path, Assembly assembly = null)
        {
            if (assembly == null) assembly = GetCurrentAssembly();
            var fullName = GetAssemblyName(assembly) + "." + path;
            var result = assembly.GetManifestResourceStream(fullName);
            if (result == null) throw new Exception(ConstructExceptionMessage(path, assembly));
            return result;
        }

        private static Assembly GetCurrentAssembly()
        {
            // In more modern PCL profiles this is: 
            // var assembly = typeof(ResourceLoader).GetTypeInfo().Assembly;
            return typeof(ResourceLoader).Assembly;
        }

        private static string ConstructExceptionMessage(string path, Assembly assembly)
        {
            const string format = "The resource name '{0}' was not found in assembly '{1}'.";
            var message = string.Format(format, path, GetAssemblyName(assembly));

            var resourceNames = assembly.GetManifestResourceNames();
            if (resourceNames.Length == 0) return message + " There are no resources in this assembly.";

            var similarNames = resourceNames.Where(name => path.ToLower().Split(new[] { '.' })
                .Any(name.ToLower().Contains)).ToArray();
            if (similarNames.Length > 0)
            {
                var nameLength = GetAssemblyName(assembly).Length;
                similarNames = similarNames.Select(fullName => fullName.Remove(0, nameLength + 1)).ToArray();
                return message + " Did you mean: " + string.Join(", ", similarNames.ToArray()) + ".";
            }

            return message;
        }

        private static string GetAssemblyName(Assembly assembly)
        {
            string name = assembly.FullName;
            var asmName = new AssemblyName(name);
            return asmName.Name;
        }
    }
}
