using Ecommerce_CyberKnight.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CyberKnight.Data {
    public class ApplicationDbContext : IdentityDbContext<AppUser> {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<itemDoPedido> itemDoPedidos { get; set; }
        public DbSet <Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecoes { get; set; } 
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<UnidadeDeMedida> unidadeMedidas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<itemDoPedido>()
                .HasKey(i => new {i.IdPedido, i.IdProduto});

            modelBuilder.Entity<itemDoPedido>()
                .HasOne<Pedido>(i => i.Pedido)
                .WithMany(p => p.ItensDoPedido)
                .HasForeignKey(i => i.IdPedido)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<itemDoPedido>()
                .HasOne<Produto>(i => i.Produto)
                .WithMany(pr => pr.ItensDoPedido)
                .HasForeignKey(i => i.IdProduto)
                .OnDelete(DeleteBehavior.Restrict);
        }
    } 
}

