using CleanArchitecture.Core.SharedKernel;
using System;

namespace CleanArchitecture.Core.Entities
{
    public class LaborParcela : BaseEntity, IRangoFechas
    {
        public DateTime? InicioProgramado { get; set; }
        public DateTime? FinProgramado { get; set; }
        public DateTime? InicioReal { get; set; }
        public DateTime? FinReal { get; set; }

        public int LaborId { get; set; }
        public Labor Labor { get; set; }

        public int PlanSiembraParcelaId { get; set; }
        public PlanSiembraParcela PlanSiembraParcela { get; set; }
    }
}
