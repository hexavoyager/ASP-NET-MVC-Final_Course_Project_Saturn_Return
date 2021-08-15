using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SR_MVC.Infrastructure.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateTimeRangeAttribute : ValidationAttribute
    {
        private readonly DateTime _startDate;

        public DateTimeRangeAttribute()
        {
            _startDate = DateTime.Now.Date;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            int Count = value.ToString().Count();

            if (value is not DateTime)
                return new ValidationResult("Not a valid date. Choose a different one.");

            if (!IsValid((DateTime)value))
                return new ValidationResult("Not a valid date. Choose a different one.");

            if(value.ToString().Count() != 19)
                return new ValidationResult("Not a valid date. Choose a different one.");

            return ValidationResult.Success;
        }
        private bool IsValid(DateTime value)
        {
            value = value.Date;
            return value >= _startDate;
        }

        
    }
}
