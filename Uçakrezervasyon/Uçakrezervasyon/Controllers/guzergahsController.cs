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
    public class guzergahsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public guzergahsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: guzergahs
        public async Task<IActionResult> Index()
        {
              return _context.guzergah != null ? 
                          View(await _context.guzergah.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.guzergah'  is null.");
        }

        // GET: guzergahs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.guzergah == null)
            {
                return NotFound();
            }

            var guzergah = await _context.guzergah
                .FirstOrDefaultAsync(m => m.guzergahId == id);
            if (guzergah == null)
            {
                return NotFound();
            }

            return View(guzergah);
        }

        // GET: guzergahs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: guzergahs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("guzergahId,guzergahName")] guzergah guzergah)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guzergah);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guzergah);
        }

        // GET: guzergahs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.guzergah == null)
            {
                return NotFound();
            }

            var guzergah = await _context.guzergah.FindAsync(id);
            if (guzergah == null)
            {
                return NotFound();
            }
            return View(guzergah);
        }

        // POST: guzergahs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("guzergahId,guzergahName")] guzergah guzergah)
        {
            if (id != guzergah.guzergahId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guzergah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!guzergahExists(guzergah.guzergahId))
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
            return View(guzergah);
        }

        // GET: guzergahs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.guzergah == null)
            {
                return NotFound();
            }

            var guzergah = await _context.guzergah
                .FirstOrDefaultAsync(m => m.guzergahId == id);
            if (guzergah == null)
            {
                return NotFound();
            }

            return View(guzergah);
        }

        // POST: guzergahs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.guzergah == null)
            {
                return Problem("Entity set 'ApplicationDbContext.guzergah'  is null.");
            }
            var guzergah = await _context.guzergah.FindAsync(id);
            if (guzergah != null)
            {
                _context.guzergah.Remove(guzergah);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool guzergahExists(int id)
        {
          return (_context.guzergah?.Any(e => e.guzergahId == id)).GetValueOrDefault();
        }
    }
}
