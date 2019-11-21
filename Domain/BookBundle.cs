using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain
{
    public class BookBundle
    {
        public int BookBundleID { get; set; }
        public int BookID { get; set; }
        public int BundleID { get; set; }

        public Bundle Bundle { get; set; }
    }
}
