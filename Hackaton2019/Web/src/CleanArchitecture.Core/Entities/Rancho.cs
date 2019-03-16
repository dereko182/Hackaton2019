using CleanArchitecture.Core.SharedKernel;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Entities
{
    public class Rancho : BaseEntity, ICoordenadas
    {
        public string Nombre { get; set; }

        public int ProductorId { get; set; }
        public Productor Productor { get; set; }

        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Poligono { get; set; }

        public ICollection<Lote> Lotes { get; set; } = new List<Lote>();

    }

    public class Lote : BaseEntity
    {
        public string Nombre { get; set; }
        public string Catastro { get; set; }
        public ICollection<Parcela> Parcelas { get; set; } = new List<Parcela>();
    }
}
