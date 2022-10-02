using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StorageStation.Infrastructure.Common.DbContext;

namespace StorageStation.Infrastructure.Common.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        => services
            .AddDbContext(config)
            .Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses()
                .AsMatchingInterface());

    private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration config)
        => services.AddDbContext<StorageStationDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        });
}