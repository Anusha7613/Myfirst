using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Myfirst.Models;

namespace Myfirst.Models
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Membership> GetMemberships { get; set; }
        public List<Customer> Gender { get; set; } 
    }
}