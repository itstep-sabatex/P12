using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesDemo.Data;
using RazorPagesDemo.Services;

namespace RazorPagesDemo.Pages.UserTasks
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly RazorPagesDemo.Data.ApplicationDbContext _context;

        public CreateModel(RazorPagesDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            UserTask task = new UserTask();
            task.UserId = User.GetUserId();
            return Page();
        }

        [BindProperty]
        public UserTask UserTask { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (UserTask.UserId != User.GetUserId())
            {
                return NotFound();
            }
            _context.UserTasks.Add(UserTask);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
