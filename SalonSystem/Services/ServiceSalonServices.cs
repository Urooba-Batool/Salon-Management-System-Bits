using SalonSystem.Data;
using Dapper;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Models.DTOs.ResponseModels;

namespace SalonSystem.Services
{
    public class ServiceSalonServices
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ServiceSalonServices(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        // get all services
        public async Task<IEnumerable<SalonServiceResponse>> GetAllSalonServices()
        {
            using var connection = _connectionFactory.CreateConnection();   // the _connectionFactory calls and gives the postgresql connection

            const string sql = """
            select ss.service_id as ServiceId, ss.service_name as ServiceName, ss.service_price as ServicePrice, st.service_type_name as ServiceTypeName, c.category_name as CategoryName, ss.service_status as ServiceStatus 
            from salon_services ss 
            left join service_types st on ss.service_type_id = st.service_type_id
            left join categories c on c.category_id = ss.category_id
            order by ss.service_id;   
            """;        

            return await connection.QueryAsync<SalonServiceResponse>(sql);     // queryasync returns all the rows or multiple rows 
        }


        // get by id
        public async Task<SalonServiceResponse?> GetSalonServiceById(int serviceId)
        {
            using var connection = _connectionFactory.CreateConnection();   // the _connectionFactory calls and gives the postgresql connection

            const string sql = """
            select ss.service_id as ServiceId, ss.service_name as ServiceName, ss.service_price as ServicePrice, st.service_type_name as ServiceTypeName, c.category_name as CategoryName, ss.service_status as ServiceStatus 
            from salon_services ss 
            left join service_types st on ss.service_type_id = st.service_type_id
            left join categories c on c.category_id = ss.category_id
            where ss.service_id = @ServiceId
            order by ss.service_id;   
            """;

            return await connection.QueryFirstOrDefaultAsync<SalonServiceResponse>(sql, new { ServiceId = serviceId });      // QueryFirstOrDefaultAsync returns the first or one row just like sql exists
        }



        //create new services

        public async Task<int> CreateService(CreateSalonServiceRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                insert into salon_services(service_name, service_price, service_type_id, category_id, service_status, created_at) 
                values(@ServiceName, @ServicePrice, @ServiceTypeId, @CategoryId, 1, current_timestamp)
                returning service_id as ServiceId;
                """;

            return await connection.ExecuteScalarAsync<int>(sql, request);      // ExecuteScalarAsync returns one single value and not a row 
        }

        //update services
        public async Task<bool> UpdateService(int serviceId, UpdateSalonServiceRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();
            var setParts = new List<string>();

            if (request.ServiceName != null)
            {
                setParts.Add("service_name = @ServiceName");
            }

            if (request.ServicePrice != null)
            {
                setParts.Add("service_price = @ServicePrice");
            }

            if (request.ServiceTypeId != null)
            {
                setParts.Add("service_type_id = @ServiceTypeId");
            }

            if (request.ServiceStatus != null)
            {
                setParts.Add("service_status = @ServiceStatus");
            }

            if (request.CategoryId != null)
            {
                setParts.Add("category_id = @CategoryId");
            }


            if (setParts.Count == 0)
            {
                return false;
            }

            var sql = $"""
                UPDATE salon_services
                SET {string.Join(", ", setParts)}
                WHERE service_id = @ServiceId
                """;

            var RowsAffected = await connection.ExecuteAsync(sql, new { ServiceId = serviceId, ServiceName = request.ServiceName, ServiceStatus = request.ServiceStatus, ServicePrice = request.ServicePrice, ServiceTypeId = request.ServiceTypeId, CategoryId = request.CategoryId });
            return RowsAffected > 0;
        }

    }
}
