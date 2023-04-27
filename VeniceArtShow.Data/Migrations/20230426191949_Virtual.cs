using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeniceArtShow.Data.Migrations
{
    /// <inheritdoc />
    public partial class Virtual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_EmailId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_EmailId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BuyerEmail",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateListed",
                value: new DateTime(2023, 4, 26, 15, 19, 49, 528, DateTimeKind.Local).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateListed",
                value: new DateTime(2023, 4, 26, 15, 19, 49, 528, DateTimeKind.Local).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 26, 15, 19, 49, 528, DateTimeKind.Local).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 4, 26, 15, 19, 49, 528, DateTimeKind.Local).AddTicks(2400));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerEmail",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmailId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateListed",
                value: new DateTime(2023, 4, 26, 15, 0, 35, 575, DateTimeKind.Local).AddTicks(9980));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateListed",
                value: new DateTime(2023, 4, 26, 15, 0, 35, 575, DateTimeKind.Local).AddTicks(9990));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 26, 15, 0, 35, 575, DateTimeKind.Local).AddTicks(9830));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 4, 26, 15, 0, 35, 575, DateTimeKind.Local).AddTicks(9900));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmailId",
                table: "Orders",
                column: "EmailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_EmailId",
                table: "Orders",
                column: "EmailId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
