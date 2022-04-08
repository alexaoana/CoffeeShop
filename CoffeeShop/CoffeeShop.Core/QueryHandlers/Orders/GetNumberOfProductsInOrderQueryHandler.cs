using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Queries.Orders;
using MediatR;

namespace CoffeeShop.Core.QueryHandlers.Orders
{
    public class GetNumberOfProductsInOrderQueryHandler : IRequestHandler<GetNumberOfProductsInOrderQuery, int>
    {
        private IUnitOfWork _unitOfWork;
        public GetNumberOfProductsInOrderQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(GetNumberOfProductsInOrderQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.OrderRepository
                .GetOrder(request.OrderId).ProductOrders
                .Sum(x => x.Quantity);
        }
    }
}
