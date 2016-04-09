using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

// Just paste this class into your project and use it like:
// ResourceLoader.Load("images.myimage.png", typeof(MyTypeInSameAssemblyAsImage));

namespace PortableResourceLoader
{

    public static class ResourceLoader
    {
        public static Stream Load(string relativePath, Type typeOfClassInSameAssembly = null)
        {
            if (typeOfClassInSameAssembly == null) typeOfClassInSameAssembly = typeof(ResourceLoader);
            var assembly = typeOfClassInSameAssembly.GetTypeInfo().Assembly;
            var fullName = GetAssemblyName(assembly) + "." + relativePath;
            var result = assembly.GetManifestResourceStream(fullName);
            if (result == null) throw new Exception(ConstructExceptionMessage(relativePath, assembly));
            return result;
        }

        private static string ConstructExceptionMessage(string path, Assembly assembly)
        {
            const string format = "The resource name '{0}' was not found in assembly '{1}'.";
            var message = string.Format(format, path, GetAssemblyName(assembly));

            var resourceNames = assembly.GetManifestResourceNames();
            if (resourceNames.Length == 0)
            {
                message += " There are no resources in this assembly.";
                Debug.WriteLine(message);
                return message;
            }

            var similarNames = resourceNames.Where(name => path.ToLower().Split('.')
                .Any(name.ToLower().Contains)).ToArray();

            if (similarNames.Length <= 0) return message;

            var nameLength = GetAssemblyName(assembly).Length;
            similarNames = similarNames.Select(fullName => fullName.Remove(0, nameLength + 1)).ToArray();
            message += " Did you mean: " + string.Join("\n ", similarNames.ToArray()) + ".";
            Debug.WriteLine(message);
            return message;
        }

        private static string GetAssemblyName(Assembly assembly)
        {
            return new AssemblyName(assembly.FullName).Name;
        }
    }
}
