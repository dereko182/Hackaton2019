using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CleanArchitecture.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PlanSiembraParcela>()
                .HasKey(etm => new { etm.ParcelaId, etm.PlanSiembraId });

            builder.Entity<PlanSiembraParcela>()
                .HasOne(etm => etm.PlanSiembra)
                .WithMany(etm => etm.Parcelas)
                .HasForeignKey(etm => etm.PlanSiembraId);

            builder.Entity<PlanSiembraParcela>()
                .HasOne(etm => etm.Parcela)
                .WithMany(etm => etm.Planes)
                .HasForeignKey(etm => etm.ParcelaId);
        }

        public DbSet<Productor> Productores { get; set; }
        public DbSet<Rancho> Ranchos { get; set; }
        public DbSet<Lote> Lotes { get; set; }

        public DbSet<PlanSiembra> PlanesSiembra { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }
        public DbSet<Cultivo> Cultivos { get; set; }
        public DbSet<Fase> Fases { get; set; }
        public DbSet<Labor> Labores { get; set; }
        public DbSet<LaborParcela> LaboresParcela { get; set; }
        public DbSet<Plaga> Plagas { get; set; }
        public DbSet<PlanSiembraParcela> PlanesSiembraParcelas { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public DbSet<ProductoReceta> ProductoRecetas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Receta> Recetas { get; set; }

        public override int SaveChanges()
        {
            int result = base.SaveChanges();

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    _dispatcher.Dispatch(domainEvent);
                }
            }

            return result;
        }
    }
}
