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
    public class ucaksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ucaksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ucaks
        public async Task<IActionResult> Index()
        {
              return _context.ucak != null ? 
                          View(await _context.ucak.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ucak'  is null.");
        }

        // GET: ucaks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ucak == null)
            {
                return NotFound();
            }

            var ucak = await _context.ucak
                .FirstOrDefaultAsync(m => m.ucakId == id);
            if (ucak == null)
            {
                return NotFound();
            }

            return View(ucak);
        }

        // GET: ucaks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ucaks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ucakId,ucakName,koltukSayisi")] ucak ucak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ucak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ucak);
        }

        // GET: ucaks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ucak == null)
            {
                return NotFound();
            }

            var ucak = await _context.ucak.FindAsync(id);
            if (ucak == null)
            {
                return NotFound();
            }
            return View(ucak);
        }

        // POST: ucaks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ucakId,ucakName,koltukSayisi")] ucak ucak)
        {
            if (id != ucak.ucakId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ucak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ucakExists(ucak.ucakId))
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
            return View(ucak);
        }

        // GET: ucaks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ucak == null)
            {
                return NotFound();
            }

            var ucak = await _context.ucak
                .FirstOrDefaultAsync(m => m.ucakId == id);
            if (ucak == null)
            {
                return NotFound();
            }

            return View(ucak);
        }

        // POST: ucaks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ucak == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ucak'  is null.");
            }
            var ucak = await _context.ucak.FindAsync(id);
            if (ucak != null)
            {
                _context.ucak.Remove(ucak);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ucakExists(int id)
        {
          return (_context.ucak?.Any(e => e.ucakId == id)).GetValueOrDefault();
        }
    }
}
