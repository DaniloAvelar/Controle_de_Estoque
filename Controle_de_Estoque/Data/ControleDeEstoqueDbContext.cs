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
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
