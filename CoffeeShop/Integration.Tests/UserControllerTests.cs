using CoffeeShop.Core;
using CoffeeShop.Core.Commands.Users;
using CoffeeShop.Core.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        private static TestContext _testContext;
        private static WebApplicationFactory<Program> _factory;

        [ClassInitialize]
        public static void UserControllerClassInitialize(TestContext testContext)
        {
            _testContext = testContext;
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [TestMethod]
        public async Task Get_All_Users_ShouldReturnOKResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Users");
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task Get_All_Users_ShouldReturnExistingUsers()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Users");
            var result = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<UserDTO>>(result);
            var user = users.FirstOrDefault(x => x.FirstName.Equals("Ana"));
            var newUser = new UserDTO
            {
                Id = 1,
                FirstName = "Ana",
                LastName = "Pop",
                Email = "ana.pop@y.com",
                Password = "ana",
                AddressCity = "Cluj-Napoca",
                AddressStreet = "Dorobantilor",
                AddressNumber = "17A"
            };
            Assert.AreEqual(JsonConvert.SerializeObject(user), JsonConvert.SerializeObject(newUser));
        }

        [TestMethod]
        public async Task Get_User_By_Id_ShouldReturnExistingUser()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Users/1");
            var result = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDTO>(result);
            var newUser = new UserDTO
            {
                Id = 1,
                FirstName = "Ana",
                LastName = "Pop",
                Email = "ana.pop@y.com",
                Password = "ana",
                AddressCity = "Cluj-Napoca",
                AddressStreet = "Dorobantilor",
                AddressNumber = "17A"
            };
            Assert.AreEqual(JsonConvert.SerializeObject(user), JsonConvert.SerializeObject(newUser));
        }

        [TestMethod]
        public async Task Get_Orders_Of_User_ShouldReturnOKResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Users/1/orders");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Get_Orders_Of_User_ShouldReturnExistingOrder()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Users/1/orders");
            var result = await response.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<List<OrderDTO>>(result);
            Assert.AreNotEqual(orders, null);
            Assert.AreEqual(orders.Count, 1);
        }

        [TestMethod]
        public async Task Post_User_ShoulReturnCreatedResponse()
        {
            var user = new UserDTO
            {
                FirstName = "Mihai",
                LastName = "Popescu",
                Email = "mihai.popescu@y.com",
                Password = "mihai",
                AddressCity = "Timisoara",
                AddressStreet = "Bulevardul Revolutiei",
                AddressNumber = "12A"
            };
            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/Users",
                new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            Assert.IsTrue(HttpStatusCode.Created == response.StatusCode);
        }

        [TestMethod]
        public async Task Post_User_ShouldReturnCreatedUser()
        {
            var newUser = new UserDTO
            {
                Id = 3,
                FirstName = "Mihai",
                LastName = "Popescu",
                Email = "mihai.popescu@y.com",
                Password = "mihai",
                AddressCity = "Timisoara",
                AddressStreet = "Bulevardul Revolutiei",
                AddressNumber = "12A"
            };
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/Users",
                new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json"));
            var result = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDTO>(result);
            Assert.IsNotNull(user);
            Assert.AreEqual(JsonConvert.SerializeObject(user), JsonConvert.SerializeObject(newUser));
        }

        [TestMethod]
        public async Task Get_CurrentOrder_ShouldReturnExistingOrder()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Users/1/currentOrder");
            var result = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<OrderDTO>(result);
            Assert.AreNotEqual(order, null);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }
    }
}
