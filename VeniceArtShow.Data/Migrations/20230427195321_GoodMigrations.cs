using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VeniceArtShow.Data.Migrations
{
    /// <inheritdoc />
    public partial class GoodMigrations : Migration
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
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false)
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
                });

            migrationBuilder.InsertData(
                table: "Medias",
                columns: new[] { "Id", "MediaType" },
                values: new object[,]
                {
                    { 1, "Painting" },
                    { 2, "Photograph" },
                    { 3, "Ceramics" },
                    { 4, "Digital" },
                    { 5, "Glass" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Biography", "DateCreated", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "Retired from a life fishing along the Mississippi, Horace began his unique sandbar drawings and they quiclky became popular on Instagram.", new DateTime(2023, 4, 27, 15, 53, 21, 270, DateTimeKind.Local).AddTicks(5840), "unbricker@veniceart.show", "Horace", "Greenbottom", "openSesame32211!", "bricksRnotUs" },
                    { 2, "Holly, a friend of Go Lightly, decided one day to aim her Hollywood lights at 3 mirrors. The rest is history.", new DateTime(2023, 4, 27, 15, 53, 21, 270, DateTimeKind.Local).AddTicks(5900), "thingPainter@veniceart.show", "Holly", "Janedie", "8dj23jdjdj1++", "LotsOfThingsToPaint" },
                    { 3, "A Fourth Grade Teacher who loves sunsets and Animal Kingdom art.", new DateTime(2023, 4, 27, 15, 53, 21, 270, DateTimeKind.Local).AddTicks(5910), "artlover4@veniceart.show", "Lorraine", "Lansbury", "password", "artLover4" },
                    { 4, "'Whenever I go out the people always shout'.", new DateTime(2023, 4, 27, 15, 53, 21, 270, DateTimeKind.Local).AddTicks(5910), "towers4art@veniceart.show", "John", "Jingleheimerschmit", "password", "TowersForArt" },
                    { 5, "Heir of the famous store, now dabbles in photography.", new DateTime(2023, 4, 27, 15, 53, 21, 270, DateTimeKind.Local).AddTicks(5910), "versaceart@veniceart.show", "L.S.", "Ayres", "password", "VersaceArt" },
                    { 6, "Loves to go on walks and set up his easel.", new DateTime(2023, 4, 27, 15, 53, 21, 270, DateTimeKind.Local).AddTicks(5920), "bentleyinthehouse@veniceart.show", "Beastly", "Gentle", "password!", "BentleyInTheHouse" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ArtistId", "DateListed", "Description", "ImageUrl", "IsSold", "MediaId", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 4, 27, 15, 53, 21, 270, DateTimeKind.Local).AddTicks(6030), "Painting of Mona Lisa in style of Edward Hopper", "https://effinghamdailynews.com/today", false, 1, 4.9900000000000002, "Nighthawks Nona Lisa" },
                    { 2, 2, new DateTime(2023, 4, 27, 15, 53, 21, 270, DateTimeKind.Local).AddTicks(6030), "A depiction of sound which is like but not the same as that Scream painting by Edward Munch", "https://hollyjanedie.com", false, 2, 40.530000000000001, "Sirens That Make You Scream" },
                    { 3, 3, new DateTime(2023, 4, 27, 15, 53, 21, 270, DateTimeKind.Local).AddTicks(6040), "A set of three hand-blown vases.", "www.ikea.com/us/en/cat/vases-10776/", false, 5, 983.33000000000004, "Call It V" },
                    { 4, 4, new DateTime(2023, 4, 27, 15, 53, 21, 270, DateTimeKind.Local).AddTicks(6040), "A collection of dreamy sunsets on hazy days.", "https://wallpapers.com", false, 4, 763.83000000000004, "Sunsets to Fall Asleep To" },
                    { 5, 5, new DateTime(2023, 4, 27, 15, 53, 21, 270, DateTimeKind.Local).AddTicks(6040), "A sculpture of the three faces of eve.", "https://clevelandmuseumofart.org", false, 3, 73333.0, "Three Faces of Eve" },
                    { 6, 6, new DateTime(2023, 4, 27, 15, 53, 21, 270, DateTimeKind.Local).AddTicks(6040), "Color photographs of skiers in Tahoe circa 1964.", "https://andersart.com", false, 2, 400.00999999999999, "On The Tahoe Slopes" },
                    { 7, 1, new DateTime(2023, 4, 27, 15, 53, 21, 270, DateTimeKind.Local).AddTicks(6050), "You already know it. We have it. The Scream painting by Edward Munch", "https://nationalmuseumofoslo", false, 1, 392822.97999999998, "The Scream" },
                    { 8, 2, new DateTime(2023, 4, 27, 15, 53, 21, 270, DateTimeKind.Local).AddTicks(6050), "Vr ripoffs of famous art.", "https://metaverse.com", false, 4, 1000.0, "3D Masters in Virtual Reality" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ArtistId", "BuyerId", "CreatedUtc", "Price", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 3, new DateTime(2023, 4, 27, 15, 53, 21, 270, DateTimeKind.Local).AddTicks(6060), 4.9900000000000002, 1 },
                    { 2, 2, 4, new DateTime(2023, 4, 27, 15, 53, 21, 270, DateTimeKind.Local).AddTicks(6060), 40.530000000000001, 2 },
                    { 3, 3, 4, new DateTime(2023, 4, 27, 15, 53, 21, 270, DateTimeKind.Local).AddTicks(6070), 983.33000000000004, 3 }
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
