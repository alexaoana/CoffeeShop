using MediatR;

namespace CoffeeShop.Core.Queries.Orders
{
    public class GetTotalPricePerOrderQuery : IRequest<decimal>
    {
        public Order Order { get; set; }
    }
}
