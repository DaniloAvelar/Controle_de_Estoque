using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_de_Estoque.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }

        public int NomeCategoria { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}
