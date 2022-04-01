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

var appDBContext = new AppDBContext();
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
**/

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

