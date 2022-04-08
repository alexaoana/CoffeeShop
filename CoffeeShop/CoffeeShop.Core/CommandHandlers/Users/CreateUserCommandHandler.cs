using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Commands.Users;
using MediatR;

namespace CoffeeShop.Core.CommandHandlers.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private IUnitOfWork _unitOfWork;
        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.FirstName, request.LastName,
                request.Email, request.Password);
            user.Address = request.Address;
            _unitOfWork.UserRepository.AddUser(user);
            return true;
        }
    }
}
