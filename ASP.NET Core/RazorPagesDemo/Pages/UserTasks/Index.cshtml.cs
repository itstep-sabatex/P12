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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesDemo.Data.ApplicationDbContext _context;

        public IndexModel(RazorPagesDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UserTask> UserTask { get;set; } = default!;

        public async Task OnGetAsync()
        {
            UserTask = await _context.UserTasks.Where(s=>s.UserId==User.GetUserId()).ToListAsync();
        }
    }
}
