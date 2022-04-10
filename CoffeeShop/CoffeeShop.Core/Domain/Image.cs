﻿using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Core.Domain
{
    public class Image
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string AzurePath { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Image(int id, string azurePath)
        {
            Id = id;
            AzurePath = azurePath;
        }
        public Image(string azurePath)
        {
            AzurePath = azurePath;
        }
    }
}
