using SharedModels;
using System.Threading.Tasks;

namespace XamarinApp.Interfaces
{
   interface IMapaService
    {
        Task<RanchoModel> ObtenerRancho(int ranchoId);      
    }
}
