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

            //var vibrator = (Vibrator)this.GetSystemService(Context.VibratorService);
            //vibrator.Vibrate(15000);

            var level = Battery.ChargeLevel; // returns 0.0 to 1.0 or 1.0 when on AC or no battery.
            Console.WriteLine("Battery level " + level);

            var state = Battery.State;
            Console.WriteLine("Battery state " + state);

            var source = Battery.PowerSource;
            Console.WriteLine("Battery source " + source);

            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    await SpeakNowDefaultSettings("Your latitude is " + location.Latitude.ToString());
                    await SpeakNowDefaultSettings("Your longitude is " + location.Longitude.ToString());
                    await SpeakNowDefaultSettings("Your altitude is " + location.Altitude.ToString());

                    Location kool = new Location(59.4286489, 24.7339675);
                    double miles = Location.CalculateDistance(kool, location, DistanceUnits.Kilometers);

                    await SpeakNowDefaultSettings("Your distance from school is " + miles.ToString());
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            await SpeakNowDefaultSettings("Your battery level is " + level.ToString());
            SpeakNowDefaultSettings2();
            await SpeakNow();

            

        }

        public async Task NavigateToBuilding()
        {
            var location = new Location(47.645160, -122.1306032);
            var options = new MapLaunchOptions { Name = "Microsoft building" };
            await Map.OpenAsync(location, options);
        }

        public async Task SpeakNowDefaultSettings(string text)
        {
            await TextToSpeech.SpeakAsync(text);

            // This method will block until utterance finishes.
        }

        public void SpeakNowDefaultSettings2()
        {
            TextToSpeech.SpeakAsync("Hello World").ContinueWith((t) =>
            {
                // Logic that will run after utterance finishes.

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public async Task SpeakNow()
        {
            var settings = new SpeechOptions()
            {
                Volume = .75f,
                Pitch = 1.0f
            };

            await TextToSpeech.SpeakAsync("My name is Erik", settings);
        }
    }
}