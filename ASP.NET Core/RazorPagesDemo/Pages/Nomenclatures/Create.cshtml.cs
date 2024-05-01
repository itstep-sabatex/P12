using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cafe.Models;
using RazorPagesDemo.Data;

namespace RazorPagesDemo.Pages.Nomenclatures
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesDemo.Data.ApplicationDbContext _context;

        public CreateModel(RazorPagesDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Nomenclature Nomenclature { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Nomenclature.Add(Nomenclature);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
