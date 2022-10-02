using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace StorageStation.Application.Common.Extensions;

public static class ApplicationServiceExtensions
{
    private static Assembly CallingAssembly => Assembly.GetCallingAssembly();

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddMediatR(CallingAssembly)
            .AddAutoMapper(CallingAssembly)
            .Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses()
                .AsMatchingInterface());

        return services;
    }
}