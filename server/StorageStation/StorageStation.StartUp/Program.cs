using StorageStation.Application.Common.Extensions;
using StorageStation.Infrastructure.Common.Extensions;
using StorageStation.Web.Common.Extensions;
using StorageStation.Web.Common.Middleware.ErrorHandling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration;

builder.Services
    .AddWebServices(config)
    .AddApplicationServices()
    .AddInfrastructureServices(config);

var app = builder.Build();

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