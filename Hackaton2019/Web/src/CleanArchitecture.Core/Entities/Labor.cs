using CleanArchitecture.Core.SharedKernel;

namespace CleanArchitecture.Core.Entities
{
    public class Labor : BaseEntity
    {
        public string Nombre { get; set; }

        public int FaseId { get; set; }
        public Fase Fase { get; set; }

        public bool RequiereReceta { get; set; }

        public int? RecetaId { get; set; }
        public Receta Receta { get; set; }
    }
}
