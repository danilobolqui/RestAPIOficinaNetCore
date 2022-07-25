using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPIOficina.Extensions;

namespace WebAPIOficina.Configuration
{
    public static class JwtConfig
    {
        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //Busca dados no appsettings.json.
            var appSettingsSection = configuration.GetSection("AppSettings");

            //Vincula classe AppSettings com dados do arquivo appsettings.
            //Quando a classe "AppSettings" for injetada, ela já virá populada.
            services.Configure<AppSettings>(appSettingsSection);

            //Busca secret.
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //Padrão de autenticação.
            services.AddAuthentication(x =>
            {
                //Padrão.
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //Validação de token.
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                //Requer HTTPS.
                x.RequireHttpsMetadata = true;
                //Guardar token após autenticação.
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    //Validar chave emissor.
                    ValidateIssuerSigningKey = true,
                    //Criptografia.
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    //Validar emissor.
                    ValidateIssuer = true,
                    //Validar audiência (localhost, no caso configurado).
                    ValidateAudience = true,
                    //Informação da audiência.
                    ValidAudience = appSettings.ValidoEm,
                    //Emissor.
                    ValidIssuer = appSettings.Emissor
                };
            });

            return services;
        }
    }
}
