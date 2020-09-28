using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Myfirst.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public string MembershipType { get; set; }
        public double SignUpFee { get; set; }
        public int Duration { get; set; }
        public float Discount { get; set; }
        
    }
}