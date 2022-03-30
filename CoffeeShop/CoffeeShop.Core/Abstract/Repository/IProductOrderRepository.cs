using CoffeeShop.Core.Abstract.Repository.Paginate;

namespace CoffeeShop.Core.Abstract.Repository
{
    public interface IProductOrderRepository
    {
        ProductOrder GetProductOrder(int id);
        IEnumerable<ProductOrder> GetProductOrders();
        IEnumerable<ProductOrder> GetProductOrders(Filter filter);
        void AddProductOrder(ProductOrder productOrder);
        void RemoveProductOrder(int id);
        void UpdateProductOrder(ProductOrder productOrder);
    }
}
