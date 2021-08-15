using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using F = SR_MVC.Models.Forms;

namespace SR_MVC.Infrastructure.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateTimeRangeAttribute : ValidationAttribute
    {
        private readonly DateTime _today;
        public DateTimeRangeAttribute()
        {
            _today = DateTime.Now.Date;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value is not DateTime)
                return new ValidationResult("Date format is not valid.");

            if (!IsValid((DateTime)value))
                return new ValidationResult("Chosen date is in the past.");

            if(value.ToString().Count() != 19)
                return new ValidationResult("Not a valid date. Choose a different one.");

            return ValidationResult.Success;
        }
        private bool IsValid(DateTime value)
        {
            value = value.Date;
            return value >= _today;
        }
 
    }
}
