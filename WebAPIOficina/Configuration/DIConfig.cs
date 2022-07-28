using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebAPIOficina.Application.Areas;
using WebAPIOficina.Application.Interfaces;
using WebAPIOficina.Data.Context;
using WebAPIOficina.Data.Repositories;
using WebAPIOficina.Domain.Interfaces;
using WebAPIOficina.Domain.Notifier;
using WebAPIOficina.Extensions;

namespace WebAPIOficina.Configuration
{
    public static class DIConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddScoped<WebAPIOficinaDbContext>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddScoped<IOrdemServicoRepository, OrdemServicoRepository>();
            services.AddScoped<IVeiculoCorRepository, VeiculoCorRepository>();

            services.AddScoped<IVeiculoApplication, VeiculoApplication>();
            services.AddScoped<IOsApplication, OsApplication>();

            return services;
        }
    }
}
