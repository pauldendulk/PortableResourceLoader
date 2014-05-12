using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace PortableResourceLoader
{
    public class ResourceLoader
    {
        private const string ApplicationSchema = "ms-appx://";

        public Stream Load(string path, string assembly)
        {
            var uri = new Uri(ApplicationSchema + "/" + assembly + "/" + path);
            var rass = RandomAccessStreamReference.CreateFromUri(uri);
            return GetStreamAsync(rass).Result.AsStream();
        }
        
        private async Task<IRandomAccessStream> GetStreamAsync(RandomAccessStreamReference rass)
        {
            return await rass.OpenReadAsync();
        }
    }
}
