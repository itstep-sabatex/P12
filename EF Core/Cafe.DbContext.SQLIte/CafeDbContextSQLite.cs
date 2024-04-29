using Microsoft.EntityFrameworkCore;

namespace Cafe.DbContext.SQLIte
{
    public class CafeDbContextSQLite:BaseDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("FileName=C:/Users/serhi/.databases/itstep/cafe.db");
        }
    }
}
