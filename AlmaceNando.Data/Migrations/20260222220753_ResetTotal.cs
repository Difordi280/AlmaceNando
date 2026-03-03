using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlmaceNando.Data.Migrations
{
    /// <inheritdoc />
    public partial class ResetTotal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
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
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
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
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
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
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
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
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
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
                name: "SaleDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    saleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    productId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
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
                columns: new[] { "Id", "Brand", "CreatedAt", "CurrentPrice", "IsDeleted", "Name", "Price", "SearchName", "Stock", "keyword" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Colanta", new DateTime(2026, 2, 22, 17, 7, 52, 230, DateTimeKind.Local).AddTicks(7555), 0m, false, "Leche Colanta 1L", 4200m, "leche colanta 1l lacteo nevera", 20, "101" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Postobon", new DateTime(2026, 2, 22, 17, 7, 52, 232, DateTimeKind.Local).AddTicks(8426), 0m, false, "Jugo Hit Mora", 2500m, "jugo hit mora bebida nevera", 15, "102" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Diana", new DateTime(2026, 2, 22, 17, 7, 52, 232, DateTimeKind.Local).AddTicks(8449), 0m, false, "Arroz Diana 1kg", 3500m, "arroz diana grano", 50, "201" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Premier", new DateTime(2026, 2, 22, 17, 7, 52, 232, DateTimeKind.Local).AddTicks(8452), 0m, false, "Aceite Premier", 12000m, "aceite premier cocina", 10, "202" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Van Camps", new DateTime(2026, 2, 22, 17, 7, 52, 232, DateTimeKind.Local).AddTicks(8455), 0m, false, "Atun Van Camps", 6000m, "atun van camps conserva", 30, "301" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Rey", new DateTime(2026, 2, 22, 17, 7, 52, 232, DateTimeKind.Local).AddTicks(8458), 0m, false, "Jabon Rey", 2200m, "jabon rey aseo", 40, "401" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Sello Rojo", new DateTime(2026, 2, 22, 17, 7, 52, 232, DateTimeKind.Local).AddTicks(8461), 0m, false, "Cafe Sello Rojo", 9000m, "cafe sello rojo tinto", 25, "501" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "Doria", new DateTime(2026, 2, 22, 17, 7, 52, 232, DateTimeKind.Local).AddTicks(8464), 0m, false, "Pasta Doria", 3000m, "pasta doria espagueti", 35, "601" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "Refisal", new DateTime(2026, 2, 22, 17, 7, 52, 232, DateTimeKind.Local).AddTicks(8467), 0m, false, "Sal Refisal", 1500m, "sal refisal condimento", 80, "701" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Bimbo", new DateTime(2026, 2, 22, 17, 7, 52, 232, DateTimeKind.Local).AddTicks(8470), 0m, false, "Pan Bimbo", 7500m, "pan bimbo tajado", 12, "801" }
                });

            migrationBuilder.InsertData(
                table: "BarCodes",
                columns: new[] { "Id", "Code", "CreatedAt", "IsDeleted", "ProductId", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("4bb001ec-24a4-44e4-9894-f9e30003d028"), "7701001", new DateTime(2026, 2, 22, 17, 7, 52, 234, DateTimeKind.Local).AddTicks(2464), false, new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 22, 17, 7, 52, 234, DateTimeKind.Local).AddTicks(2344) },
                    { new Guid("680af0c3-9d37-49c4-b8f0-3e8c596f4c59"), "7701002", new DateTime(2026, 2, 22, 17, 7, 52, 234, DateTimeKind.Local).AddTicks(3357), false, new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 22, 17, 7, 52, 234, DateTimeKind.Local).AddTicks(3354) }
                });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "ProductId", "tag" },
                values: new object[,]
                {
                    { new Guid("78512d64-2c78-4e70-9c2d-3cc6c96c7829"), new DateTime(2026, 2, 22, 17, 7, 52, 234, DateTimeKind.Local).AddTicks(135), false, new Guid("11111111-1111-1111-1111-111111111111"), "lacteo" },
                    { new Guid("a73c3a8c-7c96-44a6-8095-3578f658f3ec"), new DateTime(2026, 2, 22, 17, 7, 52, 234, DateTimeKind.Local).AddTicks(1056), false, new Guid("22222222-2222-2222-2222-222222222222"), "nevera" },
                    { new Guid("cfced2b9-0c7b-4ff2-b61f-7c41952c7451"), new DateTime(2026, 2, 22, 17, 7, 52, 234, DateTimeKind.Local).AddTicks(1047), false, new Guid("11111111-1111-1111-1111-111111111111"), "nevera" },
                    { new Guid("d1cb6831-0e92-43fb-9596-a98e5623370d"), new DateTime(2026, 2, 22, 17, 7, 52, 234, DateTimeKind.Local).AddTicks(1054), false, new Guid("22222222-2222-2222-2222-222222222222"), "bebida" }
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
        }
    }
}
