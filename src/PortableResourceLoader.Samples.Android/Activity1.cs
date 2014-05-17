using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PortableResourceLoader.Samples.Core;
using Android.Graphics.Drawables;

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
            //image.SetScaleType(ImageView.ScaleType.);

            LoadSample.LoadBitmapAsStream();
        }
    }
}

