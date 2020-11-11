using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Web1.Helpers.CustomValidationAttribute
{
    public class PasswordPolicyAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var password = value as string;
            if (password != null)
            {
                var regex = new Regex("^(?=.*^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]*[@#^!$%&*()][a-zA-Z0-9]*$)");
                if (!regex.IsMatch(password))
                    return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Password does not match the policy";
        }
    }
}
