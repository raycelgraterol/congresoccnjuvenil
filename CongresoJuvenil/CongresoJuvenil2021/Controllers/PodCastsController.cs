using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CongresoJuvenil2021.Data;
using CongresoJuvenil2021.Models;
using Microsoft.AspNetCore.Authorization;

namespace CongresoJuvenil2021.Controllers
{
    [Authorize]
    public class PodCastsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PodCastsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PodCasts
        public async Task<IActionResult> Index()
        {
            return View(await _context.PodCasts.ToListAsync());
        }

        // GET: PodCasts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podCast = await _context.PodCasts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (podCast == null)
            {
                return NotFound();
            }

            return View(podCast);
        }

        // GET: PodCasts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PodCasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Link,Description,TransmissionDate")] PodCast podCast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(podCast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(podCast);
        }

        // GET: PodCasts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podCast = await _context.PodCasts.FindAsync(id);
            if (podCast == null)
            {
                return NotFound();
            }
            return View(podCast);
        }

        // POST: PodCasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Link,Description,TransmissionDate")] PodCast podCast)
        {
            if (id != podCast.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(podCast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PodCastExists(podCast.Id))
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
            return View(podCast);
        }

        // GET: PodCasts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podCast = await _context.PodCasts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (podCast == null)
            {
                return NotFound();
            }

            return View(podCast);
        }

        // POST: PodCasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var podCast = await _context.PodCasts.FindAsync(id);
            _context.PodCasts.Remove(podCast);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PodCastExists(int id)
        {
            return _context.PodCasts.Any(e => e.Id == id);
        }
    }
}
