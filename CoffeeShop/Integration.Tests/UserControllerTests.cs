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
            UserAsserts(user);
        }

        [TestMethod]
        public async Task Get_User_By_Id_ShouldReturnExistingUser()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Users/1");
            var result = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDTO>(result);
            UserAsserts(user);
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
            var order = JsonConvert.DeserializeObject<OrderDTO>(result);
            Assert.AreEqual(order, null);
        }

        [TestMethod]
        public async Task Post_User_ShoulReturnCreatedResponse()
        {
            var user = new CreateUserCommand
            {
                FirstName = "Mihai",
                LastName = "Popescu",
                Email = "mihai.popescu@y.com",
                Password = "mihai",
                Address = new Address("Timisoara", "Revolutiei", "12A")
            };
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/Users",
                new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            Assert.IsTrue(HttpStatusCode.Created == response.StatusCode);
        }

        [TestMethod]
        public async Task Post_User_ShouldReturnCreatedUser()
        {
            var newUser = new CreateUserCommand
            {
                FirstName = "Mihai",
                LastName = "Popescu",
                Email = "mihai.popescu@y.com",
                Password = "mihai",
                Address = new Address("Timisoara", "Revolutiei", "12A")
            };
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/Users",
                new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json"));
            var result = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDTO>(result);
            Assert.IsNotNull(user);
            Assert.AreEqual(newUser.FirstName, user.FirstName);
            Assert.AreEqual(newUser.LastName, user.LastName);
            Assert.AreEqual(newUser.Email, user.Email);
            Assert.AreEqual(newUser.Password, user.Password);
            Assert.AreEqual(newUser.Address.City, user.AddressCity);
            Assert.AreEqual(newUser.Address.Street, user.AddressStreet);
            Assert.AreEqual(newUser.Address.Number, user.AddressNumber);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }

        private static void UserAsserts(UserDTO user)
        {
            Assert.AreEqual(user.FirstName, "Ana");
            Assert.AreEqual(user.LastName, "Pop");
            Assert.AreEqual(user.Email, "ana.pop@y.com");
            Assert.AreEqual(user.Password, "ana");
        }
    }
}
