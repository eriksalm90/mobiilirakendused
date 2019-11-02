using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace SecondApp
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.second_layout);
            var text = Intent.GetStringExtra("editextvalue");

            var textView = FindViewById<TextView>(Resource.Id.textView1);
            textView.Text = text;

            //XAMARIN ESSENTIALS OSA

            var appName = AppInfo.Name;
            var packageName = AppInfo.PackageName;
            var version = AppInfo.VersionString;
            var build = AppInfo.BuildString;

            AppInfo.ShowSettingsUI();

            //var duration = TimeSpan.FromSeconds(10);
            //Vibration.Vibrate(duration);
            //await NavigateToBuilding();

            var vibrator = (Vibrator)this.GetSystemService(Context.VibratorService);
            vibrator.Vibrate(15000);
        }

        public async Task NavigateToBuilding()
        {
            var location = new Location(47.645160, -122.1306032);
            var options = new MapLaunchOptions { Name = "Microsoft building" };
            await Map.OpenAsync(location, options);
        }
    }
}