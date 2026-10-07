using Dapper;
using SalonSystem.Data;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Models.DTOs.ResponseModels;

namespace SalonSystem.Services
{
    public class EmployeeService
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public EmployeeService(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public async Task<IEnumerable<EmployeeResponse>> GetAllEmployees()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                select e.employee_id as EmployeeId, u.first_name || ' ' || u.last_name as EmployeeName, u.user_phone as UserPhone, e.employee_email as EmployeeEmail, e.employee_cnic as EmployeeCnic, e.user_id as UserId, r.role_name as RoleName, e.employee_salary as EmployeeSalary, e.employee_address as EmployeeAddress, e.employee_status as EmployeeStatus
                from employees e 
                left join users u on u.user_id = e.user_id
                left join roles r on r.role_id = e.role_id
                order by e.employee_id
                """;

            return await connection.QueryAsync<EmployeeResponse>(sql);
        }


        public async Task<EmployeeResponse> GetEmployeeById(int employeeId)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                select e.employee_id as EmployeeId, e.employee_email as EmployeeEmail, u.first_name || ' ' || u.last_name as EmployeeName, u.user_phone as UserPhone, e.employee_cnic as EmployeeCnic, e.user_id as UserId, r.role_name as RoleName, e.employee_salary as EmployeeSalary, e.employee_address as EmployeeAddress, e.employee_status as EmployeeStatus                
                from employees e
                left join users u on u.user_id = e.user_id
                left join roles r on r.role_id = e.role_id
                where e.employee_id = @EmployeeId 
                order by e.employee_id
                """;

            return await connection.QueryFirstOrDefaultAsync<EmployeeResponse>(sql, new {EmployeeId = employeeId});
        }

        public async Task<int> CreateEmployee(CreateEmployeeRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                insert into employees(employee_email, employee_password, employee_cnic, user_id, role_id, employee_salary, employee_address, employee_status, created_at)
                values(@EmployeeEmail, @EmployeePassword, @EmployeeCnic, @UserId, @RoleId, @EmployeeSalary, @EmployeeAddress, 1, current_timestamp)
                returning employee_id;                
                """;

            return await connection.ExecuteScalarAsync<int>(sql, request);
        }

        public async Task<bool> UpdateEmployee(int employeeId, UpdateEmployeeRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();
            var setPart = new List<string>();
            var setUserPart = new List<string>();
            var sql = " ";

            if (request.FirstName != null)
                setUserPart.Add("first_name = @FirstName");

            if (request.LastName != null)
                setUserPart.Add("last_name = @LastName");

            if (request.UserPhone != null)
                setUserPart.Add("user_phone = @UserPhone");

            if (request.EmployeeEmail != null)
                setPart.Add("employee_email = @EmployeeEmail");

            if(request.EmployeePassword != null)
                setPart.Add("employee_password = @EmployeePassword");

            if (request.EmployeeCnic != null)
                setPart.Add("employee_cnic = @EmployeeCnic");

            if(request.UserId != null)
                setPart.Add("user_id = @UserId");

            if(request.RoleId != null)
                setPart.Add("role_id = @RoleId");

            if(request.EmployeeSalary != null)
                setPart.Add("employee_salary = @EmployeeSalary");

            if(request.EmployeeAddress != null)
                setPart.Add("employee_address = @EmployeeAddress");

            if(request.EmployeeStatus != null)
                setPart.Add("employee_status = @EmployeeStatus");

            if(setUserPart.Count > 0)
            {
                sql += $"""
                update users 
                set {string.Join(", ", setUserPart)}, updated_at = current_timestamp
                where user_id = (select user_id from employees where employee_id = @EmployeeId);
                """;
            }
            
            if(setPart.Count > 0)
            {
                sql += $"""
                update employees
                set {string.Join(", ", setPart)}, updated_at = current_timestamp
                where employee_id = @EmployeeId
                """;
            }


            var rowsAffected = await connection.ExecuteAsync(sql, new
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserPhone = request.UserPhone,
                EmployeeEmail = request.EmployeeEmail,
                EmployeePassword = request.EmployeePassword,
                EmployeeCnic = request.EmployeeCnic,
                UserId = request.UserId,
                RoleId = request.RoleId,
                EmployeeSalary = request.EmployeeSalary,
                EmployeeAddress = request.EmployeeAddress,
                EmployeeStatus = request.EmployeeStatus,
                employeeId = employeeId
            });
            return rowsAffected > 0;
        }
    }
}
