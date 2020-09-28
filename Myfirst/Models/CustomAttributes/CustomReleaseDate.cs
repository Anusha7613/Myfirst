using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Myfirst.Models.CustomAttributes
{
    public class CustomReleaseDate:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt = Convert.ToDateTime(value);
            if (value == null)
            {
                return new ValidationResult("Release Date is required");
            }
            if (dt > DateTime.Now)
            {
                return new ValidationResult("Release Date Can't be greater than today's date");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}