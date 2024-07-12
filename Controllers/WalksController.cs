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
    public class WalksController : Controller
    {
        private readonly DogGoDbContext _context;

        public WalksController(DogGoDbContext context)
        {
            _context = context;
        }

        // GET: Walks
        public async Task<IActionResult> Index()
        {
            var dogGoDbContext = _context.Walks.Include(w => w.Dog).Include(w => w.Walker);
            return View(await dogGoDbContext.ToListAsync());
        }

        // GET: Walks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walk = await _context.Walks
                .Include(w => w.Dog)
                .Include(w => w.Walker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (walk == null)
            {
                return NotFound();
            }

            return View(walk);
        }

        // GET: Walks/Create
        public IActionResult Create()
        {
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "Id");
            ViewData["WalkerId"] = new SelectList(_context.Walkers, "Id", "Id");
            return View();
        }

        // POST: Walks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Walk walk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(walk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "Id", walk.DogId);
            ViewData["WalkerId"] = new SelectList(_context.Walkers, "Id", "Id", walk.WalkerId);
            return View(walk);
        }

        // GET: Walks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walk = await _context.Walks.FindAsync(id);
            if (walk == null)
            {
                return NotFound();
            }
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "Id", walk.DogId);
            ViewData["WalkerId"] = new SelectList(_context.Walkers, "Id", "Id", walk.WalkerId);
            return View(walk);
        }

        // POST: Walks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DogId,WalkerId,Duration")] Walk walk)
        {
            if (id != walk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(walk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WalkExists(walk.Id))
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
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "Id", walk.DogId);
            ViewData["WalkerId"] = new SelectList(_context.Walkers, "Id", "Id", walk.WalkerId);
            return View(walk);
        }

        // GET: Walks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walk = await _context.Walks
                .Include(w => w.Dog)
                .Include(w => w.Walker)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (walk == null)
            {
                return NotFound();
            }

            return View(walk);
        }

        // POST: Walks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var walk = await _context.Walks.FindAsync(id);
            if (walk != null)
            {
                _context.Walks.Remove(walk);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WalkExists(int id)
        {
            return _context.Walks.Any(e => e.Id == id);
        }
    }
}
