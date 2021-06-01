using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controle_de_Estoque.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [Display(Name = "Categoria")]
        public string NomeCategoria { get; set; }

        public ICollection<Produto> Produtos { get; set; }

        //public virtual Produto Produto { get; set; }

    }
}
