using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Models
{
    public class Publisher
    {
        public int PublisherID { get; set; }
        public string Name { get; set; }
        public IList<BookPublisher> BookPublishers { get; set; }
    }
}
