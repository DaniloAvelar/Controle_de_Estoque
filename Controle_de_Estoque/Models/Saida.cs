using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controle_de_Estoque.Models
{
    public class Saida
    {
        [Key]
        public int SaidaId { get; set; }

        [Display(Name = "Data Saída")]
        public DateTime dataSaida { get; set; }

        [Display(Name = "Motivo Saída")]
        public string motivoSaida { get; set; }

        [ForeignKey("Usuario")]
        public int usuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("Produto")]
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
