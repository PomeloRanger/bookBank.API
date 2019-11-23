using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Models
{
    public class BookCategory
    {
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int BookID { get; set; }
        public Book Book { get; set; }
    }
}
