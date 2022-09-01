using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _272Ass3.Data;
using _272Ass3.Models;

namespace _272Ass3.Controllers
{
    public class SeminarsController : Controller
    {
        private readonly _272Ass3Context _context;

        public SeminarsController(_272Ass3Context context)
        {
            _context = context;
        }

        // GET: Seminars
        public async Task<IActionResult> Index()
        {
              return _context.Seminar != null ? 
                          View(await _context.Seminar.ToListAsync()) :
                          Problem("Entity set '_272Ass3Context.Seminar'  is null.");
        }

        // GET: Seminars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Seminar == null)
            {
                return NotFound();
            }

            var seminar = await _context.Seminar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seminar == null)
            {
                return NotFound();
            }

            return View(seminar);
        }

        // GET: Seminars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seminars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,CreatedDate,StartDate,RegistrationStart,RegistrationEnd,CreatedUserID,Price")] Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seminar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seminar);
        }

        // GET: Seminars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Seminar == null)
            {
                return NotFound();
            }

            var seminar = await _context.Seminar.FindAsync(id);
            if (seminar == null)
            {
                return NotFound();
            }
            return View(seminar);
        }

        // POST: Seminars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,CreatedDate,StartDate,RegistrationStart,RegistrationEnd,CreatedUserID,Price")] Seminar seminar)
        {
            if (id != seminar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seminar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeminarExists(seminar.Id))
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
            return View(seminar);
        }

        // GET: Seminars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Seminar == null)
            {
                return NotFound();
            }

            var seminar = await _context.Seminar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seminar == null)
            {
                return NotFound();
            }

            return View(seminar);
        }

        // POST: Seminars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Seminar == null)
            {
                return Problem("Entity set '_272Ass3Context.Seminar'  is null.");
            }
            var seminar = await _context.Seminar.FindAsync(id);
            if (seminar != null)
            {
                _context.Seminar.Remove(seminar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeminarExists(int id)
        {
          return (_context.Seminar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
