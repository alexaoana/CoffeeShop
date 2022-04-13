using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Commands.Users;
using CoffeeShop.Core.DTOs;
using MediatR;

namespace CoffeeShop.Core.CommandHandlers.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDTO>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.FirstName, request.LastName,
                request.Email, request.Password);
            user.Address = request.Address;
            _unitOfWork.UserRepository.AddUser(user);
            return _mapper.Map<User, UserDTO>(user);
        }
    }
}
