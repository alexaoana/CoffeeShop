using CoffeeShop.Core.Abstract.Repository;
using CoffeeShop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Infrastructure.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _dbContext;
        public UserRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users;
        }
    }
}
