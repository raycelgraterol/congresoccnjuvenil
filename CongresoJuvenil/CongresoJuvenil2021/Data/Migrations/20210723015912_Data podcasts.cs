using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CongresoJuvenil2021.Data.Migrations
{
    public partial class Datapodcasts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Link", "Name", "TransmissionDate" },
                values: new object[] { "#", "Alabanza y adoración", new DateTime(2021, 8, 25, 14, 50, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Link", "Name", "TransmissionDate" },
                values: new object[] { "#", "Vocación, visión, llamado y productividad", new DateTime(2021, 8, 25, 15, 50, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "PodCasts",
                columns: new[] { "Id", "Description", "Link", "Name", "TransmissionDate" },
                values: new object[,]
                {
                    { 3, null, "#", "Pandemia de Amor", new DateTime(2021, 8, 25, 16, 50, 0, 0, DateTimeKind.Local) },
                    { 4, null, "#", "Desenmascarando la ideología de género", new DateTime(2021, 8, 25, 17, 45, 0, 0, DateTimeKind.Local) },
                    { 5, null, "#", "Visión, emprendimiento y libertad financiera", new DateTime(2021, 8, 26, 14, 50, 0, 0, DateTimeKind.Local) },
                    { 6, null, "#", "¿Y cómo funciona esto? Especial para novios", new DateTime(2021, 8, 26, 15, 55, 0, 0, DateTimeKind.Local) },
                    { 7, null, "#", "Porque estar solo, nunca será mejor. Especial para solteros", new DateTime(2021, 8, 26, 16, 55, 0, 0, DateTimeKind.Local) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Link", "Name", "TransmissionDate" },
                values: new object[] { "https://google.com", "Empresarios", new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PodCasts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Link", "Name", "TransmissionDate" },
                values: new object[] { "https://google.com", "Matrimonios", new DateTime(2021, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
