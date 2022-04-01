using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Queries.Orders;
using MediatR;

namespace CoffeeShop.Core.QueryHandlers.Orders
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private IUnitOfWork _unitOfWork;
        public GetOrderByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.OrderRepository.GetOrder(request.OrderId);
        }
    }
}
