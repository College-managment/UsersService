using Microsoft.Data.SqlClient;
using System.Data;

namespace UsersService.Infrastructure.Repositories
{
    public interface IUsersRepository
    {
        Task<int> InsertUserAsync(string email, string passwordHash, CancellationToken ct);
        Task<bool> EmailExistsAsync(string email, CancellationToken ct);
    }

    public class UsersRepository : IUsersRepository
    {
        private readonly IDbConnection _connection;

        public UsersRepository(IConfiguration config)
        {
            _connection = new SqlConnection(config.GetConnectionString("UsersDb"));
        }

        Task<int> IUsersRepository.InsertUserAsync(string email, string passwordHash, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EmailExistsAsync(string email, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}