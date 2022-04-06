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
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.TotalPrice, act => act.MapFrom(src => GetTotalPrice(src)));
        }

        private async Task<decimal> GetTotalPrice(Order order)
        {
            var totalPricePerOrderQuery = new GetTotalPricePerOrderQuery
            {
                Order = order
            };
            var totalPricePerOrderQueryHandler = new GetTotalPricePerOrderQueryHandler();
            decimal totalPrice = await totalPricePerOrderQueryHandler.Handle(totalPricePerOrderQuery, new CancellationToken());
            return totalPrice;
        }
    }
}
