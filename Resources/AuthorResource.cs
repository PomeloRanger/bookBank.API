using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Resources
{
    public class AuthorResource
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public BookResource Book { get; set; }
    }
}
