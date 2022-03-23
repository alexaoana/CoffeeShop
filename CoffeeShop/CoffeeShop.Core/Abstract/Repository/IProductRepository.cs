namespace CoffeeShop.Core.Abstract.Repository
{
    public interface IProductRepository
    {
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
        void RemoveProduct(int id);
        void UpdateProduct(Product product);
    }
}
