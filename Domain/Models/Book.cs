using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ISBN_10 { get; set; }
        public string ISBN_13 { get; set; }

        public virtual ICollection<BookPublisher> BookPublishers { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        public virtual ICollection<BookBundle> BookBundles { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}