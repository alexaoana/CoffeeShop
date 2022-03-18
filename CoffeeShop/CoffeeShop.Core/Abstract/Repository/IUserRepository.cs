using CoffeeShop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Abstract.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        IEnumerable<User> GetUsers();
    }
}
