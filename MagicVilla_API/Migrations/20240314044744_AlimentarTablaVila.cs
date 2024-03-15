using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTablaVila : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "amenidad", "detalle", "fechaActualizacion", "fechaCreacion", "imagenUrl", "metrocuadrado", "nombre", "ocupante", "tarifa" },
                values: new object[,]
                {
                    { 1, "", "Es verde", new DateTime(2024, 3, 13, 22, 47, 44, 617, DateTimeKind.Local).AddTicks(872), new DateTime(2024, 3, 13, 22, 47, 44, 617, DateTimeKind.Local).AddTicks(859), "", 50.0, "Villa real", 5, 50.0 },
                    { 2, "", "Es azul", new DateTime(2024, 3, 13, 22, 47, 44, 617, DateTimeKind.Local).AddTicks(875), new DateTime(2024, 3, 13, 22, 47, 44, 617, DateTimeKind.Local).AddTicks(874), "", 25.0, "Villa azul", 6, 80.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
