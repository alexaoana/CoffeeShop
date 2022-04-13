using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.CommandHandlers.Users;
using CoffeeShop.Core.Commands.Orders;
using CoffeeShop.Core.Commands.Users;
using CoffeeShop.Core.Enums;
using MediatR;

namespace CoffeeShop.Core.CommandHandlers.Orders
{
    public class PayOrderCommandHandler : IRequestHandler<PayOrderCommand, bool>
    {
        private IUnitOfWork _unitOfWork;
        public PayOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(PayOrderCommand request, CancellationToken cancellationToken)
        {
            request.Payment.Pay(request.Order.Price);
            request.Order.OrderStatus = OrderStatus.Placed;
            _unitOfWork.OrderRepository.UpdateOrder(request.Order);
            var command = new UpdateUserDiscountCommandHandler(_unitOfWork);
            command.Handle(new UpdateUserDiscountCommand
            {
                OrderId = request.Order.Id,
                UserId = request.Order.UserId
            }, cancellationToken);
            return true;
        }
    }
}
