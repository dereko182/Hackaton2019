using CleanArchitecture.Core.SharedKernel;

namespace CleanArchitecture.Core.Entities
{
    public class Producto : BaseEntity
    {
        public string Nombre { get; set; }

        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        public double Precio { get; set; }

        public UnidadMedida UnidadMedida { get; set; }
    }
}