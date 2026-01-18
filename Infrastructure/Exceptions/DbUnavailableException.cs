namespace UsersService.Infrastructure.Exceptions
{
    public sealed class DbUnavailableException : Exception
    {
        public DbUnavailableException(string message, Exception inner) : base(message, inner) { }
    }
}