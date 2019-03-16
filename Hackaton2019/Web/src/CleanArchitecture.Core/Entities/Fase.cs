using System.Collections.Generic;
using CleanArchitecture.Core.SharedKernel;

namespace CleanArchitecture.Core.Entities
{
    public class Fase : BaseEntity
    {
        public string Nombre { get; set; }
        public ICollection<Labor> Labores { get; set; } = new List<Labor>();
    }
}