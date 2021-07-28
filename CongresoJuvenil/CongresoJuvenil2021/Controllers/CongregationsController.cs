using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CongresoJuvenil2021.Data;
using CongresoJuvenil2021.Models;

namespace CongresoJuvenil2021.Controllers
{
    public class CongregationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CongregationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Congregations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Congregations.ToListAsync());
        }

        // GET: Congregations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congregation = await _context.Congregations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (congregation == null)
            {
                return NotFound();
            }

            return View(congregation);
        }

        // GET: Congregations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Congregations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Direction")] Congregation congregation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(congregation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(congregation);
        }

        // GET: Congregations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congregation = await _context.Congregations.FindAsync(id);
            if (congregation == null)
            {
                return NotFound();
            }
            return View(congregation);
        }

        // POST: Congregations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Direction")] Congregation congregation)
        {
            if (id != congregation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(congregation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CongregationExists(congregation.Id))
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
            return View(congregation);
        }

        // GET: Congregations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congregation = await _context.Congregations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (congregation == null)
            {
                return NotFound();
            }

            return View(congregation);
        }

        // POST: Congregations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var congregation = await _context.Congregations.FindAsync(id);
            _context.Congregations.Remove(congregation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CongregationExists(int id)
        {
            return _context.Congregations.Any(e => e.Id == id);
        }
    }
}
