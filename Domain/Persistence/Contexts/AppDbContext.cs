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

            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.BookID, ba.AuthorID });

            /*
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorID);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookID);
            */

            modelBuilder.Entity<BookBundle>().HasKey(bb => new { bb.BookID, bb.BundleID });

            modelBuilder.Entity<BookBundle>()
                .HasOne(bb => bb.Bundle)
                .WithMany(bundle => bundle.BookBundles)
                .HasForeignKey(bb => bb.BundleID);

            modelBuilder.Entity<BookBundle>()
                .HasOne(bb => bb.Book)
                .WithMany(book => book.BookBundles)
                .HasForeignKey(bb => bb.BookID);


            modelBuilder.Entity<BookCategory>().HasKey(bc => new { bc.BookID, bc.CategoryID });

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryID);

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookID);

            modelBuilder.Entity<BookPublisher>().HasKey(bp => new { bp.BookID, bp.PublisherID });

            modelBuilder.Entity<BookPublisher>()
                .HasOne(bp => bp.Publisher)
                .WithMany(p => p.BookPublishers)
                .HasForeignKey(bp => bp.PublisherID);

            modelBuilder.Entity<BookPublisher>()
                .HasOne(bp => bp.Book)
                .WithMany(b => b.BookPublishers)
                .HasForeignKey(bp => bp.BookID);

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
                    new Book { BookID = 100, Description = "Wow such doge", ISBN_10 = "101212", ISBN_13 = "1292192", Title = "Doge", Price = 102M },
                    new Book { BookID = 101, Description = "Testing2", ISBN_10="12121", ISBN_13="4444212", Title="Test2", Price=29M}
                );

            modelBuilder.Entity<BookAuthor>()
                .HasData(
                    new BookAuthor { AuthorID = 100, BookID = 100 },
                    new BookAuthor { AuthorID = 101, BookID = 101}
                );
            */

            var Books = new[]
            {
                new Book{ BookID=101, Description="Tom", Price=130M, ISBN_10="21412", ISBN_13="19281", Title="Tom"  },
                new Book{ BookID=102, Description="Jerry", Price=140M, ISBN_10="12121", ISBN_13="92121", Title="Jerry" }
            };

            var Authors = new[]
            {
                new Author{ AuthorID=101, AuthorName = "Timothy"}
            };

            var BookAuthors = new[]
            {
                new BookAuthor{ AuthorID=101, BookID=101  },
                new BookAuthor{ AuthorID=101, BookID=102 }
            };

            var Publishers = new[]
            {
                new Publisher{ PublisherID=101, PublisherName="Jerome"},
                new Publisher{ PublisherID=102, PublisherName = "Timothy"}
            };

            var BookPublishers = new[]
            {
                new BookPublisher{ PublisherID=101, BookID=101}
            };

            modelBuilder.Entity<Book>().HasData(Books[0], Books[1]);
            modelBuilder.Entity<Author>().HasData(Authors[0]);
            modelBuilder.Entity<Publisher>().HasData(Publishers[0], Publishers[1]);
            modelBuilder.Entity<BookAuthor>().HasData(BookAuthors[0], BookAuthors[1]);
            modelBuilder.Entity<BookPublisher>().HasData(BookPublishers[0]);

            base.OnModelCreating(modelBuilder);
        }
    }
}
