using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UcakRezervasyon.Data;
using UcakRezervasyon.Models;

namespace UcakRezervasyon.Controllers
{
    public class ucusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ucusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ucus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ucus.Include(u => u.guzergah).Include(u => u.ucak);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ucus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ucus == null)
            {
                return NotFound();
            }

            var ucus = await _context.ucus
                .Include(u => u.guzergah)
                .Include(u => u.ucak)
                .FirstOrDefaultAsync(m => m.ucusId == id);
            if (ucus == null)
            {
                return NotFound();
            }

            return View(ucus);
        }

        // GET: ucus/Create
        public IActionResult Create()
        {
            ViewData["guzergahId"] = new SelectList(_context.guzergah, "guzergahId", "guzergahName");
            ViewData["ucakId"] = new SelectList(_context.ucak, "ucakId", "ucakName");
            return View();
        }

        // POST: ucus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ucusId,ucakId,guzergahId")] ucus ucus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ucus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["guzergahId"] = new SelectList(_context.guzergah, "guzergahId", "guzergahName", ucus.guzergahId);
            ViewData["ucakId"] = new SelectList(_context.ucak, "ucakId", "ucakName", ucus.ucakId);
            return View(ucus);
        }

        // GET: ucus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ucus == null)
            {
                return NotFound();
            }

            var ucus = await _context.ucus.FindAsync(id);
            if (ucus == null)
            {
                return NotFound();
            }
            ViewData["guzergahId"] = new SelectList(_context.guzergah, "guzergahId", "guzergahName", ucus.guzergahId);
            ViewData["ucakId"] = new SelectList(_context.ucak, "ucakId", "ucakName", ucus.ucakId);
            return View(ucus);
        }

        // POST: ucus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ucusId,ucakId,guzergahId")] ucus ucus)
        {
            if (id != ucus.ucusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ucus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ucusExists(ucus.ucusId))
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
            ViewData["guzergahId"] = new SelectList(_context.guzergah, "guzergahId", "guzergahName", ucus.guzergahId);
            ViewData["ucakId"] = new SelectList(_context.ucak, "ucakId", "ucakName", ucus.ucakId);
            return View(ucus);
        }

        // GET: ucus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ucus == null)
            {
                return NotFound();
            }

            var ucus = await _context.ucus
                .Include(u => u.guzergah)
                .Include(u => u.ucak)
                .FirstOrDefaultAsync(m => m.ucusId == id);
            if (ucus == null)
            {
                return NotFound();
            }

            return View(ucus);
        }

        // POST: ucus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ucus == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ucus'  is null.");
            }
            var ucus = await _context.ucus.FindAsync(id);
            if (ucus != null)
            {
                _context.ucus.Remove(ucus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ucusExists(int id)
        {
          return (_context.ucus?.Any(e => e.ucusId == id)).GetValueOrDefault();
        }
    }
}
