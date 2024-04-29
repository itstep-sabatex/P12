using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cafe.Models
{
    public class ClientTable
    {
        public int A;
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        [JsonIgnore]
        public IEnumerable<Order>? Orders { get; set; }

        public static IEnumerable<ClientTable> DefaultClientTables()
        {
            yield return new ClientTable { Id=1,Name="Столик біля вікна"};
            yield return new ClientTable { Id = 2, Name = "Столик 1" };
            yield return new ClientTable { Id = 3, Name = "Столик 2" };
        }
    }
}
