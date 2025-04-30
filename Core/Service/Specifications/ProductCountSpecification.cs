using Domain.Models.Products;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    public class ProductCountSpecification:BaseSpecifications<Product,int>
    {
          public ProductCountSpecification(ProductQueryParms QueryParam) :
            base(p => (!QueryParam.BrandId.HasValue || p.BrandId == QueryParam.BrandId)
            && (!QueryParam.TypeId.HasValue || p.TypeId == QueryParam.TypeId)
            && (string.IsNullOrEmpty(QueryParam.SearchValue) || p.Name.ToLower().Contains(QueryParam.SearchValue.ToLower())))
        {
          
         
        }
    }
}
