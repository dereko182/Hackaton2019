using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using RestSharp;
using SharedModels;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using XamarinApp.Interfaces;

namespace XamarinApp.Services
{
    public class MapaService : IMapaService
    {
        private RestClient _restClient = null;
        private GeometryService _geometryService;
        private static readonly string _host = "https://hackaton2019.mnbt.co/";

        public MapaService()
        {
            _restClient = new RestClient(_host);
            _geometryService = new GeometryService();
        }

        public async Task<RanchoModel> ObtenerRancho(int ranchoId)
        {
            var request = new RestRequest("api/ObtenerRancho/{id}", Method.GET);
            request.AddUrlSegment("id", ranchoId);
            var response = await _restClient.ExecuteTaskAsync<RanchoModel>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            //var reader = new WKTReader(new GeometryFactory());
            //var listaAreas = new List<IPolygon>();
            //foreach (var wktString in response.Data)
            //{
            //    var polygon = _geometryService.FromWktString(wktString);

            //    if (polygon == null)
            //    {
            //        return null;
            //    }

            //    listaAreas.Add(polygon);
            //}

            return response.Data;
        }

        public async Task<List<LaborModel>> ObtenerLabores(int ranchoId)
        {
            var request = new RestRequest("api/Labores/{id}", Method.GET);
            request.AddUrlSegment("id", ranchoId);
            var response = await _restClient.ExecuteTaskAsync<List<LaborModel>>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data;
        }
    }
}
