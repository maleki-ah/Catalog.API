using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.API.Domain.ProductAggregate;
using Catalog.API.Models.DTOs.ProductDTOs;

namespace Catalog.API.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductForAddDTO, Product>();
            CreateMap<ProductForUpdateDTO, Product>();
        }
    }
}
