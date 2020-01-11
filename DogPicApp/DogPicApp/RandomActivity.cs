using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DogPicApp;
using Newtonsoft.Json;
using StarwarsApp.Core;
using static Android.Widget.AdapterView;

namespace StarwarsApp
{
    [Activity(Label = "RandomActivity")]
    public class RandomActivity : Activity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.random_layout);
            // Create your application here
            var breed = Intent.GetStringExtra("selectedBreed");
            var films = await DataService.GetRandomDog(breed);
            var filmsListView = FindViewById<ListView>(Resource.Id.randomdogListView);
            filmsListView.Adapter = new RandomAdapter(this, films.Status, films.Message);

            filmsListView.ItemClick += (object sender, ItemClickEventArgs e) =>
            {
                //var filmDetails = films.Message;
                Intent intent = new Intent(this, typeof(RandomActivity));
                //var intent = new Intent(this, typeof(FilmDetailsActivity));
                //intent.PutExtra("filmDetails", JsonConvert.SerializeObject(filmDetails));
                intent.PutExtra("selectedBreed", breed);
                StartActivity(intent);
            };

            var backButton = FindViewById<Button>(Resource.Id.buttonBackToMenu);

            backButton.Click += delegate
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };

        }
    }
}