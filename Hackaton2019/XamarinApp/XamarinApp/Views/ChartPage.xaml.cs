using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChartPage : ContentPage
    {
        public ChartPage()
        {
            //InitializeComponent();
            SfChart chart = new SfChart();
            chart.Title.Text = "Producción agrícola en el Valle";

            //Initializing primary axis
            CategoryAxis primaryAxis = new CategoryAxis();
            primaryAxis.Title.Text = "Cultivo";
            chart.PrimaryAxis = primaryAxis;

            //Initializing secondary Axis
            NumericalAxis secondaryAxis = new NumericalAxis();
            secondaryAxis.Title.Text = "Toneladas";
            chart.SecondaryAxis = secondaryAxis;

            //Initializing column series
            ColumnSeries series = new ColumnSeries();
            var vm = new ChartViewModel();

            series.ItemsSource = vm.Data;
            series.XBindingPath = "Name";
            series.YBindingPath = "Height";
            series.Label = "Cultivos";

            series.DataMarker = new ChartDataMarker();
            series.EnableTooltip = true;
            chart.Legend = new ChartLegend();

            chart.Series.Add(series);
            this.Content = chart;
        }
    }
}
