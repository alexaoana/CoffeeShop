using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Abstract.Repository;
using CoffeeShop.Infrastructure.Data.Repository;

namespace CoffeeShop.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appDbContext;
        private IAddressRepository _addressRepository;
        private IUserRepository _userRepository;
        private IOrderRepository _orderRepository;
        private IProductOrderRepository _productOrderRepository;
        private IProductRepository _productRepository;

        public UnitOfWork(AppDbContext appDBContext)
        {
            _appDbContext = appDBContext;
        }

        public IAddressRepository AddressRepository
        {
            get
            {
                if (_addressRepository == null)
                    _addressRepository = new AddressRepository(_appDbContext);
                return _addressRepository;
            }
            set
            {
                _addressRepository = value;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_appDbContext);
                return _userRepository;
            }
            set
            {
                _userRepository = value;
            }
        }

        public IProductRepository ProductRepository 
        { 
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_appDbContext);
                return _productRepository;
            }
            set
            {
                _productRepository = value;
            } 
        }
        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_appDbContext);
                return _orderRepository;
            }
            set
            {
                _orderRepository = value;
            }
        }
        public IProductOrderRepository ProductOrderRepository
        {
            get
            {
                if (_productOrderRepository == null)
                    _productOrderRepository= new ProductOrderRepository(_appDbContext);
                return _productOrderRepository;
            }
            set
            {
                _productOrderRepository = value;
            }
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
