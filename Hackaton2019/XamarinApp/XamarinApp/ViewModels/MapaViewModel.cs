using Acr.UserDialogs;
using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using SharedModels;
using Syncfusion.XForms.Backdrop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using XamarinApp.Services;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    public class MapaViewModel : BaseViewModel
    {
        public ObservableCollection<Xamarin.Forms.GoogleMaps.Polygon> Polygons { get; set; }
        public ObservableCollection<Pin> Pins { get; set; }
        public Map Mapa { get; set; }
        public StackLayout SlBackLayer { get; set; }
        public SfBackdropPage BackdropPage { get; set; }
        private MapaService _mapaService;
        private IUserDialogs _userDialogs;
        private GeometryService _geometryService;

        private RanchoModel _rancho;
        public RanchoModel Rancho
        {
            get => _rancho;
            set => SetProperty(ref _rancho, value);
        }

        private ParcelaModel _parcelaSeleccionada;
        public ParcelaModel ParcelaSeleccionada
        {
            get => _parcelaSeleccionada;
            set => SetProperty(ref _parcelaSeleccionada, value);
        }

        public Command<MapClickedEventArgs> MapClickedCommand => new Command<MapClickedEventArgs>(async (obj) => await ExecuteMap(obj));
        public Command<InfoWindowClickedEventArgs> InfoClickedCommand => new Command<InfoWindowClickedEventArgs>(ExecuteInfo);
        public Command AppearingCommand => new Command(async () => await ExecuteAppearingCommand());
        public Command VerLaboresCommand => new Command(async () => await ExecuteVerLabores());
        public Command VerReportesCommand => new Command(async () => await ExecuteVerReportes());

        private async Task ExecuteVerLabores()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new LaboresPage(new LaboresViewModel())));
        }
        
        private async Task ExecuteVerReportes()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new ChartPage()));
        }

        public MapaViewModel()
        {
            _mapaService = new MapaService();
            _userDialogs = UserDialogs.Instance;
            _geometryService = new GeometryService();
        }

        private async Task ExecuteAppearingCommand()
        {
            _userDialogs.ShowLoading("Ubicando rancho...");
            await CargaDatos();
            _userDialogs.HideLoading();
        }

        private async Task CargaDatos()
        {            
            Rancho = await _mapaService.ObtenerRancho(1);
            Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Rancho.Latitud, Rancho.Longitud), new Distance(500)), true);
            ObtenerPoligonosRancho();
        }

        private void ObtenerPoligonosRancho()
        {
            Pins.Add(new Pin
            {
                Type = PinType.SearchResult,
                Label = Rancho.Nombre,
                Address = Rancho.Productor.Nombre,
                Position = new Position(Rancho.Latitud, Rancho.Longitud),
                IsDraggable = false,
            });

            var iPolygons = new List<IPolygon>();

            var poligonos = new List<string>
            {
                Rancho.Poligono
            };

            poligonos.AddRange(Rancho.Lotes.First().Parcelas.Select(s => s.Poligono));

            foreach (var poligono in poligonos)
            {
                var reader = new WKTReader(new GeometryFactory());
                var listaAreas = new List<IPolygon>();

                var polygon = _geometryService.FromWktString(poligono);             

                iPolygons.Add(polygon);
            }

            foreach (var parcela in Rancho.Lotes.First().Parcelas)
            {
                Pins.Add(new Pin
                {
                    Type = PinType.SearchResult,
                    Label = parcela.Nombre,
                    Address = Rancho.Nombre,
                    Position = new Position(parcela.Latitud, parcela.Longitud),
                    IsDraggable = false,
                });

                foreach (var iPolygon in iPolygons)
                {
                    var poligonoParcela = _geometryService.ToMapPolygon(iPolygon);

                    poligonoParcela.StrokeWidth = 3;
                    poligonoParcela.StrokeColor = Color.FromHex("#2D9CDB");
                    poligonoParcela.FillColor = Color.FromHex("#332D9CDB");
                    poligonoParcela.IsClickable = true;
                    poligonoParcela.Clicked += new EventHandler(ExecutePolygon);
                    poligonoParcela.Tag = parcela.Id;                    

                    Polygons.Add(poligonoParcela);
                } 
            }
        }

        private void ExecuteInfo(InfoWindowClickedEventArgs obj)
        {
            BackdropPage.IsBackLayerRevealed = true;
        }

        private async Task ExecuteMap(MapClickedEventArgs obj)
        {
            //IsBusy = true;
            //_userDialogs.ShowLoading("Cargando datos parcela...");
            //var rancho = await _mapaService.ObtenerRancho(1);
            //_userDialogs.HideLoading();
            //IsBusy = false;

            //Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(32.62217d, -115.5156767d), new Distance(100)), true);

            //var position = obj.Point;

            //var polygon = new Polygon();
            //polygon.Positions.Add(new Position(32.6224915d, -115.5213733d));
            //polygon.Positions.Add(new Position(32.621784d, -115.516213d));
            //polygon.Positions.Add(new Position(32.621765d, -115.514809d));
            //polygon.Positions.Add(new Position(32.622270d, -115.514863d));
            //polygon.IsClickable = true;
            //polygon.StrokeColor = Color.Green;
            //polygon.StrokeWidth = 3f;
            //polygon.FillColor = Color.FromRgba(255, 0, 0, 64);
            //polygon.Tag = "POLYGON"; // Can set any object
            ////polygon.Clicked += Polygon_Clicked;
            //polygon.Clicked += new EventHandler(ExecutePolygon);

            //Polygons.Add(polygon);

            //var pinMexicali = new Pin()
            //{
            //    Type = PinType.SearchResult,
            //    Label = "Parcel 12 - Marieta",
            //    Address = "Rancho del pitayo",
            //    Position = new Position(32.62217d, -115.5156767d),
            //    IsDraggable = false,
            //    InfoWindowAnchor = new Point(new Size(300, 300))
            //};

            //Pins.Add(pinMexicali);
        }

        private void ExecutePolygon(object sender, EventArgs e)
        {
            var poligono = (Xamarin.Forms.GoogleMaps.Polygon)sender;
            var parcelaSeleccionadaId = Convert.ToInt32(poligono.Tag);

            BackdropPage.IsBackLayerRevealed = true;
            ParcelaSeleccionada = Rancho.Lotes.First().Parcelas.Where(w => w.Id == parcelaSeleccionadaId).Select(s => new ParcelaModel
            {
                Id = s.Id,
                Latitud = s.Latitud,
                Longitud = s.Longitud,
                Nombre = s.Nombre,                
            }).FirstOrDefault();

            //var polygon = (Polygon)sender;

            //SlBackLayer.Children.Add(new Label
            //{
            //    Text = $"HOLA MUNDO!!! Poligono Latitud: {polygon.Positions.First().Latitude}, Longitud: {polygon.Positions.First().Longitude}"
            //});            
        }
    }
}
