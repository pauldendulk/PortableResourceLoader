
using Android.App;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Widget;
using PortableResourceLoader.Samples.Wpf;

namespace PortableResourceLoader.Samples.Android
{
    [Activity(Label = "PortableResourceLoader.Samples.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
                        
            var image = FindViewById<ImageView>(Resource.Id.MyImage);
            image.SetImageDrawable(Drawable.CreateFromStream(LoadSample.LoadBitmapAsStream(), null));
        }
    }
}

