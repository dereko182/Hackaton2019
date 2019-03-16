using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comentario",
                table: "LaboresParcela",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Costo",
                table: "LaboresParcela",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Estatus",
                table: "LaboresParcela",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentario",
                table: "LaboresParcela");

            migrationBuilder.DropColumn(
                name: "Costo",
                table: "LaboresParcela");

            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "LaboresParcela");
        }
    }
}
