using Ecommerce_CyberKnight.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }
        public DbSet<Clientes> Clientes { get; set; }
    
    }
}
