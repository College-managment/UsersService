using Microsoft.Data.SqlClient;
using System.Data;

namespace UsersService.Repositories
{
    public interface IUsersRepository
    {

    }

    public class UsersRepository : IUsersRepository
    {
        private readonly IDbConnection _connection;

        public UsersRepository(IConfiguration config)
        {
            _connection = new SqlConnection(config.GetConnectionString("UsersDb"));
        }
    }
}
