using Newtonsoft.Json;
using RestSharp;
using SharedModels;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using XamarinApp.Interfaces;

namespace XamarinApp.Services
{
    public class LaborService : ILaborService
    {
        private RestClient _restClient = null;
        private GeometryService _geometryService;

        public LaborService()
        {
            _restClient = new RestClient(App.ApiUrl);
            _geometryService = new GeometryService();
        }

        public async Task<List<LaborModel>> ObtenerTodos()
        {
            var request = new RestRequest("api/Labores", Method.GET);
            var response = await _restClient.ExecuteTaskAsync<List<LaborModel>>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data ?? JsonConvert.DeserializeObject<List<LaborModel>>(response.Content);
        }

        public async Task<List<LaborModel>> ObtenerPorParcela(int parcelaId)
        {
            var request = new RestRequest("api/Labores/{id}", Method.GET);
            request.AddUrlSegment("id", parcelaId);
            var response = await _restClient.ExecuteTaskAsync<List<LaborModel>>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data ?? JsonConvert.DeserializeObject<List<LaborModel>>(response.Content); 
        }

        public async Task<bool> CambiarEstado(LaborSimpleModel labor)
        {
            var request = new RestRequest("api/Labores/CambiarEstado", Method.POST);
            request.AddJsonBody(labor);

            var response = await _restClient.ExecuteTaskAsync<bool>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                return false;

            return response.Data == null ? JsonConvert.DeserializeObject<bool>(response.Content) : false;
        }
    }
}
