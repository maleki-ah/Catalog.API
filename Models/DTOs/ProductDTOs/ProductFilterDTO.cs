using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Application.Models.Paging;

namespace Catalog.API.Models.DTOs.ProductDTOs
{
    public class ProductFilterDTO
    {
        public ProductFilterDTO()
        {
            PageIndex = 1;
            PageSize = PagingParam.DefaultPageSize;
        }

        public string? Filter { get; set; }
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
        public string? Sort { get; set; }
    }
}
