using MediatR;

namespace CoffeeShop.Core.Queries.Orders
{
    public class GetOrdersOfUserQuery : IRequest<IEnumerable<Order>>
    {
        public User User { get; set; }
    }
}
