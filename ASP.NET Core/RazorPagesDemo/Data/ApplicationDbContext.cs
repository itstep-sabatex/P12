using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cafe.Models;

namespace RazorPagesDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cafe.Models.Nomenclature> Nomenclature { get; set; } = default!;
        public DbSet<UserTask> UserTasks { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserTask>().HasOne<ApplicationUser>().WithMany().HasForeignKey(F=>F.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
