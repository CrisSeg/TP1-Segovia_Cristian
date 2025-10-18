using Application.Interfaces.InterfaceCategory;
using Application.Interfaces.InterfaceDeliveryType;
using Application.Interfaces.InterfaceDish;
using Application.Interfaces.InterfaceOrderItem;
using Application.Interfaces.InterfacesOrder;
using Application.Interfaces.InterfaceStatus;
using Application.Service.ServiceCategory;
using Application.Service.ServiceDeliveryType;
using Application.Service.ServiceDish;
using Application.Service.ServiceOrder;
using Application.Service.ServiceStatus;
using Infrastructure.Commands;
using Infrastructure.Middlewore;
using Infrastructure.Querys;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using AppContext = Infrastructure.Persistence.AppContext;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Conexion a base de datos
builder.Services.AddDbContext<AppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Custom Services creation
builder.Services.AddScoped<IServicesDishCreate, ServiceDishCreate>();
builder.Services.AddScoped<IDishCommand, DishCommand>();
builder.Services.AddScoped<IDishQuery, DishQuery>();

// Custom Sevices get
builder.Services.AddScoped<ISeviceDishGet, ServiceDishGet>();

// Custom Services Update
builder.Services.AddScoped<IServicesDishUpdate, ServiceUpdateDish>();

// Custom Services Filter
builder.Services.AddScoped<IServiceDishFilter, ServiceFilterDish>();

// JSon para menu desplegable SortOrder
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Services de deleteDish
builder.Services.AddScoped<IServiceDeleteDish, ServiceDeleteDish>();

// Implementaciones de Category
// Custom Services get Category
builder.Services.AddScoped<ICategoryQuery, CategoryQuery>();
builder.Services.AddScoped<IServiceCategoryGet, ServiceCategoryGet>();


// Implementaciones de DeliveryType
builder.Services.AddScoped<IServiceDeliveryTypeGet, ServiceDeliveryTypeGet>();
builder.Services.AddScoped<IDeliveryTypeQuery1, DeliveryTypeQuery>();

// Implementaciones de Status
builder.Services.AddScoped<IServiceStatusGet, ServiceStatusGet>();
builder.Services.AddScoped<IStatusQuery, StatusQuery>();

// Implementaciones de Order
builder.Services.AddScoped<IOrderCommand, OrderCommand>();
builder.Services.AddScoped<IOrderQuery, OrderQuery>();
builder.Services.AddScoped<IServiceCreateOrder, ServiceOrderCreate>();
builder.Services.AddScoped<IServiceFilterOrder, ServiceFilterOrder>();
builder.Services.AddScoped<IServiceUpdateOrderItem, ServiceUpdateOrderItem>();
builder.Services.AddScoped<IServiceGetOrderByID, ServiceGetOrderById>();
builder.Services.AddScoped<IServiceUpdateStatusOrder, ServiceUpdateStatusOrder>();

// Implementaciones de ordenItem
builder.Services.AddScoped<IOrderItemQuery, OrderItemQuery>();

//configuracion CORS
// habilitamos el CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<Middlewore>();

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
