using System.Reflection;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace StorageStation.Web.Common.Extensions
{
    public static class WebServiceExtensions
    {
        private const string TokenKey = "TokenKey";

        private static Assembly ExecutingAssembly => Assembly.GetExecutingAssembly();

        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            return services
                .AddSwaggerGen()
                .AddJwtAuthentication(configuration)
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddCustomFluentValidation();
        }

        private static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[TokenKey]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                    cfg.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/comments"))
                            {
                                context.Token = accessToken;
                            }

                            return Task.CompletedTask;
                        }
                    };
                });

            return services;
        }

        private static IServiceCollection AddCustomFluentValidation(this IServiceCollection services)
            => services
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssembly(ExecutingAssembly);
    }
}