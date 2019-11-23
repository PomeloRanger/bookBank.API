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

        public IList<BookPublisher> BookPublishers { get; set; }
        public IList<BookAuthor> BookAuthors { get; set; }
        public IList<BookBundle> BookBundles { get; set; }
        public IList<BookCategory> BookCategories { get; set; }
    }
}