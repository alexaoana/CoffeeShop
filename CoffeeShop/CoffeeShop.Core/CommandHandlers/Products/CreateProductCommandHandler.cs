using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Commands.Products;
using CoffeeShop.Core.DTOs;
using MediatR;

namespace CoffeeShop.Core.CommandHandlers.Products
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDTO>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Amount, 
                request.Price, request.ProductUnit, request.CoffeeIntensity);
            _unitOfWork.ProductRepository.AddProduct(product);
            return _mapper.Map<Product, ProductDTO>(product);
        }
    }
}
