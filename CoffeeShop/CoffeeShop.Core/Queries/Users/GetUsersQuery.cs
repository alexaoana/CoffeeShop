﻿using MediatR;

namespace CoffeeShop.Core.Queries.Users
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {

    }
}
