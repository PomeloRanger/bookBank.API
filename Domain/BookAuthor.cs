using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain
{
    public class BookAuthor
    {
        public int BookAuthorID { get; set; }
        public int BookID { get; set; }

        public Author Author { get; set; }
    }
}
