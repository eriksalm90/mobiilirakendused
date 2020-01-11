using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Content;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using DogPicApp;
using StarwarsApp;
using System;
using System.Collections.Generic;

namespace DogPicApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AppCenter.Start("c6d4036f-1930-4e0a-ac10-ae62f3c7209c",
                   typeof(Analytics), typeof(Crashes));
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var breedsButton = FindViewById<Button>(Resource.Id.button2);
            var randomButton = FindViewById<Button>(Resource.Id.button1);

            breedsButton.Click += delegate
           {
               Intent intent = new Intent(this, typeof(BreedActivity));
               StartActivity(intent);
           };

            randomButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(RandomActivity));
                intent.PutExtra("selectedBreed", "random");
                StartActivity(intent);
            };
        }
    }
}