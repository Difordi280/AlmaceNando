using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlmaceNando.Data.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNombresTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customer_CustomerId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customer_CustomerId1",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_User_UserId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_User_UserId1",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "customers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                table: "customers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "userHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    actionType = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    SyncStatus = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a3b2c1d0-e4f5-4a3b-8c7d-6e5f4d3c2b1a"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 0, 15, 41, 946, DateTimeKind.Local).AddTicks(4111));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d7f965d1-9f9b-4e1b-b461-8f6920f09a56"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 0, 15, 41, 944, DateTimeKind.Local).AddTicks(7585));

            migrationBuilder.CreateIndex(
                name: "IX_userHistories_UserId",
                table: "userHistories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_UserId1",
                table: "Sales",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_customers_CustomerId",
                table: "Sales",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_customers_CustomerId1",
                table: "Sales",
                column: "CustomerId1",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Users_UserId1",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_customers_CustomerId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_customers_CustomerId1",
                table: "Sales");

            migrationBuilder.DropTable(
                name: "userHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customers",
                table: "customers");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "customers",
                newName: "Customer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a3b2c1d0-e4f5-4a3b-8c7d-6e5f4d3c2b1a"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 23, 33, 58, 755, DateTimeKind.Local).AddTicks(3167));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d7f965d1-9f9b-4e1b-b461-8f6920f09a56"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 23, 33, 58, 753, DateTimeKind.Local).AddTicks(3877));

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customer_CustomerId",
                table: "Sales",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customer_CustomerId1",
                table: "Sales",
                column: "CustomerId1",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_User_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_User_UserId1",
                table: "Sales",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
