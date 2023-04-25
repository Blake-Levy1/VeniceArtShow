using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeniceArtShow.Data.Migrations
{
    /// <inheritdoc />
    public partial class TuesdayRootOut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Medias_MediaId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MediaId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ModifiedUtc",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateListed",
                value: new DateTime(2023, 4, 25, 10, 58, 47, 53, DateTimeKind.Local).AddTicks(1570));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateListed",
                value: new DateTime(2023, 4, 25, 10, 58, 47, 53, DateTimeKind.Local).AddTicks(1570));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 25, 10, 58, 47, 53, DateTimeKind.Local).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 4, 25, 10, 58, 47, 53, DateTimeKind.Local).AddTicks(1480));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MediaId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedUtc",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MediaId",
                table: "Orders",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Medias_MediaId",
                table: "Orders",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
