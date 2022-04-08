using CoffeeShop.Core;
using CoffeeShop.Core.Abstract.Repository;
using CoffeeShop.Core.Paginate;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Infrastructure.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDBContext)
        {
            _appDbContext = appDBContext;
        }

        public User GetUser(int id)
        {
            return _appDbContext.Users
                 .Include(x => x.Orders)
                .SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _appDbContext.Users.Include(x => x.Orders);
        }

        public IEnumerable<User> GetUsers(Filter filter)
        {
            return _appDbContext.Users
                .Include(x => x.Orders)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);
        }

        public void AddUser(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
        }

        public void RemoveUser(int id)
        {
            _appDbContext.Users.Remove(GetUser(id));
            _appDbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            foreach (var item in _appDbContext.Users)
                if (item.Id == user.Id)
                {
                    item.FirstName = user.FirstName;
                    item.LastName = user.LastName;
                    item.Email = user.Email;
                    item.Password = user.Password;
                    item.Orders = user.Orders;
                    item.Discount = user.Discount;
                }
            _appDbContext.SaveChanges();
        }
    }
}
