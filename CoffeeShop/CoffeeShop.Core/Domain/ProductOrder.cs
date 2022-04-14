using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoffeeShop.Core
{
    public class ProductOrder
    {
        [Required]
        public int Id { get; set; }
        [JsonIgnore]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [JsonIgnore]
        public int OrderId { get; set; }
        [JsonIgnore]
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
