using System;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            // OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
            OpenWebCommand = new Command(async () => await VerLabores());

        }

        public ICommand OpenWebCommand { get; }

        private async Task VerLabores()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new LaboresPage(new LaboresViewModel())));
        }
    }
}