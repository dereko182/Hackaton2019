using CleanArchitecture.Core.SharedKernel;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Entities
{
    public class PlanSiembraParcela : BaseEntity
    {
        public int ParcelaId { get; set; }
        public Parcela Parcela { get; set; }

        public int PlanSiembraId { get; set; }
        public PlanSiembra PlanSiembra { get; set; }

        public ICollection<LaborParcela> LaboresParcela { get; set; } = new List<LaborParcela>();
    }
}
