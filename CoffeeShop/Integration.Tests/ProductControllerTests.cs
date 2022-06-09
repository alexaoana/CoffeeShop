using CoffeeShop.Core.Domain;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Enums;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
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
    public class ProductControllerTests
    {
        private static TestContext _testContext;
        private static WebApplicationFactory<Program> _factory;

        [ClassInitialize]
        public static void ProductControllerClassInitialize(TestContext testContext)
        {
            _testContext = testContext;
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [TestMethod]
        public async Task Get_All_Products_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Products?PageNumber=1&PageSize=1");
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task Get_All_Products_ShouldReturnExistingProducts()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Products?PageNumber=1&PageSize=1");
            var result = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ProductDTO>>(result);
            var product = products.FirstOrDefault(x => x.Name.Equals("Espresso"));
            var newProduct = new ProductDTO
            {
                Id = 1,
                Name = "Espresso",
                Amount = 50,
                Description = "Cafea simpla",
                ProductUnit = ProductUnit.Ml,
                Price = 5.5,
                CoffeeIntensity = 5,
                AzurePath = "product"
            };
            Assert.AreEqual(JsonConvert.SerializeObject(product), JsonConvert.SerializeObject(newProduct));
        }

        [TestMethod]
        public async Task Get_Product_By_Id_ShouldReturnExistingProduct()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Products/1");
            var result = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDTO>(result);
            var newProduct = new ProductDTO
            {
                Id = 1,
                Name = "Espresso",
                Amount = 50,
                Description = "Cafea simpla",
                ProductUnit = ProductUnit.Ml,
                Price = 5.5,
                CoffeeIntensity = 5,
                AzurePath = "product"
            };
            Assert.AreEqual(JsonConvert.SerializeObject(product), JsonConvert.SerializeObject(newProduct));
        }

        [TestMethod]
        public async Task Post_Product_ShouldReturnCreatedResponse()
        {
            var product = new ProductDTO
            {
                Id = 2,
                Name = "Cappucino",
                Description = "Cafea cu lapte",
                CoffeeIntensity = 6,
                Price = 10,
                Amount = 150,
                ProductUnit = ProductUnit.Ml,
                AzurePath = ""
            };
            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/Products",
                new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json"));
            Assert.IsTrue(HttpStatusCode.Created == response.StatusCode);
        }

        [TestMethod]
        public async Task Post_Product_ShouldReturnCreatedProduct()
        {
            var newProduct = new ProductDTO
            {
                Id = 3,
                Name = "Cappucino",
                Description = "Cafea cu lapte",
                CoffeeIntensity = 6,
                Price = 10,
                Amount = 150,
                ProductUnit = ProductUnit.Ml,
                AzurePath = "abcd",
            };
            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/Products",
                new StringContent(JsonConvert.SerializeObject(newProduct), Encoding.UTF8, "application/json"));
            var result = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDTO>(result);
            Assert.AreEqual(JsonConvert.SerializeObject(product), JsonConvert.SerializeObject(newProduct));
        }
    }
}
