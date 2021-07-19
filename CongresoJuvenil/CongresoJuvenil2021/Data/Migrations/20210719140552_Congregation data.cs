using Microsoft.EntityFrameworkCore.Migrations;

namespace CongresoJuvenil2021.Data.Migrations
{
    public partial class Congregationdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Congregations",
                columns: new[] { "Id", "Direction", "Name" },
                values: new object[,]
                {
                    { 1, "", "Caracas" },
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
                    { 78, "", "Villa Gesell" },
                    { 67, "", "Moreno" },
                    { 65, "", "Morón" },
                    { 64, "", "Ciudad Ojeda" },
                    { 63, "", "Bachaquero" },
                    { 62, "", "Maracaibo" },
                    { 61, "", "Mérida" },
                    { 60, "", "San Cristobal" },
                    { 59, "", "Valera" },
                    { 58, "", "Santa Elena de Uairen" },
                    { 57, "", "Caicara del Orinoco" },
                    { 56, "", "Upata" },
                    { 66, "", "El Palomar" },
                    { 79, "", "Centro Cristiano Restauración(Asociado)" },
                    { 80, "", "Fundación Apostólica Jesús te ama(Asociado)" },
                    { 81, "", "Encarnación" },
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
                    { 84, "", "Santiago" },
                    { 83, "", "Viña del Mar" },
                    { 82, "", "Discípulos de Cristo(Asociado)" },
                    { 55, "", "Ciudad Guayana" },
                    { 54, "", "Temblador" },
                    { 53, "", "Punta de Mata" },
                    { 52, "", "Maturín" },
                    { 24, "", "Los Teques" },
                    { 23, "", "Carrizal" },
                    { 22, "", "El Rodeo" },
                    { 21, "", "Guarenas" },
                    { 20, "", "Ocumare" },
                    { 19, "", "Cua" },
                    { 18, "", "Charallave" },
                    { 17, "", "Araira" },
                    { 16, "", "Caucagua" },
                    { 15, "", "San Antonio" },
                    { 14, "", "Guatire" },
                    { 13, "", "Coro" },
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
                    { 25, "", "La Via" },
                    { 105, "", "Sarasota" },
                    { 26, "", "Higuerote" },
                    { 28, "", "Las Clavellinas" },
                    { 51, "", "San Carlos" },
                    { 50, "", "Puerto Cabello" },
                    { 49, "", "San Felipe" },
                    { 48, "", "Valencia" },
                    { 47, "", "Fundagex(Asociado)" },
                    { 46, "Barinitas", "" },
                    { 45, "", "Chabasquen" },
                    { 44, "", "Potreritos" },
                    { 43, "", "Campo Ameno" },
                    { 42, "", " Las Tejerías" },
                    { 41, "", "Barquisimeto" },
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
                    { 29, "", "Juan Griego" },
                    { 27, "", "Rio Chico" },
                    { 106, "", "New York" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Congregations",
                keyColumn: "Id",
                keyValue: 106);
        }
    }
}
