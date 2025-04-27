using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    public class ProductWithBrandAndTypeSpec : BaseSpecifications<Product, int>
    {
        public ProductWithBrandAndTypeSpec(int? brandId, int? typeId) : base(p=> (!brandId.HasValue|| p.BrandId==brandId) &&(!typeId.HasValue||p.TypeId==typeId))
        {
            AddInclude(p => p.Brand);
            AddInclude(p => p.Type);


        }

        public ProductWithBrandAndTypeSpec(int id) : base(p=>p.Id==id)
        {
            AddInclude(p => p.Brand);
            AddInclude(p => p.Type);

        }

    }
}
