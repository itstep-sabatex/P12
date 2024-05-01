using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cafe.Models;
using MVCDemo.Data;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class NomenclaturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NomenclaturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nomenclatures
        public async Task<IActionResult> Index(string? filter,bool SearchMiddle)
        {
            var model = new NomenclatureIndexViwModel
            {
                Filter = filter ?? string.Empty,
                Items = await _context.Nomenclature.Where(s => s.Name.StartsWith(filter ?? string.Empty)).ToListAsync()

            };
 
            return View(model);
        }

        // GET: Nomenclatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomenclature = await _context.Nomenclature
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nomenclature == null)
            {
                return NotFound();
            }

            return View(nomenclature);
        }

        // GET: Nomenclatures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nomenclatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] Nomenclature nomenclature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nomenclature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nomenclature);
        }

        // GET: Nomenclatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomenclature = await _context.Nomenclature.FindAsync(id);
            if (nomenclature == null)
            {
                return NotFound();
            }
            return View(nomenclature);
        }

        // POST: Nomenclatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] Nomenclature nomenclature)
        {
            if (id != nomenclature.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nomenclature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NomenclatureExists(nomenclature.Id))
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
            return View(nomenclature);
        }

        // GET: Nomenclatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomenclature = await _context.Nomenclature
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nomenclature == null)
            {
                return NotFound();
            }

            return View(nomenclature);
        }

        // POST: Nomenclatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nomenclature = await _context.Nomenclature.FindAsync(id);
            if (nomenclature != null)
            {
                _context.Nomenclature.Remove(nomenclature);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NomenclatureExists(int id)
        {
            return _context.Nomenclature.Any(e => e.Id == id);
        }
    }
}
