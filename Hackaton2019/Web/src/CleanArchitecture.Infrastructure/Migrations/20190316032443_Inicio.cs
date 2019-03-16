using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cultivos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plagas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plagas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    RFC = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    RFC = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanesSiembra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InicioProgramado = table.Column<DateTime>(nullable: true),
                    FinProgramado = table.Column<DateTime>(nullable: true),
                    InicioReal = table.Column<DateTime>(nullable: true),
                    FinReal = table.Column<DateTime>(nullable: true),
                    CultivoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanesSiembra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanesSiembra_Cultivos_CultivoId",
                        column: x => x.CultivoId,
                        principalTable: "Cultivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    PlagaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recetas_Plagas_PlagaId",
                        column: x => x.PlagaId,
                        principalTable: "Plagas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ranchos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    ProductorId = table.Column<int>(nullable: false),
                    Latitud = table.Column<double>(nullable: false),
                    Longitud = table.Column<double>(nullable: false),
                    Poligono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranchos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ranchos_Productores_ProductorId",
                        column: x => x.ProductorId,
                        principalTable: "Productores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    ProveedorId = table.Column<int>(nullable: false),
                    Precio = table.Column<double>(nullable: false),
                    UnidadMedida = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Labores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    FaseId = table.Column<int>(nullable: false),
                    RequiereReceta = table.Column<bool>(nullable: false),
                    RecetaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Labores_Fases_FaseId",
                        column: x => x.FaseId,
                        principalTable: "Fases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Labores_Recetas_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Recetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Catastro = table.Column<string>(nullable: true),
                    RanchoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lotes_Ranchos_RanchoId",
                        column: x => x.RanchoId,
                        principalTable: "Ranchos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoRecetas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<double>(nullable: false),
                    UnidadMedida = table.Column<int>(nullable: false),
                    RecetaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoRecetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoRecetas_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoRecetas_Recetas_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Recetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parcelas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoteId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Latitud = table.Column<double>(nullable: false),
                    Longitud = table.Column<double>(nullable: false),
                    Poligono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcelas_Lotes_LoteId",
                        column: x => x.LoteId,
                        principalTable: "Lotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanesSiembraParcelas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ParcelaId = table.Column<int>(nullable: false),
                    PlanSiembraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanesSiembraParcelas", x => new { x.ParcelaId, x.PlanSiembraId });
                    table.ForeignKey(
                        name: "FK_PlanesSiembraParcelas_Parcelas_ParcelaId",
                        column: x => x.ParcelaId,
                        principalTable: "Parcelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanesSiembraParcelas_PlanesSiembra_PlanSiembraId",
                        column: x => x.PlanSiembraId,
                        principalTable: "PlanesSiembra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaboresParcela",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InicioProgramado = table.Column<DateTime>(nullable: true),
                    FinProgramado = table.Column<DateTime>(nullable: true),
                    InicioReal = table.Column<DateTime>(nullable: true),
                    FinReal = table.Column<DateTime>(nullable: true),
                    LaborId = table.Column<int>(nullable: false),
                    PlanSiembraParcelaId = table.Column<int>(nullable: false),
                    PlanSiembraParcelaParcelaId = table.Column<int>(nullable: true),
                    PlanSiembraParcelaPlanSiembraId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboresParcela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboresParcela_Labores_LaborId",
                        column: x => x.LaborId,
                        principalTable: "Labores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaboresParcela_PlanesSiembraParcelas_PlanSiembraParcelaParcelaId_PlanSiembraParcelaPlanSiembraId",
                        columns: x => new { x.PlanSiembraParcelaParcelaId, x.PlanSiembraParcelaPlanSiembraId },
                        principalTable: "PlanesSiembraParcelas",
                        principalColumns: new[] { "ParcelaId", "PlanSiembraId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Labores_FaseId",
                table: "Labores",
                column: "FaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Labores_RecetaId",
                table: "Labores",
                column: "RecetaId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboresParcela_LaborId",
                table: "LaboresParcela",
                column: "LaborId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboresParcela_PlanSiembraParcelaParcelaId_PlanSiembraParcelaPlanSiembraId",
                table: "LaboresParcela",
                columns: new[] { "PlanSiembraParcelaParcelaId", "PlanSiembraParcelaPlanSiembraId" });

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_RanchoId",
                table: "Lotes",
                column: "RanchoId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelas_LoteId",
                table: "Parcelas",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanesSiembra_CultivoId",
                table: "PlanesSiembra",
                column: "CultivoId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanesSiembraParcelas_PlanSiembraId",
                table: "PlanesSiembraParcelas",
                column: "PlanSiembraId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoRecetas_ProductoId",
                table: "ProductoRecetas",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoRecetas_RecetaId",
                table: "ProductoRecetas",
                column: "RecetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ProveedorId",
                table: "Productos",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranchos_ProductorId",
                table: "Ranchos",
                column: "ProductorId");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_PlagaId",
                table: "Recetas",
                column: "PlagaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaboresParcela");

            migrationBuilder.DropTable(
                name: "ProductoRecetas");

            migrationBuilder.DropTable(
                name: "Labores");

            migrationBuilder.DropTable(
                name: "PlanesSiembraParcelas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Fases");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "Parcelas");

            migrationBuilder.DropTable(
                name: "PlanesSiembra");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Plagas");

            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.DropTable(
                name: "Cultivos");

            migrationBuilder.DropTable(
                name: "Ranchos");

            migrationBuilder.DropTable(
                name: "Productores");
        }
    }
}
