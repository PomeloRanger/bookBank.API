using bookBank.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Resources
{
    public class BundleResource
    {
        public int BundleID { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public ICollection<BookResource> Books { get; set; }
    }
}
