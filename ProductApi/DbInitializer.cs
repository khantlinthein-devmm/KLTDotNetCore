using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ProductApi.Models;
using ProductApi.Data;

namespace ProductApi
{
	public static class DbInitializer
	{
		public static void Seed(IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();
			var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

			context.Database.EnsureCreated(); // Only if using SQLite

			if(!context.Products.Any())
			{
				context.Products.AddRange(
					new Product {  Name = "Laptop" , Price = 99.99m},
					new Product {  Name = "Smartphone", Price = 499.99m},
					new Product { Name = "Headphones", Price=99.9m}
				);
				context.SaveChanges();
			}
		}
	}
}
