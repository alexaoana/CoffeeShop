﻿namespace CoffeeShop.Core.DTOs
{
    public class ProductOrderDTO
    {
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
    }
}