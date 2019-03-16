using CleanArchitecture.Core.SharedKernel;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Entities
{
    public class Parcela : BaseEntity, ICoordenadas
    {
        public int LoteId { get; set; }
        public Lote Lote { get; set; }

        public string Nombre { get; set; }

        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Poligono { get; set; }

        public ICollection<PlanSiembraParcela> Planes { get; set; } = new List<PlanSiembraParcela>();
    }
}
