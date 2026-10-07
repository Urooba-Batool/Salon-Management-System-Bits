using Microsoft.EntityFrameworkCore;
using SalonSystem.Models.Entities;
using System.Xml.Linq;
namespace SalonSystem.Data
{
    public class SalonSystemDbContext : DbContext
    {
        public SalonSystemDbContext(DbContextOptions<SalonSystemDbContext> options)
        : base(options)
        {
        }

        //dbset is not being used for crud operations, it is being used to tell ef core what schemas to create in the database
        
        // dbset tells that db has a table called xyz and this table is based on xyz class. the class is mentioned in <>. the set returns the dbset for the xyz class
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderService> OrderServices => Set<OrderService>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Role> Role => Set<Role>();
        public DbSet<SalonService> SalonServices => Set<SalonService>();
        public DbSet<ServiceType> ServiceTypes => Set<ServiceType>();
        public DbSet<User> Users => Set<User>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //renaming the tables in snake_case for database 
            modelBuilder.Entity<Brand>().ToTable("brands");
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Employee>().ToTable("employees");
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<OrderService>().ToTable("order_services");
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Role>().ToTable("roles");
            modelBuilder.Entity<SalonService>().ToTable("salon_services");
            modelBuilder.Entity<ServiceType>().ToTable("service_types");
            modelBuilder.Entity<User>().ToTable("users");

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("role_id");
                entity.Property(e => e.RoleName).HasColumnName("role_name");
                entity.Property(e => e.RoleStatus).HasColumnName("role_status");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.BrandId).HasColumnName("brand_id");
                entity.Property(e => e.BrandName).HasColumnName("brand_name");
                entity.Property(e => e.BrandStatus).HasColumnName("brand_status");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.CategoryName).HasColumnName("category_name");
                entity.Property(e => e.CategoryStatus).HasColumnName("category_status");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                entity.Property(e => e.EmployeeEmail).HasColumnName("employee_email");
                entity.Property(e => e.EmployeeCnic).HasColumnName("employee_cnic");
                entity.Property(e => e.EmployeeSalary).HasColumnName("employee_salary");
                entity.Property(e => e.EmployeeAddress).HasColumnName("employee_address");
                entity.Property(e => e.EmployeePassword).HasColumnName("employee_password");
                entity.Property(e => e.EmployeeStatus).HasColumnName("employee_status");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.RoleId).HasColumnName("role_id");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                entity.Property(e => e.BookedFor).HasColumnName("booked_for");
                entity.Property(e => e.OrderType).HasColumnName("order_type");
                entity.Property(e => e.BookedOn).HasColumnName("booked_on");
                entity.Property(e => e.PaymentType).HasColumnName("payment_type");
                entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
                entity.Property(e => e.Source).HasColumnName("source");
                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
                entity.Property(e => e.UpdatedOn).HasColumnName("updated_on");
            });

            modelBuilder.Entity<OrderService>(entity =>
            {
                entity.Property(e => e.OrderServiceId).HasColumnName("order_service_id");
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.ServiceId).HasColumnName("service_id");
                entity.Property(e => e.CreatedBy).HasColumnName("created_by");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductName).HasColumnName("product_name");
                entity.Property(e => e.ProductPrice).HasColumnName("product_price");
                entity.Property(e => e.ProductStatus).HasColumnName("product_status");
                entity.Property(e => e.BrandId).HasColumnName("brand_id");
                entity.Property(e => e.InStockQuantity).HasColumnName("instock_quantity");
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<SalonService>(entity =>
            {
                entity.Property(e => e.ServiceId).HasColumnName("service_id");
                entity.Property(e => e.ServiceName).HasColumnName("service_name");
                entity.Property(e => e.ServicePrice).HasColumnName("service_price");
                entity.Property(e => e.ServiceStatus).HasColumnName("service_status");
                entity.Property(e => e.ServiceTypeId).HasColumnName("service_type_id");
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.Property(e => e.ServiceTypeId).HasColumnName("service_type_id");
                entity.Property(e => e.ServiceTypeName).HasColumnName("service_type_name");
                entity.Property(e => e.ServiceTypeStatus).HasColumnName("service_type_status");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.FirstName).HasColumnName("first_name");
                entity.Property(e => e.LastName).HasColumnName("last_name");
                entity.Property(e => e.UserPhone).HasColumnName("user_phone");
                entity.Property(e => e.UserTypes).HasColumnName("user_type");
                entity.Property(e => e.UserStatus).HasColumnName("user_status");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.BookedBy).HasColumnName("booked_by");
                entity.Property(e => e.OrderStatus).HasColumnName("order_status");
            });

        }
    }
}
