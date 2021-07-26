using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CongresoJuvenil2021.Migrations
{
    public partial class Initloadalltables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Congregations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Direction = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Congregations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PodCasts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Link = table.Column<string>(maxLength: 500, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    TransmissionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodCasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Link = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Instagram = table.Column<string>(maxLength: 255, nullable: true),
                    Facebook = table.Column<string>(maxLength: 255, nullable: true),
                    TikTok = table.Column<string>(maxLength: 255, nullable: true),
                    Twitter = table.Column<string>(maxLength: 255, nullable: true),
                    NeedContact = table.Column<bool>(nullable: false),
                    CongregationId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Congregations_CongregationId",
                        column: x => x.CongregationId,
                        principalTable: "Congregations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PodCastUsers",
                columns: table => new
                {
                    AppUserId = table.Column<long>(nullable: false),
                    PodCastId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodCastUsers", x => new { x.PodCastId, x.AppUserId });
                    table.ForeignKey(
                        name: "FK_PodCastUsers_User_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PodCastUsers_PodCasts_PodCastId",
                        column: x => x.PodCastId,
                        principalTable: "PodCasts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Congregations",
                columns: new[] { "Id", "Direction", "Name" },
                values: new object[,]
                {
                    { 1, "", "Caracas" },
                    { 80, "", "Fundación Apostólica Jesús te ama(Asociado)" },
                    { 79, "", "Centro Cristiano Restauración(Asociado)" },
                    { 78, "", "Villa Gesell" },
                    { 77, "", "Banda Rio Sali - Tucumán" },
                    { 76, "", "Ezeiza" },
                    { 75, "", "General Alvear" },
                    { 74, "", "Lanus" },
                    { 73, "", "Berazategui" },
                    { 72, "", "Huanguelen" },
                    { 71, "", "América" },
                    { 70, "", "Tucumán" },
                    { 69, "", "José León Suarez" },
                    { 68, "", "Cordoba" },
                    { 67, "", "Moreno" },
                    { 66, "", "El Palomar" },
                    { 65, "", "Morón" },
                    { 64, "", "Ciudad Ojeda" },
                    { 63, "", "Bachaquero" },
                    { 61, "", "Mérida" },
                    { 60, "", "San Cristobal" },
                    { 59, "", "Valera" },
                    { 58, "", "Santa Elena de Uairen" },
                    { 57, "", "Caicara del Orinoco" },
                    { 81, "", "Encarnación" },
                    { 56, "", "Upata" },
                    { 82, "", "Discípulos de Cristo(Asociado)" },
                    { 84, "", "Santiago" },
                    { 107, "", "Ninguna" },
                    { 106, "", "New York" },
                    { 105, "", "Sarasota" },
                    { 104, "", "Miami" },
                    { 103, "", "Coatzacoalcos / Minatitlán" },
                    { 102, "", "Leon" },
                    { 101, "", "Minatitlán" },
                    { 100, "", "Coatzacoalcos" },
                    { 99, "", "Lima" },
                    { 98, "", "Panamá" },
                    { 97, "", "Armenia" },
                    { 96, "", "Sincelejos" },
                    { 95, "", "Cúcuta" },
                    { 94, "", "Bogota" },
                    { 93, "", "Cartagena" },
                    { 92, "", "Barranquilla" },
                    { 91, "", "Madrid" },
                    { 90, "", "CT Casablanca" },
                    { 89, "", "CT Copiapó" },
                    { 88, "", "CT Chumil" },
                    { 87, "", "Lautaro" },
                    { 86, "", "Los Ángeles" },
                    { 85, "", "Rancagua" },
                    { 83, "", "Viña del Mar" },
                    { 55, "", "Ciudad Guayana" },
                    { 62, "", "Maracaibo" },
                    { 53, "", "Punta de Mata" },
                    { 25, "", "La Via" },
                    { 24, "", "Los Teques" },
                    { 23, "", "Carrizal" },
                    { 22, "", "El Rodeo" },
                    { 21, "", "Guarenas" },
                    { 54, "", "Temblador" },
                    { 19, "", "Cua" },
                    { 18, "", "Charallave" },
                    { 17, "", "Araira" },
                    { 16, "", "Caucagua" },
                    { 15, "", "San Antonio" },
                    { 26, "", "Higuerote" },
                    { 14, "", "Guatire" },
                    { 12, "", "El Hatillo" },
                    { 11, "", "Baruta" },
                    { 10, "", "Clarines" },
                    { 9, "", "Puerto la Cruz" },
                    { 8, "", "El Junquito" },
                    { 7, "", "Naiguata" },
                    { 6, "", "Punto Fijo" },
                    { 5, "", "Mariches" },
                    { 4, "", "Las Adjuntas" },
                    { 3, "", "Catia" },
                    { 2, "", "Catia La Mar" },
                    { 13, "", "Coro" },
                    { 27, "", "Rio Chico" },
                    { 20, "", "Ocumare" },
                    { 29, "", "Juan Griego" },
                    { 52, "", "Maturín" },
                    { 51, "", "San Carlos" },
                    { 50, "", "Puerto Cabello" },
                    { 49, "", "San Felipe" },
                    { 28, "", "Las Clavellinas" },
                    { 47, "", "Fundagex(Asociado)" },
                    { 46, "Barinitas", "Barinitas" },
                    { 45, "", "Chabasquen" },
                    { 44, "", "Potreritos" },
                    { 43, "", "Campo Ameno" },
                    { 42, "", " Las Tejerías" },
                    { 48, "", "Valencia" },
                    { 40, "", "Biscucuy" },
                    { 39, "", "Guárico" },
                    { 38, "", "La Victoria" },
                    { 37, "", "Maracay" },
                    { 36, "", "CT Curiepe" },
                    { 35, "", "Cumana" },
                    { 34, "", "San Diego" },
                    { 33, "", "Cantaura" },
                    { 32, "", "Anaco" },
                    { 31, "", "Yare" },
                    { 30, "", "Santa Teresa" },
                    { 41, "", "Barquisimeto" }
                });

            migrationBuilder.InsertData(
                table: "PodCasts",
                columns: new[] { "Id", "Description", "Link", "Name", "TransmissionDate" },
                values: new object[,]
                {
                    { 7, null, "#", "Porque estar solo, nunca será mejor. Especial para solteros", new DateTime(2021, 8, 26, 16, 55, 0, 0, DateTimeKind.Unspecified) },
                    { 6, null, "#", "¿Y cómo funciona esto? Especial para novios", new DateTime(2021, 8, 26, 15, 55, 0, 0, DateTimeKind.Unspecified) },
                    { 5, null, "#", "Visión, emprendimiento y libertad financiera", new DateTime(2021, 8, 26, 14, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, "#", "Vocación, visión, llamado y productividad", new DateTime(2021, 8, 25, 15, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, "#", "Pandemia de Amor", new DateTime(2021, 8, 25, 16, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 1, null, "#", "Alabanza y adoración", new DateTime(2021, 8, 25, 14, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 4, null, "#", "Desenmascarando la ideología de género", new DateTime(2021, 8, 25, 17, 45, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 4L, "1209d965-96f4-4402-8f9a-991e6964728a", "Coordinador Congreso", "Coordinador Congreso" },
                    { 1L, "1209d965-96f4-4402-8f9a-991e6964728a", "Admin", "ADMIN" },
                    { 2L, "1209d965-96f4-4402-8f9a-991e6964728a", "Lider Equipo", "LIDER EQUIPO" },
                    { 3L, "1209d965-96f4-4402-8f9a-991e6964728a", "Coordinador MOXA", "COORDINADOR MOXA" },
                    { 5L, "1209d965-96f4-4402-8f9a-991e6964728a", "Participante", "Participante" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Link", "Name" },
                values: new object[,]
                {
                    { 1, "https://t.me/joinchat/HZegqf-GylxlMWUx", "M-1 MOXAGUILAS" },
                    { 2, "https://t.me/joinchat/WHUPm1WLCWZjYjAx", "M-2 Manada Divergente" },
                    { 3, "https://t.me/joinchat/BmGdsXc_nUU1OTNh", "M-3 LEGENDARIOS" },
                    { 4, "https://t.me/joinchat/cdnPblmq7C0wMzVh", "M-4 JUVENTUD DIVERGENTE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PodCastUsers_AppUserId",
                table: "PodCastUsers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CongregationId",
                table: "User",
                column: "CongregationId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_TeamId",
                table: "User",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "PodCastUsers");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "PodCasts");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Congregations");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
