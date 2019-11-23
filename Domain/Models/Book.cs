using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ISBN_10 { get; set; }
        public string ISBN_13 { get; set; }

        public ICollection<BookPublisher> BookPublishers { get; set; } = new List<BookPublisher>();
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
        public ICollection<BookBundle> BookBundles { get; set; } = new List<BookBundle>();
        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }
}