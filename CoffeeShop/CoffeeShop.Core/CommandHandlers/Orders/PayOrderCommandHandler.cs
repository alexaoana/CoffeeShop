using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.CommandHandlers.Users;
using CoffeeShop.Core.Commands.Orders;
using CoffeeShop.Core.Commands.Users;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Enums;
using CoffeeShop.Core.Queries.Orders;
using CoffeeShop.Core.QueryHandlers.Orders;
using MediatR;

namespace CoffeeShop.Core.CommandHandlers.Orders
{
    public class PayOrderCommandHandler : IRequestHandler<PayOrderCommand, bool>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public PayOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(PayOrderCommand request, CancellationToken cancellationToken)
        {
            var query = new GetOrderByIdQueryHandler(_unitOfWork, _mapper);
            var order = _mapper.Map<OrderDTO, Order>(await query.Handle(new GetOrderByIdQuery 
                { OrderId = request.OrderId }, cancellationToken));
            request.Payment.Pay(order.Price);
            order.OrderStatus = OrderStatus.Placed;
            order.Id = request.OrderId;
            _unitOfWork.OrderRepository.UpdateOrder(order);
            var command = new UpdateUserDiscountCommandHandler(_unitOfWork);
            command.Handle(new UpdateUserDiscountCommand
            {
                OrderId = request.OrderId,
                UserId = order.UserId
            }, cancellationToken);
            return true;
        }
    }
}
