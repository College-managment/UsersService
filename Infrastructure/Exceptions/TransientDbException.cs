namespace UsersService.Infrastructure.Exceptions
{
    public sealed class TransientDbException : Exception
    {
        public TransientDbException(string message, Exception inner) : base(message, inner) { }
    }
}