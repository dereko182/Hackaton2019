using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Core.Extensions;
using CleanArchitecture.Core.SharedKernel;

namespace CleanArchitecture.Core.Entities
{
    public class Cultivo : BaseEntity
    {
        public string Nombre { get; set; }

        public ICollection<PlanSiembra> PlanesSiembra { get; set; } = new List<PlanSiembra>();

        public static List<Cultivo> Seed()
        {
            var str =
                "Trigo, cebada, algodón, alfalfa, avena, ajonjolí, cártamo, sorgo forrajero, hortalizas, chile, cebolla, col, rabanito, cilantro, lechuga, brócoli, betabel, coliflor, jitomate, tomatillo, pepino, calabaza, quelite, espárrago, sandía, melón, maíz, elote, vid, nopal, frijol";
            return str.Split(',').Select(x => new Cultivo
            {
                Nombre = StringExtensions.FirstCharToUpper(x.Trim())
            }).ToList();
        }
    }
}