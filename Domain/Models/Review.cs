using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int Rating { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public int BookID { get; set; }
        public Book Book { get; set; }
    }
}
