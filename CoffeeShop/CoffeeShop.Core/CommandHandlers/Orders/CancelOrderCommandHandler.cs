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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.CommandHandlers.Orders
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, OrderDTO>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CancelOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDTO> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var query = new GetOrderByIdQueryHandler(_unitOfWork, _mapper);
            var order = _mapper.Map<OrderDTO, Order>(await query.Handle(new GetOrderByIdQuery
            { OrderId = request.OrderId }, cancellationToken));
            order.OrderStatus = OrderStatus.Canceled;
            order.Id = request.OrderId;
            _unitOfWork.OrderRepository.UpdateOrder(order);
            var command = new UpdateUserDiscountCommandHandler(_unitOfWork);
            command.Handle(new UpdateUserDiscountCommand
            {
                OrderId = request.OrderId,
                UserId = order.UserId
            }, cancellationToken);
            return _mapper.Map<Order, OrderDTO>(order);
        }
    }
}
