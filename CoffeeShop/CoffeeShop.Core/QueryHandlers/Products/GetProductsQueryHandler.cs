using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Queries.Products;
using MediatR;

namespace CoffeeShop.Core.QueryHandlers.Products
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private IUnitOfWork _unitOfWork;
        public GetProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ProductRepository.GetProducts(request.Filter);
        }
    }
}
