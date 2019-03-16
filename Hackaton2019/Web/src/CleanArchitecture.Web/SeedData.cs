using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace CleanArchitecture.Web
{
    public static class SeedData
    {
        public static void PopulateTestData(this AppDbContext dbContext)
        {
            if (!EnumerableExtensions.Any(dbContext.Productores))
            {
                dbContext.Productores.AddRange(new[] { "Jaime Ramírez Parra", "" }.Select(x => new Productor { Nombre = x }));
                dbContext.SaveChanges();
            }

            var i = 0;
            dbContext.SaveChanges();

            var productores = dbContext.Productores.ToArray();

            dbContext.Ranchos.AddRange(new[] { "Los Manantiales", "Constitución", "Insurgentes" }.Select(x =>
            {
                var rancho = new Rancho() { Nombre = x };
                i++;

                rancho.ProductorId = i % 2 == 0 ? productores[0].Id : productores[1].Id;
                return rancho;
            }));

            dbContext.SaveChanges();

            var ranchos = dbContext.Ranchos.ToArray();

            ranchos[0].Lotes.Add(new Lote { Nombre = "1", Catastro = "9872023 VH5797S 0001 WX" });
            ranchos[0].Lotes.Add(new Lote { Nombre = "2", Catastro = "13 077 A 018 00039 0000 FP" });
            ranchos[1].Lotes.Add(new Lote { Nombre = "1", Catastro = "9872023 VH5797S 0001 WX" });
            ranchos[1].Lotes.Add(new Lote { Nombre = "2", Catastro = "13 077 A 018 00039 0000 FP" });
            ranchos[2].Lotes.Add(new Lote { Nombre = "1", Catastro = "13 088 B 018 00039 0000 FP" });
        }
    }
}
