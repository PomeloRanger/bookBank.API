using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bookBank.API.Migrations
{
    public partial class InitialBookBank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ISBN_10 = table.Column<string>(nullable: true),
                    ISBN_13 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "Bundles",
                columns: table => new
                {
                    BundleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundles", x => x.BundleID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PostalCode = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    AuthorID = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.BookID, x.AuthorID });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBundles",
                columns: table => new
                {
                    BundleID = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBundles", x => new { x.BookID, x.BundleID });
                    table.ForeignKey(
                        name: "FK_BookBundles_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBundles_Bundles_BundleID",
                        column: x => x.BundleID,
                        principalTable: "Bundles",
                        principalColumn: "BundleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => new { x.BookID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_BookCategories_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookPublishers",
                columns: table => new
                {
                    PublisherID = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPublishers", x => new { x.BookID, x.PublisherID });
                    table.ForeignKey(
                        name: "FK_BookPublishers_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookPublishers_Publishers_PublisherID",
                        column: x => x.PublisherID,
                        principalTable: "Publishers",
                        principalColumn: "PublisherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailsID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorID", "AuthorName" },
                values: new object[] { 1, "Timothy" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "Description", "ISBN_10", "ISBN_13", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Nine-year-old Meena can’t wait to grow up and break free from her parents. But, as the daughter of the only Punjabi family in the mining village of Tollington, her struggle for independence is different from most. Meena wants fishfingers and chips, not chapati and dhal; she wants an English Christmas, not the usual interminable Punjabi festivities – but more than anything, she wants to roam the backyards of working -class Tollington with feisty Anita Rutter and her gang.Blonde, cool, aloof, outrageous and sassy, Anita is everything Meena thinks she wants to be.Meena wheedles her way into Anita’s life, but the arrival of a baby brother, teenage hormones, impending entrance exams for the posh grammar school and a motorcycling rebel without a future threaten to turn Anita’s salad days sour. Anita and Me paints a comic, poignant, compassionate and colourful portrait of village life in the era of flares, power cuts, glam rock, decimalisation and Ted Heath. It is a unique vision of a British childhood in the Seventies, a childhood caught between two cultures, each on the brink of change.", "0006548768", "978-0006548768", "https://i.imgur.com/RwxM72M.jpg", 14.98m, "Anita and Me" },
                    { 2, "When the enemy is one of your own, the payback is twice as hard. The Butler brothers are the Kings of the East End, and their motto is 'what goes around, comes around'. In their world, family counts; so when the truth about Vinny's nephew's death comes to light, it rocks the Butlers to the core. One by one, Vinny's friends and family are turning against him. Then, the unimaginable happens - Vinny's little daughter Molly goes missing. She's the one chink of light in all their lives, and the one they'd commit murders to bring back. But is it already too late for that?", "0007435053", "978-0007435053", "https://i.imgur.com/0DK022r.jpg", 14.99m, "Payback" }
                });

            migrationBuilder.InsertData(
                table: "Bundles",
                columns: new[] { "BundleID", "Price" },
                values: new object[] { 1, 50m });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Genre" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherID", "PublisherName" },
                values: new object[,]
                {
                    { 1, "Jerome" },
                    { 2, "Timothy" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "BookID", "AuthorID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "BookBundles",
                columns: new[] { "BookID", "BundleID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "BookID", "CategoryID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "BookPublishers",
                columns: new[] { "BookID", "PublisherID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorID",
                table: "BookAuthors",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_BookBundles_BundleID",
                table: "BookBundles",
                column: "BundleID");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_CategoryID",
                table: "BookCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_BookPublishers_PublisherID",
                table: "BookPublishers",
                column: "PublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_BookID",
                table: "OrderDetails",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookID",
                table: "Reviews",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserID",
                table: "Reviews",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BookBundles");

            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropTable(
                name: "BookPublishers");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Bundles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
