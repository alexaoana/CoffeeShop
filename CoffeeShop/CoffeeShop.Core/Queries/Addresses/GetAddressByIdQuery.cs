using CoffeeShop.Core.DTOs;
using MediatR;

namespace CoffeeShop.Core.Queries.Addresses
{
    public class GetAddressByIdQuery : IRequest<AddressDTO>
    {
        public int AddressId { get; set; }
    }
}
