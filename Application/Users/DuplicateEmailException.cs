namespace UsersService.Application.Users
{
    public class DuplicateEmailException : Exception
    {
        public string Email { get; set; }
        public DuplicateEmailException(string email) : base("Email already exists: {Email}")
        {
            Email = email;
        }
    }
}