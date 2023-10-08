using Newtonsoft.Json;
using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.BLL.Services.Concrete;
using NorthwindAPI.Core.ApplicationSettings.Concrete;
using NorthwindAPI.DAL.Repositories.Abstract;
using NorthwindAPI.DAL.Repositories.Concrete.Dapper;
using NorthwindAPI.DAL.Repositories.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

using StreamReader r = new StreamReader("appsettings.json");
string json = r.ReadToEnd();
var settings = JsonConvert.DeserializeObject<APIApplicationSetting>(json);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();
if (settings.ORM.ToLower() == "dapper")
{
    builder.Services.AddSingleton<IProductRepository, DapperProductRepository>();
    builder.Services.AddSingleton<ICategoryRepository, DapperCategoryRepository>();
}
else if(settings.ORM.ToLower() == "ef")
{
    builder.Services.AddSingleton<IProductRepository, EFProductRepository>();
    builder.Services.AddSingleton<ICategoryRepository, EFCategoryRepository>();
}
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
