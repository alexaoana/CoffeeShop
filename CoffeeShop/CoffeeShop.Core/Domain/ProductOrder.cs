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
        public int Quantity
        {
            get
            {
                return Quantity;
            }
            set
            {
                if (value > 0)
                    Quantity = value;
            }
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
