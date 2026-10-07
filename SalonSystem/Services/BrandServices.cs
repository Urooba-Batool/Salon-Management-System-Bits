using Dapper;
using SalonSystem.Data;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Models.DTOs.ResponseModels;

namespace SalonSystem.Services
{
    public class BrandServices
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public BrandServices(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        // get all brands
        public async Task<IEnumerable<BrandResponse>> GetAllBrands()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                select b.brand_id as BrandId, b.brand_name as BrandName, b.brand_status as BrandStatus
                from brands b order by b.brand_id
                """;

            return await connection.QueryAsync<BrandResponse>(sql);
        }

        // get by id
        public async Task<BrandResponse> GetBrandsById(int brandId)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                select b.brand_id as BrandId, b.brand_name as BrandName, b.brand_status as BrandStatus
                from brands b where b.brand_id = @BrandId
                """;

            return await connection.QueryFirstOrDefaultAsync<BrandResponse>(sql, new { BrandId = brandId });
        }

        //create brands
        public async Task<int> CreateBrand(CreateBrandRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();
            const string sql = """
                insert into brands (brand_name, brand_status, created_at)
                values (@BrandName, 1, current_timestamp)
                returning brand_id
                """;
            return await connection.ExecuteScalarAsync<int>(sql, request);
        }

        //update brands
        public async Task<bool> UpdateBrand(int brandId, UpdateBrandRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();
            var setPart = new List<string>();

            if (request.BrandName != null)
                setPart.Add("brand_name = @BrandName");

            if (request.BrandStatus != null)
                setPart.Add("brand_status = @BrandStatus");

            if (setPart.Count == 0)
                return false;

            var sql = $"""
                update brands
                set {string.Join(", ", setPart)}, updated_at = current_timestamp
                where brand_id = @BrandId
                """;

            var rowsAffected = await connection.ExecuteAsync(sql, new { BrandId = brandId, BrandName = request.BrandName, BrandStatus = request.BrandStatus });

            return rowsAffected > 0;
        }
    }
}
