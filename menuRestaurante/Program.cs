using Application.Interfaces;
using Application.Service;
using Infrastructure.Commands;
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
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("La cadena de conexión 'DefaultConnection' no está configurada.");
builder.Services.AddDbContext<AppContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
