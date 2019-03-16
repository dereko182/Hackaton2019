using CleanArchitecture.Core.SharedKernel;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Entities
{
    public class Plaga : BaseEntity
    {
        public string Nombre { get; set; }
        public ICollection<Receta> Recetas { get; set; } = new List<Receta>();
    }
}
