namespace Cafe.Models
{
    public class Waiter
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime Birthday { get; set; }
        public override string ToString()
        {
            return $"{Name} - {Birthday}";
        }
    }
}
