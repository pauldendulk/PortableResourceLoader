using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PortableResourceLoader.Samples.Wpf
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (sender, args) =>
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = EmbeddedResourceLoader.Load("Images.sample_image.png", typeof(EmbeddedResourceLoader));
                bitmapImage.EndInit();
                Image.Stretch = Stretch.None;
                Image.BeginInit();
                Image.Source = bitmapImage;
                Image.EndInit();
            };
        }
    }
}
