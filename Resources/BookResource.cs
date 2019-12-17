using bookBank.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Resources
{
    public class BookResource
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string ISBN_10 { get; set; }
        public string ISBN_13 { get; set; }
        public ICollection<PublisherResource> Publishers { get; set; }
        public ICollection<CategoryResource> Categories { get; set; }
        public ICollection<AuthorResource> Authors { get; set; }
    }
}