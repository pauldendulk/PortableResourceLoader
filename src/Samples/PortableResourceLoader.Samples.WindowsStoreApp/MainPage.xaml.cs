using System.IO;
using Windows.UI.Xaml.Media.Imaging;

namespace PortableResourceLoader.Samples.WindowsStoreApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            var stream = EmbeddedResourceLoader.Load("Images.sample_image.png", typeof(EmbeddedResourceLoader));
            Loaded += (sender, args) => Image.Source = ToBitmapImage(stream); 
        }

        public static BitmapImage ToBitmapImage(Stream stream)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.SetSourceAsync(stream.AsRandomAccessStream());
            return bitmapImage;
        }
    }
}
