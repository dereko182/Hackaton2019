using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinApp
{
    public partial class App : Application
    {
        public App()
        {
            var syncfusionKey = "Nzc4MzFAMzEzNjJlMzQyZTMwWDh0QWc0MmJXSHllVjNyelFFODV3VW9La1A1OEdWdTBUL2NLWFJZRm4vdz0=;Nzc4MzJAMzEzNjJlMzQyZTMwZmJIUHhweXFwUW80UFdtVVkxNU1hd2FEazlFNU9FcENiY2RLSHZKcVZFOD0=;Nzc4MzNAMzEzNjJlMzQyZTMwU2pCenBqQitJZXFPNHFMRlVyb0ZKRWN4Yk9sNzNrdGprOXZZMHArOE9VOD0=;Nzc4MzRAMzEzNjJlMzQyZTMwWUZnYlZ1TmdDUTk1WWZ6SFlmYUZpSjA1d1poTGVTUmpMRkp3b3BsWUplYz0=";
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(syncfusionKey);

            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
