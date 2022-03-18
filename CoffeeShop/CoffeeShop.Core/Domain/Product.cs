using CoffeeShop.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public ProductUnitEnum ProductUnitEnum { get; set; }
        public int AvailableQuantity { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
    }
}
