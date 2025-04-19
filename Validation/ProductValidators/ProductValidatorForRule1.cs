using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Models.DTOs.ProductDTOs;

namespace Catalog.API.Validation.ProductValidators
{
    public class ProductValidatorForRule1 : ValidationAttribute
    {
        public ProductValidatorForRule1()
        {
            ErrorMessage = "Custom Error Message For Rule1";
        }

        public override bool IsValid(object? value)
        {
            //? Custom Logic

            if (value is null)
            {
                return true;
            }

            var product = value as ProductForAddDTO;

            //! Rule 1
            if (
                product?.Name?.Equals("phone", StringComparison.OrdinalIgnoreCase) == true
                && product?.Price == 500
            )
                return false;

            return true;
        }
    }
}
