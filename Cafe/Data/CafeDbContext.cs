using Cafe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Data
{
    class CafeDbContext:DbContext
    {
        public DbSet<Waiter> Waiters { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"FileName=C:\\Users\\serhi\\.databases\\itstep\\cafe.db");
        }
    }
}
