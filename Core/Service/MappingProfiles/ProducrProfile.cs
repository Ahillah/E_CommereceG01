using AutoMapper;
using Domain.Models.Products;
using Shared.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MappingProfiles
{
    public class ProducrProfile:Profile
    {
        public ProducrProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(Dist => Dist.BrandName, options =>
                options.MapFrom(src => src.Brand.Name
                ))
                .ForMember(Dist => Dist.TypeName, options =>
                options.MapFrom(src => src.Type.Name
                ))
                .ForMember(src => src.PictureUrl, options => options.MapFrom<ProductResolver>());
            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductType,TypeDto>();
                
        }
    }
}
