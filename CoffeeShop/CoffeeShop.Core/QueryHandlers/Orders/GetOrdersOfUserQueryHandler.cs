using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Queries.Orders;
using MediatR;

namespace CoffeeShop.Core.QueryHandlers.Orders
{
    public class GetOrdersOfUserQueryHandler : IRequestHandler<GetOrdersOfUserQuery, IEnumerable<OrderDTO>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetOrdersOfUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OrderDTO>> Handle(GetOrdersOfUserQuery request, CancellationToken cancellationToken)
        {
            var orders = _unitOfWork.OrderRepository.GetOrders().Where(x => x.User == request.User);
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(orders);
        }
    }
}
