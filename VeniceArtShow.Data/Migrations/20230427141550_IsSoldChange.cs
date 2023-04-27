using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeniceArtShow.Data.Migrations
{
    /// <inheritdoc />
    public partial class IsSoldChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ArtistId",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "IsSold",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateListed", "IsSold" },
                values: new object[] { new DateTime(2023, 4, 27, 10, 15, 49, 889, DateTimeKind.Local).AddTicks(3472), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateListed", "IsSold" },
                values: new object[] { new DateTime(2023, 4, 27, 10, 15, 49, 889, DateTimeKind.Local).AddTicks(3475), false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 27, 10, 15, 49, 889, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 4, 27, 10, 15, 49, 889, DateTimeKind.Local).AddTicks(3296));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_ArtistId",
                table: "Orders",
                column: "ArtistId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_ArtistId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsSold",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateListed",
                value: new DateTime(2023, 4, 25, 13, 55, 16, 610, DateTimeKind.Local).AddTicks(4870));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateListed",
                value: new DateTime(2023, 4, 25, 13, 55, 16, 610, DateTimeKind.Local).AddTicks(4870));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 25, 13, 55, 16, 610, DateTimeKind.Local).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 4, 25, 13, 55, 16, 610, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ArtistId",
                table: "Orders",
                column: "ArtistId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
