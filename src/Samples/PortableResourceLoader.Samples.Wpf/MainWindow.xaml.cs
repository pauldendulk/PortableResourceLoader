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
                bitmapImage.StreamSource = LoadSample.LoadBitmapAsStream();
                bitmapImage.EndInit();

                Image.BeginInit();
                Image.Source = bitmapImage;
                Image.EndInit();
            };
        }
    }
}
