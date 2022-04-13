using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Commands.ProductOrders;
using CoffeeShop.Core.DTOs;
using MediatR;

namespace CoffeeShop.Core.CommandHandlers.ProductOrders
{
    public class CreateProductOrderCommandHandler : IRequestHandler<CreateProductOrderCommand, ProductOrderDTO>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CreateProductOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProductOrderDTO> Handle(CreateProductOrderCommand request, CancellationToken cancellationToken)
        {
            var productOrder = new ProductOrder(request.Quantity);
            productOrder.Product = request.Product;
            productOrder.Order = request.Order;
            _unitOfWork.ProductOrderRepository.AddProductOrder(productOrder);
            return _mapper.Map<ProductOrder, ProductOrderDTO>(productOrder);
        }
    }
}
