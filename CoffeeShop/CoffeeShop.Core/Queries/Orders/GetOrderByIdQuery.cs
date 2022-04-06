using CoffeeShop.Core.DTOs;
using MediatR;

namespace CoffeeShop.Core.Queries.Orders
{
    public class GetOrderByIdQuery : IRequest<OrderDTO>
    {
        public int OrderId { get; set; }
    }
}
