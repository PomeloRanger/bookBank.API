﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Domain.Models
{
    public class OrderDetails
    {
        public int OrderDetailsID { get; set; }

        public int BookID { get; set; }
        public Book Book { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}
