using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain
{
    public class BookPublisher
    {
        public int BookPublisherID { get; set; }
        public int BookID { get; set; }

        public Publisher Publisher { get; set; }
    }
}