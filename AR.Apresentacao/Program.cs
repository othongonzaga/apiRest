using AR.Data;
using AR.Data.Imp;
using AR.Data.Interfaces;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",new OpenApiInfo { Title = "ApiRestCliente AR.Apresentacao", Version = "v1"});
});

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddDbContext<ContextoPrincipal>(options =>
    options.UseSqlServer("Server =.\\SQLEXPRESS; Database = ApiRestExemplo; Trusted_Connection = yes;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APiRestCliente AR.Apresentacao v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
