using CoffeeShop.Core.Paginate;

namespace CoffeeShop.Core.Abstract.Repository
{
    public interface IAddressRepository
    {
        Address GetAddress(int id);
        IEnumerable<Address> GetAddresses();
        IEnumerable<Address> GetAddresses(Filter filter);
        void AddAddress(Address address);
        void RemoveAddress(int id);
        void UpdateAddress(Address address);
    }
}
