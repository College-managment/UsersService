using UsersService.Domain.Exceptions;

namespace UsersService.Domain.Entities
{
    public sealed class User
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }

        public User() { }

        public User(string email, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new DomainInvariantException("User created with empty email");

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new DomainInvariantException("User created with empty password hash");

            Email = email.Trim();
            PasswordHash = passwordHash;
            IsActive = true;
        }
    }
}