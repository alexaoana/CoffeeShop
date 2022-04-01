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
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                Email = request.Email,
            };
            _unitOfWork.UserRepository.AddUser(user);
            return true;
        }
    }
}
