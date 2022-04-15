using CoffeeShop.Core.DTOs;
using MediatR;

namespace CoffeeShop.Core.Commands.Orders
{
    public class CreateOrderCommand : IRequest<OrderDTO>
    {
        public int UserId { get; set; }
    }
}
