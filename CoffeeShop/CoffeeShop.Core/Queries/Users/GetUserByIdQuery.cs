using CoffeeShop.Core.DTOs;
using MediatR;


namespace CoffeeShop.Core.Queries.Users
{
    public class GetUserByIdQuery : IRequest<UserDTO>
    {
        public int UserId { get; set; }
    }
}
