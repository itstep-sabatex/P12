using Cafe.DbContext;
using Cafe.Models;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class CafeArchive
    {
        public ClientTable[]?  ClientTables   { get; set; }
        public Currency[]? Currencies { get; set; }
        public Nomenclature[]? Nomenclatures { get; set; }
        public Order[]? Orders { get; set; }
        public OrderDetail[]? OrderDetails { get; set; }
        public Role[]? Roles { get; set; }
        public UserRole[]? UserRoles { get; set; }
        public Waiter[]? Waiters { get; set; }

        public static string CreateArchive(BaseDbContext context)
        {
            var cs = Config.Configuration.GetConnectionString("DefaultConnection");
            string r = "";
            using (var connection = new SqliteConnection(cs))
            {
                var nomenclatures = connection.Query("select * from nomenclatures").ToArray();
                foreach (var nom in nomenclatures)
                {
                    r = r +nom.Name+"\n";
                }
               
            }
            

            var archive = new CafeArchive();
            archive.ClientTables = context.ClientTables.ToArray();
            archive.Currencies = context.Currencies.ToArray();
            archive.Nomenclatures = context.Nomenclatures.ToArray();
            archive.Orders = context.Orders.ToArray();
            archive.OrderDetails = context.OrderDetails.ToArray();
            //archive.Roles = context.Roles.ToArray();
            //archive.UserRoles = context.UserRoles.ToArray();
            archive.Waiters = context.Waiters.ToArray();
            var result = System.Text.Json.JsonSerializer.Serialize(archive);

            var baseAr = System.Text.Json.JsonSerializer.Deserialize<CafeArchive>(result);

            //var attr = context.GetType().GetProperty("Id");
            //attr.GetValue(context);



            ////foreach (var attr in context.GetType().GetProperties())
            //{
            //    attr = context.GetType().GetProperty("Id");
            //    attr.SetValue(context, 10);

            //}


            return result;
        }
 
    }
}
