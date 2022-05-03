using CoffeeShop.Core;
using CoffeeShop.Core.Domain;
using CoffeeShop.Core.Enums;
using CoffeeShop.Infrastructure.Data;
using System;

namespace Integration.Tests.Utilities
{
    public class UtilitiesDatabase
    {
        public static void PopulateDatabase(AppDbContext appDbContext)
        {
            var address = new Address("Cluj-Napoca", "Dorobantilor", "17A");
            var user = new User("Ana", "Pop", "ana.pop@y.com", "ana");
            var image = new Image("product");
            var product = new Product("Espresso", "Cafea simpla", 50, 5.5, ProductUnit.Ml, image, 5);
            var order = new Order();
            var productOrder = new ProductOrder(3, product);

            order.User = user;
            user.Address = address;
            productOrder.Product = product;
            productOrder.Order = order;

            appDbContext.Users.Add(user);
            appDbContext.Products.Add(product);
            appDbContext.Orders.Add(order);
            appDbContext.ProductOrders.Add(productOrder);
            appDbContext.SaveChanges();
        }
    }
}
