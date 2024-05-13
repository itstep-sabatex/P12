using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Data;

namespace RazorPagesDemo.Pages
{
    //[Authorize(Roles ="Administrator")]
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly UserManager<ApplicationUser>  _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public PrivacyModel(ILogger<PrivacyModel> logger,UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager; 
        }

        public async Task OnGetAsync()
        {
            var r = User.IsInRole("Administrator");
            var user = await _userManager.GetUserAsync(User);
            var r1 = await _userManager.IsInRoleAsync(user,"Administrator");

            await _userManager.AddToRoleAsync(user, "Administrator");
        }
    }

}
