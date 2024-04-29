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
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Order.Include(o => o.ClientTable).Include(o => o.Waiter);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.ClientTable)
                .Include(o => o.Waiter)
                .FirstOrDefaultAsync(m => m.Date == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["ClientTableId"] = new SelectList(_context.Set<ClientTable>(), "Id", "Name");
            ViewData["WaiterId"] = new SelectList(_context.Set<Waiter>(), "Id", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,WaiterId,ClientTableId,Bill")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientTableId"] = new SelectList(_context.Set<ClientTable>(), "Id", "Name", order.ClientTableId);
            ViewData["WaiterId"] = new SelectList(_context.Set<Waiter>(), "Id", "Name", order.WaiterId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["ClientTableId"] = new SelectList(_context.Set<ClientTable>(), "Id", "Name", order.ClientTableId);
            ViewData["WaiterId"] = new SelectList(_context.Set<Waiter>(), "Id", "Name", order.WaiterId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateTime id, [Bind("Id,Date,WaiterId,ClientTableId,Bill")] Order order)
        {
            if (id != order.Date)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Date))
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
            ViewData["ClientTableId"] = new SelectList(_context.Set<ClientTable>(), "Id", "Name", order.ClientTableId);
            ViewData["WaiterId"] = new SelectList(_context.Set<Waiter>(), "Id", "Name", order.WaiterId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.ClientTable)
                .Include(o => o.Waiter)
                .FirstOrDefaultAsync(m => m.Date == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(DateTime id)
        {
            return _context.Order.Any(e => e.Date == id);
        }
    }
}
