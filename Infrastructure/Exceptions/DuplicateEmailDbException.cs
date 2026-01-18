namespace UsersService.Infrastructure.Exceptions
{
    public sealed class DuplicateEmailDbException : Exception
    {
        public string Email { get; set; }
        public DuplicateEmailDbException(string email, Exception inner) : base($"Duplicate email detected in DB: {email}", inner) 
        {
            Email = email;
        }
    }
}