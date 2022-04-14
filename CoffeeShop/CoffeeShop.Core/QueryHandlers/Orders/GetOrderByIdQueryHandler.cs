using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Queries.Orders;
using MediatR;

namespace CoffeeShop.Core.QueryHandlers.Orders
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDTO>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetOrderByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OrderDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = _unitOfWork.OrderRepository
                .GetOrder(request.OrderId);
            return _mapper.Map<Order, OrderDTO>(order);
        }
    }
}
