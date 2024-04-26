namespace WebAPiDemo.Services
{
    public class ScopedService
    {
        public readonly DateTime date;
        public ScopedService()
        {
            date = DateTime.UtcNow;
        }
    }
}
