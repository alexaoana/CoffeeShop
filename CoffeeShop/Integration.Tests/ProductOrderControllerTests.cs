using CoffeeShop.Core;
using CoffeeShop.Core.Domain;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Enums;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Tests
{
    [TestClass]
    public class ProductOrderControllerTests
    {
        private static TestContext _testContext;
        private static WebApplicationFactory<Program> _factory;

        [ClassInitialize]
        public static void ProductOrderControllerClassInitialize(TestContext testContext)
        {
            _testContext = testContext;
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [TestMethod]
        public async Task Get_ProductOrder_By_Id_ShouldReturnExistingProductOrder()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/ProductOrders/1");
            var result = await response.Content.ReadAsStringAsync();
            var productOrder = JsonConvert.DeserializeObject<ProductOrderDTO>(result);
            var newProductOrder = new ProductOrderDTO
            {
                Quantity = 3,
                Price = 5.5,
                Description = "Cafea simpla",
                Name = "Espresso",
                CoffeeIntensity = 5,
                Amount = 50,
                Ingredients = new List<Ingredient>(),
                OrderId = 1,
                ProductId = 1
            };
            Assert.AreEqual(JsonConvert.SerializeObject(newProductOrder), JsonConvert.SerializeObject(productOrder));
        }

        [TestMethod]
        public async Task Post_ProductOrder_ShouldReturnCreatedResponse()
        {
            var ingredients = new List<Ingredient>();
            ingredients.Add(Ingredient.Milk);
            ingredients.Add(Ingredient.NoCaffeine);
            ingredients.Add(Ingredient.AlmondMilk);
            ingredients.Add(Ingredient.Caffeine);
            ingredients.Add(Ingredient.Ice);
            ingredients.Add(Ingredient.Sugar);
            ingredients.Add(Ingredient.CoconutMilk);
            ingredients.Add(Ingredient.Cream);
            var productOrder = new ProductOrderDTO
            {
                ProductId = 1,
                OrderId = 1,
                Quantity = 6,
                Ingredients = ingredients,
                Name = "",
                Description = "",
                Amount = 0,
                CoffeeIntensity = 0,
                Price = 0
            };
            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/ProductOrders",
                new StringContent(JsonConvert.SerializeObject(productOrder), Encoding.UTF8, "application/json"));
            Assert.IsTrue(HttpStatusCode.Created == response.StatusCode);
        }

        [TestMethod]
        public async Task Delete_ProductOrder_ShouldReturnOkStatus()
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync("api/ProductOrders/1");
            Assert.IsTrue(HttpStatusCode.OK == response.StatusCode);
        }
    }
}
