﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controle_de_Estoque.Models
{
    public class Saida
    {
        [Key]
        public int SaidaId { get; set; }
        public DateTime dataSaida { get; set; }
        public string motivoSaida { get; set; }

        [ForeignKey("Usuario")]
        public int usuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
