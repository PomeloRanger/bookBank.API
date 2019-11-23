using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Models
{
    public class Bundle
    {
        public int BundleID { get; set; }
        public decimal Price { get; set; }
        public IList<BookBundle> BookBundles { get; set; }
    }
}
