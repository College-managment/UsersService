namespace UsersService.Domain.Exceptions
{
    public sealed class DomainInvariantException : Exception
    {
        public DomainInvariantException(string message) : base(message) { }
    }
}