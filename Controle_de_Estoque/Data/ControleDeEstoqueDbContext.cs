using Controle_de_Estoque.Models;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_Estoque.Data
{
    public class ControleDeEstoqueDbContext : DbContext
    {

        public ControleDeEstoqueDbContext(DbContextOptions<ControleDeEstoqueDbContext> options) : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasKey(x => new { x.IdProduto, x.IdCategoria });
        }
    }
}
