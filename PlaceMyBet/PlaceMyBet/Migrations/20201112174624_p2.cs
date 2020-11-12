using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlaceMyBet.Migrations
{
    public partial class p2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaId", "Cuota", "DineroApostado", "FechaApuesta", "MercadoId", "TipoApuesta", "UsuarioId" },
                values: new object[] { 3, 2.8500000000000001, 300.0, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, "1000@qq.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apuestas",
                keyColumn: "ApuestaId",
                keyValue: 3);
        }
    }
}
