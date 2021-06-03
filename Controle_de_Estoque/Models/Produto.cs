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
        //[Required(ErrorMessage = "A quantidade do produto é obrigatória", AllowEmptyStrings = false)]
        [Required(AllowEmptyStrings = false)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "A quantidade do produto deve ser maior que '0'")]
        public int QtdeProduto { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição do produto é obrigatória", AllowEmptyStrings = false)]
        public string DescricaoProduto { get; set; }

        //[ForeignKey("Categoria")]
        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public virtual Categoria Categoria { get; set; }
    }
}
