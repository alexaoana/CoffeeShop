using CoffeeShop.Infrastructure.Data;
using Integration.Tests.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net.Http;

namespace Integration.Tests
{
	internal class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
	{
		private SqliteConnection _sqlConnection;
		public CustomWebApplicationFactory()
		{
			_sqlConnection = new SqliteConnection("DataSource=:memory:");
			_sqlConnection.Open();
		}

        protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			builder.ConfigureServices(services =>
			{
				var serviceDescriptor = services.SingleOrDefault(d => d.ServiceType ==
																		typeof(DbContextOptions<AppDbContext>));
				services.Remove(serviceDescriptor);
				var serviceProvider = new ServiceCollection()
					.AddEntityFrameworkSqlite()
					.BuildServiceProvider();
				services.AddDbContext<AppDbContext>(options =>
				{
					options.UseSqlite(_sqlConnection);
					options.UseInternalServiceProvider(serviceProvider);
				}, ServiceLifetime.Scoped);
				var sp = services.BuildServiceProvider();
				using (var scope = sp.CreateScope())
				{
					var scopedServices = scope.ServiceProvider;
					var db = scopedServices.GetRequiredService<AppDbContext>();
					db.Database.EnsureDeleted();
					db.Database.EnsureCreated();
					UtilitiesDatabase.PopulateDatabase(db);
				}
			});
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			_sqlConnection.Close();
			_sqlConnection.Dispose();
		}
	}
}
