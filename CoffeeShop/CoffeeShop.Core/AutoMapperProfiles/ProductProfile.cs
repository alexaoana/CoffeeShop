using AutoMapper;
using CoffeeShop.Core;
using CoffeeShop.Core.Domain;
using CoffeeShop.Core.DTOs;

namespace CoffeeShop.Core.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.AzurePath, opt => opt.MapFrom(src => src.Image.AzurePath));
            CreateMap<ProductDTO, Product>(); ;
        }
    }
}
