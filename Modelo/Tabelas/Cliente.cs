using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Tabelas
{
    public class Cliente
    {
        [Key]
        public long? ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteCpf { get; set; }
        public double ClienteCredito { get; set; }
        public string ClienteTelefone { get; set; }

        public Status Status { get; set; }
    }
}
