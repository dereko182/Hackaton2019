using CleanArchitecture.Core.SharedKernel;

namespace CleanArchitecture.Core.Entities
{
    public class ProductoReceta : BaseEntity
    {
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public double Cantidad { get; set; }
        public UnidadMedida UnidadMedida { get; set; }

        public int RecetaId { get; set; }
        public Receta Receta { get; set; }
    }
}
