/*
 * Projeto: Sistema de Gerenciamento de Clientes - Grupo Colorado
 * Autor: Mauricio Amorim
 * GitHub: https://github.com/mgamorim
 * Email: mauricioamorim22@gmail.com
 * Data: Janeiro 2026
 * Descrição: API RESTful para gerenciamento de clientes usando ASP.NET Core 6.0
 */

using ColoradoDesafio.Data.Context;
using ColoradoDesafio.Data.Repositories;
using ColoradoDesafio.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Database
builder.Services.AddDbContext<ColoradoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ITipoTelefoneRepository, TipoTelefoneRepository>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Colorado Desafio API",
        Version = "v1",
        Description = "API RESTful para gerenciamento de clientes - Desenvolvido por Mauricio Amorim para o Grupo Colorado",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Mauricio Amorim",
            Email = "mauricioamorim22@gmail.com",
            Url = new Uri("https://github.com/mgamorim")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Colorado Desafio API V1");
        c.RoutePrefix = string.Empty; // Swagger na raiz
    });
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
