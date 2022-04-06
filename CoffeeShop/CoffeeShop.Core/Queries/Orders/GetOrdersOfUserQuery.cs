using CoffeeShop.Core.DTOs;
using MediatR;

namespace CoffeeShop.Core.Queries.Orders
{
    public class GetOrdersOfUserQuery : IRequest<IEnumerable<OrderDTO>>
    {
        public User User { get; set; }
    }
}
