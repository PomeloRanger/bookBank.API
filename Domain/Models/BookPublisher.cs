using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Models
{
    public class BookPublisher
    {
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }

        public int BookID { get; set; }
        public Book Book { get; set; }
    }
}
