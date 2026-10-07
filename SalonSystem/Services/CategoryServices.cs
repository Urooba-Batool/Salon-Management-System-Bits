using Dapper;
using SalonSystem.Data;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Models.DTOs.ResponseModels;

namespace SalonSystem.Services
{
    public class CategoryServices
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public CategoryServices(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        // get all category
        public async Task<IEnumerable<CategoryResponse>> GetAllCategory()
        {
            using var connection =  _connectionFactory.CreateConnection();

            const string sql = """
                select c.category_id as CategoryId, c.category_name as CategoryName, c.category_status as CategoryStatus
                from categories c order by c.category_id
                """;

            return await connection.QueryAsync<CategoryResponse>(sql);
        }

        // get by id
        public async Task<CategoryResponse> GetCategoryById(int categoryId)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                select c.category_id as CategoryId, c.category_name as CategoryName, c.category_status as CategoryStatus
                from categories c where c.category_id = @CategoryId
                """;

            return await connection.QueryFirstOrDefaultAsync<CategoryResponse>(sql, new { CategoryId = categoryId });
        }

        //create category
        public async Task<int> CreateCategory(CreateCategoryRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();
            const string sql = """
                insert into categories (category_name, category_status, created_at)
                values (@CategoryName, 1, current_timestamp)
                returning category_id
                """;
            return await connection.ExecuteScalarAsync<int>(sql, request);
        }

        //update category
        public async Task<bool> UpdateCategory(int categoryId, UpdateCategoryRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();
            var setPart = new List<string>();

            if (request.CategoryName != null)
                setPart.Add("category_name = @CategoryName");

            if (request.CategoryStatus != null)
                setPart.Add("category_status = @CategoryStatus");

            if (setPart.Count == 0)
                return false;

            var sql = $"""
                update categories
                set {string.Join(", ", setPart)}, updated_at = current_timestamp
                where category_id = @CategoryId
                """;

            var rowsAffected =  await connection.ExecuteAsync(sql, new { CategoryId = categoryId, CategoryName = request.CategoryName, CategoryStatus = request.CategoryStatus });

            return rowsAffected > 0;
        }
    }
}
