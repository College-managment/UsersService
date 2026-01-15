namespace UsersService.Api.Contracts.Users
{
    public sealed record CreateUserRequest (string Email, string Password);
}