using Abstraction;
using AutoMapper;
using Domain.Contruct;
using Domain.Models.Products;
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

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var Repository = unitOfWork.GetRepository<Product, int>();
            var Products = await Repository.GetAllAsync();
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
        {
          var Product =await unitOfWork.GetRepository<Product,int>().GetByIdAsync(id);
            var MappedProduct =mapper.Map<Product,ProductDto>(Product);
            return MappedProduct;
        }
    }
}
