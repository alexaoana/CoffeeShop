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
            ProductOrderAsserts(productOrder);
        }

        [TestMethod]
        public async Task Post_ProductOrder_ShouldReturnCreatedResponse()
        {
            var productOrder = new ProductOrderDTO
            {
                ProductId = 1,
                OrderId = 1,
                Quantity = 6,
                Ingredients = new List<Ingredient>()
            };
            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/ProductOrders",
                new StringContent(JsonConvert.SerializeObject(productOrder), Encoding.UTF8, "application/json"));
            Assert.IsTrue(HttpStatusCode.Created == response.StatusCode);
        }

        private static void ProductOrderAsserts(ProductOrderDTO productOrder)
        {
            Assert.AreEqual(productOrder.Quantity, 3);
            Assert.AreEqual(productOrder.Price, 5.5);
            Assert.AreEqual(productOrder.Description, "Cafea simpla");
            Assert.AreEqual(productOrder.Name, "Espresso");
            Assert.AreEqual(productOrder.CoffeeIntensity, 5);
            Assert.AreEqual(productOrder.Amount, 50);
        }
    }
}
