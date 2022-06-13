using WebAPIOficina.Data.Context;
using Microsoft.EntityFrameworkCore;
using WebAPIOficina.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using WebAPIOficina.Configuration;

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
    options.DefaultApiVersion = new ApiVersion(2, 0);
    options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddControllers();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
