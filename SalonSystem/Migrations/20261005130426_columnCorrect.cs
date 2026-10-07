using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalonSystem.Migrations
{
    /// <inheritdoc />
    public partial class columnCorrect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_employees_BookedBy",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "orders",
                newName: "order_status");

            migrationBuilder.RenameColumn(
                name: "BookedBy",
                table: "orders",
                newName: "booked_by");

            migrationBuilder.RenameIndex(
                name: "IX_orders_BookedBy",
                table: "orders",
                newName: "IX_orders_booked_by");

            migrationBuilder.AddColumn<int>(
                name: "ProductCalculate",
                table: "products",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "total_amount",
                table: "orders",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_employees_booked_by",
                table: "orders",
                column: "booked_by",
                principalTable: "employees",
                principalColumn: "employee_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_employees_booked_by",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ProductCalculate",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "order_status",
                table: "orders",
                newName: "OrderStatus");

            migrationBuilder.RenameColumn(
                name: "booked_by",
                table: "orders",
                newName: "BookedBy");

            migrationBuilder.RenameIndex(
                name: "IX_orders_booked_by",
                table: "orders",
                newName: "IX_orders_BookedBy");

            migrationBuilder.AlterColumn<double>(
                name: "total_amount",
                table: "orders",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_employees_BookedBy",
                table: "orders",
                column: "BookedBy",
                principalTable: "employees",
                principalColumn: "employee_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
