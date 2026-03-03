using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlmaceNando.Data.Migrations
{
    /// <inheritdoc />
    public partial class Sincronizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BarCodes",
                keyColumn: "Id",
                keyValue: new Guid("4bb001ec-24a4-44e4-9894-f9e30003d028"));

            migrationBuilder.DeleteData(
                table: "BarCodes",
                keyColumn: "Id",
                keyValue: new Guid("680af0c3-9d37-49c4-b8f0-3e8c596f4c59"));

            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("78512d64-2c78-4e70-9c2d-3cc6c96c7829"));

            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("a73c3a8c-7c96-44a6-8095-3578f658f3ec"));

            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("cfced2b9-0c7b-4ff2-b61f-7c41952c7451"));

            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("d1cb6831-0e92-43fb-9596-a98e5623370d"));

            migrationBuilder.AddColumn<bool>(
                name: "SyncStatus",
                table: "tags",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SyncStatus",
                table: "Sales",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SyncStatus",
                table: "SaleDetails",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SyncStatus",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SyncStatus",
                table: "PriceHistories",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SyncStatus",
                table: "Combos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SyncStatus",
                table: "BarCodes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "BarCodes",
                columns: new[] { "Id", "Code", "CreatedAt", "IsDeleted", "ProductId", "SyncStatus", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("2abe7187-6c46-4017-87cb-57ed77803606"), "7701001", new DateTime(2026, 3, 2, 21, 33, 32, 204, DateTimeKind.Local).AddTicks(9500), false, new Guid("11111111-1111-1111-1111-111111111111"), false, new DateTime(2026, 3, 2, 21, 33, 32, 204, DateTimeKind.Local).AddTicks(9394) },
                    { new Guid("ebeb56d6-2be1-429c-939f-44ca76b51e9a"), "7701002", new DateTime(2026, 3, 2, 21, 33, 32, 205, DateTimeKind.Local).AddTicks(285), false, new Guid("22222222-2222-2222-2222-222222222222"), false, new DateTime(2026, 3, 2, 21, 33, 32, 205, DateTimeKind.Local).AddTicks(282) }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "SyncStatus" },
                values: new object[] { new DateTime(2026, 3, 2, 21, 33, 32, 201, DateTimeKind.Local).AddTicks(5744), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "SyncStatus" },
                values: new object[] { new DateTime(2026, 3, 2, 21, 33, 32, 203, DateTimeKind.Local).AddTicks(7789), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "SyncStatus" },
                values: new object[] { new DateTime(2026, 3, 2, 21, 33, 32, 203, DateTimeKind.Local).AddTicks(7814), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "CreatedAt", "SyncStatus" },
                values: new object[] { new DateTime(2026, 3, 2, 21, 33, 32, 203, DateTimeKind.Local).AddTicks(7817), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "CreatedAt", "SyncStatus" },
                values: new object[] { new DateTime(2026, 3, 2, 21, 33, 32, 203, DateTimeKind.Local).AddTicks(7820), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                columns: new[] { "CreatedAt", "SyncStatus" },
                values: new object[] { new DateTime(2026, 3, 2, 21, 33, 32, 203, DateTimeKind.Local).AddTicks(7822), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                columns: new[] { "CreatedAt", "SyncStatus" },
                values: new object[] { new DateTime(2026, 3, 2, 21, 33, 32, 203, DateTimeKind.Local).AddTicks(7825), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "CreatedAt", "SyncStatus" },
                values: new object[] { new DateTime(2026, 3, 2, 21, 33, 32, 203, DateTimeKind.Local).AddTicks(7828), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "CreatedAt", "SyncStatus" },
                values: new object[] { new DateTime(2026, 3, 2, 21, 33, 32, 203, DateTimeKind.Local).AddTicks(7830), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "SyncStatus" },
                values: new object[] { new DateTime(2026, 3, 2, 21, 33, 32, 203, DateTimeKind.Local).AddTicks(7832), false });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "ProductId", "SyncStatus", "tag" },
                values: new object[,]
                {
                    { new Guid("3b145ac8-91c3-4b8a-9d33-4bc9a0227701"), new DateTime(2026, 3, 2, 21, 33, 32, 204, DateTimeKind.Local).AddTicks(8217), false, new Guid("22222222-2222-2222-2222-222222222222"), false, "nevera" },
                    { new Guid("46dfd4cb-2a54-4e13-9b2e-579e6912f725"), new DateTime(2026, 3, 2, 21, 33, 32, 204, DateTimeKind.Local).AddTicks(8215), false, new Guid("22222222-2222-2222-2222-222222222222"), false, "bebida" },
                    { new Guid("6a33856d-a1bc-4e86-8ff3-126a2bf598ca"), new DateTime(2026, 3, 2, 21, 33, 32, 204, DateTimeKind.Local).AddTicks(8207), false, new Guid("11111111-1111-1111-1111-111111111111"), false, "nevera" },
                    { new Guid("6f7708d3-4ede-4132-aee2-9c13de4c239d"), new DateTime(2026, 3, 2, 21, 33, 32, 204, DateTimeKind.Local).AddTicks(7368), false, new Guid("11111111-1111-1111-1111-111111111111"), false, "lacteo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BarCodes",
                keyColumn: "Id",
                keyValue: new Guid("2abe7187-6c46-4017-87cb-57ed77803606"));

            migrationBuilder.DeleteData(
                table: "BarCodes",
                keyColumn: "Id",
                keyValue: new Guid("ebeb56d6-2be1-429c-939f-44ca76b51e9a"));

            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("3b145ac8-91c3-4b8a-9d33-4bc9a0227701"));

            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("46dfd4cb-2a54-4e13-9b2e-579e6912f725"));

            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("6a33856d-a1bc-4e86-8ff3-126a2bf598ca"));

            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("6f7708d3-4ede-4132-aee2-9c13de4c239d"));

            migrationBuilder.DropColumn(
                name: "SyncStatus",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "SyncStatus",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SyncStatus",
                table: "SaleDetails");

            migrationBuilder.DropColumn(
                name: "SyncStatus",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SyncStatus",
                table: "PriceHistories");

            migrationBuilder.DropColumn(
                name: "SyncStatus",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "SyncStatus",
                table: "BarCodes");

            migrationBuilder.InsertData(
                table: "BarCodes",
                columns: new[] { "Id", "Code", "CreatedAt", "IsDeleted", "ProductId", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("4bb001ec-24a4-44e4-9894-f9e30003d028"), "7701001", new DateTime(2026, 2, 22, 17, 7, 52, 234, DateTimeKind.Local).AddTicks(2464), false, new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 22, 17, 7, 52, 234, DateTimeKind.Local).AddTicks(2344) },
                    { new Guid("680af0c3-9d37-49c4-b8f0-3e8c596f4c59"), "7701002", new DateTime(2026, 2, 22, 17, 7, 52, 234, DateTimeKind.Local).AddTicks(3357), false, new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 22, 17, 7, 52, 234, DateTimeKind.Local).AddTicks(3354) }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 22, 17, 7, 52, 230, DateTimeKind.Local).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 22, 17, 7, 52, 232, DateTimeKind.Local).AddTicks(8426));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 22, 17, 7, 52, 232, DateTimeKind.Local).AddTicks(8449));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 22, 17, 7, 52, 232, DateTimeKind.Local).AddTicks(8452));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 22, 17, 7, 52, 232, DateTimeKind.Local).AddTicks(8455));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 22, 17, 7, 52, 232, DateTimeKind.Local).AddTicks(8458));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 22, 17, 7, 52, 232, DateTimeKind.Local).AddTicks(8461));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 22, 17, 7, 52, 232, DateTimeKind.Local).AddTicks(8464));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 22, 17, 7, 52, 232, DateTimeKind.Local).AddTicks(8467));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "CreatedAt",
                value: new DateTime(2026, 2, 22, 17, 7, 52, 232, DateTimeKind.Local).AddTicks(8470));

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
        }
    }
}
