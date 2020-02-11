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

        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
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

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Review)
                .HasForeignKey(r => r.UserID);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Review)
                .HasForeignKey(r => r.BookID);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Order)
                .HasForeignKey(o => o.UserID);

            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Book)
                .WithMany(b => b.OrderDetails)
                .HasForeignKey(od => od.BookID);


            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderID);


            //Scaffold simulate data
            var Books = new[]
            {
                new Book{ 
                    BookID=1, 
                    Description="Nine-year-old Meena can’t wait to grow up and break free from her parents. But, as the daughter of the only Punjabi family in the mining village of Tollington, her struggle for independence is different from most. Meena wants fishfingers and chips, not chapati and dhal; she wants an English Christmas, not the usual interminable Punjabi festivities – but more than anything, she wants to roam the backyards of working -class Tollington with feisty Anita Rutter and her gang.Blonde, cool, aloof, outrageous and sassy, Anita is everything Meena thinks she wants to be.Meena wheedles her way into Anita’s life, but the arrival of a baby brother, teenage hormones, impending entrance exams for the posh grammar school and a motorcycling rebel without a future threaten to turn Anita’s salad days sour. Anita and Me paints a comic, poignant, compassionate and colourful portrait of village life in the era of flares, power cuts, glam rock, decimalisation and Ted Heath. It is a unique vision of a British childhood in the Seventies, a childhood caught between two cultures, each on the brink of change.", 
                    ImageUrl="https://i.imgur.com/RwxM72M.jpg", 
                    Price=14.98M, 
                    ISBN_10="0006548768", 
                    ISBN_13="978-0006548768", 
                    Title="Anita and Me"
                },

                new Book{ 
                    BookID=2, 
                    Description="When the enemy is one of your own, the payback is twice as hard. The Butler brothers are the Kings of the East End, and their motto is 'what goes around, comes around'. In their world, family counts; so when the truth about Vinny's nephew's death comes to light, it rocks the Butlers to the core. One by one, Vinny's friends and family are turning against him. Then, the unimaginable happens - Vinny's little daughter Molly goes missing. She's the one chink of light in all their lives, and the one they'd commit murders to bring back. But is it already too late for that?", 
                    ImageUrl="https://i.imgur.com/0DK022r.jpg" ,
                    Price=14.99M, 
                    ISBN_10="0007435053", 
                    ISBN_13="978-0007435053", 
                    Title="Payback" 
                }
            };

            var Authors = new[]
            {
                new Author{ AuthorID=1, AuthorName = "Timothy"}
            };

            var BookAuthors = new[]
            {
                new BookAuthor{ AuthorID=1, BookID=1  },
                new BookAuthor{ AuthorID=1, BookID=2 }
            };

            var Publishers = new[]
            {
                new Publisher{ PublisherID=1, PublisherName="Jerome"},
                new Publisher{ PublisherID=2, PublisherName = "Timothy"}
            };

            var BookPublishers = new[]
            {
                new BookPublisher{ PublisherID=1, BookID=1},
                new BookPublisher{ PublisherID=2, BookID=2}
            };

            var Categorys= new[]
            {
                new Category{ CategoryID=1, Genre=Genre.Contemporary},
                new Category{ Genre = Genre.Art}
            };

            var BookCategories = new[]
            {
                new BookCategory{ BookID=1, CategoryID=1}
            };

            var Bundles = new[]
            {
                new Bundle{ BundleID=1, Price=50},
            };

            var BookBundles = new[]
            {
                new BookBundle{ BookID=1, BundleID=1},
                new BookBundle { BookID=2, BundleID=1}
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