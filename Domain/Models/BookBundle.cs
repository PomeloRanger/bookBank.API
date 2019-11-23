using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Models
{
    public class BookBundle
    {
        public int BundleID { get; set; }
        public Bundle Bundle { get; set; }

        public int BookID { get; set; }
        public Book Book { get; set; }
    }
}
