using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Validation.ProductValidators
{
    public class ProductNameValidator : ValidationAttribute
    {
        public ProductNameValidator()
        {
            ErrorMessage = "Custom Error Message For Name";
        }

        public override bool IsValid(object? value)
        {
            //? Custom Logic

            if (value is not string str || string.IsNullOrWhiteSpace(str))
            {
                return true;
            }

            return str.All(char.IsLetter);
        }
    }
}
