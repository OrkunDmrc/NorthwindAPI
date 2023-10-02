using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.BLL.Services.Concrete;
using NorthwindAPI.DAL.Repositories.Abstract;
using NorthwindAPI.DAL.Repositories.Concrete.Dapper;
using NorthwindAPI.DAL.Repositories.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IProductRepository, DapperProductRepository>();
//builder.Services.AddSingleton<IProductRepository, EFProductRepository>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddSingleton<ICategoryRepository, DapperCategoryRepository>();
//builder.Services.AddSingleton<ICategoryRepository, EFCategoryRepository>();

var app = builder.Build();

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
