using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using UsersService.Domain.Entities;

namespace UsersService.Infrastructure.Repositories
{
    public interface IUsersRepository
    {
        Task<int> InsertUserAsync(string email, string passwordHash, CancellationToken ct);
        Task<bool> EmailExistsAsync(string email, CancellationToken ct);
    }

    public class UsersRepository : IUsersRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<UsersRepository> _logger;

        public UsersRepository(IConfiguration config,
                               ILogger<UsersRepository> logger)
        {
            _connectionString = config.GetConnectionString("UsersDb") ?? throw new InvalidOperationException("UsersDb connection string not configured");
            _logger = logger;
        }

        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        Task<int> IUsersRepository.InsertUserAsync(string email, string passwordHash, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EmailExistsAsync(string email, CancellationToken ct)
        {
            using var conn = CreateConnection();
            var res = await conn.QueryAsync<List<User>>("usp_GetUserByEmail", new { Email = email }, commandType: CommandType.StoredProcedure);
            if (res.Count() > 1)
                return true;
            return false;
        }
    }
}