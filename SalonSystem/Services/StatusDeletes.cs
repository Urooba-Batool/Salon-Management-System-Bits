using Dapper;
using SalonSystem.Data;

namespace SalonSystem.Services
{
    public class StatusDeletes
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public StatusDeletes(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        //delete a role
        public async Task<bool> DeleteRole(int roleId)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                update roles 
                set role_status = 2
                where role_id = @RoleId and role_status = 1
                """;

            var RowsAffected = await connection.ExecuteAsync(sql, new { RoleId = roleId });
            return RowsAffected > 0;
        }



    }
}
