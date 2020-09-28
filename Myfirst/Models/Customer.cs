using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Myfirst.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name="Customer Name")]
        [Required(ErrorMessage ="Please Enter the name of Customer")]
        [StringLength(100)]
        public String Name { get; set; }

        [Display(Name="Date Of Birth")]
        [Required(ErrorMessage ="Please provide Date Of Birth")]
        public DateTime DateofBirth { get; set; }

        [Display(Name="Customer Address")]
        [Required(ErrorMessage ="Please Enter the Address")]
        [StringLength(100)]
        public string Address { get; set; }
        [Display(Name = "Gender")]
        [Required]

        public string Gender { get; set; }
        public Membership Membership { get; set; }
        [Display(Name="Membership")]
        [Required]
        public int MembershipId { get; set; }
    }
}