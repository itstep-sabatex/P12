using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cafe.Models;
using RazorPagesDemo.Data;

namespace RazorPagesDemo.Pages.Nomenclatures
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesDemo.Data.ApplicationDbContext _context;

        public EditModel(RazorPagesDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Nomenclature Nomenclature { get; set; } = default!;

        public async Task<IActionResult> OnGetFilterAsync(int? id) // /Nomenclatures?handle=Filter
        {
            return Page();
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomenclature =  await _context.Nomenclature.FirstOrDefaultAsync(m => m.Id == id);
            if (nomenclature == null)
            {
                return NotFound();
            }
            Nomenclature = nomenclature;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ModelState.AddModelError("Nomenclature.Name", "Просто так бакенд не пропускає"); // 2 слова/унікальність/ Пиво Чернігівське  = Чернігівське пиво


            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Nomenclature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NomenclatureExists(Nomenclature.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NomenclatureExists(int id)
        {
            return _context.Nomenclature.Any(e => e.Id == id);
        }
    }
}
