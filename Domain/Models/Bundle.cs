using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Models
{
    public class Bundle
    {
        public int BundleID { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public ICollection<BookBundle> BookBundles { get; set; }
    }
}