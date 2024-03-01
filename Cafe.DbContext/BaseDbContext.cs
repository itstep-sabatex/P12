using Cafe.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;

namespace Cafe.DbContext
{
    public abstract class BaseDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        readonly DbContextOptions contextOptions;
        //protected BaseDbContext(DbContextOptions contextOptions)
        //{
        //    this.contextOptions = contextOptions;   
        //}

        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<ClientTable> ClientTables { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Nomenclature> Nomenclatures { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Waiter>().HasData(new Waiter[] { Waiter.Admin });
            modelBuilder.Entity<Role>().HasData(new Role[] { Role.Admin, Role.Manager, Role.User });
            modelBuilder.Entity<UserRole>().HasData(new UserRole[] { new UserRole { Id = 1, RoleId = Role.Admin.Id, WaiterId = Waiter.Admin.Id } });

        }
    }
}
