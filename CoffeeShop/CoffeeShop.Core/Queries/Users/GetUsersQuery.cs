using CoffeeShop.Core.DTOs;
using MediatR;

namespace CoffeeShop.Core.Queries.Users
{
    public class GetUsersQuery : IRequest<IEnumerable<UserDTO>>
    {

    }
}
