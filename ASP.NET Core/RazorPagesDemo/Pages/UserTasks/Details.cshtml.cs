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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesDemo.Data.ApplicationDbContext _context;

        public DetailsModel(RazorPagesDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
