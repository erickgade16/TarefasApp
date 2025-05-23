using Microsoft.EntityFrameworkCore;
using Tarefas.Application.Services;
using Tarefas.Domain.Interfaces;
using Tarefas.Infrastructure.Context;
using Tarefas.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);



// Adiciona os serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:3001", "http://localhost:3002")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Banco de dados
builder.Services.AddDbContext<TarefasDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injeção de dependência
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddScoped<TarefaService>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Permitir Front


app.UseCors("PermitirFrontend");


app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
