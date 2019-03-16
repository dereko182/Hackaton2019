using Syncfusion.XForms.Backdrop;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace XamarinApp.ViewModels
{
    public class MapaViewModel : BaseViewModel
    {
        public ObservableCollection<Polygon> Polygons { get; set; }
        public ObservableCollection<Pin> Pins { get; set; }
        public Map Mapa { get; set; }
        public StackLayout SlBackLayer { get; set; }
        public SfBackdropPage BackdropPage { get; set; }

        public Command<MapClickedEventArgs> MapClickedCommand => new Command<MapClickedEventArgs>(ExecuteMap);
        public Command<InfoWindowClickedEventArgs> InfoClickedCommand => new Command<InfoWindowClickedEventArgs>(ExecuteInfo);

        private void ExecuteInfo(InfoWindowClickedEventArgs obj)
        {
            BackdropPage.IsBackLayerRevealed = true;
        }

        private void ExecuteMap(MapClickedEventArgs obj)
        {
            Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(32.62217d, -115.5156767d), new Distance(100)), true);

            var position = obj.Point;

            var polygon = new Polygon();
            polygon.Positions.Add(new Position(32.6224915d, -115.5213733d));
            polygon.Positions.Add(new Position(32.621784d, -115.516213d));
            polygon.Positions.Add(new Position(32.621765d, -115.514809d));
            polygon.Positions.Add(new Position(32.622270d, -115.514863d));
            polygon.IsClickable = true;
            polygon.StrokeColor = Color.Green;
            polygon.StrokeWidth = 3f;
            polygon.FillColor = Color.FromRgba(255, 0, 0, 64);
            polygon.Tag = "POLYGON"; // Can set any object
            //polygon.Clicked += Polygon_Clicked;
            polygon.Clicked += new EventHandler(ExecutePolygon);

            Polygons.Add(polygon);

            var pinMexicali = new Pin()
            {
                Type = PinType.SearchResult,
                Label = "Parcel 12 - Marieta",
                Address = "Rancho del pitayo",
                Position = new Position(32.62217d, -115.5156767d),
                IsDraggable = false,
                InfoWindowAnchor = new Point(new Size(300, 300))
            };

            Pins.Add(pinMexicali);
        }

        private void ExecutePolygon(object sender, EventArgs e)
        {
            var polygon = (Polygon)sender;

            SlBackLayer.Children.Add(new Label
            {
                Text = $"HOLA MUNDO!!! Poligono Latitud: {polygon.Positions.First().Latitude}, Longitud: {polygon.Positions.First().Longitude}"
            });

            BackdropPage.IsBackLayerRevealed = true;
        }
    }
}
