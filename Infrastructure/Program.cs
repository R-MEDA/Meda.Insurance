// using Domain.Ports.Mocks;
using Domain.Ports;
using Domain.UseCases;
using Domain.UseCases.Implementations;
using Infrastructure.Clients.Rdw;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Application;
using Infrastructure.Persistence.Car;
using Infrastructure.Persistence.Policy;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PolicyContext>(options =>
  options.UseSqlServer(
    builder.Configuration.GetConnectionString("PolicyContext"))
    .EnableSensitiveDataLogging());

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add RDW Client
builder.Services.AddSingleton<IRdw, RdwClient>();

//Add DI for the Domain.Ports
builder.Services.AddScoped<IApplication, ApplicationRepository>();
builder.Services.AddScoped<IPolicy, PolicyRepository>();
builder.Services.AddScoped<ICar, CarRepository>();

//Add Mock DI for the Domain.Ports ---> Romove the comments here and comment out the Repo Injections above.

// Dont forget to remove the comments at line onen
// builder.Services.AddSingleton<IApplication, ApplicationMock>();
// builder.Services.AddSingleton<IPolicy, PolicyMock>();
// builder.Services.AddSingleton<ICar, CarMock>();

//Add DI for the Domain.UseCases
builder.Services.AddScoped<IApplyForPolicy, ApplyForPolicy>();
builder.Services.AddScoped<IProcessApplication, ProcessApplication>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
