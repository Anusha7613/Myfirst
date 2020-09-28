using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Myfirst.Models.CustomAttributes
{
    public class CustomDateOfBirth:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt=Convert.ToDateTime(value);
            int age=DateTime.Now.Year-dt.Year;
            if (value == null)
            {
                return new ValidationResult("Date of Birth can't be null");
            }
            if (age<18)
            {
                
                
                return new ValidationResult("Age should not be greater than 18 ");
            }
            else
            {
                return ValidationResult.Success;
            }
        }

    }
}