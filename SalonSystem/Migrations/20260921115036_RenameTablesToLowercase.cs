using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalonSystem.Migrations
{
    /// <inheritdoc />
    public partial class RenameTablesToLowercase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Role_RoleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employees_BookedBy",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employees_EmployeeId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employees_UpdatedBy",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Employees_CreatedBy",
                table: "OrderServices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Employees_UpdatedBy",
                table: "OrderServices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Orders_OrderId",
                table: "OrderServices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Services_ServiceId",
                table: "OrderServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Categories_CategoryId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceTypes",
                table: "ServiceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderServices",
                table: "OrderServices");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "services");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "employees");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "categories");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "brands");

            migrationBuilder.RenameTable(
                name: "ServiceTypes",
                newName: "service_types");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "OrderServices",
                newName: "order_services");

            migrationBuilder.RenameIndex(
                name: "IX_Services_ServiceTypeId",
                table: "services",
                newName: "IX_services_ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_CategoryId",
                table: "services",
                newName: "IX_services_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "products",
                newName: "IX_products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BrandId",
                table: "products",
                newName: "IX_products_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "orders",
                newName: "IX_orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UpdatedBy",
                table: "orders",
                newName: "IX_orders_UpdatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_EmployeeId",
                table: "orders",
                newName: "IX_orders_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_BookedBy",
                table: "orders",
                newName: "IX_orders_BookedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_UserId",
                table: "employees",
                newName: "IX_employees_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_RoleId",
                table: "employees",
                newName: "IX_employees_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderServices_UpdatedBy",
                table: "order_services",
                newName: "IX_order_services_UpdatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_OrderServices_ServiceId",
                table: "order_services",
                newName: "IX_order_services_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderServices_OrderId",
                table: "order_services",
                newName: "IX_order_services_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderServices_CreatedBy",
                table: "order_services",
                newName: "IX_order_services_CreatedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_services",
                table: "services",
                column: "ServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employees",
                table: "employees",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_brands",
                table: "brands",
                column: "BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_service_types",
                table: "service_types",
                column: "ServiceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order_services",
                table: "order_services",
                column: "OrderServiceId");

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
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_services_orders_OrderId",
                table: "order_services",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_services_services_ServiceId",
                table: "order_services",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_employees_BookedBy",
                table: "orders",
                column: "BookedBy",
                principalTable: "employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_employees_EmployeeId",
                table: "orders",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_employees_UpdatedBy",
                table: "orders",
                column: "UpdatedBy",
                principalTable: "employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_services_categories_CategoryId",
                table: "services",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_services_service_types_ServiceTypeId",
                table: "services",
                column: "ServiceTypeId",
                principalTable: "service_types",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_order_services_services_ServiceId",
                table: "order_services");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_employees_BookedBy",
                table: "orders");

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
                name: "FK_services_categories_CategoryId",
                table: "services");

            migrationBuilder.DropForeignKey(
                name: "FK_services_service_types_ServiceTypeId",
                table: "services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_services",
                table: "services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employees",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_brands",
                table: "brands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_service_types",
                table: "service_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order_services",
                table: "order_services");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "services",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "employees",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "brands",
                newName: "Brands");

            migrationBuilder.RenameTable(
                name: "service_types",
                newName: "ServiceTypes");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "order_services",
                newName: "OrderServices");

            migrationBuilder.RenameIndex(
                name: "IX_services_ServiceTypeId",
                table: "Services",
                newName: "IX_Services_ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_services_CategoryId",
                table: "Services",
                newName: "IX_Services_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_products_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_products_BrandId",
                table: "Products",
                newName: "IX_Products_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_UpdatedBy",
                table: "Orders",
                newName: "IX_Orders_UpdatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_orders_EmployeeId",
                table: "Orders",
                newName: "IX_Orders_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_BookedBy",
                table: "Orders",
                newName: "IX_Orders_BookedBy");

            migrationBuilder.RenameIndex(
                name: "IX_employees_UserId",
                table: "Employees",
                newName: "IX_Employees_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_employees_RoleId",
                table: "Employees",
                newName: "IX_Employees_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_order_services_UpdatedBy",
                table: "OrderServices",
                newName: "IX_OrderServices_UpdatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_order_services_ServiceId",
                table: "OrderServices",
                newName: "IX_OrderServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_order_services_OrderId",
                table: "OrderServices",
                newName: "IX_OrderServices_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_order_services_CreatedBy",
                table: "OrderServices",
                newName: "IX_OrderServices_CreatedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "ServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceTypes",
                table: "ServiceTypes",
                column: "ServiceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderServices",
                table: "OrderServices",
                column: "OrderServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Role_RoleId",
                table: "Employees",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employees_BookedBy",
                table: "Orders",
                column: "BookedBy",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employees_EmployeeId",
                table: "Orders",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employees_UpdatedBy",
                table: "Orders",
                column: "UpdatedBy",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServices_Employees_CreatedBy",
                table: "OrderServices",
                column: "CreatedBy",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServices_Employees_UpdatedBy",
                table: "OrderServices",
                column: "UpdatedBy",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServices_Orders_OrderId",
                table: "OrderServices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServices_Services_ServiceId",
                table: "OrderServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Categories_CategoryId",
                table: "Services",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
