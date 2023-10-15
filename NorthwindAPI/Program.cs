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
builder.Services.AddSingleton<ISupplierService, SupplierService>();
builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddSingleton<IOrderDetailService, OrderDetailService>();
builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddSingleton<IShipperService, ShipperService>();
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();


if (settings.ORM.ToLower() == "dapper")
{
    builder.Services.AddSingleton<IProductRepository, DapperProductRepository>();
    builder.Services.AddSingleton<ICategoryRepository, DapperCategoryRepository>();
    builder.Services.AddSingleton<ISupplierRepository, DapperSupplierRepository>();
    builder.Services.AddSingleton<IOrderRepository, DapperOrderRepository>();
    builder.Services.AddSingleton<IOrderDetailRepository, DapperOrderDetailRepository>();
    builder.Services.AddSingleton<ICustomerRepository, DapperCustomerRepository>();
    builder.Services.AddSingleton<IShipperRepository, DapperShipperRepository>();
    builder.Services.AddSingleton<IEmployeeRepository, DapperEmployeeRepository>();
}
else if(settings.ORM.ToLower() == "ef")
{
    builder.Services.AddSingleton<IProductRepository, EFProductRepository>();
    builder.Services.AddSingleton<ICategoryRepository, EFCategoryRepository>();
    builder.Services.AddSingleton<ISupplierRepository, EFSupplierRepository>();
    builder.Services.AddSingleton<IOrderRepository, EFOrderRepository>();
    builder.Services.AddSingleton<IOrderDetailRepository, EFOrderDetailRepository>();
    builder.Services.AddSingleton<ICustomerRepository, EFCustomerRepository>();
    builder.Services.AddSingleton<IShipperRepository, EFShipperRepository>();
    builder.Services.AddSingleton<IEmployeeRepository, EFEmployeeRepository>();
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
