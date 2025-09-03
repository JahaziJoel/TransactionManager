using Microsoft.EntityFrameworkCore;
using Project.Api.Data;
using Project.Api;
using Project.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=gestor.db"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirBlazorClient", policy =>
    {
        policy.WithOrigins("http://localhost:5173") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

DataSeeder.Inicializar(app.Services);

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PermitirBlazorClient");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
