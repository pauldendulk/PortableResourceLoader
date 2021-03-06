﻿using Android.App;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Widget;

namespace PortableResourceLoader.Samples.Android
{
    [Activity(Label = "PortableResourceLoader.Samples.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
                        
            var image = FindViewById<ImageView>(Resource.Id.MyImage);
            var stream = EmbeddedResourceLoader.Load("Images.sample_image.png", typeof(TypeInAssembly));
            image.SetImageDrawable(Drawable.CreateFromStream(stream, null));
        }
    }
}

