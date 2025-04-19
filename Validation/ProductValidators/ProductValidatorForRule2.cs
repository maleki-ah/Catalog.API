using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Models.DTOs.ProductDTOs;

namespace Catalog.API.Validation.ProductValidators
{
    public class ProductValidatorForRule2 : ValidationAttribute
    {
        public ProductValidatorForRule2()
        {
            ErrorMessage = "Custom Error Message For Rule2";
        }

        public override bool IsValid(object? value)
        {
            //? Custom Logic

            if (value is null)
            {
                return true;
            }

            var product = value as ProductForAddDTO;

            //! Rule 2
            if (
                product?.Name?.Equals("laptop", StringComparison.OrdinalIgnoreCase) == true
                && product?.Price == 1500
            )
                return false;

            return true;
        }
    }
}
