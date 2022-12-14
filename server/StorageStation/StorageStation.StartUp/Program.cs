using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StorageStation.Application.Common.Extensions;
using StorageStation.Infrastructure.Common.DbContext;
using StorageStation.Infrastructure.Common.Extensions;
using StorageStation.StartUp.Helpers;
using StorageStation.Web.Common.Extensions;
using StorageStation.Web.Common.Middleware.ErrorHandling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration;

builder.Services
    .AddWebServices(config)
    .AddInfrastructureServices(config)
    .AddApplicationServices();

var app = builder.Build();

DataSeedHelper.GetRequiredServiceAndSeedDataAsync(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var allowedCorsUrls = builder.Configuration.GetSection("AllowedCorsUrls").Get<string[]>();
if (allowedCorsUrls != null && allowedCorsUrls.Any())
{
    app.UseCors(appBuilder =>
    {
        appBuilder.WithOrigins(allowedCorsUrls)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

app.Run();