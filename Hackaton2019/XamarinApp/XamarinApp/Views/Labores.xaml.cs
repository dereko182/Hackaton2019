using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LaboresPage : ContentPage
    {
        public LaboresPage(LaboresViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}