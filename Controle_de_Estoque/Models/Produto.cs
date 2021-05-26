using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_de_Estoque.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public int IdCategoria { get; set; }
        public string NomeProduto { get; set; }
        public int QtdeProduto { get; set; }
        public string DescricaoProduto { get; set; }
    }
}
