using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_de_Estoque.Models
{
    public class ProdutoViewModel
    {
        public int IdProduto { get; set; }


        [Required(ErrorMessage = "O nome do produto é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome do Produto")]
        public string NomeProduto { get; set; }


        [Display(Name = "Qtde")]
        [Required(AllowEmptyStrings = false)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "A quantidade do produto deve ser maior que '0'")]
        public int QtdeProduto { get; set; }


        [Required(ErrorMessage = "A descrição do produto é obrigatória", AllowEmptyStrings = false)]
        [Display(Name = "Descrição do Produto")]
        public string DescricaoProduto { get; set; }

        [Display(Name = "Caixa")]
        [Required(ErrorMessage = "O Código da caixa deve ser preenchido", AllowEmptyStrings = false)]
        public int Caixa { get; set; }


        [Required(ErrorMessage = "Selecione uma categoria", AllowEmptyStrings = false)]
        [Display(Name = "Categoria")]
        public int IdCategoria { get; set; }

        //[Required(ErrorMessage = "Selecione uma categoria", AllowEmptyStrings = false)]
        //[Display(Name = "Categoria")]
        //public Categoria NomeCategoria { get; set; }
    }
}
