using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
