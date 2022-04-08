using MediatR;

namespace CoffeeShop.Core.Queries.Orders
{
    public class GetNumberOfProductsInOrderQuery : IRequest<int>
    {
        public int OrderId { get; set; }
    }
}
