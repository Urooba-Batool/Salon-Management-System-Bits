using SalonSystem.Data;
using Dapper;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Models.DTOs.ResponseModels;

namespace SalonSystem.Services
{
    public class ProductServices
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ProductServices(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        // get all Products
        public async Task<IEnumerable<ProductResponse>> GetAllProducts()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                select p.product_id as ProductId, p.product_name as ProductName, b.brand_name as BrandName, c.category_name as CategoryName, p.product_price as ProductPrice, p.instock_quantity as InStockQuantity, p.product_status as ProductStatus
                from products p
                left join brands b on p.brand_id = b.brand_id
                left join categories c on p.category_id = c.category_id
                order by p.product_id
                """;

            return await connection.QueryAsync<ProductResponse>(sql);
        }

        // get by id
        public async Task<ProductResponse> GetProductById(int productId)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                select p.product_id as ProductId, p.product_name as ProductName, b.brand_name as BrandName, c.category_name as CategoryName, p.product_price as ProductPrice, p.instock_quantity as InStockQuantity, p.product_status as ProductStatus
                from products p
                left join brands b on p.brand_id = b.brand_id
                left join categories c on p.category_id = c.category_id
                where p.product_id = @ProductId
                order by p.product_id
                """;

            return await connection.QueryFirstOrDefaultAsync<ProductResponse>(sql, new { ProductId = productId });
        }

        //create products
        public async Task<int> CreateProduct(CreateProductRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();
            const string sql = """
                insert into products (product_name, product_price, brand_id, instock_quantity, category_id, product_status, created_at)
                values (@ProductName, @ProductPrice, @BrandId, @InStockQuantity, @CategoryId, 1, current_timestamp)
                returning product_id
                """;
            return await connection.ExecuteScalarAsync<int>(sql, request);
        }


        //update products
        public async Task<bool> UpdateProducts(int productId, UpdateProductRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();
            var setPart = new List<string>();

            if (request.ProductName != null)
                setPart.Add("product_name = @ProductName");

            if (request.ProductPrice != null)
                setPart.Add("product_price = @ProductPrice");

            if (request.BrandId != null)
                setPart.Add("brand_id = @BrandId");

            if (request.CategoryId != null)
                setPart.Add("category_id = @CategoryId");

            if (request.InStockQuantity != null)
                setPart.Add("instock_quantity = @InstockQuantity");

            if (request.ProductStatus != null)
                setPart.Add("product_status = @ProductStatus");

            if (setPart.Count == 0)
                return false;

            var sql = $"""
                update products
                set {string.Join(", ", setPart)}, updated_at = current_timestamp
                where product_id = @ProductId
                """;

            var rowsAffected = await connection.ExecuteAsync(sql, new { ProductId = productId, ProductName = request.ProductName, ProductPrice = request.ProductPrice, ProductStatus = request.ProductStatus, BrandId = request.BrandId, CategoryId = request.CategoryId, InstockQuantity = request.InStockQuantity });

            return rowsAffected > 0;
        }


        public async Task<bool> UpdateProductQuantity(int productId, UpdateProductRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            string sql;

            if (request.ProductCalculate == Constant.Enums.Calculate.Add)
            {
               sql = """
                    UPDATE products
                    SET instock_quantity = instock_quantity + @Quantity, updated_at = current_timestamp
                    WHERE product_id = @ProductId
                    """;
            }
            else if (request.ProductCalculate == Constant.Enums.Calculate.Subtract)
            {
                sql = """
                    UPDATE products
                    SET instock_quantity = instock_quantity - @Quantity, updated_at = current_timestamp
                    WHERE product_id = @ProductId
                      AND instock_quantity >= @Quantity
                    """;
            }
            else
            {
                return false;
            }

            var rowsAffected = await connection.ExecuteAsync(sql, new { ProductId = productId, Quantity = request.Quantity });
            return rowsAffected > 0;
        }
    }
}
