using WebAPIOficina.Data.Context;
using Microsoft.EntityFrameworkCore;
using WebAPIOficina.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using WebAPIOficina.Configuration;
using WebAPIOficina.Application.AutoMapper;

//******
//BUILDER.
//******
var builder = WebApplication.CreateBuilder(args);

//DI.
builder.Services.ResolveDependencies();

//Versionamento da API.
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

//Adiciona configuração do identity.
builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddControllers();

//Desativa validação de models padrão do asp.net.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

//AutoMapper: Procura todas classes que implementam "Profile" para buscar mapeamentos, no assembly do tipo informado.
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

//Adiciona contexto de banco de dados.
builder.Services.AddDbContext<WebAPIOficinaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Configurações do swagger.
builder.Services.AddSwaggerConfig();

//******
//APP.
//******
var app = builder.Build();

//Usar configs do swagger.
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
app.UseSwaggerConfig(apiVersionDescriptionProvider);

app.UseHttpsRedirection();

//Precisa do Authentication + Authorization para o Bearer JWT funcionar corretamente.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
