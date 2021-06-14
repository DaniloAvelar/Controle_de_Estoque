using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Controle_de_Estoque.Models
{
    public class Usuario
    {
        [Key]
        public int usuarioId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é obrigatório", AllowEmptyStrings = false)]
        public string usuarioNome { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "O email é obrigatório", AllowEmptyStrings = false)]
        public string usuarioEmail { get; set; }


        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A senha é obrigatória", AllowEmptyStrings = false)]
        public string Senha { get; set; }

        public List<Saida> Saida { get; set; }
        public List<Entrada> Entrada { get; set; }


    }
}
