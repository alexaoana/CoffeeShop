using CoffeeShop.Core.Abstract;
using CoffeeShop.Core;
using CoffeeShop.Infrastructure.Data;
using CoffeeShop.Core.Enums;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Http;
using CoffeeShop.Infrastructure.Services;
using CoffeeShop.Core.Abstract.Services;

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
    OrderStatus = OrderStatusEnum.DELIVERED
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
unitOfWork.UserRepository.AddUser(user);
var users = unitOfWork.UserRepository.GetUsers().ToList();
foreach (var user1 in users)
    Console.WriteLine(user1.FirstName);



