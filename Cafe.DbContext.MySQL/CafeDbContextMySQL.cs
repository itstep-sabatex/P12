using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;

namespace Cafe.DbContext.MySQL
{
    public class CafeDbContextMySQL:BaseDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseMySql();
        }
    }
}
