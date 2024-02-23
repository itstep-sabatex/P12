using Cafe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        public DbSet<ClientTable> ClientTables { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Nomenclature> Nomenclatures { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(Config.Configuration.GetConnectionString("SQLiteConnection"));
            //optionsBuilder.UseNpgsql(Config.Configuration.GetConnectionString("PostgresqlConnection"));
        }
    }
}
