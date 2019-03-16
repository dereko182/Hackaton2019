using SharedModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamarinApp.Interfaces
{
    interface ILaborService
    {
        Task<List<LaborModel>> ObtenerTodos();
        Task<List<LaborModel>> ObtenerPorParcela(int parcelaId);
        Task<bool> CambiarEstado(LaborSimpleModel labor);
    }
}
