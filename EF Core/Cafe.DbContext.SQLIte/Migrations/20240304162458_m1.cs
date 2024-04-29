using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cafe.DbContext.SQLIte.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClientTables",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Столик біля вікна" },
                    { 2, "Столик 1" },
                    { 3, "Столик 2" }
                });

            migrationBuilder.InsertData(
                table: "Nomenclatures",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Суп гороховий", 45.0 },
                    { 2, "Суп сирний", 75.0 },
                    { 3, "Суп харчо", 55.0 },
                    { 4, "Лоці", 105.0 },
                    { 5, "Картопля фрі", 60.0 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Date", "Bill", "ClientTableId", "Id", "WaiterId" },
                values: new object[,]
                {
                    { new DateTime(2024, 3, 4, 18, 24, 57, 518, DateTimeKind.Local).AddTicks(7131), 0.0, 1, 1, 1 },
                    { new DateTime(2024, 3, 4, 18, 24, 57, 518, DateTimeKind.Local).AddTicks(7180), 0.0, 2, 2, 1 },
                    { new DateTime(2024, 3, 4, 18, 24, 57, 518, DateTimeKind.Local).AddTicks(7184), 0.0, 3, 3, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nomenclatures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nomenclatures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Nomenclatures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Nomenclatures",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Nomenclatures",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Date",
                keyValue: new DateTime(2024, 3, 4, 18, 24, 57, 518, DateTimeKind.Local).AddTicks(7131));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Date",
                keyValue: new DateTime(2024, 3, 4, 18, 24, 57, 518, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Date",
                keyValue: new DateTime(2024, 3, 4, 18, 24, 57, 518, DateTimeKind.Local).AddTicks(7184));

            migrationBuilder.DeleteData(
                table: "ClientTables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientTables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClientTables",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
