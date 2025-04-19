using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.API.Application.Contracts.Query;
using Catalog.API.Application.Models;
using Catalog.API.Application.Models.Paging;
using Catalog.API.Domain.ProductAggregate;
using Catalog.API.Models.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductRepository _repository;
        private readonly IProductQuery _query;
        private readonly IMapper _mapper;

        public ProductsController(
            ILogger<ProductsController> logger,
            IProductRepository repository,
            IProductQuery query,
            IMapper mapper
        )
        {
            _logger = logger;
            _repository = repository;
            _query = query;
            _mapper = mapper;
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int productId)
        {
            var product = await _repository.GetProductByIdAsync(productId);

            if (product is null)
            {
                return NotFound($"Product Id [{productId}] is not found !!!");
            }

            //? Domain Object --> DTO
            var productDto = _mapper.Map<ProductDTO>(product);

            return Ok(productDto);
        }

        [HttpPost("addProduct")]
        public async Task<ActionResult<ProductDTO>> AddProductAsync(
            [FromBody] ProductForAddDTO productForAddDTO
        )
        {
            var product = _mapper.Map<Product>(productForAddDTO);

            if (product is null)
            {
                return BadRequest($"Can't add null product.");
            }

            await _repository.AddProductAsync(product);

            var productDto = _mapper.Map<ProductDTO>(product);

            return Ok(productDto);
        }

        [HttpPut("{productId}")]
        public async Task<ActionResult<ProductDTO>> UpdateProductAsync(
            [FromRoute] int productId,
            [FromBody] ProductForUpdateDTO productForUpdateDTO
        )
        {
            var product = await _repository.GetProductByIdAsync(productId);

            if (product is null)
            {
                return BadRequest($"Can't update null product.");
            }

            _mapper.Map(productForUpdateDTO, product);

            await _repository.UpdateProductAsync(product);

            var productDto = _mapper.Map<ProductDTO>(product);

            return Ok(productDto);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] int productId)
        {
            var product = await _repository.GetProductByIdAsync(productId);

            if (product is null)
            {
                return BadRequest($"Can't update null product.");
            }

            //? Query Logic

            await _repository.DeleteProductAsync(product);

            return Ok();
        }

        [HttpGet("query/byminprice")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsByMinPriceIdAsync(
            [FromQuery] int minPrice
        )
        {
            var products = await _query.GetProductsByMinPriceAsync(minPrice);

            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(productDTOs);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> FilterProductsAsync(
            [FromQuery] ProductFilterDTO filterDTO
        )
        {
            var queryData = new QueryData();
            queryData.Paging = new PagingParam
            {
                PageSize = filterDTO.PageSize.Value,
                PageIndex = filterDTO.PageIndex.Value,
            };

            queryData.Sort = filterDTO.Sort;

            var products = await _query.FilterProductsAsync(filterDTO.Filter, queryData);

            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(productDTOs);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> SearchProductsAsync(
            [FromQuery] ProductSearchDTO searchDTO
        )
        {
            var queryData = new QueryData();
            queryData.Paging = new PagingParam
            {
                PageSize = searchDTO.PageSize.Value,
                PageIndex = searchDTO.PageIndex.Value,
            };

            queryData.Sort = searchDTO.Sort;

            var products = await _query.SearchProductsAsync(searchDTO.SearchText, queryData);

            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(productDTOs);
        }
    }
}
