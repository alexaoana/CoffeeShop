using MediatR;

namespace CoffeeShop.Core.Commands.Users
{
    public class UpdateUserDiscountCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
    }
}
