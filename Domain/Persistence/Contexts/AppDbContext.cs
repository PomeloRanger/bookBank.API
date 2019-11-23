using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookBank.API.Domain.Models;

namespace bookBank.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Bundle> Bundles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookBundle> BookBundles { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<BookPublisher> BookPublishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.BookID, ba.AuthorID });

            modelBuilder.Entity<BookBundle>().HasKey(bb => new { bb.BookID, bb.BundleID });

            modelBuilder.Entity<BookCategory>().HasKey(bc => new { bc.BookID, bc.CategoryID });

            modelBuilder.Entity<BookPublisher>().HasKey(bp => new { bp.BookID, bp.PublisherID });

            var Categories = new[]
            {
                new Category { CategoryID=103, Genre = Genre.Art},
                new Category { CategoryID=104, Genre = Genre.Contemporary}
            };

            var Books = new[]
            {
                new Book{BookID = 101, Description = "Test3", ISBN_10="9821", ISBN_13 = "12821", Title = "Doge", Price = 152M },
                new Book{BookID = 102, Description = "Test2", ISBN_10 = "101212", ISBN_13 = "1292192", Title = "Doge", Price = 102M }
            };

            var Author = new[]
            {
                new Author { AuthorID = 100, AuthorName="Jonas" },
                new Author { AuthorID = 101, AuthorName="Timothy"}
            };

            var BookAuthor = new[]
            {
                new BookAuthor { AuthorID=100, BookID=101},
                new BookAuthor { AuthorID= 101, BookID=102}
            };

            var BookCategory = new[]
            {
                new BookCategory{ BookID = 101, CategoryID= 103},
                new BookCategory{ BookID = 102, CategoryID = 104}
            };

            /*
            modelBuilder.Entity<Author>()
                .HasData
                (
                    new Author { AuthorID = 100, AuthorName = "Tom"}, 
                    new Author { AuthorID = 101, AuthorName = "John" }
                );

            modelBuilder.Entity<Bundle>()
                .HasData(
                    new Bundle { BundleID = 101, Price = 19.1M},
                    new Bundle {  BundleID = 102, Price = 15.9M}
                );

            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { CategoryID = 101, Genre = Genre.Adventure },
                    new Category { CategoryID = 102, Genre = Genre.Children}
                );

            modelBuilder.Entity<Publisher>()
                .HasData(
                    new Publisher { PublisherID = 101, Name = "Thomas" },
                    new Publisher { PublisherID = 102, Name = "Jonas"}
                );

            modelBuilder.Entity<Book>()
                .HasData(
                    new Book { BookID = 100, Description = "Wow such doge", ISBN_10 = "101212", ISBN_13 = "1292192", Title = "Doge", Price = 102M }
                );
            */


            modelBuilder.Entity<Book>().HasData(Books[0], Books[1]);
            modelBuilder.Entity<Category>().HasData(Categories[0], Categories[1]);
            modelBuilder.Entity<Author>().HasData(Author[0], Author[1]);
            modelBuilder.Entity<BookCategory>().HasData(BookCategory[0], BookCategory[1]);
            modelBuilder.Entity<BookAuthor>().HasData(BookAuthor[0], BookAuthor[1]);
        }
    }
}
