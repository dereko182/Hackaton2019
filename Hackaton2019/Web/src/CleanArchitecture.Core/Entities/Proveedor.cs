using System.Collections.Generic;
using CleanArchitecture.Core.SharedKernel;

namespace CleanArchitecture.Core.Entities
{
    public class Proveedor : BaseEntity
    {
        public string Nombre { get; set; }
        public string RFC { get; set; }

        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}