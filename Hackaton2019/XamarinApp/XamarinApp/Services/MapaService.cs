using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using RestSharp;
using SharedModels;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace XamarinApp.Services
{
    public class MapaService
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
            var request = new RestRequest("api/ranchos/{id}", Method.GET);
            request.AddUrlSegment("id", ranchoId);
            var response = await _restClient.ExecuteTaskAsync<RanchoModel>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data ?? JsonConvert.DeserializeObject<RanchoModel>(response.Content);
        }
    }
}
