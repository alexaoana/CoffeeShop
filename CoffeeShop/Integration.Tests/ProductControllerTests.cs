using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
