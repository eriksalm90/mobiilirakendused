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
using StarwarsApp.Core;

namespace StarwarsApp
{
    [Activity(Label = "BreedActivity")]
    public class BreedActivity : Activity
    {
        List<String> breeds = new List<String>(new string[] {
                "affenpinscher", "african","airedale","akita","appenzeller","australian","basenji","beagle","bluetick","borzoi","bouvier","boxer","brabancon",
"briard","buhund","bulldog","bullterrier","cairn","cattledog","chihuahua","chow","clumber","cockapoo","collie","coonhound","corgi","cotondetulear",
"dachshund","dalmatian","dane","deerhound","dhole","dingo","doberman","elkhound","entlebucher","eskimo","frise","germanshepherd","greyhound","groenendael",
"hound","husky","keeshond","kelpie","komondor","kuvasz","labrador","leonberg","lhasa","malamute","malinois","maltese","mastiff","mexicanhairless","mix",
"mountain","newfoundland","otterhound","papillon","pekinese","pembroke","pinscher","pitbull","pointer","pomeranian","poodle","pug","puggle","pyrenees",
"redbone","retriever","ridgeback","rottweiler","saluki","samoyed","schipperke","schnauzer","setter","sheepdog","shiba","shihtzu","spaniel","springer",
"stbernard","terrier","vizsla","waterdog","weimaraner","whippet","wolfhound"});


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.breed_layout);
            //ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.breeds_row_layout, breeds);


            var listView = FindViewById<ListView>(Resource.Id.breedListView);
            listView.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, breeds);
            //listView.Adapter = new PeopleAdapter(this, breeds);

            listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                var position = args.Position;          
                Intent intent = new Intent(this, typeof(RandomActivity));
                intent.PutExtra("selectedBreed", breeds[position]);
                StartActivity(intent);
            };
        }

    }
}