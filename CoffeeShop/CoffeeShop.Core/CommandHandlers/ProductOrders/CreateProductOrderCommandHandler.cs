using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.CommandHandlers.Products;
using CoffeeShop.Core.Commands.ProductOrders;
using CoffeeShop.Core.Commands.Products;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Queries.Products;
using CoffeeShop.Core.QueryHandlers.Products;
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
            var query = new GetProductByIdQueryHandler(_unitOfWork, _mapper);
            var product = _mapper.Map<ProductDTO, Product>(await query.Handle(new GetProductByIdQuery
            {
                ProductId = request.ProductId,
            }, cancellationToken));
            var productOrder = new ProductOrder(request.Quantity, product);
            productOrder.ProductId = request.ProductId;
            productOrder.OrderId = request.OrderId;
            var command = new CreateCustomProductCommandHandler(_mapper);
            var result = await command.Handle(new CreateCustomProductCommand
            {
                Product = productOrder,
                Ingredients = request.Ingredients,
            }, cancellationToken);
            _unitOfWork.ProductOrderRepository.AddProductOrder(_mapper.Map<ProductOrderDTO, ProductOrder>(result));
            return result;
        }
    }
}
