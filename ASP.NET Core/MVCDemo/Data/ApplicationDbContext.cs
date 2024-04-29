using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cafe.Models;

namespace MVCDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cafe.Models.Nomenclature> Nomenclature { get; set; } = default!;
        public DbSet<Cafe.Models.Order> Order { get; set; } = default!;
        public DbSet<Cafe.Models.ClientTable> ClientTable { get; set; } = default!;
        public DbSet<Cafe.Models.Waiter> Waiter { get; set; } = default!;
        public DbSet<Cafe.Models.OrderDetail> OrderDetail { get; set; } = default!;
    }
}
