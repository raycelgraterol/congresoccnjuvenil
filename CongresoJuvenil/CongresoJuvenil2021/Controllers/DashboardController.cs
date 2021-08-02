using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using CongresoJuvenil2021.Data;
using CongresoJuvenil2021.Models;
using CongresoJuvenil2021.ViewModels;
using FastMember;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CongresoJuvenil2021.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ApplicationDbContext _context;

        public DashboardController(
            UserManager<AppUser> userManager,
            ApplicationDbContext context)
        {
            this.userManager = userManager;
            _context = context;
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
        public IActionResult UserPodCasts()
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

            return View(result);
        }

        // GET: Totals
        public async Task<IActionResult> UserReferred()
        {
            var resultTotals = (from T1 in _context.Teams
                          join T2 in userManager.Users on T1.Id equals T2.TeamId
                          where T2.IsReferred
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
                            .Where(x => x.IsReferred)
                            .OrderBy(o => o.TeamId)
                            .ToListAsync();

            ViewBag.CountTotal = result.Count();
            ViewBag.resultTotals = resultTotals;

            return View(result);
        }

        public IActionResult ExportDataTabletoExcel()
        {
            var result = userManager.Users.Include(t => t.Team).Include(c => c.Congregation)
                               .Where(x => x.IsReferred)
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
    }
}
