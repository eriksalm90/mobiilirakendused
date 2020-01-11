using System.Collections.Generic;
using System.Net;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using DogPicApp;
using StarwarsApp.Core.Models;

namespace StarwarsApp
{
    public class RandomAdapter : BaseAdapter<RandomDogs>
    {
        string _status;
        string _url;
        Bitmap _image;
        Activity _context;

        public RandomAdapter(Activity context, string status, string message) : base()
        {
            this._context = context;
            this._status = status;
            this._url = message;
            this._image = GetImageBitmapFromUrl(message);
        }

        public override RandomDogs this[int position]
        {
            get { return null; }
        }

        public override int Count
        {
            get { return 1; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = _context.LayoutInflater.Inflate(Resource.Layout.random_row_layout, null);
            //view.FindViewById<TextView>(Resource.Id.filmNameTextField).Text = item._url;
            view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageBitmap(this._image);

            return view;
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }
}