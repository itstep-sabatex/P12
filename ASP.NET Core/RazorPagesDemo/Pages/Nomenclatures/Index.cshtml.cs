using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cafe.Models;
using RazorPagesDemo.Data;

namespace RazorPagesDemo.Pages.Nomenclatures
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesDemo.Data.ApplicationDbContext _context;

        public IndexModel(RazorPagesDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Nomenclature> Nomenclature { get;set; } = default!;
        
        [BindProperty(SupportsGet =true)]
        public string Filter { get; set; }
        public async Task OnGetAsync()
        {
            Nomenclature = await _context.Nomenclature.Where(f=>f.Name.Contains(Filter ?? string.Empty)).ToListAsync();
        }
    }
}
