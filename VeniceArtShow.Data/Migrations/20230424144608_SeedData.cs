using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VeniceArtShow.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateListed",
                table: "Products",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedUtc",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedUtc",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.InsertData(
                table: "Medias",
                columns: new[] { "Id", "MediaType", "OrderEntityId" },
                values: new object[,]
                {
                    { 1, "Painting", null },
                    { 2, "Photograph", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Biography", "DateCreated", "Email", "FirstName", "LastName", "OrderEntityId", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "Retired from a life fishing along the Mississippi, Horace began his unique sandbar drawings and they quiclky became popular on Instagram.", new DateTime(2023, 4, 24, 10, 46, 8, 379, DateTimeKind.Local).AddTicks(3060), "unbricker@efa.org", "Horace", "Greenbottom", null, "openSesame32211!", "bricksRnotUs" },
                    { 2, "Holly, a friend of Go Lightly, decided one day to aim her Hollywood lights at 3 mirrors. The rest is history.", new DateTime(2023, 4, 24, 10, 46, 8, 379, DateTimeKind.Local).AddTicks(3150), "thingPainter@efa.org", "Holly", "Janedie", null, "8dj23jdjdj1++", "LotsOfThingsToPaint" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ArtistId", "DateListed", "Description", "ImageUrl", "MediaId", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 4, 24, 10, 46, 8, 379, DateTimeKind.Local).AddTicks(3340), "Painting of Mona Lisa in style of Edward Hopper", "https://effinghamdailynews.com/today", 1, 4.9900000000000002, "Nighthawks Nona Lisa" },
                    { 2, 2, new DateTime(2023, 4, 24, 10, 46, 8, 379, DateTimeKind.Local).AddTicks(3350), "A depiction of sound which is like but not the same as that Scream painting by Edward Munch", "https://hollyjanedie.com", 2, 40.530000000000001, "Sirens That Make You Scream" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Users",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateListed",
                table: "Products",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedUtc",
                table: "Orders",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedUtc",
                table: "Orders",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
