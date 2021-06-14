using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_de_Estoque.Models
{
    public class Entrada
    {
        [Key]
        public int EntradaId { get; set; }
        [Display(Name = "Data Entrada")]
        public DateTime dataEntrada { get; set; }

        [Display(Name = "Motivo Entrada")]
        public string motivoEntrada { get; set; }

        [ForeignKey("Usuario")]
        public int usuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("Produto")]
        public int IdProduto{ get; set; }
        public virtual Produto Produto { get; set; }
    }
}
