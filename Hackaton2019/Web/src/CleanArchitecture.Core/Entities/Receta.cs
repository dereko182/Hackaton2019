using CleanArchitecture.Core.SharedKernel;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Entities
{
    public class Receta : BaseEntity
    {
        public string Nombre { get; set; }

        public int PlagaId { get; set; }
        public Plaga Plaga { get; set; }

        public ICollection<ProductoReceta> RecetaProductos { get; set; } = new List<ProductoReceta>();
    }
}
