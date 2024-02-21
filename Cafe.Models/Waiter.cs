namespace Cafe.Models
{
    public class Waiter
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Password { get; set; }
        public DateTime Birthday { get; set; }

        public IEnumerable<Order>? Orders { get; set; }
        public override string ToString()
        {
            return $"{Name} - {Birthday}";
        }
    }
}
