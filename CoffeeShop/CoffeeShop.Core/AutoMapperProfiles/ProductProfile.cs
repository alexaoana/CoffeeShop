using AutoMapper;
using CoffeeShop.Core.DTOs;

namespace CoffeeShop.Core.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}
