using Abstraction;
using AutoMapper;
using Domain.Contruct;
using Domain.Models.Products;
using Service.Specifications;
using Shared;
using Shared.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductServices (IUnitOfWork unitOfWork, IMapper mapper) : IProductServices
    {
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
           var Repository =unitOfWork.GetRepository<ProductBrand, int>();
          
            var Brands = await Repository.GetAllAsync();
            var MappedBrands = mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandDto>>(Brands);
            return MappedBrands;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(ProductQueryParms QueryParam)
        { var Repository = unitOfWork.GetRepository<Product, int>();
            var spec = new ProductWithBrandAndTypeSpec(QueryParam);
            var Products = await Repository.GetAllAsync(spec);
            var MappedProducts = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products);
            return MappedProducts;
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {

            var Repository = unitOfWork.GetRepository<ProductType, int>();
            var Types = await Repository.GetAllAsync();
            var MappedTypes = mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Types);
            return MappedTypes;

        }   

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {  var spec= new ProductWithBrandAndTypeSpec(id);
          var Product =await unitOfWork.GetRepository<Product,int>().GetByIdAsync(spec);
            var MappedProduct =mapper.Map<Product,ProductDto>(Product);
            return MappedProduct;
        }
    }
}
