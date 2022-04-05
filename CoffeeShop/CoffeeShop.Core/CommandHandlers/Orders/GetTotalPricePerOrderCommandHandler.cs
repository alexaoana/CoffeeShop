using CoffeeShop.Core.Commands.Orders;
using MediatR;

namespace CoffeeShop.Core.CommandHandlers.Orders
{
    public class GetTotalPricePerOrderCommandHandler : IRequestHandler<GetTotalPricePerOrderCommand, decimal>
    {
        public async Task<decimal> Handle(GetTotalPricePerOrderCommand request, CancellationToken cancellationToken)
        {
            decimal totalPrice = 0;
            foreach (var productOrder in request.Order.ProductOrders)
                totalPrice = totalPrice + productOrder.Product.Price;
            return totalPrice;
        }
    }
}
