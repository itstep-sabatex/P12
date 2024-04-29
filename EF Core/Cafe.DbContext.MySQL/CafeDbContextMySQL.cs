using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore;

namespace Cafe.DbContext.MySQL
{
    public class CafeDbContextMySQL:BaseDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var serverVersion = new MySqlServerVersion(new Version(8,0));
            optionsBuilder.UseMySql("server=localhost;database=cafe;user=root;password=12345", serverVersion);

        }
    }
}
