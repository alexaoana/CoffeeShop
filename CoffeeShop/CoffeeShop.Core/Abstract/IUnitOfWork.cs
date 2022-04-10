using CoffeeShop.Core.Abstract.Repository;

namespace CoffeeShop.Core.Abstract
{
    public interface IUnitOfWork
    {
        IAddressRepository AddressRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        IProductRepository ProductRepository { get; set; }
        IOrderRepository OrderRepository { get; set; }
        IProductOrderRepository ProductOrderRepository { get; set; }
        void SaveChanges();
    }
}
