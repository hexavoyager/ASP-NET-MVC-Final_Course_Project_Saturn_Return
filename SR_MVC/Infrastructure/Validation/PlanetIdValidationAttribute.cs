using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SR_BLL.Data;
using SR_BLL.Repos;


namespace SR_MVC.Infrastructure.Validation
{
    public class PlanetIdValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int planetId = (int)value;

            IPlanetRepo planetService = (IPlanetRepo)validationContext.GetService(typeof(IPlanetRepo));

            Planet planet = planetService.Get().Where(c => c.Id == planetId).SingleOrDefault();

            if (planet is null)
            {
                return new ValidationResult("This planet is not part of our journey.");
            }

            return ValidationResult.Success;
        }
    }
}
