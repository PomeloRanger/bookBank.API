using bookBank.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Resources
{
    public class ReviewResource
    {
        public int ReviewID { get; set; }
        public int Rating { get; set; }

        public int UserID { get; set; }
        public UserResource User { get; set; }
    }
}