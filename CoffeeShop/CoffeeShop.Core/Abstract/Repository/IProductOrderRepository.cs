namespace CoffeeShop.Core.Abstract.Repository
{
    public interface IProductOrderRepository
    {
        ProductOrder GetProductOrder(int id);
        IEnumerable<ProductOrder> GetProductOrders();
        void AddProductOrder(ProductOrder productOrder);
        void RemoveProductOrder(int id);
        void UpdateProductOrder(ProductOrder productOrder);
    }
}
