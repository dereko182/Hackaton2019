using CleanArchitecture.Core.Entities;

namespace SharedModels
{
    public class ProductoRecetaModel : ProductoReceta
    {
        public string NombreProducto { get; set; }
        public string CantidadProducto { get; set; }
        public string UnidadMedidaProducto { get; set; }
    }
}
