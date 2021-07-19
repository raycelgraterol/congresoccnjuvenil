using Microsoft.EntityFrameworkCore.Migrations;

namespace CongresoJuvenil2021.Data.Migrations
{
    public partial class PodCastUsernewtableNN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PodCastUsers",
                columns: table => new
                {
                    AppUserId = table.Column<string>(nullable: false),
                    PodCastId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodCastUsers", x => new { x.PodCastId, x.AppUserId });
                    table.ForeignKey(
                        name: "FK_PodCastUsers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PodCastUsers_PodCasts_PodCastId",
                        column: x => x.PodCastId,
                        principalTable: "PodCasts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PodCastUsers_AppUserId",
                table: "PodCastUsers",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PodCastUsers");
        }
    }
}
