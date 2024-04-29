namespace WebAPiDemo.Services
{
    public class TransientService
    {
        public readonly DateTime date;
        public TransientService()
        {
            date = DateTime.UtcNow;
        }
    }
}
