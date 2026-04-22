using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlmaceNando.Data.Migrations
{
    /// <inheritdoc />
    public partial class InicialUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarCodes_Products_ProductId",
                table: "BarCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Combos_Products_ComboProductId",
                table: "Combos");

            migrationBuilder.DropForeignKey(
                name: "FK_Combos_Products_ComponentProductId",
                table: "Combos");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceHistories_Products_ProductId",
                table: "PriceHistories");

            migrationBuilder.DeleteData(
                table: "BarCodes",
                keyColumn: "Id",
                keyValue: new Guid("8ef06a82-e92a-47e7-a5c9-6da3e76a8f48"));

            migrationBuilder.DeleteData(
                table: "BarCodes",
                keyColumn: "Id",
                keyValue: new Guid("a9d44eae-0463-4543-bbd7-e9c9b2e8cecc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("1a97a1a4-c7e9-4429-9e3a-e6cad6fff504"));

            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("396cac5e-9f37-4681-b0e9-74e28b033412"));

            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("43a80338-30cb-41e0-8426-04a1a582622e"));

            migrationBuilder.DeleteData(
                table: "tags",
                keyColumn: "Id",
                keyValue: new Guid("8175a70c-dc35-4d4f-b7a0-9e18030b47cb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.AlterColumn<string>(
                name: "Rol",
                table: "User",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true,
                oldDefaultValue: "NN");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId1",
                table: "Sales",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "Sales",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "keyword",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Products",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<int>(
                name: "Stock",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 70,
                oldDefaultValue: "NN");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentPrice",
                table: "Products",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentDebt",
                table: "Customer",
                type: "TEXT",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "CreditLimit",
                table: "Customer",
                type: "TEXT",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldDefaultValue: 50000m);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Identification", "IsDeleted", "Name", "Password", "Rol", "SyncStatus", "UserName" },
                values: new object[,]
                {
                    { new Guid("a3b2c1d0-e4f5-4a3b-8c7d-6e5f4d3c2b1a"), new DateTime(2026, 3, 24, 23, 33, 58, 755, DateTimeKind.Local).AddTicks(3167), null, false, "Ana Cajera", "456", "Cajero", false, "ana" },
                    { new Guid("d7f965d1-9f9b-4e1b-b461-8f6920f09a56"), new DateTime(2026, 3, 24, 23, 33, 58, 753, DateTimeKind.Local).AddTicks(3877), null, false, "Diego Administrador", "123", "Admin", false, "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId1",
                table: "Sales",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId1",
                table: "Sales",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BarCodes_Products_ProductId",
                table: "BarCodes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Combos_Products_ComboProductId",
                table: "Combos",
                column: "ComboProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Combos_Products_ComponentProductId",
                table: "Combos",
                column: "ComponentProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceHistories_Products_ProductId",
                table: "PriceHistories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customer_CustomerId1",
                table: "Sales",
                column: "CustomerId1",
                principalTable: "Customer",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarCodes_Products_ProductId",
                table: "BarCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Combos_Products_ComboProductId",
                table: "Combos");

            migrationBuilder.DropForeignKey(
                name: "FK_Combos_Products_ComponentProductId",
                table: "Combos");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceHistories_Products_ProductId",
                table: "PriceHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customer_CustomerId1",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_User_UserId1",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CustomerId1",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_UserId1",
                table: "Sales");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a3b2c1d0-e4f5-4a3b-8c7d-6e5f4d3c2b1a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d7f965d1-9f9b-4e1b-b461-8f6920f09a56"));

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Sales");

            migrationBuilder.AlterColumn<string>(
                name: "Rol",
                table: "User",
                type: "TEXT",
                nullable: true,
                defaultValue: "NN",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "keyword",
                table: "Products",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Stock",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "TEXT",
                maxLength: 70,
                nullable: false,
                defaultValue: "NN",
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentDebt",
                table: "Customer",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "CreditLimit",
                table: "Customer",
                type: "TEXT",
                nullable: false,
                defaultValue: 50000m,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldPrecision: 18,
                oldScale: 2);

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

            migrationBuilder.AddForeignKey(
                name: "FK_BarCodes_Products_ProductId",
                table: "BarCodes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Combos_Products_ComboProductId",
                table: "Combos",
                column: "ComboProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Combos_Products_ComponentProductId",
                table: "Combos",
                column: "ComponentProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceHistories_Products_ProductId",
                table: "PriceHistories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
