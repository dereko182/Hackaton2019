using Android.App;
using Android.Content.PM;
using Android.OS;

namespace XamarinApp.Droid
{
    [Activity(Label = "XamarinApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            var syncfusionKey = "Nzc4MzFAMzEzNjJlMzQyZTMwWDh0QWc0MmJXSHllVjNyelFFODV3VW9La1A1OEdWdTBUL2NLWFJZRm4vdz0=;Nzc4MzJAMzEzNjJlMzQyZTMwZmJIUHhweXFwUW80UFdtVVkxNU1hd2FEazlFNU9FcENiY2RLSHZKcVZFOD0=;Nzc4MzNAMzEzNjJlMzQyZTMwU2pCenBqQitJZXFPNHFMRlVyb0ZKRWN4Yk9sNzNrdGprOXZZMHArOE9VOD0=;Nzc4MzRAMzEzNjJlMzQyZTMwWUZnYlZ1TmdDUTk1WWZ6SFlmYUZpSjA1d1poTGVTUmpMRkp3b3BsWUplYz0=";
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(syncfusionKey);
            base.OnCreate(savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsGoogleMaps.Init(this, savedInstanceState);
            Xamarin.FormsGoogleMapsBindings.Init();
            LoadApplication(new App());
        }
    }
}