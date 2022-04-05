using CoffeeShop.Core.Queries.Orders;
using MediatR;

namespace CoffeeShop.Core.QueryHandlers.Orders
{
    public class GetTotalPricePerOrderQueryHandler : IRequestHandler<GetTotalPricePerOrderQuery, decimal>
    {
        public async Task<decimal> Handle(GetTotalPricePerOrderQuery request, CancellationToken cancellationToken)
        {
            decimal totalPrice = 0;
            foreach (var productOrder in request.Order.ProductOrders)
                totalPrice = totalPrice + productOrder.Product.Price;
            return totalPrice;
        }
    }
}
