using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain
{
    public class BookCategory
    {
        public int BookCategoryID { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public Category Category { get; set; }
    }
}
