using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Queries.Users;
using MediatR;

namespace CoffeeShop.Core.QueryHandlers.Users
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDTO>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _unitOfWork.UserRepository.GetUsers();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        }
    }
}
