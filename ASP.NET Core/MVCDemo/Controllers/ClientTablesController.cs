using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cafe.Models;
using MVCDemo.Data;

namespace MVCDemo.Controllers
{
    public class ClientTablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientTablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClientTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientTable.ToListAsync());
        }

        // GET: ClientTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientTable = await _context.ClientTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientTable == null)
            {
                return NotFound();
            }

            return View(clientTable);
        }

        // GET: ClientTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ClientTable clientTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientTable);
        }

        // GET: ClientTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientTable = await _context.ClientTable.FindAsync(id);
            if (clientTable == null)
            {
                return NotFound();
            }
            return View(clientTable);
        }

        // POST: ClientTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ClientTable clientTable)
        {
            if (id != clientTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientTableExists(clientTable.Id))
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
            return View(clientTable);
        }

        // GET: ClientTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientTable = await _context.ClientTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientTable == null)
            {
                return NotFound();
            }

            return View(clientTable);
        }

        // POST: ClientTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientTable = await _context.ClientTable.FindAsync(id);
            if (clientTable != null)
            {
                _context.ClientTable.Remove(clientTable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientTableExists(int id)
        {
            return _context.ClientTable.Any(e => e.Id == id);
        }
    }
}
