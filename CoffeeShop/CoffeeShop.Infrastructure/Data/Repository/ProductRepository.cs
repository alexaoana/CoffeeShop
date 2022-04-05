using CoffeeShop.Core;
using CoffeeShop.Core.Abstract.Repository;
using CoffeeShop.Core.Paginate;

namespace CoffeeShop.Infrastructure.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private AppDBContext _appDBContext;
        public ProductRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public Product GetProduct(int id)
        {
            return _appDBContext.Products.SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _appDBContext.Products;
        }

        public IEnumerable<Product> GetProducts(Filter filter)
        {
            return _appDBContext.Products
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);
        }

        public void AddProduct(Product product)
        {
            _appDBContext.Products.Add(product);
            _appDBContext.SaveChanges();
        }

        public void RemoveProduct(int id)
        {
            _appDBContext.Products.Remove(GetProduct(id));
            _appDBContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            foreach (var item in _appDBContext.Products)
                if (item.Id == product.Id)
                {
                    item.ProductUnit = product.ProductUnit;
                    item.Price = product.Price;
                    item.Amount = product.Amount;
                    item.Description = product.Description;
                    item.CoffeeIntensity = product.CoffeeIntensity;
                    item.Name = product.Name;
                }
            _appDBContext.SaveChanges();
        }
    }
}
