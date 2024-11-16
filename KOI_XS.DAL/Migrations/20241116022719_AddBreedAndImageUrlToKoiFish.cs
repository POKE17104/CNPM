using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KOI_XS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddBreedAndImageUrlToKoiFish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "KoiFishId",
                table: "OrderKois",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderKois",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderKois",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "OrderKois",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "KoiFishes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "KoiFishes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Kois",
                columns: table => new
                {
                    KoiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kois", x => x.KoiId);
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "Address", "Password", "PhoneNumber", "Username" },
                values: new object[] { "123/34 Lê Văn Thọ, p15, Gò vấp,TP-HCM", "password123", "0123456789", "nguyenvana" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "Address", "Password", "PhoneNumber", "Username" },
                values: new object[] { "456 Nguyễn Thị Minh Khai,p1,Quận 1, Tp-HCM", "password456", "0987654321", "tranthib" });

            migrationBuilder.UpdateData(
                table: "KoiFishes",
                keyColumn: "KoiFishId",
                keyValue: 1,
                columns: new[] { "Breed", "ImageUrl" },
                values: new object[] { "Dragon", "http://example.com/koi-red-dragon.jpg" });

            migrationBuilder.UpdateData(
                table: "KoiFishes",
                keyColumn: "KoiFishId",
                keyValue: 2,
                columns: new[] { "Breed", "ImageUrl" },
                values: new object[] { "Beauty", "http://example.com/koi-black-beauty.jpg" });

            migrationBuilder.UpdateData(
                table: "KoiFishes",
                keyColumn: "KoiFishId",
                keyValue: 3,
                columns: new[] { "Breed", "ImageUrl" },
                values: new object[] { "Pearl", "http://example.com/koi-white-pearl.jpg" });

            migrationBuilder.UpdateData(
                table: "OrderKois",
                keyColumns: new[] { "KoiFishId", "OrderId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "Quantity", "UnitPrice" },
                values: new object[] { 1, 150.00m });

            migrationBuilder.UpdateData(
                table: "OrderKois",
                keyColumns: new[] { "KoiFishId", "OrderId" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "Quantity", "UnitPrice" },
                values: new object[] { 1, 200.00m });

            migrationBuilder.UpdateData(
                table: "OrderKois",
                keyColumns: new[] { "KoiFishId", "OrderId" },
                keyValues: new object[] { 3, 2 },
                columns: new[] { "Quantity", "UnitPrice" },
                values: new object[] { 1, 180.00m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 11, 6, 9, 27, 17, 673, DateTimeKind.Local).AddTicks(8306));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 11, 11, 9, 27, 17, 673, DateTimeKind.Local).AddTicks(8346));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kois");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderKois");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "OrderKois");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "KoiFishes");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "KoiFishes");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "KoiFishId",
                table: "OrderKois",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderKois",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 0);

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

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 10, 23, 16, 1, 47, 341, DateTimeKind.Local).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 10, 28, 16, 1, 47, 341, DateTimeKind.Local).AddTicks(4879));
        }
    }
}
