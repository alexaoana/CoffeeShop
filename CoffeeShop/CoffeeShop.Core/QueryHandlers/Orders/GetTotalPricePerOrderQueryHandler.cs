using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Queries.Orders;
using MediatR;

namespace CoffeeShop.Core.QueryHandlers.Orders
{
    public class GetTotalPricePerOrderQueryHandler : IRequestHandler<GetTotalPricePerOrderQuery, decimal>
    {
        private IUnitOfWork _unitOfWork;
        public GetTotalPricePerOrderQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<decimal> Handle(GetTotalPricePerOrderQuery request, CancellationToken cancellationToken)
        {
            var order = _unitOfWork.OrderRepository
                .GetOrder(request.OrderId);
            decimal totalPrice = order.ProductOrders
                .Sum(x => x.Product.Price);
            return totalPrice * (1 - order.User.Discount);
        }
    }
}
