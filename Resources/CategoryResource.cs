using bookBank.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Resources
{
    public class CategoryResource
    {
        public int CategoryID { get; set; }
        public Genre Genre { get; set; }
    }
}
