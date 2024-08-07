using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesDemo.Data;
using RazorPagesDemo.Services;

namespace RazorPagesDemo.Pages.UserTasks
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly RazorPagesDemo.Data.ApplicationDbContext _context;

        public EditModel(RazorPagesDemo.Data.ApplicationDbContext context)
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

            var usertask =  await _context.UserTasks.FirstOrDefaultAsync(m => m.Id == id);
            if (usertask == null)
            {
                return NotFound();
            }

            if (usertask.UserId != User.GetUserId())
            {
                return NotFound();
            }

            UserTask = usertask;
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

            if (UserTask.UserId != User.GetUserId())
            {
                return NotFound();
            }


            _context.Attach(UserTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTaskExists(UserTask.Id))
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

        private bool UserTaskExists(int id)
        {
            return _context.UserTasks.Any(e => e.Id == id);
        }
    }
}
