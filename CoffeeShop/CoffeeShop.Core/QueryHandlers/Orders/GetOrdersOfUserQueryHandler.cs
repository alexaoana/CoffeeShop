using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Queries.Orders;
using MediatR;

namespace CoffeeShop.Core.QueryHandlers.Orders
{
    public class GetOrdersOfUserQueryHandler : IRequestHandler<GetOrdersOfUserQuery, IEnumerable<Order>>
    {
        private IUnitOfWork _unitOfWork;
        public GetOrdersOfUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Order>> Handle(GetOrdersOfUserQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.OrderRepository.GetOrders().Where(x => x.User == request.User);
        }
    }
}
