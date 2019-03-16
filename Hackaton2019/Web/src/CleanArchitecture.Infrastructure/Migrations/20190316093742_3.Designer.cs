﻿// <auto-generated />
using System;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArchitecture.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190316093742_3")]
    partial class _3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Cultivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Cultivos");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Fase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Fases");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Labor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FaseId");

                    b.Property<string>("Nombre");

                    b.Property<int?>("RecetaId");

                    b.Property<bool>("RequiereReceta");

                    b.HasKey("Id");

                    b.HasIndex("FaseId");

                    b.HasIndex("RecetaId");

                    b.ToTable("Labores");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.LaborParcela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comentario");

                    b.Property<double>("Costo");

                    b.Property<int>("Estatus");

                    b.Property<DateTime?>("FinProgramado");

                    b.Property<DateTime?>("FinReal");

                    b.Property<DateTime?>("InicioProgramado");

                    b.Property<DateTime?>("InicioReal");

                    b.Property<int>("LaborId");

                    b.Property<int>("PlanSiembraParcelaId");

                    b.Property<int?>("PlanSiembraParcelaParcelaId");

                    b.Property<int?>("PlanSiembraParcelaPlanSiembraId");

                    b.HasKey("Id");

                    b.HasIndex("LaborId");

                    b.HasIndex("PlanSiembraParcelaParcelaId", "PlanSiembraParcelaPlanSiembraId");

                    b.ToTable("LaboresParcela");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Lote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Catastro");

                    b.Property<string>("Nombre");

                    b.Property<int?>("RanchoId");

                    b.HasKey("Id");

                    b.HasIndex("RanchoId");

                    b.ToTable("Lotes");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Parcela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color");

                    b.Property<double>("Latitud");

                    b.Property<double>("Longitud");

                    b.Property<int>("LoteId");

                    b.Property<string>("Nombre");

                    b.Property<string>("Poligono");

                    b.HasKey("Id");

                    b.HasIndex("LoteId");

                    b.ToTable("Parcelas");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Plaga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Plagas");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.PlanSiembra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CultivoId");

                    b.Property<DateTime?>("FinProgramado");

                    b.Property<DateTime?>("FinReal");

                    b.Property<DateTime?>("InicioProgramado");

                    b.Property<DateTime?>("InicioReal");

                    b.HasKey("Id");

                    b.HasIndex("CultivoId");

                    b.ToTable("PlanesSiembra");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.PlanSiembraParcela", b =>
                {
                    b.Property<int>("ParcelaId");

                    b.Property<int>("PlanSiembraId");

                    b.Property<int>("Id");

                    b.HasKey("ParcelaId", "PlanSiembraId");

                    b.HasIndex("PlanSiembraId");

                    b.ToTable("PlanesSiembraParcelas");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria");

                    b.Property<string>("Nombre");

                    b.Property<double>("Precio");

                    b.Property<int>("ProveedorId");

                    b.Property<int>("UnidadMedida");

                    b.HasKey("Id");

                    b.HasIndex("ProveedorId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Productor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.Property<string>("RFC");

                    b.HasKey("Id");

                    b.ToTable("Productores");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.ProductoReceta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cantidad");

                    b.Property<int>("ProductoId");

                    b.Property<int>("RecetaId");

                    b.Property<int>("UnidadMedida");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("RecetaId");

                    b.ToTable("ProductoRecetas");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.Property<string>("RFC");

                    b.HasKey("Id");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Rancho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Latitud");

                    b.Property<double>("Longitud");

                    b.Property<string>("Nombre");

                    b.Property<string>("Poligono");

                    b.Property<int>("ProductorId");

                    b.HasKey("Id");

                    b.HasIndex("ProductorId");

                    b.ToTable("Ranchos");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Receta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.Property<int>("PlagaId");

                    b.HasKey("Id");

                    b.HasIndex("PlagaId");

                    b.ToTable("Recetas");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Labor", b =>
                {
                    b.HasOne("CleanArchitecture.Core.Entities.Fase", "Fase")
                        .WithMany("Labores")
                        .HasForeignKey("FaseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CleanArchitecture.Core.Entities.Receta", "Receta")
                        .WithMany()
                        .HasForeignKey("RecetaId");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.LaborParcela", b =>
                {
                    b.HasOne("CleanArchitecture.Core.Entities.Labor", "Labor")
                        .WithMany()
                        .HasForeignKey("LaborId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CleanArchitecture.Core.Entities.PlanSiembraParcela", "PlanSiembraParcela")
                        .WithMany("LaboresParcela")
                        .HasForeignKey("PlanSiembraParcelaParcelaId", "PlanSiembraParcelaPlanSiembraId");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Lote", b =>
                {
                    b.HasOne("CleanArchitecture.Core.Entities.Rancho")
                        .WithMany("Lotes")
                        .HasForeignKey("RanchoId");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Parcela", b =>
                {
                    b.HasOne("CleanArchitecture.Core.Entities.Lote", "Lote")
                        .WithMany("Parcelas")
                        .HasForeignKey("LoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.PlanSiembra", b =>
                {
                    b.HasOne("CleanArchitecture.Core.Entities.Cultivo", "Cultivo")
                        .WithMany("PlanesSiembra")
                        .HasForeignKey("CultivoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.PlanSiembraParcela", b =>
                {
                    b.HasOne("CleanArchitecture.Core.Entities.Parcela", "Parcela")
                        .WithMany("Planes")
                        .HasForeignKey("ParcelaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CleanArchitecture.Core.Entities.PlanSiembra", "PlanSiembra")
                        .WithMany("Parcelas")
                        .HasForeignKey("PlanSiembraId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Producto", b =>
                {
                    b.HasOne("CleanArchitecture.Core.Entities.Proveedor", "Proveedor")
                        .WithMany("Productos")
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.ProductoReceta", b =>
                {
                    b.HasOne("CleanArchitecture.Core.Entities.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CleanArchitecture.Core.Entities.Receta", "Receta")
                        .WithMany("RecetaProductos")
                        .HasForeignKey("RecetaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Rancho", b =>
                {
                    b.HasOne("CleanArchitecture.Core.Entities.Productor", "Productor")
                        .WithMany("Ranchos")
                        .HasForeignKey("ProductorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Receta", b =>
                {
                    b.HasOne("CleanArchitecture.Core.Entities.Plaga", "Plaga")
                        .WithMany("Recetas")
                        .HasForeignKey("PlagaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}