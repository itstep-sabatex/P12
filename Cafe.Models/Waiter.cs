using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe.Models
{
    public class Waiter
    {
        public static Waiter Admin => new Waiter {Id=1,Name="Administartor",Password="12345",Birthday=DateTime.Parse("01.01.2000") };
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Password { get; set; }
        public DateTime Birthday { get; set; }
        //public int Counter { get; set; }
        public IEnumerable<Order>? Orders { get; set; }
        public override string ToString()
        {
            return $"{Name} - {Birthday}";
        }
    }
}
