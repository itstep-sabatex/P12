using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cafe.Models;
using RazorPagesDemo.Data;
using System.Text.Unicode;
using System.Text;

namespace RazorPagesDemo.Pages.Nomenclatures
{
    public class IndexModel : PageModel
    {
        internal record NomenclatureR(int id,string name,string price);
        private readonly RazorPagesDemo.Data.ApplicationDbContext _context;

        public IndexModel(RazorPagesDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Nomenclature> Nomenclature { get;set; } = default!;
        
        [BindProperty(SupportsGet =true)]
        public string Filter { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }
        public async Task OnGetAsync()
        {
     
            Nomenclature = await _context.Nomenclature.Where(f=>f.Name.Contains(Filter ?? string.Empty)).ToListAsync();
        }

        public async Task OnPostAsync()
        {
            using (var memoryStream = new MemoryStream())
            {
                await Upload.CopyToAsync(memoryStream);
                var str = Encoding.UTF8.GetString(memoryStream.ToArray());
                var nomenclatures = System.Text.Json.JsonSerializer.Deserialize<NomenclatureR[]>(str);
                foreach (var item in nomenclatures)
                {
                    var nomenclature = new Nomenclature { Id = item.id, Name = item.name ,Price = double.Parse(item.price.Replace('.',','))};

                    await _context.Nomenclature.AddAsync(nomenclature);
                }
               
                await _context.SaveChangesAsync();

            }
            Nomenclature = await _context.Nomenclature.Where(f => f.Name.Contains(Filter ?? string.Empty)).ToListAsync();
        }

    }
}
