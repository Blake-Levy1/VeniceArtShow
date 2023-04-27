using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VeniceArtShow.Data.Migrations
{
    /// <inheritdoc />
    public partial class AuthoEmail1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DateListed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Products_Users_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    BuyerEmail = table.Column<int>(type: "int", nullable: false),
                    EmailId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Orders_Users_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Orders_Users_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Orders_Users_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Medias",
                columns: new[] { "Id", "MediaType" },
                values: new object[,]
                {
                    { 1, "Painting" },
                    { 2, "Photograph" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Biography", "DateCreated", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "Retired from a life fishing along the Mississippi, Horace began his unique sandbar drawings and they quiclky became popular on Instagram.", new DateTime(2023, 4, 26, 15, 0, 35, 575, DateTimeKind.Local).AddTicks(9830), "unbricker@efa.org", "Horace", "Greenbottom", "openSesame32211!", "bricksRnotUs" },
                    { 2, "Holly, a friend of Go Lightly, decided one day to aim her Hollywood lights at 3 mirrors. The rest is history.", new DateTime(2023, 4, 26, 15, 0, 35, 575, DateTimeKind.Local).AddTicks(9900), "thingPainter@efa.org", "Holly", "Janedie", "8dj23jdjdj1++", "LotsOfThingsToPaint" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ArtistId", "DateListed", "Description", "ImageUrl", "MediaId", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 4, 26, 15, 0, 35, 575, DateTimeKind.Local).AddTicks(9980), "Painting of Mona Lisa in style of Edward Hopper", "https://effinghamdailynews.com/today", 1, 4.9900000000000002, "Nighthawks Nona Lisa" },
                    { 2, 2, new DateTime(2023, 4, 26, 15, 0, 35, 575, DateTimeKind.Local).AddTicks(9990), "A depiction of sound which is like but not the same as that Scream painting by Edward Munch", "https://hollyjanedie.com", 2, 40.530000000000001, "Sirens That Make You Scream" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ArtistId",
                table: "Orders",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmailId",
                table: "Orders",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ArtistId",
                table: "Products",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MediaId",
                table: "Products",
                column: "MediaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
