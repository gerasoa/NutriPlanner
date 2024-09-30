using CCRS.MessageBus;
using CCRS.User.API.Configuration;
using CCRS.User.API.Models.Configuration;
using CCRS.WebAPI.Core.Identity;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath);
builder.Configuration.AddJsonFile("appsettings.json", true, true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddApiConfiguration(builder.Configuration);

builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.RegisterServices();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMessageBusConfiguration(builder.Configuration);


builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwaggerConfiguration();

app.UseApiConfiguration(app.Environment);

app.Run();
