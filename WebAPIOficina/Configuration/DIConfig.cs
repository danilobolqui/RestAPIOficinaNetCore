using WebAPIOficina.Data.Contexto;

namespace WebAPIOficina.Configuration
{
    public static class DIConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<WebAPIOficinaDbContext>();
            
            //services.AddScoped<IProdutoRepository, ProdutoRepository>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}