using AutoMapper;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Queries.Orders;
using CoffeeShop.Core.QueryHandlers.Orders;

namespace CoffeeShop.Core.AutoMapperProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>();
        }
    }
}
