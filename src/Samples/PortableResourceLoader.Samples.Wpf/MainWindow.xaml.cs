using PortableResourceLoader.Samples.Core;
using System.Windows;

namespace PortableResourceLoader.Samples.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (sender, args) => LoadSample.LoadBitmap();
        }
    }
}
