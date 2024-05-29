namespace RazorPagesDemo.Data
{
    public class UserTask
    {
        public int Id { get; set; }
        public string UserId { get; set; } = default!;
        public string? TaskName { get; set; }
    }
}
