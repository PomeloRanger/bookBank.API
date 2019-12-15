﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace bookBank.API.Migrations
{
    public partial class CreateBookDB : Migration
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

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorID", "AuthorName" },
                values: new object[] { 101, "Timothy" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "Description", "ISBN_10", "ISBN_13", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 101, "FBI Agent Atlee Pine's life was never the same after her twin sister Mercy was kidnapped--and likely killed--thirty years ago. After a lifetime of torturous uncertainty, Atlee's unresolved anger finally gets the better of her on the job, and she finds she has to deal with the demons of her past if she wants to remain with the FBI.", "1538761602", "978-1538761601", "https://i.imgur.com/1mSWvvS.jpg", 14.98m, "A Minute to Midnight (An Atlee Pine Thriller (2))" },
                    { 102, "Reacher is on a Greyhound bus, minding his own business, with no particular place to go, and all the time in the world to get there. Then he steps off the bus to help an old man who is obviously just a victim waiting to happen. But you know what they say about good deeds. Now Reacher wants to make it right.", "0399593543", "978-0399593543", "https://i.imgur.com/ELBaTAe.jpg", 14.99m, "Blue Moon: A Jack Reacher Novel" }
                });

            migrationBuilder.InsertData(
                table: "Bundles",
                columns: new[] { "BundleID", "Price" },
                values: new object[] { 101, 50m });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Genre" },
                values: new object[] { 101, 3 });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherID", "PublisherName" },
                values: new object[,]
                {
                    { 101, "Jerome" },
                    { 102, "Timothy" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "BookID", "AuthorID" },
                values: new object[,]
                {
                    { 101, 101 },
                    { 102, 101 }
                });

            migrationBuilder.InsertData(
                table: "BookBundles",
                columns: new[] { "BookID", "BundleID" },
                values: new object[,]
                {
                    { 101, 101 },
                    { 102, 101 }
                });

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "BookID", "CategoryID" },
                values: new object[] { 101, 101 });

            migrationBuilder.InsertData(
                table: "BookPublishers",
                columns: new[] { "BookID", "PublisherID" },
                values: new object[,]
                {
                    { 101, 101 },
                    { 102, 102 }
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
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Bundles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}