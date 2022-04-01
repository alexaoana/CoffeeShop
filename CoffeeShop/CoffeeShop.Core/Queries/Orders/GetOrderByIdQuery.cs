using MediatR;

namespace CoffeeShop.Core.Queries.Orders
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public int OrderId { get; set; }
    }
}
