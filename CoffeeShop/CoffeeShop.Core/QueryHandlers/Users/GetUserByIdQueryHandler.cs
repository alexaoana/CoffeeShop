using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Queries.Users;
using MediatR;

namespace CoffeeShop.Core.QueryHandlers.Users
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _unitOfWork.UserRepository.GetUser(request.UserId);
            return _mapper.Map<User, UserDTO>(user);
        }
    }
}
