using System;

namespace CleanArchitecture.Core.Entities
{
    public interface IRangoFechas
    {
        DateTime? InicioProgramado { get; set; }
        DateTime? FinProgramado { get; set; }
        DateTime? InicioReal { get; set; }
        DateTime? FinReal { get; set; }
    }
}
