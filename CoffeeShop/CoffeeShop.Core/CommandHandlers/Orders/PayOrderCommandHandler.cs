using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Commands.Orders;
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
            decimal price = 0;
            foreach (var productOrder in request.Order.ProductOrders)
                price += productOrder.Product.Price;
            request.Payment.Pay(price);
            request.Order.OrderStatus = OrderStatus.Placed;
            _unitOfWork.OrderRepository.UpdateOrder(request.Order);
            return true;
        }
    }
}
