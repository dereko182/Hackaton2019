using GeoAPI.Geometries;

namespace XamarinApp.Interfaces
{
    public interface IGeometryService
    {
        Xamarin.Forms.GoogleMaps.Position ToMapPosition(IPoint point);
        Xamarin.Forms.GoogleMaps.Polygon ToMapPolygon(IPolygon polygon);

        IPoint FromMapPosition(Xamarin.Forms.GoogleMaps.Position position);

        IPolygon FromWktString(string WktString);

        bool IsPositionInPolygon(IPoint position, IPolygon polygon);
        double GetDistance(IPoint pos1, IPoint pos2);

    }
}
