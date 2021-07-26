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

namespace CongresoJuvenil2021.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public UsersController(
            UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();

            return View(users);
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
