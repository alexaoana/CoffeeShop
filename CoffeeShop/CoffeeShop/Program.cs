using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.AutoMapperProfiles;
using CoffeeShop.Core.Commands.Orders;
using CoffeeShop.Core.Commands.ProductOrders;
using CoffeeShop.Core.Commands.Products;
using CoffeeShop.Core.Commands.Users;
using CoffeeShop.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(@"Server=ROMOB41210\SQLEXPRESS;Database=CoffeeShop;Trusted_Connection=True;MultipleActiveResultSets = True"));

builder.Services.AddMediatR(typeof(CreateUserCommand));
builder.Services.AddMediatR(typeof(CreateProductCommand));
builder.Services.AddMediatR(typeof(CreateCustomProductCommand));
builder.Services.AddMediatR(typeof(CreateOrderCommand));
builder.Services.AddMediatR(typeof(CreateProductOrderCommand));

builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddAutoMapper(typeof(ProductProfile));
builder.Services.AddAutoMapper(typeof(AddressProfile));
builder.Services.AddAutoMapper(typeof(ProductOrderProfile));
builder.Services.AddAutoMapper(typeof(OrderProfile));
builder.Services.AddAutoMapper(typeof(ImageProfile));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
