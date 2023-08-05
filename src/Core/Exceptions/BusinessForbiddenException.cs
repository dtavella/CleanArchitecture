namespace Core.Exceptions
{
    public class BusinessForbiddenException : Exception
    {
        public BusinessForbiddenException(string message) : base(message) { }
    }
}
