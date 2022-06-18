using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estates2.ViewModels
{
    public class ValidateDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var date = (DateTime)value;
                if (date.Year > 1900 && date < DateTime.Now)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Please enter a valid date.");
        }
    }
}