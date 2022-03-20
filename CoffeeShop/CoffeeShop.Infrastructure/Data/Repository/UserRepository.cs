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
        private readonly AppDBContext _appDBContext;
        public UserRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public User GetUser(int id)
        {
            foreach (var user in _appDBContext.Users)
                if (user.Id == id)
                    return user;
            return null;
        }

        public IEnumerable<User> GetUsers()
        {
            return _appDBContext.Users;
        }

        public void AddUser(User user)
        {
            _appDBContext.Users.Add(user);
        }

        public void RemoveUser(int id)
        {
            _appDBContext.Users.Remove(GetUser(id));
        }

        public void UpdateUser(User user)
        {
            RemoveUser(user.Id);
            AddUser(user);
        }
    }
}
