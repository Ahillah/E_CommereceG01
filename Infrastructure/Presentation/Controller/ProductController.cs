using Abstraction;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IServicesManager servicesManager ) :ControllerBase
    {
        [HttpGet]
        public async Task <ActionResult<IEnumerable<ProductDto>>> GetAllProducts(int? brandId, int? typeId,ProductSortingOptions sortingOption)
        {
            var Products = await servicesManager.ProductServices.GetAllProductsAsync(brandId, typeId, sortingOption);
            return Ok(Products);


        }
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
        {
            var Brands = await servicesManager.ProductServices.GetAllBrandsAsync();
            return Ok(Brands);


        }
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllTypes()
        {
            var Types = await servicesManager.ProductServices.GetAllTypesAsync();
            return Ok(Types);


        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product= await servicesManager.ProductServices.GetProductByIdAsync(id);
            return Ok(product);


        }


    }
}
