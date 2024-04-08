using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practico2024NET.Domain;
using Practico2024NET.Persistence;

namespace Practico2024NET.Controllers
{
    public class ConfederaciesController : Controller
    {
        private readonly DataContext _context;

        public ConfederaciesController(DataContext context)
        {
            _context = context;
        }

        // GET: Confederacies
        public async Task<IActionResult> Index()
        {
            return View(await _context.confederacies.ToListAsync());
        }

        // GET: Confederacies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confederacy = await _context.confederacies
                .FirstOrDefaultAsync(m => m.id == id);
            if (confederacy == null)
            {
                return NotFound();
            }

            return View(confederacy);
        }

        // GET: Confederacies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Confederacies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,creation_date")] Confederacy confederacy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(confederacy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(confederacy);
        }

        // GET: Confederacies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confederacy = await _context.confederacies.FindAsync(id);
            if (confederacy == null)
            {
                return NotFound();
            }
            return View(confederacy);
        }

        // POST: Confederacies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,creation_date")] Confederacy confederacy)
        {
            if (id != confederacy.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(confederacy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfederacyExists(confederacy.id))
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
            return View(confederacy);
        }

        // GET: Confederacies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confederacy = await _context.confederacies
                .FirstOrDefaultAsync(m => m.id == id);
            if (confederacy == null)
            {
                return NotFound();
            }

            return View(confederacy);
        }

        // POST: Confederacies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var confederacy = await _context.confederacies.FindAsync(id);
            if (confederacy != null)
            {
                _context.confederacies.Remove(confederacy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfederacyExists(int id)
        {
            return _context.confederacies.Any(e => e.id == id);
        }
    }
}
