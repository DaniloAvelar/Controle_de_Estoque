using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controle_de_Estoque.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        [Display(Name = "Produto")]
        [Required(ErrorMessage = "O nome do produto é obrigatório", AllowEmptyStrings = false)]
        public string NomeProduto { get; set; }

        [Display(Name = "Qtde")]
        [Required(ErrorMessage = "A quantidade do produto é obrigatória", AllowEmptyStrings = false)]
        public int QtdeProduto { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição do produto é obrigatória", AllowEmptyStrings = false)]
        public string DescricaoProduto { get; set; }

        //[ForeignKey("Categoria")]
        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }
    }
}
