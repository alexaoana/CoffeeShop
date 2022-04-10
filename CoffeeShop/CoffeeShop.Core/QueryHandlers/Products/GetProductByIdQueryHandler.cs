using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Queries.Products;
using MediatR;

namespace CoffeeShop.Core.QueryHandlers.Products
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductQuery, ProductDTO>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<Product, ProductDTO>(_unitOfWork.ProductRepository
                .GetProduct(request.Id));
        }
    }
}
