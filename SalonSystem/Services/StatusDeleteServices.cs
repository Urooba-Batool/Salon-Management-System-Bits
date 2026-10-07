using Dapper;
using SalonSystem.Data;
using SalonSystem.Models.DTOs.RequestModels;

namespace SalonSystem.Services
{
    public class StatusDeleteServices
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public StatusDeleteServices(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }



        //delete a role
        public async Task<bool> DeleteStatus(UpdateStatusDeleteRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            string sql;

            switch (request.EntityName.ToLower())
            {
                case "roles":
                    sql = """
                        update roles 
                        set role_status = 2 
                        where role_id = @EntityId
                        """;
                    break;

                case "brands":
                    sql = """
                        update brands 
                        set brand_tatus = 2, updated_at = current_timestamp
                        where brand_id = @EntityId
                        """;
                    break;

                case "categories":
                    sql = """
                        update categories 
                        set category_status = 2, updated_at = current_timestamp
                        where category_id = @EntityId
                        """;
                    break;

                case "employees":
                    sql = """
                        update employees 
                        set employee_status = 2, updated_at = current_timestamp
                        where employee_id = @EntityId
                        """;
                    break;

                case "orders":
                    sql = """
                        update orders 
                        set order_status = 2, updated_on = current_timestamp
                        where OrderId = @EntityId;
                        update order_services
                        set updated_at = current_timestamp
                        where order_id = @EntityId
                        """;
                    break;

                case "products":
                    sql = """
                        update products 
                        set product_status = 2, updated_at = current_timestamp
                        where product_id = @EntityId
                        """;
                    break;

                case "services":
                    sql = """
                        update salon_services 
                        set service_status = 2, updated_at = current_timestamp
                        where service_id = @EntityId
                        """;
                    break;

                case "servicetypes":
                    sql = """
                        update service_types 
                        set service_type_status = 2
                        where service_type_id = @EntityId
                        """;
                    break;

                case "users":
                    sql = """
                        update users 
                        set user_status = 2, updated_at = current_timestamp
                        where user_id = @EntityId
                        """;
                    break;

                default:
                    return false;

            }

            var RowsAffected = await connection.ExecuteAsync(sql, new { EntityId = request.EntityId});

            return RowsAffected > 0;
        }



    }
}
