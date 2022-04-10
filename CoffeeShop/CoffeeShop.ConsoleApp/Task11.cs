using CoffeeShop.Core;
using CoffeeShop.Core.Domain;
using CoffeeShop.Core.Enums;
using CoffeeShop.Core.Paginate;
using CoffeeShop.Infrastructure.Data;
using CoffeeShop.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.ConsoleApp
{
    public class Task11
    {
        private AppDbContext _appDbContext;
        private OrderRepository _orderRepository;
        private UserRepository _userRepository;
        private ProductOrderRepository _productOrderRepository;
        private ProductRepository _productRepository;
        public Task11()
        {
            _appDbContext = new AppDbContext();
            _orderRepository = new OrderRepository(_appDbContext);
            _userRepository = new UserRepository(_appDbContext);
            _productOrderRepository = new ProductOrderRepository(_appDbContext);
            _productRepository = new ProductRepository(_appDbContext);
        }
        public void populateDatabase()
        {
            for (int i = 0; i < 10; i++)
            {
                var address = new Address("Timisoara" + i, "Mihai Eminescu" + i, "1A" + i);
                var user = new User("Oana" + i, "Alexa" + i, "email@gmail.com", "oana" + i);
                var image = new Image("azurePath" + i);
                var product = new Product("Espresoo" + i, "blank" + i, 10 * i / 3, i % 3 + 10, ProductUnit.Ml, image, i % 3);
                address.User = user;
                user.Address = address;
                image.Product = product;
                product.Image = image;
                var order = new Order();
                order.User = user;
                if (i % 3 == 0)
                {
                    product.ProductUnit = ProductUnit.Kg;
                    order.OrderStatus = OrderStatus.InProgress;
                }
                if (i % 3 == 1)
                {
                    product.ProductUnit = ProductUnit.Ml;
                    order.OrderStatus = OrderStatus.Placed;
                }
                if (i % 3 == 2)
                {
                    product.ProductUnit = ProductUnit.G;
                    order.OrderStatus = OrderStatus.Delivered;
                }
                var productOrder = new ProductOrder(i % 3 + 1);
                productOrder.Product = product;
                productOrder.Order = order;
                _userRepository.AddUser(user);
                _orderRepository.AddOrder(order);
                _productRepository.AddProduct(product);
                _productOrderRepository.AddProductOrder(productOrder);
            }
        }

        public Task<List<IGrouping<OrderStatus, Order>>> GetOrdersByStatus()
        {
            return _appDbContext.Orders
                .GroupBy(x => x.OrderStatus)
                .ToListAsync();
        }

        public Task<List<Order>> GetOrdersOfUser(User user)
        {
            return _appDbContext.Orders
                .Where(x => x.User == user)
                .ToListAsync();
        }

        public Task<List<ProductDTO>> Top3MostBoughtProducts()
        {
            return _appDbContext.ProductOrders
                .Include(x => x.Product)
                .GroupBy(x => x.Product)
                .Select(x => new ProductDTO
                {
                    Product = x.Key,
                    BoughtQuantity = x.Sum(x => x.Quantity)
                })
                .OrderByDescending(x => x.BoughtQuantity)
                .Take(3)
                .ToListAsync();
        }

        public Task<OrderDTO> GetMostExpensiveOrder()
        {
            return _appDbContext.Orders
                .Include(x => x.ProductOrders)
                .Select(x => new OrderDTO
                {
                    Order = x,
                    Price = x.Price
                })
                .OrderByDescending(x => x.Price)
                .FirstAsync();
        }

        public Task<Dictionary<ProductUnit, decimal>> GetAveragePriceForProductCategories()
        {
            return _appDbContext.Products
                .GroupBy(x => x.ProductUnit)
                .ToDictionaryAsync(x => x.Key, x => x.Average(x => x.Price));
        }

        public Task<List<Order>> GetAllEmptyOrders()
        {
            return _appDbContext.Orders
                .Include(x => x.ProductOrders)
                .Where(x => x.ProductOrders.Count() == 0)
                .ToListAsync();
        }

        public decimal GetMostExpensivePrice()
        {
            return _appDbContext.Products
                .Max(x => x.Price);
        }

        public Order GetOrderById(int id)
        {
            return _appDbContext.Orders
                .Include(x => x.ProductOrders)
                .SingleOrDefault(o => o.Id == id);
        }

        public Task<List<User>> GetUsersFromPage(Filter filter)
        {
            return _appDbContext.Users
                .Include(x => x.Orders)
                .Include(x => x.Address)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();
        }

        public Task<OrderDTO2> GetOrdeWithMostProducts()
        {
            return _appDbContext.Orders
                .Include(x => x.ProductOrders)
                .Select(x => new OrderDTO2
                {
                    Order = x,
                    Products = x.ProductOrders.Sum(x => x.Quantity)
                })
                .OrderByDescending(x => x.Products)
                .FirstAsync();
        }
    }
}
