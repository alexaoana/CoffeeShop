using AutoMapper;
using CoffeeShop.Core;
using CoffeeShop.Core.DTOs;

namespace CoffeeShop.Core.AutoMapperProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
        }
    }
}
