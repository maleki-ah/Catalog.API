using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Validation.ProductValidators;

namespace Catalog.API.Models.DTOs.ProductDTOs
{
    [ProductValidatorForRule1]
    [ProductValidatorForRule2]
    public class ProductForAddDTO
    {
        [Required(ErrorMessage = "ورود نام اجباری است.")]
        [StringLength(100, MinimumLength = 3)]
        [ProductNameValidator]
        public required string Name { get; set; }

        [Required]
        [Range(10, 10000)]
        public required int Price { get; set; }
        public string? Description { get; set; }
    }
}
