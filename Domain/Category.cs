using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain
{
    public class Category
    {
        public int CategoryID { get; set; }
        public Genre Name { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; }
    }
}