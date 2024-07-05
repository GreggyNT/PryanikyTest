
using Core.DTO.Order.Requests;
using Core.DTO.Order.Responses;
using Core.Validators;
using DataAccess;
using DataAccess.Enums;
using DataAccess.Models;
using DataAccess.Repositories.Implementations;
using DataAccess.Repositories.Interfaces;
using FluentValidation;
using Mapster;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Validators
builder.Services.AddValidatorsFromAssemblyContaining<CreateOrderRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateOrderRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<OrderItemDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateProductRequestValidator>();
#endregion

#region Services+Repositories
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
//builder.Services.AddTransient<IOrderService, OrderService>();

#endregion
builder.Services.AddFluentValidationAutoValidation();
TypeAdapterConfig<Order, OrderResponse>.NewConfig().Map(dest => dest.Status, source => (int)source.Status);
TypeAdapterConfig<CreateOrderRequest,Order>.NewConfig().Map(dest =>dest.Status, source => (OrderStatus)source.Status);
TypeAdapterConfig<UpdateOrderRequest, Order>.NewConfig().Map(dest => dest.Status, source => (OrderStatus)source.Status);
builder.Services.AddCors();
builder.Services.AddDbContext<PryanikiDbContext>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
