using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Commands.Users;
using CoffeeShop.Core.Queries.Orders;
using CoffeeShop.Core.QueryHandlers.Orders;
using MediatR;

namespace CoffeeShop.Core.CommandHandlers.Users
{
    public class UpdateUserDiscountCommandHandler : IRequestHandler<UpdateUserDiscountCommand, bool>
    {
        private IUnitOfWork _unitOfWork;
        public UpdateUserDiscountCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateUserDiscountCommand request, CancellationToken cancellationToken)
        {
            var user = _unitOfWork.UserRepository.GetUser(request.UserId);
            var getNumberOfProductsInOrderQuery = new GetNumberOfProductsInOrderQuery
            {
                OrderId = request.OrderId,
            };
            var getNumberOfProductsInOrderQueryHandler = new GetNumberOfProductsInOrderQueryHandler(_unitOfWork);
            var numberOfProducts = await getNumberOfProductsInOrderQueryHandler.Handle(getNumberOfProductsInOrderQuery, new CancellationToken());
            user.Discount += numberOfProducts * decimal.Parse("0.001");
            _unitOfWork.UserRepository.UpdateUser(user);
            return true;
        }
    }
}
