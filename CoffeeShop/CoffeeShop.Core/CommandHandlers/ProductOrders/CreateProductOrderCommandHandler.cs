using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Commands.ProductOrders;
using MediatR;

namespace CoffeeShop.Core.CommandHandlers.ProductOrders
{
    public class CreateProductOrderCommandHandler : IRequestHandler<CreateProductOrderCommand, bool>
    {
        private IUnitOfWork _unitOfWork;
        public CreateProductOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CreateProductOrderCommand request, CancellationToken cancellationToken)
        {
            var productOrder = new ProductOrder
            {
                Product = request.Product,
                Order = request.Order,
                Quantity = request.Quantity
            };
            _unitOfWork.ProductOrderRepository.AddProductOrder(productOrder);
            return true;
        }
    }
}
