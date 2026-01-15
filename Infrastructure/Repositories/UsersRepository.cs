using Microsoft.Data.SqlClient;
using System.Data;

namespace UsersService.Infrastructure.Repositories
{
    public interface IUsersRepository
    {
        Task<bool> InsertUserAsync(string email, string passwordHash);
    }

    public class UsersRepository : IUsersRepository
    {
        private readonly IDbConnection _connection;
        private readonly

        public UsersRepository(IConfiguration config)
        {
            _connection = new SqlConnection(config.GetConnectionString("UsersDb"));
        }


        public async Task<bool> InsertUserAsync(string email, string passwordHash)
        {

        }
    }
}