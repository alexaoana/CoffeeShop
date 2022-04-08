using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Commands.Products;
using MediatR;

namespace CoffeeShop.Core.CommandHandlers.Products
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, bool>
    {
        private IUnitOfWork _unitOfWork;
        public AddProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.ProductRepository.AddProduct(new Product(request.Name, request.Description, 
                request.Amount, request.Price, request.ProductUnit, request.Image, request.CoffeeIntensity));
            return true;
        }
    }
}
