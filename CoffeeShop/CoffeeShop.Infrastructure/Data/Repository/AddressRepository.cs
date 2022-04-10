using CoffeeShop.Core;
using CoffeeShop.Core.Abstract.Repository;
using CoffeeShop.Core.Paginate;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Infrastructure.Data.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private AppDbContext _appDbContext;
        public AddressRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Address GetAddress(int id)
        {
             return _appDbContext.Addresses
                .Include(x => x.User)
                .SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Address> GetAddresses()
        {
            return _appDbContext.Addresses;
        }

        public IEnumerable<Address> GetAddresses(Filter filter)
        {
            return _appDbContext.Addresses
                .Include(x => x.User)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);
        }

        public void AddAddress(Address address)
        {
            _appDbContext.Addresses.Add(address);
            _appDbContext.SaveChanges();
        }

        public void RemoveAddress(int id)
        {
            _appDbContext.Addresses.Remove(GetAddress(id));
            _appDbContext.SaveChanges();
        }

        public void UpdateAddress(Address address)
        {
            foreach (var item in _appDbContext.Addresses)
                if (item.Id == address.Id)
                {
                    item.City = address.City;
                    item.Street = address.Street;
                    item.Number = address.Number;
                }
            _appDbContext.SaveChanges();
        }
    }
}
