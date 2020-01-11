using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using DogPicApp;
using StarwarsApp.Core.Models;

namespace StarwarsApp
{
    public class BreedAdapter : BaseAdapter<Breeds>
    {
        List<string> _breeds;
        Activity _context;

        public BreedAdapter(Activity context, List<string> breeds) : base()
        {
            this._context = context;
            this._breeds = breeds;
        }

        public override Breeds this[int position]
        {
            get { return null; }
        }

        public override int Count
        {
            get { return _breeds.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = _context.LayoutInflater.Inflate(Resource.Layout.breeds_row_layout, null);
            //view.FindViewById<TextView>(Resource.Id.textView1).Text = this._breeds[position];
            return view;
        }
    }

}