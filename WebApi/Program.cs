using Application.Common.Interfaces.Contexts;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Services;
using Persistence.Contexts;
using Application.IoC;
using Persistence.IoC;
using Persistence.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(Assembly.Load("Application"));

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureDbContext();
builder.Services.ConfigureUnitOfWork();
builder.Services.ConfigureServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IDepartmentService, DepartmentSevice>();

builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();*/
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
