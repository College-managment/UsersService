using UsersService.Api.Contracts.Users;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Repositories;

namespace UsersService.Application.Users
{
    public interface IUsersService
    {
        Task<CreateUserResponse> CreateAsync(CreateUserRequest request, string correlationId, CancellationToken ct);
    }

    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUserRequest request, string correlationId, CancellationToken ct)
        {
            var email = request.Email.Trim();

            if (await _usersRepository.EmailExistsAsync(email, ct))
                throw new DuplicateEmailException(email);

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            _ = new User(email, passwordHash);

            var userId = await _usersRepository.InsertUserAsync(email, passwordHash, ct);
            return new CreateUserResponse(userId, email);
        }
    }
}