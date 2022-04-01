using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Queries.Users;
using MediatR;

namespace CoffeeShop.Core.QueryHandlers.Users
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private IUnitOfWork _unitOfWork;
        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.UserRepository.GetUser(request.UserId);
        }
    }
}
