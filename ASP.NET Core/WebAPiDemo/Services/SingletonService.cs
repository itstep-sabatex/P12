namespace WebAPiDemo.Services
{
    public class SingletonService
    {
        public readonly DateTime date;
        public SingletonService()
        {
            date = DateTime.UtcNow;
        }
    }
}
