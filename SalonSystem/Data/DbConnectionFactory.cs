using Npgsql;
using System.Data;

namespace SalonSystem.Data
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public IDbConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection"); // 1. this fetches the connection string from the appsettings file 
            return new NpgsqlConnection(connectionString);  // 2. this creates the actual postgresql connection and returns it as IDbConnection
        }
    }
}
