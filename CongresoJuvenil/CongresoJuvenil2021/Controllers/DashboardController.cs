using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CongresoJuvenil2021.Data;
using CongresoJuvenil2021.Models;
using CongresoJuvenil2021.ViewModels;
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
    }
}
