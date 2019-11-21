using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
