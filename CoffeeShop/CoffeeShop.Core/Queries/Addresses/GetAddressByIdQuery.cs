using CoffeeShop.Core.DTOs;
using MediatR;

namespace CoffeeShop.Core.Queries.Addresses
{
    public class GetAddressByIdQuery : IRequest<Address>
    {
        public int Id { get; set; }
    }
}
