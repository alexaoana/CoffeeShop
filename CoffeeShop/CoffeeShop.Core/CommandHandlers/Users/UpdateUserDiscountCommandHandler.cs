using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Commands.Users;
using CoffeeShop.Core.Enums;
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
            var order = _unitOfWork.OrderRepository.GetOrder(request.OrderId);
            var numberOfProducts = order.NumberOfProducts;
            if (order.OrderStatus == OrderStatus.Placed)
                if (user.Discount < 1 - numberOfProducts * 0.001)
                {
                    user.Discount += numberOfProducts * 0.001;
                    _unitOfWork.UserRepository.UpdateUser(user);
                }   
                else
                {
                    user.Discount = 1;
                    _unitOfWork.UserRepository.UpdateUser(user);
                }
            if (order.OrderStatus == OrderStatus.Canceled)
                if (user.Discount > numberOfProducts * 0.001)
                {
                    user.Discount += numberOfProducts * 0.001;
                    _unitOfWork.UserRepository.UpdateUser(user);
                }
                else
                {
                    user.Discount = 0;
                    _unitOfWork.UserRepository.UpdateUser(user);
                }
            return true;
        }
    }
}
