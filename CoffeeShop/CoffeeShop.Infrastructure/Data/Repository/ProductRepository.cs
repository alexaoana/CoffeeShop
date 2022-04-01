using CoffeeShop.Core;
using CoffeeShop.Core.Abstract.Repository;
using CoffeeShop.Core.Paginate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public void RemoveProduct(int id)
        {
            _appDBContext.Products.Remove(GetProduct(id));
        }

        public void UpdateProduct(Product product)
        {
            var item = GetProduct(product.Id);
            item = product;
        }
    }
}
