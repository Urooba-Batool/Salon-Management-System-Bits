using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SalonSystem.Migrations
{
    /// <inheritdoc />
    public partial class TablesToLowercaseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_services_services_ServiceId",
                table: "order_services");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.CreateTable(
                name: "salon_services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceName = table.Column<string>(type: "text", nullable: false),
                    ServicePrice = table.Column<double>(type: "double precision", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "integer", nullable: false),
                    ServiceStatus = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salon_services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_salon_services_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_salon_services_service_types_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "service_types",
                        principalColumn: "ServiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_salon_services_CategoryId",
                table: "salon_services",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_salon_services_ServiceTypeId",
                table: "salon_services",
                column: "ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_services_salon_services_ServiceId",
                table: "order_services",
                column: "ServiceId",
                principalTable: "salon_services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_services_salon_services_ServiceId",
                table: "order_services");

            migrationBuilder.DropTable(
                name: "salon_services");

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ServiceName = table.Column<string>(type: "text", nullable: false),
                    ServicePrice = table.Column<double>(type: "double precision", nullable: false),
                    ServiceStatus = table.Column<int>(type: "integer", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_services_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_services_service_types_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "service_types",
                        principalColumn: "ServiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_services_CategoryId",
                table: "services",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_services_ServiceTypeId",
                table: "services",
                column: "ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_services_services_ServiceId",
                table: "order_services",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
