using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        public string ISBN_10 { get; set; }
        public string ISBN_13 { get; set; }

        public ICollection<BookPublisher> BookPublishers { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<BookBundle> BookBundles { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
        public ICollection<Review> Review { get; set; }
        public ICollection<OrderDetails>OrderDetails { get; set; }
    }
}