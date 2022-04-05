using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Abstract.Repository;
using CoffeeShop.Infrastructure.Data.Repository;

namespace CoffeeShop.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDBContext _appDBContext;
        private IUserRepository _userRepository;
        private IOrderRepository _orderRepository;
        private IProductOrderRepository _productOrderRepository;
        private IProductRepository _productRepository;

        public UnitOfWork(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_appDBContext);
                }
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
                {
                    _productRepository = new ProductRepository(_appDBContext);
                }
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
                {
                    _orderRepository = new OrderRepository(_appDBContext);
                }
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
                {
                    _productOrderRepository= new ProductOrderRepository(_appDBContext);
                }
                return _productOrderRepository;
            }
            set
            {
                _productOrderRepository = value;
            }
        }

        public void SaveChanges()
        {
            _appDBContext.SaveChanges();
        }
    }
}
