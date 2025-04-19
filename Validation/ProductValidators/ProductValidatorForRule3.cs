using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Models.DTOs.ProductDTOs;

namespace Catalog.API.Validation.ProductValidators
{
    public class ProductValidatorForRule3 : ValidationAttribute
    {
        public ProductValidatorForRule3()
        {
            ErrorMessage = "Custom Error Message For Rule3";
        }

        public override bool IsValid(object? value)
        {
            //? Custom Logic

            if (value is null)
            {
                return true;
            }

            var product = value as ProductForUpdateDTO;

            //! Rule 1
            if (
                product?.Name?.Equals("phone", StringComparison.OrdinalIgnoreCase) == true
                && product?.Price == 600
            )
                return false;

            return true;
        }
    }
}
