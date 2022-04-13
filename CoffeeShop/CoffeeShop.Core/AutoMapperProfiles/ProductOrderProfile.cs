using AutoMapper;
using CoffeeShop.Core.DTOs;

namespace CoffeeShop.Core.AutoMapperProfiles
{
    public class ProductOrderProfile : Profile
    {
        public ProductOrderProfile()
        {
            CreateMap<ProductOrder, ProductOrderDTO>();
            CreateMap<ProductOrderDTO, ProductOrder>();
        }
    }
}
