using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web1.Data;

namespace Web1.Helpers.CustomValidationAttribute
{
    public class UsernameUniqueAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(
         object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var _context = (DataContext)validationContext.GetService(typeof(DataContext));
                var entity = _context.Employees.SingleOrDefault(e => e.Email == value.ToString() || e.Username == value.ToString());

                if (entity != null)
                {
                    return new ValidationResult(GetErrorMessage(value.ToString()));
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage(string userName)
        {
            return $"Username {userName} is already in use.";
        }

    }
}
