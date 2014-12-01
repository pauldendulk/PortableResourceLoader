using System.IO;
using Windows.UI.Xaml.Media.Imaging;
using PortableResourceLoader.Samples.Wpf;

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
            Loaded += (sender, args) => Image.Source = ToBitmapImage(LoadSample.LoadBitmapAsStream()); 
        }

        public static BitmapImage ToBitmapImage(Stream stream)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.SetSourceAsync(stream.AsRandomAccessStream());
            return bitmapImage;
        }
    }
}
