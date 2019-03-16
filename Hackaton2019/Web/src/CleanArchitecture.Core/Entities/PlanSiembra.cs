using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Entities
{
    public class PlanSiembra : BaseEntity, IRangoFechas
    {
        public DateTime? InicioProgramado { get; set; }
        public DateTime? FinProgramado { get; set; }
        public DateTime? InicioReal { get; set; }
        public DateTime? FinReal { get; set; }

        public int CultivoId { get; set; }
        public Cultivo Cultivo { get; set; }

        public ICollection<PlanSiembraParcela> Parcelas { get; set; } = new List<PlanSiembraParcela>();
    }
}
