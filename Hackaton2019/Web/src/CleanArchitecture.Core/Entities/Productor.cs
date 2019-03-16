using CleanArchitecture.Core.SharedKernel;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Entities
{
    public class Productor : BaseEntity
    {
        public string Nombre { get; set; }
        public string RFC { get; set; }

        public ICollection<Rancho> Ranchos { get; set; } = new List<Rancho>();
    }
}
