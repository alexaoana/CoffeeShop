using AutoMapper;
using CoffeeShop.Core.DTOs;

namespace CoffeeShop.Core.AutoMapperProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>()
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.NumberOfProducts, y => y.MapFrom(z => z.NumberOfProducts));
            CreateMap<OrderDTO, Order>();
        }
    }
}
