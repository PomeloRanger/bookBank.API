using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Models
{
    public class BookAuthor
    {
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }
        public int BookID { get; set; }
        public virtual Book Book { get; set; }
    }
}
