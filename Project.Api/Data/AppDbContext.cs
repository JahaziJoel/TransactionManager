using Microsoft.EntityFrameworkCore;
using Project.Api.Models;

namespace Project.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Transaccion> Transacciones { get; set; }
    }
}
