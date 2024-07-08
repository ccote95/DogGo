using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogGo.Data;
using DogGo.Models;

namespace DogGo.Controllers
{
    public class WalkersController : Controller
    {
        private readonly DogGoDbContext _context;

        public WalkersController(DogGoDbContext context)
        {
            _context = context;
        }

        // GET: Walkers
        // GET: Walkers
        public ActionResult Index()
        {
            List<Walker> walkers = _context.Walkers.Include(w => w.Neighborhood).ToList();

            return View(walkers);
        }

        // GET: Walkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walker = await _context.Walkers
                .Include(w => w.Neighborhood)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (walker == null)
            {
                return NotFound();
            }

            return View(walker);
        }

        // GET: Walkers/Create
        public IActionResult Create()
        {
            ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhoods, "Id", "Id");
            return View();
        }

        // POST: Walkers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NeighborhoodId,ImageUrl")] Walker walker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(walker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhoods, "Id", "Id", walker.NeighborhoodId);
            return View(walker);
        }

        // GET: Walkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walker = await _context.Walkers.FindAsync(id);
            if (walker == null)
            {
                return NotFound();
            }
            ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhoods, "Id", "Id", walker.NeighborhoodId);
            return View(walker);
        }

        // POST: Walkers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NeighborhoodId,ImageUrl")] Walker walker)
        {
            if (id != walker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(walker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WalkerExists(walker.Id))
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
            ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhoods, "Id", "Id", walker.NeighborhoodId);
            return View(walker);
        }

        // GET: Walkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walker = await _context.Walkers
                .Include(w => w.Neighborhood)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (walker == null)
            {
                return NotFound();
            }

            return View(walker);
        }

        // POST: Walkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var walker = await _context.Walkers.FindAsync(id);
            if (walker != null)
            {
                _context.Walkers.Remove(walker);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WalkerExists(int id)
        {
            return _context.Walkers.Any(e => e.Id == id);
        }
    }
}
