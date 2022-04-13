using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Queries.ProductOrders;
using MediatR;

namespace CoffeeShop.Core.QueryHandlers.ProductOrders
{
    public class GetProductOrderByIdQueryHandler : IRequestHandler<GetProductOrderByIdQuery, ProductOrderDTO>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetProductOrderByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ProductOrderDTO> Handle(GetProductOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ProductOrder, ProductOrderDTO>(_unitOfWork.ProductOrderRepository
                .GetProductOrder(request.ProductOrderId));
        }
    }
}
