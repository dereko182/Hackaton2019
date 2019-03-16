using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Data;

namespace CleanArchitecture.Web
{
    public static class SeedData
    {
        public static void PopulateTestData(this AppDbContext dbContext)
        {
            var toDos = dbContext.Ranchos;
            foreach (var item in toDos)
            {
                dbContext.Remove(item);
            }

            dbContext.SaveChanges();
            dbContext.Ranchos.Add(new Rancho()
            {
                Nombre = "Insurgentes"
            });
            dbContext.SaveChanges();
        }
    }
}
