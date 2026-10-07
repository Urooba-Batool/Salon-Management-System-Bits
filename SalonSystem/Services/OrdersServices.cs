using Dapper;
using SalonSystem.Data;
using SalonSystem.Models.DTOs.RequestModels;
using SalonSystem.Models.DTOs.ResponseModels;

namespace SalonSystem.Services
{
    public class OrdersServices
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public OrdersServices(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public async Task<IEnumerable<OrderResponse>> GetAllOrders()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                with employee_details as (
                    select e.employee_id, u.first_name || ' ' || u.last_name as EmployeeName, u.first_name || ' ' || u.last_name as BookedByEmployee
                    from employees e
                    join users u on e.user_id = u.user_id
                )
                select o.order_id as OrderId, u.first_name || ' ' || u.last_name as UserName, ed.EmployeeName, ed.BookedByEmployee, o.booked_for as BookedFor, o.order_type as OrderType, o.booked_on as BookedOn, o.payment_type as PaymentType, o.total_amount as TotalAmount, o.source as Source, o.order_status as OrderStatus,    
                string_agg(s.service_name::text, ', ') as OrderItems
                from orders o
                join users u on o.user_id = u.user_id
                left join employee_details ed on o.employee_id = ed.employee_id
                left join order_services os on o.order_id = os.order_id
                left join salon_services s on os.service_id = s.service_id
                group by o.order_id, u.first_name, u.last_name, ed.EmployeeName, ed.BookedByEmployee, o.booked_for, o.booked_on
                order by o.booked_for desc;

                """;


            return await connection.QueryAsync<OrderResponse>(sql);
        }

        public async Task<OrderResponse?> GetOrderById(int orderId)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                with employee_details as (
                    select e.employee_id, u.first_name || ' ' || u.last_name as EmployeeName, u.first_name || ' ' || u.last_name as BookedByEmployee
                    from employees e
                    join users u on e.user_id = u.user_id
                )
                select o.order_id as OrderId, u.first_name || ' ' || u.last_name as UserName, ed.EmployeeName, ed.BookedByEmployee,o.booked_for as BookedFor, o.order_type as OrderType, o.booked_on as BookedOn, o.payment_type as PaymentType, o.total_amount as TotalAmount, o.source as Source, o.order_status as OrderStatus,    
                string_agg(s.service_name::text, ', ') as OrderItems
                from orders o
                join users u on o.user_id = u.user_id
                left join employee_details ed on o.employee_id = ed.employee_id
                left join order_services os on o.order_id = os.order_id
                left join salon_services s on os.service_id = s.service_id
                where o.order_id = @OrderId
                group by o.order_id, u.first_name, u.last_name, ed.EmployeeName, ed.BookedByEmployee, o.booked_for, o.booked_on, o.booked_by, o.payment_type, o.total_amount, o.source, o.order_status

                """;

            return await connection.QueryFirstOrDefaultAsync<OrderResponse>(sql, new { OrderId = orderId });
        }


        //create category

        public async Task<int> CreateOrder(CreateOrderRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();
            const string sql = """
                with new_order as (
                    insert into orders (user_id, employee_id, booked_for, order_type, booked_on, booked_by, payment_type, source, order_status, total_amount)
                    select @UserId, @EmployeeId, @BookedFor, 1, current_timestamp, @EmployeeId, 1, 3, 1, sum(s.service_price)
                    from salon_services s
                    where s.service_id = any(@ServiceId)
                    returning order_id
                )
                insert into order_services(order_id, service_id, created_at, created_by)
                select (select order_id from new_order), s.service_id, current_timestamp, @BookedBy
                from salon_services s
                where s.service_id = any(@ServiceId)
                returning order_service_id;
                """;

            return await connection.ExecuteScalarAsync<int>(sql, request);
        }


        public async Task<bool> UpdateOrders(int orderId, UpdateOrderRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();
            var setParts = new List<string>();

            if (request.UserId != null)
                setParts.Add("user_id = @UserId");

            if (request.EmployeeId != null)
                setParts.Add("employee_id = @EmployeeId");

            if (request.PaymentType != null)
                setParts.Add("payment_type = @PaymentType");

            if (request.OrderType != null)
                setParts.Add("order_type = @OrderType");

            if (request.BookedFor != null)
                setParts.Add("booked_for = @BookedFor");

            if (request.OrderStatus != null)
                setParts.Add("order_status = @OrderStatus");

            if (request.Source != null)
                setParts.Add("source = @Source");


            if (request.OrderItems != null)
            {
                await connection.ExecuteAsync("delete from order_services where order_id = @OrderId", new { OrderId = orderId });
                const string insertSql = """
                    insert into order_services(order_id, service_id, created_by, updated_by, updated_at, created_at)
                    values(@OrderId, @ServiceId, @UpdatedBy, @UpdatedBy, current_timestamp, current_timestamp);

                 """;

                foreach (var serviceId in request.OrderItems)
                {
                    await connection.ExecuteAsync(insertSql, new { OrderId = orderId, ServiceId = serviceId, UpdatedBy = request.UpdatedBy });
                }

                setParts.Add("""
                    total_amount = (select coalesce(sum(s.service_price), 0)
                    from order_services os
                    join salon_services s on os.service_id = s.service_id
                    where os.order_id = @OrderId)
                 """);
            }

            if (setParts.Count == 0)
            {
                return false;
            }

            var sql = $"""
                update orders
                set {string.Join(", ", setParts)}, updated_by = @UpdatedBy, updated_on = current_timestamp
                where order_id = @OrderId
                """;


            var affectedRows = await connection.ExecuteAsync(sql, new { OrderId = orderId, request.UserId, request.UpdatedBy, request.EmployeeId, request.PaymentType, request.OrderType, request.BookedFor, request.OrderStatus, request.Source });

            return affectedRows > 0;

        }

        public async Task<IEnumerable<OrderResponse>> GetFutureOrders()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                with employee_details as (
                    select e.employee_id, u.first_name || ' ' || u.last_name as EmployeeName, u.first_name || ' ' || u.last_name as BookedByEmployee
                    from employees e
                    join users u on e.user_id = u.user_id
                )
                select o.order_id as OrderId, u.first_name || ' ' || u.last_name as UserName, ed.EmployeeName, o.booked_for as BookedFor, o.order_type as OrderType, o.booked_on as BookedOn,  o.payment_type as PaymentType, o.total_amount as TotalAmount, o.source as Source, o.order_status as OrderStatus,    
                string_agg(s.service_name::text, ', ') as OrderItems
                from orders o
                join users u on o.user_id = u.user_id
                left join employee_details ed on o.employee_id = ed.employee_id
                left join order_services os on o.order_id = os.order_id
                left join salon_services s on os.service_id = s.service_id
                where o.booked_for > current_timestamp
                group by o.order_id, u.first_name, u.last_name, ed.EmployeeName, o.booked_for, o.booked_on, o.booked_by, o.payment_type, o.total_amount, o.source, o.order_status
                order by o.booked_for desc;

                """;

            return await connection.QueryAsync<OrderResponse>(sql);

        }
    }
}
