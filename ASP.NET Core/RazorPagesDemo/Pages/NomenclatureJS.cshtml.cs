using Cafe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesDemo.Pages
{
    public class NomenclatureJSModel : PageModel
    {
        public Nomenclature? NomenclatureEdit { get; set; }
        public void OnGet()
        {
        }

        public void OnPostNomenclature()
        {
            var i = 0;

        }
    }
}
