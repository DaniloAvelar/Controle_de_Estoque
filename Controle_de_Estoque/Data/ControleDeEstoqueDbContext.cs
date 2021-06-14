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
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Saida> Saidas { get; set; }

    }
}
