using CongresoJuvenil2021.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CongresoJuvenil2021.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<long>, long, IdentityUserClaim<long>, IdentityUserRole<long>, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().ToTable("User");
            builder.Entity<IdentityRole<long>>().ToTable("Role");
            builder.Entity<IdentityUserClaim<long>>().ToTable("UserClaim");
            builder.Entity<IdentityUserLogin<long>>().ToTable("UserLogin");
            builder.Entity<IdentityUserRole<long>>().ToTable("UserRole");
            builder.Entity<IdentityUserToken<long>>().ToTable("UserToken");
            builder.Entity<IdentityRoleClaim<long>>().ToTable("RoleClaim");


            builder.Entity<PodCastUser>()
                .HasKey(x => new { x.PodCastId, x.AppUserId });
            builder.Entity<PodCastUser>()
                .HasOne(x => x.PodCast)
                .WithMany(m => m.Users)
                .HasForeignKey(x => x.PodCastId);
            builder.Entity<PodCastUser>()
                .HasOne(x => x.AppUser)
                .WithMany(e => e.PodCasts)
                .HasForeignKey(x => x.AppUserId);

            builder.Entity<IdentityRole<long>>()
              .HasData(
                  new IdentityRole<long>
                  {
                      Id = 1,
                      Name = "Admin",
                      NormalizedName = "ADMIN",
                      ConcurrencyStamp = "1209d965-96f4-4402-8f9a-991e6964728a"
                  },
                  new IdentityRole<long>
                  {
                      Id = 2,
                      Name = "Lider Equipo",
                      NormalizedName = "LIDER EQUIPO",
                      ConcurrencyStamp = "1209d965-96f4-4402-8f9a-991e6964728a"
                  },
                  new IdentityRole<long>
                  {
                      Id = 3,
                      Name = "Coordinador MOXA",
                      NormalizedName = "COORDINADOR MOXA",
                      ConcurrencyStamp = "1209d965-96f4-4402-8f9a-991e6964728a"
                  },
                  new IdentityRole<long>
                  {
                      Id = 4,
                      Name = "Coordinador Congreso",
                      NormalizedName = "Coordinador Congreso",
                      ConcurrencyStamp = "1209d965-96f4-4402-8f9a-991e6964728a"
                  },
                  new IdentityRole<long>
                  {
                      Id = 5,
                      Name = "Participante",
                      NormalizedName = "Participante",
                      ConcurrencyStamp = "1209d965-96f4-4402-8f9a-991e6964728a"
                  }
              );

            builder.Entity<Team>()
              .HasData(
                  new Team
                  {
                      Id = 1,
                      Name = "Equipo 1 Guardianes",
                      Link = "https://t.me/+lb3zWHUEX_RlZDlh"
                  },
                  new Team
                  {
                      Id = 2,
                      Name = "Equipo-2 Transformados",
                      Link = "https://t.me/+scShTrVhdJ1kMjJh"
                  },
                  new Team
                  {
                      Id = 3,
                      Name = "Equipo-3 Trascendentes",
                      Link = "https://t.me/+igdFNnHL5k5iMTNh"
                  },
                  new Team
                  {
                      Id = 4,
                      Name = "Equipo-4 Titanes",
                      Link = "https://t.me/+YFa4bjX2QD43M2Zh"
                  },
                  new Team
                  {
                      Id = 5,
                      Name = "Equipo-5 Rompetechos",
                      Link = "https://t.me/+1KPM9wahKmw1NTEx"
                  },
                  new Team
                  {
                      Id = 6,
                      Name = "Equipo-6 Centinelas",
                      Link = "https://t.me/+64zUs09alEg5NzYx"
                  }
              );

            builder.Entity<PodCast>()
             .HasData(
                 new PodCast
                 {
                     Id = 1,
                     Name = "Jueves - Día 1",
                     Link = "#",
                     TransmissionDate = DateTime.ParseExact("2022-08-01 08:00", "yyyy-MM-dd HH:mm", null)
                 },
                 new PodCast
                 {
                     Id = 2,
                     Name = "Viernes - Día 2",
                     Link = "#",
                     TransmissionDate = DateTime.ParseExact("2022-08-01 08:00", "yyyy-MM-dd HH:mm", null)
                 },
                 new PodCast
                 {
                     Id = 3,
                     Name = "Sabado - Día 3",
                     Link = "#",
                     TransmissionDate = DateTime.ParseExact("2022-08-01 08:00", "yyyy-MM-dd HH:mm", null)
                 }
             );

            #region Congregations 
            builder.Entity<Congregation>()
              .HasData(
                    new Congregation
                    {
                        Id = 1,
                        Name = "Caracas",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 2,
                        Name = "Catia La Mar",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 3,
                        Name = "Catia",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 4,
                        Name = "Las Adjuntas",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 5,
                        Name = "Mariches",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 6,
                        Name = "Punto Fijo",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 7,
                        Name = "Naiguata",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 8,
                        Name = "El Junquito",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 9,
                        Name = "Puerto la Cruz",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 10,
                        Name = "Clarines",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 11,
                        Name = "Baruta",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 12,
                        Name = "El Hatillo",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 13,
                        Name = "Coro",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 14,
                        Name = "Guatire",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 15,
                        Name = "San Antonio",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 16,
                        Name = "Caucagua",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 17,
                        Name = "Araira",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 18,
                        Name = "Charallave",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 19,
                        Name = "Cua",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 20,
                        Name = "Ocumare",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 21,
                        Name = "Guarenas",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 22,
                        Name = "El Rodeo",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 23,
                        Name = "Carrizal",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 24,
                        Name = "Los Teques",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 25,
                        Name = "La Via",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 26,
                        Name = "Higuerote",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 27,
                        Name = "Rio Chico",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 28,
                        Name = "Las Clavellinas",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 29,
                        Name = "Juan Griego",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 30,
                        Name = "Santa Teresa",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 31,
                        Name = "Yare",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 32,
                        Name = "Anaco",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 33,
                        Name = "Cantaura",
                        Direction = ""
                    },

                    new Congregation
                    {
                        Id = 34,
                        Name = "San Diego",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 35,
                        Name = "Cumana",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 36,
                        Name = "Curiepe",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 37,
                        Name = "Maracay",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 38,
                        Name = "La Victoria",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 39,
                        Name = "San Juan de los Morros",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 40,
                        Name = "Biscucuy",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 41,
                        Name = "Barquisimeto",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 42,
                        Name = " Las Tejerías",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 43,
                        Name = "Campo Ameno",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 44,
                        Name = "Potreritos",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 45,
                        Name = "Chabasquen",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 46,
                        Name = "Barinitas",
                        Direction = "Barinitas"
                    },
                    new Congregation
                    {
                        Id = 47,
                        Name = "Fundagex(Asociado)",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 48,
                        Name = "Valencia",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 49,
                        Name = "San Felipe",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 50,
                        Name = "Puerto Cabello",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 51,
                        Name = "San Carlos",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 52,
                        Name = "Maturín",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 53,
                        Name = "Punta de Mata",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 54,
                        Name = "Temblador",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 55,
                        Name = "Ciudad Guayana",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 56,
                        Name = "Upata",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 57,
                        Name = "Caicara del Orinoco",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 58,
                        Name = "Santa Elena de Uairen",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 59,
                        Name = "Valera",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 60,
                        Name = "San Cristobal",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 61,
                        Name = "Mérida",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 62,
                        Name = "Maracaibo",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 63,
                        Name = "Bachaquero",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 64,
                        Name = "Ciudad Ojeda",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 65,
                        Name = "Morón",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 66,
                        Name = "El Palomar",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 67,
                        Name = "Moreno",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 68,
                        Name = "Cordoba",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 69,
                        Name = "José León Suarez",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 70,
                        Name = "Tucumán",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 71,
                        Name = "América",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 72,
                        Name = "Huanguelen",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 73,
                        Name = "Berazategui",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 74,
                        Name = "Lanus",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 75,
                        Name = "General Alvear",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 76,
                        Name = "Ezeiza",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 77,
                        Name = "Banda Rio Sali - Tucumán",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 78,
                        Name = "Villa Gesell",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 79,
                        Name = "Centro Cristiano Restauración(Asociado)",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 80,
                        Name = "Fundación Apostólica Jesús te ama(Asociado)",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 81,
                        Name = "Encarnación",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 82,
                        Name = "Discípulos de Cristo(Asociado)",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 83,
                        Name = "Viña del Mar",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 84,
                        Name = "Santiago",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 85,
                        Name = "Rancagua",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 86,
                        Name = "Los Ángeles",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 87,
                        Name = "Lautaro",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 88,
                        Name = "CT Chumil",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 89,
                        Name = "CT Copiapó",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 90,
                        Name = "CT Casablanca",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 91,
                        Name = "Madrid",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 92,
                        Name = "Barranquilla",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 93,
                        Name = "Cartagena",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 94,
                        Name = "Bogota",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 95,
                        Name = "Cúcuta",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 96,
                        Name = "Sincelejos",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 97,
                        Name = "Armenia",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 98,
                        Name = "Panamá",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 99,
                        Name = "Lima",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 100,
                        Name = "Coatzacoalcos",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 101,
                        Name = "Minatitlán",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 102,
                        Name = "Leon",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 103,
                        Name = "Coatzacoalcos / Minatitlán",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 104,
                        Name = "Miami",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 105,
                        Name = "Sarasota",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 106,
                        Name = "New York",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 107,
                        Name = "Guanare",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 108,
                        Name = "Porlamar",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 109,
                        Name = "Las Tejerías",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 110,
                        Name = "Santa Bárbara",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 111,
                        Name = "Otra congregación",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 112,
                        Name = "Ninguna",
                        Direction = ""
                    },//Agregadas 2022
                    new Congregation
                    {
                        Id = 113,
                        Name = "Sotillo",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 114,
                        Name = "23 de enero",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 115,
                        Name = "Carayaca",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 116,
                        Name = "Caucaguita",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 117,
                        Name = "Santa Lucía",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 118,
                        Name = "Palo Negro",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 119,
                        Name = "Pijiguaos",
                        Direction = ""
                    },
                    new Congregation
                    {
                        Id = 120,
                        Name = "San felix",
                        Direction = ""
                    }
              );
            #endregion

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<PodCast> PodCasts { get; set; }
        public DbSet<Congregation> Congregations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PodCastUser> PodCastUsers { get; set; }

    }
}
