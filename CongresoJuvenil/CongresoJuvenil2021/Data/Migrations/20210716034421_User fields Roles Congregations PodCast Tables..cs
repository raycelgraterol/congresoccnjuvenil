using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CongresoJuvenil2021.Data.Migrations
{
    public partial class UserfieldsRolesCongregationsPodCastTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Congregations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Direction = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Congregations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PodCasts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Link = table.Column<string>(maxLength: 500, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    TransmissionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodCasts", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "97aa4ac5-db47-4db1-8c4e-35fc199a8cb8", "1209d965-96f4-4402-8f9a-991e6964728a", "Admin", "ADMIN" },
                    { "929071bc-796f-4002-9b15-b44a0580f71c", "1209d965-96f4-4402-8f9a-991e6964728a", "Lider Equipo", "LIDER EQUIPO" },
                    { "3e8aa687-7f75-4ce9-a962-a39b73c5ede3", "1209d965-96f4-4402-8f9a-991e6964728a", "Coordinador MOXA", "COORDINADOR MOXA" },
                    { "39f67487-8a3e-448f-a054-88b84239eb66", "1209d965-96f4-4402-8f9a-991e6964728a", "Coordinador Congreso", "Coordinador Congreso" },
                    { "a3a79ca9-2116-4da3-884b-9fc4c825f7f6", "1209d965-96f4-4402-8f9a-991e6964728a", "Participante", "Participante" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Congregations");

            migrationBuilder.DropTable(
                name: "PodCasts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39f67487-8a3e-448f-a054-88b84239eb66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e8aa687-7f75-4ce9-a962-a39b73c5ede3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "929071bc-796f-4002-9b15-b44a0580f71c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97aa4ac5-db47-4db1-8c4e-35fc199a8cb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3a79ca9-2116-4da3-884b-9fc4c825f7f6");
        }
    }
}
