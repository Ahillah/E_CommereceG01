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
        public ProductWithBrandAndTypeSpec() : base(null)
        {
            AddInclude(p => p.Brand);
            AddInclude(p => p.Type);

        }
    }
}
