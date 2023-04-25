using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeniceArtShow.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedProductTitleAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductTitle",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateListed",
                value: new DateTime(2023, 4, 25, 10, 34, 59, 21, DateTimeKind.Local).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateListed",
                value: new DateTime(2023, 4, 25, 10, 34, 59, 21, DateTimeKind.Local).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 25, 10, 34, 59, 21, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 4, 25, 10, 34, 59, 21, DateTimeKind.Local).AddTicks(6600));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductTitle",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateListed",
                value: new DateTime(2023, 4, 25, 10, 21, 43, 135, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateListed",
                value: new DateTime(2023, 4, 25, 10, 21, 43, 135, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 25, 10, 21, 43, 135, DateTimeKind.Local).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 4, 25, 10, 21, 43, 135, DateTimeKind.Local).AddTicks(4770));
        }
    }
}
