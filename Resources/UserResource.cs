using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookBank.API.Resources
{
    public class UserResource
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PostalCode { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
    }
}