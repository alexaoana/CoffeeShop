using CoffeeShop.Core.Abstract;
using CoffeeShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(@"Server=ROMOB41210\SQLEXPRESS;Database=CoffeeShop;Trusted_Connection=True;MultipleActiveResultSets = True"));
builder.Services.AddMediatR(typeof(AssemblyMaker));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(AssemblyMaker));

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterMediatR(typeof(AssemblyMaker));
    containerBuilder.RegisterAutoMapper(typeof(AssemblyMaker));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
