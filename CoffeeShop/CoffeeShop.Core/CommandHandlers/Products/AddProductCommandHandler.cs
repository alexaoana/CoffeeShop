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
            var product = new Product()
            {
                Description = request.Description,
                Name = request.Name,
                Image = request.Image,
                Price = request.Price,
                CoffeeIntensity = request.CoffeeIntensity,
                Amount = request.Amount,
                ProductUnit = request.ProductUnit
            };
            _unitOfWork.ProductRepository.AddProduct(product);
            return true;
        }
    }
}
