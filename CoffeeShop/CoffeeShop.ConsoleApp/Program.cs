using CoffeeShop.Core.Abstract;
using CoffeeShop.Core;
using CoffeeShop.Infrastructure.Data;
using CoffeeShop.Core.Enums;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Http;
using CoffeeShop.Infrastructure.Services;
using CoffeeShop.Core.Abstract.Services;
using CoffeeShop.Core.Commands.Users;
using CoffeeShop.Core.CommandHandlers.Users;
using CoffeeShop.Core.Queries.Users;
using CoffeeShop.Core.QueryHandlers.Users;
using CoffeeShop.Core.Patterns.Strategy;
using CoffeeShop.Core.Patterns.Decorator;
using CoffeeShop.Infrastructure.Data.Repository;
using CoffeeShop.Core.Queries.Orders;
using CoffeeShop.Core.QueryHandlers.Orders;
using AutoMapper;
using CoffeeShop.Core.AutoMapperProfiles;
using CoffeeShop.Core.Domain;
using CoffeeShop.ConsoleApp;
using CoffeeShop.Core.Paginate;

/**
string containerName = "images";
string connectionString = "";
var image = await OpenReadAsync("image.jpg");
Task<Stream> OpenReadAsync(string path)
{
    return Task.FromResult((Stream)File.OpenRead(path));
}
var fileName = "phone";
IFormFile formFile = new FormFile(image, 0, image.Length, "form", fileName);

IImageService imageService = new AzureBlobImageService(connectionString, containerName);
var test = await imageService.UploadFormFileAsync(formFile);


var address = new Address
{
    City = "Timisoara",
    Id = 1,
    Number = "12A",
    Street = "Ceva"
};

var orders = new List<Order>
{
    new Order { Id = 1,
    OrderStatus = OrderStatus.Delivered
    }
};

var user = new User
{ 
    Address = address, 
    Id = 1,
    FirstName = "Oana",
    LastName = "Alexa",
    AddressId = 1,
    Orders = orders
};

var appDBContext = new AppDbContext();
IUnitOfWork unitOfWork = new UnitOfWork(appDBContext);
var userCommand = new CreateUserCommand()
{
    Address = address,
    FirstName = user.FirstName,
    LastName = user.LastName,
    Email = user.Email,
};
var userHandler = new CreateUserCommandHandler(unitOfWork);
userHandler.Handle(userCommand, new System.Threading.CancellationToken()).Wait();

var usersQuery = new GetUsersQuery();
var usersQueryHandler = new GetUsersQueryHandler(unitOfWork);
var users = await usersQueryHandler.Handle(usersQuery, new System.Threading.CancellationToken());


var context = new Context(new PayByCard("1234", "123", DateOnly.MaxValue));
context.executePayment(12);
context = new Context(new PayByCash());
context.executePayment(12);

Product product = new Product
{
    Description = "Expresso",
    Amount = 20,
    Price = 5,
    Name = "Expresso"
};

var decorated = new CoffeeWithCaffeine(new CoffeeWithSugar(new CoffeeWithCoconutMilk(new CoffeeWithCream(new CoffeeWithAlmondMilk(new CoffeeWithMilk(new CoffeeWithIce(product).GetProduct()).GetProduct()).GetProduct()).GetProduct()).GetProduct()).GetProduct()).GetProduct();
Console.WriteLine(decorated.Description);

var address = new Address
{
    City = "Arad",
    Number = "15",
    Street = "Bulevardul Revolutiei"
};

var user = new User
{
    FirstName = "Oana",
    LastName = "Alexa",
    Email = "oana.alexa@a.com",
    Password = "oanaalexa",
    Address = address
};

var order = new Order
{
    User = user,
    OrderStatus = OrderStatus.Placed
};**/

var task11 = new Task11();



//task11.populateDatabase();
//var ordersOfUser = await task11.GetOrdersOfUser(new User { Id = 2 });
//var ordersByStatus = await task11.GetOrdersByStatus();
//var mostExpensiveOrder = await task11.GetMostExpensiveOrder();
//var top3MostBoughtProducts = await task11.Top3MostBoughtProducts();
//var pricesDictionary = await task11.GetAveragePriceForProductCategories();
var emptyOrders = await task11.GetAllEmptyOrders();
var mostExpensivePrice = task11.GetMostExpensivePrice();
var order = task11.GetOrderById(3);
var usersFromPage = await task11.GetUsersFromPage(new Filter
{
    PageNumber = 1,
    PageSize = 2,
});
var orderwithMostProducts = await task11.GetOrdeWithMostProducts();

Console.ReadLine();