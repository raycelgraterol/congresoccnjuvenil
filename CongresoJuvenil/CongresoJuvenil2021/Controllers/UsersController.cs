using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CongresoJuvenil2021.Data;
using CongresoJuvenil2021.Models;
using Microsoft.AspNetCore.Identity;
using System.IO;
using ClosedXML.Excel;
using System.Data;
using FastMember;
using Microsoft.AspNetCore.Http;

namespace CongresoJuvenil2021.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ApplicationDbContext _context;

        public UsersController(
            UserManager<AppUser> userManager,
            ApplicationDbContext context)
        {
            this.userManager = userManager;
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();

            return View(users);
        }

        // GET: Users
        public async Task<IActionResult> UsersByTeam(int id)
        {
            var result = await userManager.Users.Include(c => c.Congregation)
                            .Where(x => x.TeamId == id)
                            .OrderBy(o => o.Id)
                            .ToListAsync();

            ViewBag.TeamId = id;
            ViewBag.Count = result.Count;

            return View(result);
        }

        // GET: Users By Congregation
        public async Task<IActionResult> UsersByCongregation(int id = 0)
        {
            var result = await userManager.Users.Include(c => c.Congregation)
                            .Where(x => x.CongregationId == id)
                            .OrderBy(o => o.Id)
                            .ToListAsync();

            ViewBag.CongregationId = id;
            ViewBag.Count = result.Count;

            var selectList = _context.Congregations.OrderBy(o => o.Name).ToList()
                                    .Select(x => 
                                    new SelectListItem { 
                                        Text = x.Name,
                                        Value = x.Id.ToString(),
                                        Selected = (x.Id == id)
                                    });

            ViewBag.Congregations = selectList;

            return View(result);
        }

        [HttpPost]
        public  IActionResult ChangeCongragation(IFormCollection obj)
        {
            var conid = Convert.ToInt32(obj["Congregations"].ToString());

            return RedirectToAction("UsersByCongregation", "Users", new { id = conid });
        }

        public IActionResult ExportDataTabletoExcelCongregation(int id)
        {
            var result = userManager.Users.Include(c => c.Congregation)
                               .Where(x => x.CongregationId == id)
                               .OrderBy(o => o.Id)
                               .ToList();

            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(result, "Id", "FullName", "Age", "Email", "PhoneNumber", "CongregationName", "Instagram", "Facebook", "TikTok", "Twitter"))
            {
                table.Load(reader);
            }

            table.Columns["Id"].ColumnName = "Codigo";
            table.Columns["FullName"].ColumnName = "Nombre completo";
            table.Columns["Age"].ColumnName = "Edad";
            table.Columns["Email"].ColumnName = "Correo";
            table.Columns["PhoneNumber"].ColumnName = "Telefono";
            table.Columns["CongregationName"].ColumnName = "Congregacion";

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(table, "Grid.xlsx");
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", string.Format("Participantes.xlsx", id));
                }
            }
        }

        public IActionResult ExportDataTabletoExcel(int id)
        {
            var result = userManager.Users.Include(c => c.Congregation)
                               .Where(x => x.TeamId == id)
                               .OrderBy(o => o.Id)
                               .ToList();

            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(result, "Id", "FullName", "Age", "Email", "PhoneNumber", "CongregationName", "Instagram", "Facebook", "TikTok", "Twitter"))
            {
                table.Load(reader);
            }

            table.Columns["Id"].ColumnName = "Codigo";
            table.Columns["FullName"].ColumnName = "Nombre completo";
            table.Columns["Age"].ColumnName = "Edad";
            table.Columns["Email"].ColumnName = "Correo";
            table.Columns["PhoneNumber"].ColumnName = "Telefono";
            table.Columns["CongregationName"].ColumnName = "Congregacion";

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(table, "Grid.xlsx");
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", string.Format("Equipo{0}.xlsx", id));
                }
            }
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var tempUser = await userManager.FindByIdAsync(id.ToString());
            if (tempUser == null)
            {
                return NotFound();
            }

            return View(tempUser);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Age,Instagram,Facebook,TikTok,Twitter")] AppUser tempUser)
        {
            if (ModelState.IsValid)
            {
                await userManager.CreateAsync(tempUser);

                return RedirectToAction(nameof(Index));
            }
            return View(tempUser);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var tempUser = await userManager.FindByIdAsync(id.ToString());
            if (tempUser == null)
            {
                return NotFound();
            }
            return View(tempUser);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,FirstName,LastName,PhoneNumber,Age,Instagram,Facebook,TikTok,Twitter")] AppUser tempUser)
        {
            if (id != tempUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var currentUser = await userManager.FindByIdAsync(id.ToString());

                    currentUser.FirstName = tempUser.FirstName;
                    currentUser.LastName = tempUser.LastName;
                    currentUser.PhoneNumber = tempUser.PhoneNumber;
                    currentUser.Age = tempUser.Age;
                    currentUser.Instagram = tempUser.Instagram;
                    currentUser.Facebook = tempUser.Facebook;
                    currentUser.TikTok = tempUser.TikTok;
                    currentUser.Twitter = tempUser.Twitter;


                    IdentityResult result = await userManager.UpdateAsync(currentUser);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await TempUserExists(id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tempUser);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var tempUser = await userManager.FindByIdAsync(id.ToString());

            if (tempUser == null)
            {
                return NotFound();
            }

            return View(tempUser);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tempUser = await userManager.FindByIdAsync(id.ToString());
            await userManager.DeleteAsync(tempUser);
            
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TempUserExists(long id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());

            return (user != null);
        }
    }
}
