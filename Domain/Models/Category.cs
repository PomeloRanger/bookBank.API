using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public Genre Genre { get; set; }
        public IList<BookCategory> BookCategories { get; set; }
    }
}
