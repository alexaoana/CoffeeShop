using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Queries.Addresses;
using MediatR;

namespace CoffeeShop.Core.QueryHandlers.Addresses
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, Address>
    {
        private IUnitOfWork _unitOfWork;
        public GetAddressByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Address> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.AddressRepository
                .GetAddress(request.Id);
        }
    }
}
