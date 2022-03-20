using CoffeeShop.Core.Abstract;
using CoffeeShop.Core;
using CoffeeShop.Infrastructure.Data;
using CoffeeShop.Core.Enums;

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



