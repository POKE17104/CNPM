using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KOI_XS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KoiId",
                table: "KoiFishes",
                newName: "KoiFishId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "KoiFishes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "KoiFishes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderKois",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    KoiFishId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderKois", x => new { x.OrderId, x.KoiFishId });
                    table.ForeignKey(
                        name: "FK_OrderKois_KoiFishes_KoiFishId",
                        column: x => x.KoiFishId,
                        principalTable: "KoiFishes",
                        principalColumn: "KoiFishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderKois_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "nguyenvana@example.com", "Nguyen Van A" },
                    { 2, "tranthib@example.com", "Tran Thi B" }
                });

            migrationBuilder.InsertData(
                table: "KoiFishes",
                columns: new[] { "KoiFishId", "Color", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Red", "Koi Red Dragon", 150.00m },
                    { 2, "Black", "Koi Black Beauty", 200.00m },
                    { 3, "White", "Koi White Pearl", 180.00m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 23, 16, 1, 47, 341, DateTimeKind.Local).AddTicks(4832) },
                    { 2, 2, new DateTime(2024, 10, 28, 16, 1, 47, 341, DateTimeKind.Local).AddTicks(4879) }
                });

            migrationBuilder.InsertData(
                table: "OrderKois",
                columns: new[] { "KoiFishId", "OrderId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderKois_KoiFishId",
                table: "OrderKois",
                column: "KoiFishId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderKois");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DeleteData(
                table: "KoiFishes",
                keyColumn: "KoiFishId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KoiFishes",
                keyColumn: "KoiFishId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KoiFishes",
                keyColumn: "KoiFishId",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "KoiFishId",
                table: "KoiFishes",
                newName: "KoiId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "KoiFishes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "KoiFishes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
