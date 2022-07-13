using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClosedXML.Excel;
using CongresoJuvenil2021.Data;
using CongresoJuvenil2021.Models;
using CongresoJuvenil2021.Services;
using CongresoJuvenil2021.ViewModels;
using FastMember;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CongresoJuvenil2021.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public DashboardController(
            UserManager<AppUser> userManager,
            ApplicationDbContext context,
            IConfiguration configuration,
            IEmailService emailService)
        {
            this.userManager = userManager;
            _context = context;
            _configuration = configuration;
            _emailService = emailService;
        }

        // GET: Totals
        public IActionResult Index()
        {
            var result = (from T1 in _context.Congregations
                          join T2 in userManager.Users on T1.Id equals T2.CongregationId
                          select new { Congregations = T1, Users = T2 })
                          .ToList()
                          .GroupBy(
                            p => p.Congregations,
                            p => p.Users,
                            (key, g) => new UserCongregation
                            {
                                CongregationId = key.Id,
                                CongregationName = key.Name,
                                TotalUser = g.Count()
                            })
                          .ToList();

            ViewBag.CountTotal = userManager.Users.Count();


            return View(result);
        }

        // GET: Totals
        public IActionResult UserTeams()
        {
            var result = (from T1 in _context.Teams
                          join T2 in userManager.Users on T1.Id equals T2.TeamId
                          select new { Teams = T1, Users = T2 })
                          .ToList()
                          .GroupBy(
                            p => p.Teams,
                            p => p.Users,
                            (key, g) => new TeamCongregation
                            {
                                TeamId = key.Id,
                                TeamName = key.Name,
                                TotalUser = g.Count()
                            })
                          .ToList();

            ViewBag.CountTotal = userManager.Users.Count();


            return View(result);
        }

        // GET: Totals
        public IActionResult UserPodCasts(string message = "Iniciado")
        {
            var result = (from T1 in _context.PodCastUsers.Include(x => x.PodCast).Include(x => x.AppUser)
                          select new { PodCastUsers = T1 })
                          .ToList()
                          .GroupBy(
                            p => p.PodCastUsers.PodCast,
                            p => p.PodCastUsers.AppUser,
                            (key, g) => new UsersPodCast
                            {
                                PodCastId = key.Id,
                                PodCastName = key.Name,
                                TotalUser = g.Count()
                            })
                          .ToList();

            ViewBag.message = message;

            return View(result);
        }

        // GET: Totals
        public async Task<IActionResult> UserReferred()
        {
            var resultTotals = (from T1 in _context.Teams
                                join T2 in userManager.Users on T1.Id equals T2.TeamId
                                select new { Teams = T1, Users = T2 })
                          .ToList()
                          .GroupBy(
                            p => p.Teams,
                            p => p.Users,
                            (key, g) => new TeamCongregation
                            {
                                TeamId = key.Id,
                                TeamName = key.Name,
                                TotalUser = g.Count()
                            })
                          .OrderBy(x => x.TeamId)
                          .ToList();

            var result = await userManager.Users.Include(t => t.Team).Include(c => c.Congregation)
                            .OrderBy(o => o.TeamId)
                            .ToListAsync();

            ViewBag.CountTotal = result.Count();
            ViewBag.resultTotals = resultTotals;

            return View(result);
        }

        // GET: Totals
        public async Task<IActionResult> UserNewConverted()
        {
            var resultTotals = (from T1 in _context.Teams
                                join T2 in userManager.Users on T1.Id equals T2.TeamId
                                where T2.IsNewConverted
                                select new { Teams = T1, Users = T2 })
                          .ToList()
                          .GroupBy(
                            p => p.Teams,
                            p => p.Users,
                            (key, g) => new TeamCongregation
                            {
                                TeamId = key.Id,
                                TeamName = key.Name,
                                TotalUser = g.Count()
                            })
                          .OrderBy(x => x.TeamId)
                          .ToList();

            var result = await userManager.Users.Include(t => t.Team).Include(c => c.Congregation)
                            .Where(x => x.IsNewConverted)
                            .OrderBy(o => o.TeamId)
                            .ToListAsync();

            ViewBag.CountTotal = result.Count();
            ViewBag.resultTotals = resultTotals;

            return View(result);
        }

        public IActionResult ExporExcelNewConverted()
        {
            var result = userManager.Users.Include(t => t.Team).Include(c => c.Congregation)
                               .Where(x => x.IsNewConverted)
                               .OrderBy(o => o.TeamId)
                               .ToList();

            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(result, "Id", "FullName", "Age", "Email", "PhoneNumber", "CongregationName", "TeamId", "ReferredBy", "Instagram", "Facebook", "TikTok", "Twitter"))
            {
                table.Load(reader);
            }

            table.Columns["Id"].ColumnName = "Codigo";
            table.Columns["FullName"].ColumnName = "Nombre completo";
            table.Columns["Age"].ColumnName = "Edad";
            table.Columns["Email"].ColumnName = "Correo";
            table.Columns["PhoneNumber"].ColumnName = "Telefono";
            table.Columns["CongregationName"].ColumnName = "Congregacion";
            table.Columns["TeamId"].ColumnName = "Equipo";
            table.Columns["ReferredBy"].ColumnName = "Referido por";

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(table, "Grid.xlsx");
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", string.Format("Nuevos.xlsx"));
                }
            }
        }

        public IActionResult ExportDataTabletoExcel()
        {
            var result = userManager.Users.Include(t => t.Team).Include(c => c.Congregation)
                               .OrderBy(o => o.TeamId)
                               .ToList();

            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(result, "Id", "FullName", "Age", "Email", "PhoneNumber", "CongregationName", "TeamId", "ReferredBy", "Instagram", "Facebook", "TikTok", "Twitter"))
            {
                table.Load(reader);
            }

            table.Columns["Id"].ColumnName = "Codigo";
            table.Columns["FullName"].ColumnName = "Nombre completo";
            table.Columns["Age"].ColumnName = "Edad";
            table.Columns["Email"].ColumnName = "Correo";
            table.Columns["PhoneNumber"].ColumnName = "Telefono";
            table.Columns["CongregationName"].ColumnName = "Congregacion";
            table.Columns["TeamId"].ColumnName = "Equipo";
            table.Columns["ReferredBy"].ColumnName = "Referido por";

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(table, "Grid.xlsx");
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", string.Format("Referidos.xlsx"));
                }
            }
        }


        public async Task<IActionResult> SendEmailsDayOne(int id = 0)
        {
            var stringHTML = EmailDay1();
            var currentUsersLot = new List<AppUser>();
            var quantity = userManager.Users.Count() / 4;

            switch (id)
            {
                case 1:
                    // code block
                    currentUsersLot = userManager.Users.Take(quantity).ToList();
                    break;
                case 2:
                    // code block
                    currentUsersLot = userManager.Users.Skip(quantity).Take(quantity).ToList();
                    break;
                case 3:
                    // code block
                    currentUsersLot = userManager.Users.Skip(quantity * 2).Take(quantity).ToList();
                    break;
                case 4:
                    // code block
                    currentUsersLot = userManager.Users.Skip(quantity * 3).ToList();
                    break;
                default:
                    // code block
                    break;
            }

            foreach (var item in currentUsersLot)
            {
                await _emailService.Send(item.Email, "Podcast | Día 1 | Congreso juvenil | MOXA a prueba de fuego", stringHTML);
                var milliseconds = 50;
                Thread.Sleep(milliseconds);
            }

            return LocalRedirect("/Dashboard/UserPodCasts?message=enviados");
        }

        public async Task<IActionResult> SendEmailsDayTwo(int id = 0)
        {
            var stringHTML = EmailDay2();
            var currentUsersLot = new List<AppUser>();
            var quantity = userManager.Users.Count()/4;


            switch (id)
            {
                case 1:
                    // code block
                    currentUsersLot = userManager.Users.Take(quantity).ToList();
                    break;
                case 2:
                    // code block
                    currentUsersLot = userManager.Users.Skip(quantity).Take(quantity).ToList();
                    break;
                case 3:
                    // code block
                    currentUsersLot = userManager.Users.Skip(quantity * 2).Take(quantity).ToList();
                    break;
                case 4:
                    // code block
                    currentUsersLot = userManager.Users.Skip(quantity * 3).ToList();
                    break;
                default:
                    // code block
                    break;
            }


            foreach (var item in currentUsersLot)
            {
                await _emailService.Send(item.Email, "Podcast | Día 2 | Congreso juvenil | MOXA a prueba de fuego", stringHTML);
                var milliseconds = 50;
                Thread.Sleep(milliseconds);
            }

            return LocalRedirect("/Dashboard/UserPodCasts?message=enviados");
        }

        public async Task<IActionResult> SendEmailsDayThree(int id = 0)
        {
            var stringHTML = EmailDay3();
            var currentUsersLot = new List<AppUser>();
            var quantity = userManager.Users.Count() / 4;


            switch (id)
            {
                case 1:
                    // code block
                    currentUsersLot = userManager.Users.Take(quantity).ToList();
                    break;
                case 2:
                    // code block
                    currentUsersLot = userManager.Users.Skip(quantity).Take(quantity).ToList();
                    break;
                case 3:
                    // code block
                    currentUsersLot = userManager.Users.Skip(quantity * 2).Take(quantity).ToList();
                    break;
                case 4:
                    // code block
                    currentUsersLot = userManager.Users.Skip(quantity * 3).ToList();
                    break;
                default:
                    // code block
                    break;
            }

            foreach (var item in currentUsersLot)
            {
                await _emailService.Send(item.Email, "Conferencias | Día 1 | Congreso juvenil | MOXA a prueba de fuego", stringHTML);
                var milliseconds = 50;
                Thread.Sleep(milliseconds);
            }

            return LocalRedirect("/Dashboard/UserPodCasts?message=enviados");
        }

        public async Task<IActionResult> SendEmailsDayFour(int id = 0)
        {
            var stringHTML = EmailDay4();
            var currentUsersLot = new List<AppUser>();
            var quantity = userManager.Users.Count() / 4;


            switch (id)
            {
                case 1:
                    // code block
                    currentUsersLot = userManager.Users.Take(quantity).ToList();
                    break;
                case 2:
                    // code block
                    currentUsersLot = userManager.Users.Skip(quantity).Take(quantity).ToList();
                    break;
                case 3:
                    // code block
                    currentUsersLot = userManager.Users.Skip(quantity * 2).Take(quantity).ToList();
                    break;
                case 4:
                    // code block
                    currentUsersLot = userManager.Users.Skip(quantity * 3).ToList();
                    break;
                default:
                    // code block
                    break;
            }

            foreach (var item in currentUsersLot)
            {
                await _emailService.Send(item.Email, "Conferencias | Día 2 | Congreso juvenil | MOXA a prueba de fuego", stringHTML).ConfigureAwait(false);
                var milliseconds = 50;
                Thread.Sleep(milliseconds);
            }

            return LocalRedirect("/Dashboard/UserPodCasts?message=enviados");
        }

        #region Zona Privada

        private string EmailDay1()
        {
            var title = "¡Bienvenido a los podcast!";
            var link = _configuration["defaultValues:Enlace1"];

            var stringHTML = string.Format(
                    @"
                    <div style='text-align: center; padding:5px; margin-bottom:10px'>
                        <img width='900px' height='auto' src='https://congresoccnjuvenil.com/img/banner-correo.png' alt='' />
                    </div>
                    <div style='text-align: center; padding:5px;'>                        
                        <h2>{0}</h2>
                        <p style='font-size: 16px;'>Gracias por haberte inscrito en la segunda fase del congreso juvenil.</p>
                        <p style='font-size: 16px;'>¡Contamos con tu participación para este día, que será especial para todos!</p>
                        <p style='font-size: 16px;font-weight: bold;'>Podrás verlo a través de una sala de zoom que tendrá un ÚNICO enlace en todo este día.</p>
                        <br />
                        <p style='font-size: 16px;'>Te dejamos aquí la información que necesitas para conectarte:</p>
                        <p style='font-size: 16px;'><b>Fecha:</b> miércoles 25 de agosto.</p>
                        <p style='font-size: 16px;'><b>Hora:</b> 2:50 p.m. hora Venezuela.</p>
                        <p style='font-size: 16px;'><b>Enlace de transmisión:</b> {1}</p>
                        <a href='{1}' style='color: #fff;background-color: #17a2b8;border-color: #17a2b8;text-decoration: none;padding: 10px;border-radius: .25rem;margin-bottom:10px;'>
                        Link Zoom</a>
                        <br />
                        <p style='font-size: 16px;'>Guarda este correo en tus destacados  para que te puedas conectar en pocos minutos y tengas toda la información al alcance de tu mano.</p>
                        <br />
                        <p style='font-size: 16px; margin-top: 30px;'>Cualquier duda, estamos pendientes a través de este medio o de nuestra cuenta de Instagram @ccnjuvenil</p>
                        <a href='https://www.instagram.com/ccnjuvenil/' style='color: #fff;background-color: #17a2b8;border-color: #17a2b8;text-decoration: none;padding: 10px;border-radius: .25rem;margin-bottom:10px;'>
                        @ccnjuvenil</a>
                        <br />
                        <p style='font-size: 16px;font-weight: bold;'>¡MOXA a prueba de fuego!</p>
                        <br />
                    </div>
                    ", title, link);

            return stringHTML;
        }

        private string EmailDay2()
        {
            var title = "¡Finalizamos los podcast!";
            var link = _configuration["defaultValues:Enlace2"];

            var stringHTML = string.Format(
                    @"
                    <div style='text-align: center; padding:5px; margin-bottom:10px'>
                        <img width='900px' height='auto' src='https://congresoccnjuvenil.com/img/banner-correo.png' alt='' />
                    </div>
                    <div style='text-align: center; padding:5px;'>                        
                        <h2>{0}</h2>
                        <p style='font-size: 16px;'>¡Contamos con tu participación para este día, que será especial para todos!</p>
                        <p style='font-size: 16px;font-weight: bold;'>Podrás verlo a través de una sala de zoom que tendrá un ÚNICO enlace en todo este día.</p>
                        <br />
                        <p style='font-size: 16px;'>Te dejamos aquí la información que necesitas para conectarte:</p>
                        <p style='font-size: 16px;'><b>Fecha:</b> jueves 26 de agosto.</p>
                        <p style='font-size: 16px;'><b>Hora:</b> 2:50 p.m. hora Venezuela.</p>
                        <p style='font-size: 16px;'><b>Enlace de transmisión:</b> {1}</p>
                        <a href='{1}' style='color: #fff;background-color: #17a2b8;border-color: #17a2b8;text-decoration: none;padding: 10px;border-radius: .25rem;margin-bottom:10px;'>
                        Link Zoom</a>
                        <br />
                        <p style='font-size: 16px;'>Guarda este correo en tus destacados  para que te puedas conectar en pocos minutos y tengas toda la información al alcance de tu mano.</p>
                        <br />
                        <p style='font-size: 16px; margin-top: 30px;'>Cualquier duda, estamos pendientes a través de este medio o de nuestra cuenta de Instagram @ccnjuvenil</p>
                        <a href='https://www.instagram.com/ccnjuvenil/' style='color: #fff;background-color: #17a2b8;border-color: #17a2b8;text-decoration: none;padding: 10px;border-radius: .25rem;margin-bottom:10px;'>
                        @ccnjuvenil</a>
                        <br />
                        <p style='font-size: 16px;font-weight: bold;'>¡MOXA a prueba de fuego!</p>
                        <br />
                    </div>
                    ", title, link);

            return stringHTML;
        }

        private string EmailDay3()
        {
            var title = "¡Bienvenidos a las conferencias!";
            var link = _configuration["defaultValues:Enlace3"];

            var stringHTML = string.Format(
                    @"
                    <div style='text-align: center; padding:5px; margin-bottom:10px'>
                        <img width='900px' height='auto' src='https://congresoccnjuvenil.com/img/banner-correo.png' alt='' />
                    </div>
                    <div style='text-align: center; padding:5px;'>                        
                        <h2>{0}</h2>
                        <p style='font-size: 16px;'>Hemos llegado a la última fase de este congreso y vamos a estar activos con TODO.</p>
                        <p style='font-size: 16px;'>¡Contamos con tu participación para este día, que será especial para todos!</p>
                        <p style='font-size: 16px;font-weight: bold;'>Podrás verlo a través del canal de YouTube de CCN Juvenil, que tendrá un ÚNICO enlace en todo este día.</p>
                        <br />
                        <p style='font-size: 16px;'>Te dejamos aquí la información que necesitas para conectarte:</p>
                        <p style='font-size: 16px;'><b>Fecha:</b> viernes 27 de agosto.</p>
                        <p style='font-size: 16px;'><b>Hora:</b> 3:50 p.m. hora Venezuela</p>
                        <p style='font-size: 16px;'><b>Enlace de transmisión:</b> {1}</p>
                        <a href='{1}' style='color: #fff;background-color: #17a2b8;border-color: #17a2b8;text-decoration: none;padding: 10px;border-radius: .25rem;margin-bottom:10px;'>
                        Link Youtube</a>
                        <br />
                        <p style='font-size: 16px;'>Guarda este correo en tus destacados  para que te puedas conectar en pocos minutos y tengas toda la información al alcance de tu mano.</p>
                        <br />
                        <p style='font-size: 16px; margin-top: 30px;'>Cualquier duda, estamos pendientes a través de este medio o de nuestra cuenta de Instagram @ccnjuvenil</p>
                        <a href='https://www.instagram.com/ccnjuvenil/' style='color: #fff;background-color: #17a2b8;border-color: #17a2b8;text-decoration: none;padding: 10px;border-radius: .25rem;margin-bottom:10px;'>
                        @ccnjuvenil</a>
                        <br />
                        <p style='font-size: 16px;font-weight: bold;'>¡MOXA a prueba de fuego!</p>
                        <br />
                    </div>
                    ", title, link);

            return stringHTML;
        }

        private string EmailDay4()
        {
            var title = "¡Cerremos con broche de oro!";
            var link = _configuration["defaultValues:Enlace4"];

            var stringHTML = string.Format(
                    @"
                    <div style='text-align: center; padding:5px; margin-bottom:10px'>
                        <img width='900px' height='auto' src='https://congresoccnjuvenil.com/img/banner-correo.png' alt='' />
                    </div>
                    <div style='text-align: center; padding:5px;'>                        
                        <h2>{0}</h2>
                        <p style='font-size: 16px;'>Hemos llegado a la última fase y último día de este congreso y vamos a estar activos con TODO.</p>
                        <p style='font-size: 16px;'>¡Contamos con tu participación para este día, que será especial para todos!</p>
                        <p style='font-size: 16px;font-weight: bold;'>Podrás verlo a través del canal de YouTube de CCN Juvenil, que tendrá un ÚNICO enlace en todo este día.</p>
                        <br />
                        <p style='font-size: 16px;'>Te dejamos aquí la información que necesitas para conectarte:</p>
                        <p style='font-size: 16px;'><b>Fecha:</b> sábado 28 de agosto.</p>
                        <p style='font-size: 16px;'><b>Hora:</b> 8:50 a.m. hora Venezuela.</p>
                        <p style='font-size: 16px;'><b>Enlace de transmisión:</b> {1}</p>
                        <a href='{1}' style='color: #fff;background-color: #17a2b8;border-color: #17a2b8;text-decoration: none;padding: 10px;border-radius: .25rem;margin-bottom:10px;'>
                        Link Youtube</a>
                        <br />
                        <p style='font-size: 16px;'>Guarda este correo en tus destacados  para que te puedas conectar en pocos minutos y tengas toda la información al alcance de tu mano.</p>
                        <br />
                        <p style='font-size: 16px; margin-top: 30px;'>Cualquier duda, estamos pendientes a través de este medio o de nuestra cuenta de Instagram @ccnjuvenil</p>
                        <a href='https://www.instagram.com/ccnjuvenil/' style='color: #fff;background-color: #17a2b8;border-color: #17a2b8;text-decoration: none;padding: 10px;border-radius: .25rem;margin-bottom:10px;'>
                        @ccnjuvenil</a>
                        <br />
                        <p style='font-size: 16px;font-weight: bold;'>¡MOXA a prueba de fuego!</p>
                        <br />
                    </div>
                    ", title, link);

            return stringHTML;
        }

        #endregion
    }
}
