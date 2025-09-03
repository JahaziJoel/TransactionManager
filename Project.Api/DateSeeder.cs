using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Project.Api.Data;
using Project.Api.Models;

namespace Project.Api
{
    public static class DataSeeder
    {
        public static void Inicializar(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.EnsureCreated();

            if (!db.Transacciones.Any())
            {
                db.Transacciones.AddRange(
                    new Transaccion
                    {
                        Tipo = "Gasto",
                        Categoria = "Servicios",
                        Descripcion = "Internet",
                        Monto = 2403,
                        Fecha = DateTime.Today
                    },
                    new Transaccion
                    {
                        Tipo = "Ingreso",
                        Categoria = "Salario",
                        Descripcion = "Pago quincenal",
                        Monto = 25000,
                        Fecha = DateTime.Today.AddDays(-7)
                    }
                );

                db.SaveChanges();
            }
        }
    }
}
