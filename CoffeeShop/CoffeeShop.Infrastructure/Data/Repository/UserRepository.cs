using CoffeeShop.Core;
using CoffeeShop.Core.Abstract.Repository;
using CoffeeShop.Core.Paginate;

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
            return _appDBContext.Users.SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _appDBContext.Users;
        }

        public IEnumerable<User> GetUsers(Filter filter)
        {
            return _appDBContext.Users
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);
        }

        public void AddUser(User user)
        {
            _appDBContext.Users.Add(user);
            _appDBContext.SaveChanges();
        }

        public void RemoveUser(int id)
        {
            _appDBContext.Users.Remove(GetUser(id));
            _appDBContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            foreach (var item in _appDBContext.Users)
                if (item.Id == user.Id)
                {
                    item.FirstName = user.FirstName;
                    item.LastName = user.LastName;
                    item.Email = user.Email;
                    item.Password = user.Password;
                    item.Orders = user.Orders;
                }
            _appDBContext.SaveChanges();
        }
    }
}
