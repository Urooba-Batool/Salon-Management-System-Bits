using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalonSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToOrderService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "order_service_status",
                table: "order_services",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order_service_status",
                table: "order_services");
        }
    }
}
