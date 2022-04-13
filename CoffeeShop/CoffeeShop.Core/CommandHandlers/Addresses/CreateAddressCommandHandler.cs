using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Commands.Addresses;
using CoffeeShop.Core.DTOs;
using MediatR;

namespace CoffeeShop.Core.CommandHandlers.Addresses
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, AddressDTO>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CreateAddressCommandHandler(IUnitOfWork unitOfWortk, IMapper mapper)
        {
            _unitOfWork = unitOfWortk;
            _mapper = mapper;
        }

        public async Task<AddressDTO> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.City, request.Street, request.Number);
            address.User = request.User;
            _unitOfWork.AddressRepository.AddAddress(address);
            return _mapper.Map<Address, AddressDTO>(address);
        }
    }
}
