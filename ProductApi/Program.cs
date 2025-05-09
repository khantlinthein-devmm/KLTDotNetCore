using Microsoft.EntityFrameworkCore;
using ProductApi;
using ProductApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register SQLite DbContext
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=products.db"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Title = "Product API",
		Version = "v1"
	});
});

var app = builder.Build();

// Seed Data before app.Run()
DbInitializer.Seed(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
