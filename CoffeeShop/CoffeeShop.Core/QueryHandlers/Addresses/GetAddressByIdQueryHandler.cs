using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Queries.Addresses;
using MediatR;
using CoffeeShop.Core.DTOs;

namespace CoffeeShop.Core.QueryHandlers.Addresses
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, AddressDTO>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetAddressByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AddressDTO> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<Address, AddressDTO>(_unitOfWork.AddressRepository
                .GetAddress(request.AddressId));
        }
    }
}
