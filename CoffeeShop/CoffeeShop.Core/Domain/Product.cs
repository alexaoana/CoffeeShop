using CoffeeShop.Core.Domain;
using CoffeeShop.Core.Enums;

namespace CoffeeShop.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public ProductUnit ProductUnit { get; set; }
        public int AvailableQuantity { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
        public Image Image { get; set; }
    }
}
