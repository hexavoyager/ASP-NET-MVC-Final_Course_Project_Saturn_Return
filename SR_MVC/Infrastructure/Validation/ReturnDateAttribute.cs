using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SR_MVC.Infrastructure.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ReturnDateAttribute : ValidationAttribute
    {
        private readonly string _otherPropertyName;

        public ReturnDateAttribute(string otherPropertyName)
        {
            _otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not DateTime)
                throw new InvalidOperationException("Please input a valid date.");

            DateTime endDate = (DateTime)value;

            if (validationContext.ObjectInstance is null)
                throw new InvalidOperationException("The property can't be static.");

            Type objectType = validationContext.ObjectType;

            PropertyInfo otherPropertyInfo = objectType.GetProperty(_otherPropertyName);

            if (otherPropertyInfo is null)
                    throw new InvalidOperationException($"The property doesn't exist.");

            object otherValue = otherPropertyInfo.GetMethod.Invoke(validationContext.ObjectInstance, null);

            if (otherValue is not DateTime)
                throw new InvalidOperationException("Please use a valid date format.");

            DateTime startDate = (DateTime)otherValue;

            if (endDate > startDate)
                return ValidationResult.Success;
            else
                return new ValidationResult($"The return date must be at least a day after the departure date.");

        }
    }
}