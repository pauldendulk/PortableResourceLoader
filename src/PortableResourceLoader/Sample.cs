﻿using System.IO;

namespace PortableResourceLoader
{
    public class LoadSample
    {
        public static Stream LoadBitmapAsStream()
        {
            const string path = "Images.sample_image.png";
            var loader = new ResourceLoader();
            return loader.Load(path);
        }
    }
}
