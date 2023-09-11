using Ecommerce_CyberKnight.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Endereco> Enderecoes { get; set; } 
        public DbSet<Clientes> Clientes { get; set; }
    
    }
}
