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
            //Composite Key
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.BookID, ba.AuthorID });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorID);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookID);

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

            var Books = new[]
            {
                new Book{ BookID=101, Description="FBI Agent Atlee Pine's life was never the same after her twin sister Mercy was kidnapped--and likely killed--thirty years ago. After a lifetime of torturous uncertainty, Atlee's unresolved anger finally gets the better of her on the job, and she finds she has to deal with the demons of her past if she wants to remain with the FBI.", ImageUrl="https://i.imgur.com/1mSWvvS.jpg", Price=14.98M, ISBN_10="1538761602", ISBN_13="978-1538761601", Title="A Minute to Midnight (An Atlee Pine Thriller (2))"  },
                new Book{ BookID=102, Description="Reacher is on a Greyhound bus, minding his own business, with no particular place to go, and all the time in the world to get there. Then he steps off the bus to help an old man who is obviously just a victim waiting to happen. But you know what they say about good deeds. Now Reacher wants to make it right.", ImageUrl="https://i.imgur.com/ELBaTAe.jpg" ,Price=14.99M, ISBN_10="0399593543", ISBN_13="978-0399593543", Title="Blue Moon: A Jack Reacher Novel" }
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
                new BookPublisher{ PublisherID=101, BookID=101},
                new BookPublisher{ PublisherID=102, BookID=102}
            };

            var Categorys= new[]
            {
                new Category{ CategoryID=101, Genre=Genre.Contemporary},
                new Category{ Genre = Genre.Art}
            };

            var BookCategories = new[]
            {
                new BookCategory{ BookID=101, CategoryID=101}
            };

            var Bundles = new[]
            {
                new Bundle{ BundleID=101, Price=50},
            };

            var BookBundles = new[]
            {
                new BookBundle{ BookID=101, BundleID=101},
                new BookBundle { BookID=102, BundleID=101}
            };


            modelBuilder.Entity<Book>().HasData(Books[0], Books[1]);
            modelBuilder.Entity<Author>().HasData(Authors[0]);
            modelBuilder.Entity<Publisher>().HasData(Publishers[0], Publishers[1]);
            modelBuilder.Entity<BookAuthor>().HasData(BookAuthors[0], BookAuthors[1]);
            modelBuilder.Entity<BookPublisher>().HasData(BookPublishers[0], BookPublishers[1]);
            modelBuilder.Entity<Category>().HasData(Categorys[0]);
            modelBuilder.Entity<BookCategory>().HasData(BookCategories[0]);
            modelBuilder.Entity<Bundle>().HasData(Bundles[0]);
            modelBuilder.Entity<BookBundle>().HasData(BookBundles[0], BookBundles[1]);

            base.OnModelCreating(modelBuilder);
        }
    }
}