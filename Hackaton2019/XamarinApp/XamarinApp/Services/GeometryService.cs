using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System;
using Xamarin.Forms.GoogleMaps;
using XamarinApp.Interfaces;

namespace XamarinApp.Services
{
    class GeometryService : IGeometryService
    {
        public const int WGS84_SRID = 4326;

        public IPoint FromMapPosition(Position position)
        {
            var point = new Point(position.Longitude, position.Latitude);
            point.SRID = WGS84_SRID;
            return point;
        }

        public double GetDistance(IPoint pos1, IPoint pos2)
        {
            var lat1 = pos1.Y;
            var lon1 = pos1.X;
            var lat2 = pos2.Y;
            var lon2 = pos2.X;

            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double rlon1 = Math.PI * lon1 / 180;
            double rlon2 = Math.PI * lon2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;
            dist = Math.Round(dist * 1609.344, 2) + .01;
            return dist;
        }

        public bool IsPositionInPolygon(IPoint position, IPolygon polygon)
        {
            return polygon.Contains(position);
        }

        public Xamarin.Forms.GoogleMaps.Polygon ToMapPolygon(IPolygon polygon)
        {
            var mapsPolygon = new Xamarin.Forms.GoogleMaps.Polygon();

            foreach (var coords in polygon.Coordinates)
            {
                var point = new Point(coords);
                mapsPolygon.Positions.Add(ToMapPosition(point));
            }

            return mapsPolygon;
        }

        public Position ToMapPosition(IPoint point)
        {
            var position = new Position(point.Y, point.X);
            return position;
        }

        public IPolygon FromWktString(string WktString)
        {
            try
            {
                var precisionModel = new PrecisionModel();
                var geometryFactory = new GeometryFactory(precisionModel, WGS84_SRID);
                var reader = new WKTReader(geometryFactory);
                var geometry = reader.Read(WktString);

                if (geometry is IPolygon)
                {
                    return geometry as IPolygon;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public GeometryService()
        {
            GeoAPI.NetTopologySuiteBootstrapper.Bootstrap();
        }
    }
}
