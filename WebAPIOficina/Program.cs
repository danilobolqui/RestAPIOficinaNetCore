using WebAPIOficina.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using WebAPIOficina.Domain.Models;
using WebAPIOficina.Configuration;

//******
//BUILDER.
//******
var builder = WebApplication.CreateBuilder(args);

//DI.
builder.Services.ResolveDependencies();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adiciona contexto de banco de dados.
builder.Services.AddDbContext<WebAPIOficinaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//******
//APP.
//******
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
