using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Enums;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Tests
{
    [TestClass]
    public class OrderControllerTests
    {
        private static TestContext _testContext;
        private static WebApplicationFactory<Program> _factory;

        [ClassInitialize]
        public static void OrderControllerClassInitialize(TestContext testContext)
        {
            _testContext = testContext;
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [TestMethod]
        public async Task Get_Order_By_Id_ShouldReturnExistingOrder()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Orders/1");
            var result = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<OrderDTO>(result);
            var newOrder = new OrderDTO
            {
                Id = 1,
                OrderStatus = OrderStatus.InProgress
            };
            Assert.AreEqual(JsonConvert.SerializeObject(newOrder), JsonConvert.SerializeObject(order));
        }

        [TestMethod]
        public async Task Post_Order_ShouldReturnCreatedResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/Orders",
                new StringContent(JsonConvert.SerializeObject(1), Encoding.UTF8, "application/json"));
            Assert.IsTrue(HttpStatusCode.Created == response.StatusCode);
        }

        [TestMethod]
        public async Task Post_Order_ShouldReturnCreatedOrder()
        {
            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/Orders",
                new StringContent(JsonConvert.SerializeObject(1), Encoding.UTF8, "application/json"));
            Assert.IsTrue(HttpStatusCode.Created == response.StatusCode);
            var result = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<OrderDTO>(result);
            Assert.IsNotNull(order);
            Assert.AreEqual(order.OrderStatus, OrderStatus.InProgress);
        }

        [TestMethod]
        public async Task Pay_Order_ShouldReturnOKResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.PutAsync("api/Orders", 
                new StringContent(JsonConvert.SerializeObject(1), Encoding.UTF8, "application/json"));
            var result = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<OrderDTO>(result);
            Assert.AreEqual(order.OrderStatus, OrderStatus.Placed);
        }
    }
}
