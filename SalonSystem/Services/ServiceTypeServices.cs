using Dapper;
using SalonSystem.Data;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Models.DTOs.ResponseModels;

namespace SalonSystem.Services
{
    public class ServiceTypeServices
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ServiceTypeServices(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        // get all service types
        public async Task<IEnumerable<ServiceTypeResponse>> GetAllServiceType()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                select st.service_type_id as ServiceTypeId, st.service_type_name as ServiceTypeName, st.service_type_status as ServiceTypeStatus
                from service_types st order by st.service_type_id
                """;

            return await connection.QueryAsync<ServiceTypeResponse>(sql);
        }

        // get by id
        public async Task<ServiceTypeResponse> GetServiceTypeById(int serviceTypeId)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                select st.service_type_id as ServiceTypeId, st.service_type_name as ServiceTypeName, st.service_type_status as ServiceTypeStatus
                from service_types st where st.service_type_id = @ServiceTypeId
                """;

            return await connection.QueryFirstOrDefaultAsync<ServiceTypeResponse>(sql, new { ServiceTypeId = serviceTypeId });
        }

        //create service types
        public async Task<int> CreateServiceType(CreateServiceTypeRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();
            const string sql = """
                insert into service_types (service_type_name, service_type_status, created_at)
                values (@ServiceTypeName, 1, current_timestamp)
                returning service_type_id
                """;
            return await connection.ExecuteScalarAsync<int>(sql, request);
        }

        //update service types
        public async Task<bool> UpdateServiceType(int serviceTypeId, UpdateServiceTypeRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();
            var setPart = new List<string>();

            if (request.ServiceTypeName != null)
                setPart.Add("service_type_name = @ServiceTypeName");

            if (request.ServiceTypeStatus != null)
                setPart.Add("service_type_status = @ServiceTypeStatus");

            if (setPart.Count == 0)
                return false;

            var sql = $"""
                update service_types
                set {string.Join(", ", setPart)}
                where service_type_id = @ServiceTypeId
                """;

            var rowsAffected = await connection.ExecuteAsync(sql, new { ServiceTypeId = serviceTypeId, ServiceTypeName = request.ServiceTypeName, ServiceTypeStatus = request.ServiceTypeStatus });

            return rowsAffected > 0;
        }
    }
}
