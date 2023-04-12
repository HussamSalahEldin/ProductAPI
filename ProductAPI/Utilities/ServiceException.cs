namespace ProductAPI.Utilities
{
    public class ServiceException : Exception
    {
        public ServiceException(string message, Exception innerException) : base(message, innerException)
        {
            Console.WriteLine($"{message}, {InnerException?.Message}");
        }
    }

}