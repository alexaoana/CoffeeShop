using CoffeeShop.Core;
using CoffeeShop.Core.Abstract.Repository;
using CoffeeShop.Core.Paginate;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Infrastructure.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDBContext)
        {
            _appDbContext = appDBContext;
        }

        public Product GetProduct(int id)
        {
            return _appDbContext.Products
                .Include(x => x.Image)
                .SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _appDbContext.Products
                .Include(x => x.Image);
        }

        public IEnumerable<Product> GetProducts(Filter filter)
        {
            return _appDbContext.Products
                .Include(x => x.Image)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);
        }

        public void AddProduct(Product product)
        {
            _appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();
        }

        public void RemoveProduct(int id)
        {
            _appDbContext.Products.Remove(GetProduct(id));
            _appDbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            foreach (var item in _appDbContext.Products)
                if (item.Id == product.Id)
                {
                    item.ProductUnit = product.ProductUnit;
                    item.Price = product.Price;
                    item.Amount = product.Amount;
                    item.Description = product.Description;
                    item.CoffeeIntensity = product.CoffeeIntensity;
                    item.Name = product.Name;
                }
            _appDbContext.SaveChanges();
        }
    }
}
