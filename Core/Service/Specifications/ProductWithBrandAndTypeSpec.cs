using Domain.Models.Products;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    public class ProductWithBrandAndTypeSpec : BaseSpecifications<Product, int>
    {
        public ProductWithBrandAndTypeSpec(int? brandId, int? typeId, ProductSortingOptions? sortingOptions) : base(p=> (!brandId.HasValue|| p.BrandId==brandId) &&(!typeId.HasValue||p.TypeId==typeId))
        {
            AddInclude(p => p.Brand);
            AddInclude(p => p.Type);

            switch(sortingOptions)
            {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;
                    case ProductSortingOptions.NameDesc:
                    AddOrderByDes(p => p.Name);
                    break;
                    case ProductSortingOptions.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                    case ProductSortingOptions.PriceDesc:
                    AddOrderByDes(p => p.Price);
                    break;
                    default:
                    break;
            }
        }

        public ProductWithBrandAndTypeSpec(int id) : base(p=>p.Id==id)
        {
            AddInclude(p => p.Brand);
            AddInclude(p => p.Type);

        }

    }
}
