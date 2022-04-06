using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Queries.Products;
using MediatR;

namespace CoffeeShop.Core.QueryHandlers.Products
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDTO>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _unitOfWork.ProductRepository.GetProducts(request.Filter);
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
        }
    }
}
