using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Commands.Users;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.CommandHandlers.Orders
{
    public class GetCurrentOrderOfUserCommandHandler : IRequestHandler<GetCurrentOrderOfUserCommand, OrderDTO>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetCurrentOrderOfUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDTO> Handle(GetCurrentOrderOfUserCommand request, CancellationToken cancellationToken)
        {
            var order = _unitOfWork.OrderRepository.GetOrders()
                .Where(x => x.UserId == request.UserId)
                .Where(x => x.OrderStatus == OrderStatus.InProgress)
                .FirstOrDefault();
            return _mapper.Map<Order, OrderDTO>(order);
        }
    }
}
