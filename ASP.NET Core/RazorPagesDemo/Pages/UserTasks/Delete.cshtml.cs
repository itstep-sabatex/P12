using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesDemo.Data;
using RazorPagesDemo.Services;

namespace RazorPagesDemo.Pages.UserTasks
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesDemo.Data.ApplicationDbContext _context;

        public DeleteModel(RazorPagesDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserTask UserTask { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usertask = await _context.UserTasks.FirstOrDefaultAsync(m => m.Id == id);

            if (usertask == null)
            {
                return NotFound();
            }
            else
            {
                UserTask = usertask;
            }

            if (UserTask.UserId != User.GetUserId())
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usertask = await _context.UserTasks.FindAsync(id);
            if (usertask != null)
            {
                UserTask = usertask;
                if (UserTask.UserId != User.GetUserId())
                {
                    return NotFound();
                }

                _context.UserTasks.Remove(UserTask);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
