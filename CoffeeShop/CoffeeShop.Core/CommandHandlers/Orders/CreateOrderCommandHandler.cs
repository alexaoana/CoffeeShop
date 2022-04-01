using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Commands.Orders;
using CoffeeShop.Core.Enums;
using MediatR;

namespace CoffeeShop.Core.CommandHandlers.Orders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private IUnitOfWork _unitOfWork;
        public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                User = request.User,
                OrderStatus = OrderStatus.InProgress
            };
            _unitOfWork.OrderRepository.AddOrder(order);
            return true;
        }
    }
}
