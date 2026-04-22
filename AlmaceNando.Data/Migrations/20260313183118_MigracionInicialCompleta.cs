using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlmaceNando.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicialCompleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Identification = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    CreditLimit = table.Column<decimal>(type: "TEXT", nullable: false, defaultValue: 50000m),
                    CurrentDebt = table.Column<decimal>(type: "TEXT", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    SyncStatus = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 70, nullable: false, defaultValue: "NN"),
                    SearchName = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    keyword = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    SyncStatus = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Identification = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Rol = table.Column<string>(type: "TEXT", nullable: true, defaultValue: "NN"),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    SyncStatus = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BarCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    SyncStatus = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarCodes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ComboProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ComponentProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    SyncStatus = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Combos_Products_ComboProductId",
                        column: x => x.ComboProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Combos_Products_ComponentProductId",
                        column: x => x.ComponentProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PriceHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CostPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    SalePrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    PriceChangeDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    SyncStatus = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceHistories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    tag = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    SyncStatus = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tags_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    SyncStatus = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sales_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    saleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    productId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    SyncStatus = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleDetails_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleDetails_Sales_saleId",
                        column: x => x.saleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CreatedAt", "CurrentPrice", "IsDeleted", "Name", "Price", "SearchName", "Stock", "SyncStatus", "keyword" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Colanta", new DateTime(2026, 3, 13, 13, 31, 17, 740, DateTimeKind.Local).AddTicks(1682), 0m, false, "Leche Colanta 1L", 4200m, "leche colanta 1l lacteo nevera", 20, false, "101" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Postobon", new DateTime(2026, 3, 13, 13, 31, 17, 740, DateTimeKind.Local).AddTicks(3754), 0m, false, "Jugo Hit Mora", 2500m, "jugo hit mora bebida nevera", 15, false, "102" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Diana", new DateTime(2026, 3, 13, 13, 31, 17, 740, DateTimeKind.Local).AddTicks(3760), 0m, false, "Arroz Diana 1kg", 3500m, "arroz diana grano", 50, false, "201" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Premier", new DateTime(2026, 3, 13, 13, 31, 17, 740, DateTimeKind.Local).AddTicks(3762), 0m, false, "Aceite Premier", 12000m, "aceite premier cocina", 10, false, "202" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Van Camps", new DateTime(2026, 3, 13, 13, 31, 17, 740, DateTimeKind.Local).AddTicks(3765), 0m, false, "Atun Van Camps", 6000m, "atun van camps conserva", 30, false, "301" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Rey", new DateTime(2026, 3, 13, 13, 31, 17, 740, DateTimeKind.Local).AddTicks(3767), 0m, false, "Jabon Rey", 2200m, "jabon rey aseo", 40, false, "401" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Sello Rojo", new DateTime(2026, 3, 13, 13, 31, 17, 740, DateTimeKind.Local).AddTicks(3769), 0m, false, "Cafe Sello Rojo", 9000m, "cafe sello rojo tinto", 25, false, "501" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "Doria", new DateTime(2026, 3, 13, 13, 31, 17, 740, DateTimeKind.Local).AddTicks(3772), 0m, false, "Pasta Doria", 3000m, "pasta doria espagueti", 35, false, "601" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "Refisal", new DateTime(2026, 3, 13, 13, 31, 17, 740, DateTimeKind.Local).AddTicks(3774), 0m, false, "Sal Refisal", 1500m, "sal refisal condimento", 80, false, "701" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Bimbo", new DateTime(2026, 3, 13, 13, 31, 17, 740, DateTimeKind.Local).AddTicks(3776), 0m, false, "Pan Bimbo", 7500m, "pan bimbo tajado", 12, false, "801" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Identification", "IsDeleted", "Name", "Password", "Rol", "SyncStatus", "UserName" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 13, 13, 31, 17, 737, DateTimeKind.Local).AddTicks(749), null, false, "Vendedor Genérico", "000", "NN", false, "Isleros0" });

            migrationBuilder.InsertData(
                table: "BarCodes",
                columns: new[] { "Id", "Code", "CreatedAt", "IsDeleted", "ProductId", "SyncStatus", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("8ef06a82-e92a-47e7-a5c9-6da3e76a8f48"), "7701002", new DateTime(2026, 3, 13, 13, 31, 17, 740, DateTimeKind.Local).AddTicks(7317), false, new Guid("22222222-2222-2222-2222-222222222222"), false, new DateTime(2026, 3, 13, 13, 31, 17, 740, DateTimeKind.Local).AddTicks(7314) },
                    { new Guid("a9d44eae-0463-4543-bbd7-e9c9b2e8cecc"), "7701001", new DateTime(2026, 3, 13, 13, 31, 17, 740, DateTimeKind.Local).AddTicks(6577), false, new Guid("11111111-1111-1111-1111-111111111111"), false, new DateTime(2026, 3, 13, 13, 31, 17, 740, DateTimeKind.Local).AddTicks(6488) }
                });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "ProductId", "SyncStatus", "tag" },
                values: new object[,]
                {
                    { new Guid("1a97a1a4-c7e9-4429-9e3a-e6cad6fff504"), new DateTime(2026, 3, 13, 13, 31, 17, 740, DateTimeKind.Local).AddTicks(5275), false, new Guid("11111111-1111-1111-1111-111111111111"), false, "nevera" },
                    { new Guid("396cac5e-9f37-4681-b0e9-74e28b033412"), new DateTime(2026, 3, 13, 13, 31, 17, 740, DateTimeKind.Local).AddTicks(5282), false, new Guid("22222222-2222-2222-2222-222222222222"), false, "bebida" },
                    { new Guid("43a80338-30cb-41e0-8426-04a1a582622e"), new DateTime(2026, 3, 13, 13, 31, 17, 740, DateTimeKind.Local).AddTicks(4548), false, new Guid("11111111-1111-1111-1111-111111111111"), false, "lacteo" },
                    { new Guid("8175a70c-dc35-4d4f-b7a0-9e18030b47cb"), new DateTime(2026, 3, 13, 13, 31, 17, 740, DateTimeKind.Local).AddTicks(5284), false, new Guid("22222222-2222-2222-2222-222222222222"), false, "nevera" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarCodes_ProductId",
                table: "BarCodes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_ComboProductId",
                table: "Combos",
                column: "ComboProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_ComponentProductId",
                table: "Combos",
                column: "ComponentProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceHistories_ProductId",
                table: "PriceHistories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetails_productId",
                table: "SaleDetails",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetails_saleId",
                table: "SaleDetails",
                column: "saleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId",
                table: "Sales",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tags_ProductId",
                table: "tags",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarCodes");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "PriceHistories");

            migrationBuilder.DropTable(
                name: "SaleDetails");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
