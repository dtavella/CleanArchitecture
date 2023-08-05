namespace Core.Exceptions
{
    public class BusinessUnauthorizedException : Exception
    {
        public BusinessUnauthorizedException(string message) : base(message) { }
    }
}
