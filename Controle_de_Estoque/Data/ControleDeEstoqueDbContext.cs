using Controle_de_Estoque.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_de_Estoque.Data
{
    public class ControleDeEstoqueDbContext : DbContext
    {
        //public ControleDeEstoqueDbContext()
        //{
        //}

        public ControleDeEstoqueDbContext(DbContextOptions<ControleDeEstoqueDbContext> options) : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ProdutoViewModel>()
        //        .HasKey(x => new { x.IdProduto, x.CategoriaId });
        //}
    }
}
