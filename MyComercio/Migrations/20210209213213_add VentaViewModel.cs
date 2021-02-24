using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyComercio.Migrations
{
    public partial class addVentaViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Venta");

            migrationBuilder.RenameColumn(
                name: "Observaciones",
                table: "VentaDetalle",
                newName: "Cantidad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "VentaDetalle",
                newName: "Observaciones");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Venta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
