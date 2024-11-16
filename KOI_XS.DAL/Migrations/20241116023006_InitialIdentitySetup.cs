using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KOI_XS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialIdentitySetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 11, 6, 9, 30, 4, 319, DateTimeKind.Local).AddTicks(1072));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 11, 11, 9, 30, 4, 319, DateTimeKind.Local).AddTicks(1110));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
