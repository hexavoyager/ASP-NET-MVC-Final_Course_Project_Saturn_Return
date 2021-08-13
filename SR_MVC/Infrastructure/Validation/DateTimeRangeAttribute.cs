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
            if (value is not DateTime)
                return new ValidationResult($"the value of the property '{validationContext.MemberName}' must be a Date");

            if (!IsValid((DateTime)value))
                return new ValidationResult($"the value of the property '{validationContext.MemberName}' is'nt in Range");

            return ValidationResult.Success;
        }
        private bool IsValid(DateTime value)
        {
            return value >= _startDate;
        }
    }
}
