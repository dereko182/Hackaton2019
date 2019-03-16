using XamarinApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.XForms.Backdrop;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapaPage : SfBackdropPage
    {
        public MapaPage()
        {
            InitializeComponent();

            var vm = (MapaViewModel)BindingContext;
            vm.Mapa = map;
            vm.BackdropPage = this;
            vm.SlBackLayer = backdropPage.FindByName<StackLayout>("slBackLayer");
        }
    }
}