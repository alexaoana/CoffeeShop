using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Core
{
    public class ProductOrder
    {
        [Required]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        public int Quantity { get; set; }
        public ProductOrder()
        {

        }
        public ProductOrder(int id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }
        public ProductOrder(int quantity)
        {
            Quantity = quantity;
        }
    }
}
