using Dapper;
using Microsoft.EntityFrameworkCore;
using SalonSystem.Data;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Models.DTOs.ResponseModels;

namespace SalonSystem.Services 
{
    public class UserService
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public UserService(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        // get all users 
        public async Task<IEnumerable<UserResponse>> GetAllUsers()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                select u.user_id as UserId, u.first_name as FirstName, u.last_name as LastName, u.user_phone as UserPhone, u.user_type as UserTypes, u.user_status as UserStatus, u.updated_at as UpdatedAt
                from users u 
                order by u.user_id;
                """;

            return await connection.QueryAsync<UserResponse>(sql);
        }



        //get user by id
        public async Task<UserResponse> GetUserById(int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                select u.user_id as UserId, u.first_name as FirstName, u.last_name as LastName, u.user_phone as UserPhone, u.user_type as UserTypes
                from users u 
                where u.user_id = @UserId and u.user_status = 1
                """;

            return await connection.QueryFirstOrDefaultAsync<UserResponse>(sql, new { UserId = userId });
        }


        //create user
        public async Task<int> CreateUser(CreateUserRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                insert into users(first_name, last_name, user_phone, user_type, user_status, created_at)
                values(@FirstName, @LastName, @UserPhone, 1, 1, current_timestamp)
                returning user_id as UserId;
                """;

            return await connection.ExecuteScalarAsync<int>(sql, request);

        }

        // user update
        public async Task<bool> UpdateUser(int userId, UpdateUserRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();
            var setParts = new List<string>();

            if (request.FirstName != null)
                setParts.Add("first_name = @FirstName");
            
            if (request.LastName != null)
                setParts.Add("last_name = @LastName");
            
            if (request.UserPhone != null)
                setParts.Add("user_phone = @UserPhone");
            if (request.UserTypes != null)
                setParts.Add("user_type = @UserTypes");
            
            if (request.UserStatus != null)
                setParts.Add("user_status = @UserStatus");
            
            if (setParts.Count == 0)
                return false;
            
            var sql = $"""
                UPDATE users
                SET {string.Join(", ", setParts)}, updated_at = current_timestamp
                WHERE user_id = @UserId
                """;

            var rowsAffected = await connection.ExecuteAsync(sql, new
                {
                    UserId = userId,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserPhone = request.UserPhone,
                    UserTypes = request.UserTypes,
                    UserStatus = request.UserStatus
                });

            return rowsAffected > 0;
        }

    }
}
