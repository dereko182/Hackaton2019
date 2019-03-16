using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Models
{
    public class PlanSiembraModel
    {
        public int Id { get; set; }
        public DateTime? InicioProgramado { get; set; }
        public DateTime? FinProgramado { get; set; }
        public DateTime? InicioReal { get; set; }
        public DateTime? FinReal { get; set; }
        public string Cultivo { get; set; }
        public int CultivoId { get; set; }
        public List<Cultivo> CultivosDisponibles { get; set; }
        //public Cultivo Cultivo { get; set; }
    }
}
