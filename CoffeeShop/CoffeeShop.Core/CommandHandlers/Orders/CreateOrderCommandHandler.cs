using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Commands.Orders;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Enums;
using MediatR;

namespace CoffeeShop.Core.CommandHandlers.Orders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDTO>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OrderDTO> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order();
            order.User = request.User;
            _unitOfWork.OrderRepository.AddOrder(order);
            return _mapper.Map<Order, OrderDTO>(order);
        }
    }
}
