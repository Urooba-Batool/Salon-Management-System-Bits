using Dapper;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SalonSystem.Data;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Models.DTOs.ResponseModels;
using SalonSystem.Models.Entities;

namespace SalonSystem.Services
{
    public class RoleServices
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public RoleServices(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        // get all roles
        public async Task<IEnumerable<RolesResponse>> GetAllRoles()
        {
            using var connection = _connectionFactory.CreateConnection();   // the _connectionFactory calls and gives the postgresql connection

            const string sql = """
            select r.role_id as RoleId, r.role_name as RoleName, r.role_status as RoleStatus
            from roles r order by r.role_id;    
            """;        // gets all roles even if they are inactive

            return await connection.QueryAsync<RolesResponse>(sql);     // queryasync returns all the rows or multiple rows 
        }


        // get by id
        public async Task<RolesResponse?> GetRoleById(int roleId)
        {
            using var connection = _connectionFactory.CreateConnection();   // the _connectionFactory calls and gives the postgresql connection

            const string sql = """
            select r.role_id as RoleId, r.role_name as RoleName
            from roles r where r.role_id = @RoleId and r.role_status = 1
            """;

            return await connection.QueryFirstOrDefaultAsync<RolesResponse>(sql, new { RoleId = roleId });      // QueryFirstOrDefaultAsync returns the first or one row just like sql exists
        }



        //create new role
        public async Task<int> CreateRole(CreateRoleRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                insert into roles(role_name, role_status, created_at) 
                values(@RoleName, 1, current_timestamp)
                returning role_id as RoleId;
                """;

            return await connection.ExecuteScalarAsync<int>(sql, request);      // ExecuteScalarAsync returns one single value and not a row 
        }

        //update role
        public async Task<bool> UpdateRole(int roleId, UpdateRolesRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();
            var setParts = new List<string>();
            
            if(request.RoleName != null)
            {
                setParts.Add("role_name = @RoleName");
            }

            if (request.RoleStatus != null)
            {
                setParts.Add("role_status = @RoleStatus");
            }

            if (setParts.Count == 0)
            {
                return false;
            }

            var sql = $"""
                UPDATE roles
                SET {string.Join(", ", setParts)}
                WHERE role_id = @RoleId
                """;

            var RowsAffected = await connection.ExecuteAsync(sql, new { RoleId = roleId, RoleName = request.RoleName, RoleStatus = request.RoleStatus });
            return RowsAffected > 0;
        }

    }
}
