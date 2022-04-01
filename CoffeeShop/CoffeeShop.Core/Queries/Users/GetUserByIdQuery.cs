using MediatR;


namespace CoffeeShop.Core.Queries.Users
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int UserId { get; set; }
    }
}
