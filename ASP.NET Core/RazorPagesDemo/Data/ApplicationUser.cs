using Microsoft.AspNetCore.Identity;

namespace RazorPagesDemo.Data
{
    public class ApplicationUser:IdentityUser
    {
        [PersonalData]
        public string Name { get; set; } = default!;
        [PersonalData]
        public string Surname { get; set; }=default!;
    }
}
