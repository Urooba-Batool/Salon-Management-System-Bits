using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalonSystem.Migrations
{
    /// <inheritdoc />
    public partial class columnSnake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_roles_RoleId",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_users_UserId",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_order_services_employees_CreatedBy",
                table: "order_services");

            migrationBuilder.DropForeignKey(
                name: "FK_order_services_employees_UpdatedBy",
                table: "order_services");

            migrationBuilder.DropForeignKey(
                name: "FK_order_services_orders_OrderId",
                table: "order_services");

            migrationBuilder.DropForeignKey(
                name: "FK_order_services_salon_services_ServiceId",
                table: "order_services");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_employees_EmployeeId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_employees_UpdatedBy",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_UserId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_products_brands_BrandId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_salon_services_categories_CategoryId",
                table: "salon_services");

            migrationBuilder.DropForeignKey(
                name: "FK_salon_services_service_types_ServiceTypeId",
                table: "salon_services");

            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "users",
                newName: "user_type");

            migrationBuilder.RenameColumn(
                name: "UserStatus",
                table: "users",
                newName: "user_status");

            migrationBuilder.RenameColumn(
                name: "UserPhone",
                table: "users",
                newName: "user_phone");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "users",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "users",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "users",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "users",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ServiceTypeStatus",
                table: "service_types",
                newName: "service_type_status");

            migrationBuilder.RenameColumn(
                name: "ServiceTypeName",
                table: "service_types",
                newName: "service_type_name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "service_types",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "ServiceTypeId",
                table: "service_types",
                newName: "service_type_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "salon_services",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ServiceTypeId",
                table: "salon_services",
                newName: "service_type_id");

            migrationBuilder.RenameColumn(
                name: "ServiceStatus",
                table: "salon_services",
                newName: "service_status");

            migrationBuilder.RenameColumn(
                name: "ServicePrice",
                table: "salon_services",
                newName: "service_price");

            migrationBuilder.RenameColumn(
                name: "ServiceName",
                table: "salon_services",
                newName: "service_name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "salon_services",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "salon_services",
                newName: "category_id");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "salon_services",
                newName: "service_id");

            migrationBuilder.RenameIndex(
                name: "IX_salon_services_ServiceTypeId",
                table: "salon_services",
                newName: "IX_salon_services_service_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_salon_services_CategoryId",
                table: "salon_services",
                newName: "IX_salon_services_category_id");

            migrationBuilder.RenameColumn(
                name: "RoleStatus",
                table: "roles",
                newName: "role_status");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "roles",
                newName: "role_name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "roles",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "roles",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "products",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ProductStatus",
                table: "products",
                newName: "product_status");

            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "products",
                newName: "product_price");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "products",
                newName: "product_name");

            migrationBuilder.RenameColumn(
                name: "InStockQuantity",
                table: "products",
                newName: "instock_quantity");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "products",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "products",
                newName: "category_id");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "products",
                newName: "brand_id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "products",
                newName: "product_id");

            migrationBuilder.RenameIndex(
                name: "IX_products_CategoryId",
                table: "products",
                newName: "IX_products_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_products_BrandId",
                table: "products",
                newName: "IX_products_brand_id");

            migrationBuilder.RenameColumn(
                name: "Source",
                table: "orders",
                newName: "source");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "orders",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "orders",
                newName: "updated_on");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "orders",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "orders",
                newName: "total_amount");

            migrationBuilder.RenameColumn(
                name: "PaymentType",
                table: "orders",
                newName: "payment_type");

            migrationBuilder.RenameColumn(
                name: "OrderType",
                table: "orders",
                newName: "order_type");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "orders",
                newName: "employee_id");

            migrationBuilder.RenameColumn(
                name: "BookedOn",
                table: "orders",
                newName: "booked_on");

            migrationBuilder.RenameColumn(
                name: "BookedFor",
                table: "orders",
                newName: "booked_for");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "orders",
                newName: "order_id");

            migrationBuilder.RenameIndex(
                name: "IX_orders_UserId",
                table: "orders",
                newName: "IX_orders_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_orders_UpdatedBy",
                table: "orders",
                newName: "IX_orders_updated_by");

            migrationBuilder.RenameIndex(
                name: "IX_orders_EmployeeId",
                table: "orders",
                newName: "IX_orders_employee_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "order_services",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "order_services",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "order_services",
                newName: "service_id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "order_services",
                newName: "order_id");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "order_services",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "order_services",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "OrderServiceId",
                table: "order_services",
                newName: "order_service_id");

            migrationBuilder.RenameIndex(
                name: "IX_order_services_UpdatedBy",
                table: "order_services",
                newName: "IX_order_services_updated_by");

            migrationBuilder.RenameIndex(
                name: "IX_order_services_ServiceId",
                table: "order_services",
                newName: "IX_order_services_service_id");

            migrationBuilder.RenameIndex(
                name: "IX_order_services_OrderId",
                table: "order_services",
                newName: "IX_order_services_order_id");

            migrationBuilder.RenameIndex(
                name: "IX_order_services_CreatedBy",
                table: "order_services",
                newName: "IX_order_services_created_by");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "employees",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "employees",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "employees",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "EmployeeStatus",
                table: "employees",
                newName: "employee_status");

            migrationBuilder.RenameColumn(
                name: "EmployeeSalary",
                table: "employees",
                newName: "employee_salary");

            migrationBuilder.RenameColumn(
                name: "EmployeePassword",
                table: "employees",
                newName: "employee_password");

            migrationBuilder.RenameColumn(
                name: "EmployeeEmail",
                table: "employees",
                newName: "employee_email");

            migrationBuilder.RenameColumn(
                name: "EmployeeCnic",
                table: "employees",
                newName: "employee_cnic");

            migrationBuilder.RenameColumn(
                name: "EmployeeAddress",
                table: "employees",
                newName: "employee_address");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "employees",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "employees",
                newName: "employee_id");

            migrationBuilder.RenameIndex(
                name: "IX_employees_UserId",
                table: "employees",
                newName: "IX_employees_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_employees_RoleId",
                table: "employees",
                newName: "IX_employees_role_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "categories",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "categories",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CategoryStatus",
                table: "categories",
                newName: "category_status");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "categories",
                newName: "category_name");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "categories",
                newName: "category_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "brands",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "brands",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "BrandStatus",
                table: "brands",
                newName: "brand_status");

            migrationBuilder.RenameColumn(
                name: "BrandName",
                table: "brands",
                newName: "brand_name");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "brands",
                newName: "brand_id");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_roles_role_id",
                table: "employees",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "role_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employees_users_user_id",
                table: "employees",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_services_employees_created_by",
                table: "order_services",
                column: "created_by",
                principalTable: "employees",
                principalColumn: "employee_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_services_employees_updated_by",
                table: "order_services",
                column: "updated_by",
                principalTable: "employees",
                principalColumn: "employee_id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_services_orders_order_id",
                table: "order_services",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "order_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_services_salon_services_service_id",
                table: "order_services",
                column: "service_id",
                principalTable: "salon_services",
                principalColumn: "service_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_employees_employee_id",
                table: "orders",
                column: "employee_id",
                principalTable: "employees",
                principalColumn: "employee_id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_employees_updated_by",
                table: "orders",
                column: "updated_by",
                principalTable: "employees",
                principalColumn: "employee_id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_user_id",
                table: "orders",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_brands_brand_id",
                table: "products",
                column: "brand_id",
                principalTable: "brands",
                principalColumn: "brand_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_category_id",
                table: "products",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_salon_services_categories_category_id",
                table: "salon_services",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_salon_services_service_types_service_type_id",
                table: "salon_services",
                column: "service_type_id",
                principalTable: "service_types",
                principalColumn: "service_type_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_roles_role_id",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_users_user_id",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_order_services_employees_created_by",
                table: "order_services");

            migrationBuilder.DropForeignKey(
                name: "FK_order_services_employees_updated_by",
                table: "order_services");

            migrationBuilder.DropForeignKey(
                name: "FK_order_services_orders_order_id",
                table: "order_services");

            migrationBuilder.DropForeignKey(
                name: "FK_order_services_salon_services_service_id",
                table: "order_services");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_employees_employee_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_employees_updated_by",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_user_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_products_brands_brand_id",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_category_id",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_salon_services_categories_category_id",
                table: "salon_services");

            migrationBuilder.DropForeignKey(
                name: "FK_salon_services_service_types_service_type_id",
                table: "salon_services");

            migrationBuilder.RenameColumn(
                name: "user_type",
                table: "users",
                newName: "UserType");

            migrationBuilder.RenameColumn(
                name: "user_status",
                table: "users",
                newName: "UserStatus");

            migrationBuilder.RenameColumn(
                name: "user_phone",
                table: "users",
                newName: "UserPhone");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "users",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "service_type_status",
                table: "service_types",
                newName: "ServiceTypeStatus");

            migrationBuilder.RenameColumn(
                name: "service_type_name",
                table: "service_types",
                newName: "ServiceTypeName");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "service_types",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "service_type_id",
                table: "service_types",
                newName: "ServiceTypeId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "salon_services",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "service_type_id",
                table: "salon_services",
                newName: "ServiceTypeId");

            migrationBuilder.RenameColumn(
                name: "service_status",
                table: "salon_services",
                newName: "ServiceStatus");

            migrationBuilder.RenameColumn(
                name: "service_price",
                table: "salon_services",
                newName: "ServicePrice");

            migrationBuilder.RenameColumn(
                name: "service_name",
                table: "salon_services",
                newName: "ServiceName");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "salon_services",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "salon_services",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "service_id",
                table: "salon_services",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_salon_services_service_type_id",
                table: "salon_services",
                newName: "IX_salon_services_ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_salon_services_category_id",
                table: "salon_services",
                newName: "IX_salon_services_CategoryId");

            migrationBuilder.RenameColumn(
                name: "role_status",
                table: "roles",
                newName: "RoleStatus");

            migrationBuilder.RenameColumn(
                name: "role_name",
                table: "roles",
                newName: "RoleName");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "roles",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "roles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "products",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "product_status",
                table: "products",
                newName: "ProductStatus");

            migrationBuilder.RenameColumn(
                name: "product_price",
                table: "products",
                newName: "ProductPrice");

            migrationBuilder.RenameColumn(
                name: "product_name",
                table: "products",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "instock_quantity",
                table: "products",
                newName: "InStockQuantity");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "products",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "products",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "brand_id",
                table: "products",
                newName: "BrandId");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "products",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_products_category_id",
                table: "products",
                newName: "IX_products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_products_brand_id",
                table: "products",
                newName: "IX_products_BrandId");

            migrationBuilder.RenameColumn(
                name: "source",
                table: "orders",
                newName: "Source");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "orders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_on",
                table: "orders",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "orders",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "total_amount",
                table: "orders",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "payment_type",
                table: "orders",
                newName: "PaymentType");

            migrationBuilder.RenameColumn(
                name: "order_type",
                table: "orders",
                newName: "OrderType");

            migrationBuilder.RenameColumn(
                name: "employee_id",
                table: "orders",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "booked_on",
                table: "orders",
                newName: "BookedOn");

            migrationBuilder.RenameColumn(
                name: "booked_for",
                table: "orders",
                newName: "BookedFor");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "orders",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_user_id",
                table: "orders",
                newName: "IX_orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_updated_by",
                table: "orders",
                newName: "IX_orders_UpdatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_orders_employee_id",
                table: "orders",
                newName: "IX_orders_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "order_services",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "order_services",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "service_id",
                table: "order_services",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "order_services",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "order_services",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "order_services",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "order_service_id",
                table: "order_services",
                newName: "OrderServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_order_services_updated_by",
                table: "order_services",
                newName: "IX_order_services_UpdatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_order_services_service_id",
                table: "order_services",
                newName: "IX_order_services_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_order_services_order_id",
                table: "order_services",
                newName: "IX_order_services_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_order_services_created_by",
                table: "order_services",
                newName: "IX_order_services_CreatedBy");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "employees",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "employees",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "employees",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "employee_status",
                table: "employees",
                newName: "EmployeeStatus");

            migrationBuilder.RenameColumn(
                name: "employee_salary",
                table: "employees",
                newName: "EmployeeSalary");

            migrationBuilder.RenameColumn(
                name: "employee_password",
                table: "employees",
                newName: "EmployeePassword");

            migrationBuilder.RenameColumn(
                name: "employee_email",
                table: "employees",
                newName: "EmployeeEmail");

            migrationBuilder.RenameColumn(
                name: "employee_cnic",
                table: "employees",
                newName: "EmployeeCnic");

            migrationBuilder.RenameColumn(
                name: "employee_address",
                table: "employees",
                newName: "EmployeeAddress");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "employees",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "employee_id",
                table: "employees",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_employees_user_id",
                table: "employees",
                newName: "IX_employees_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_employees_role_id",
                table: "employees",
                newName: "IX_employees_RoleId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "categories",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "categories",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "category_status",
                table: "categories",
                newName: "CategoryStatus");

            migrationBuilder.RenameColumn(
                name: "category_name",
                table: "categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "categories",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "brands",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "brands",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "brand_status",
                table: "brands",
                newName: "BrandStatus");

            migrationBuilder.RenameColumn(
                name: "brand_name",
                table: "brands",
                newName: "BrandName");

            migrationBuilder.RenameColumn(
                name: "brand_id",
                table: "brands",
                newName: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_roles_RoleId",
                table: "employees",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employees_users_UserId",
                table: "employees",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_services_employees_CreatedBy",
                table: "order_services",
                column: "CreatedBy",
                principalTable: "employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_services_employees_UpdatedBy",
                table: "order_services",
                column: "UpdatedBy",
                principalTable: "employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_services_orders_OrderId",
                table: "order_services",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_services_salon_services_ServiceId",
                table: "order_services",
                column: "ServiceId",
                principalTable: "salon_services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_employees_EmployeeId",
                table: "orders",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_employees_UpdatedBy",
                table: "orders",
                column: "UpdatedBy",
                principalTable: "employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_UserId",
                table: "orders",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_brands_BrandId",
                table: "products",
                column: "BrandId",
                principalTable: "brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_salon_services_categories_CategoryId",
                table: "salon_services",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_salon_services_service_types_ServiceTypeId",
                table: "salon_services",
                column: "ServiceTypeId",
                principalTable: "service_types",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
