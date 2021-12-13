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

        public Cliente() 
        {

        }

        public Cliente(long? clienteId, string clienteNome, string clienteCpf, double clienteCredito, string clienteTelefone, Status status)
        {
            ClienteId = clienteId;
            ClienteNome = clienteNome;
            ClienteCpf = clienteCpf;
            ClienteCredito = clienteCredito;
            ClienteTelefone = clienteTelefone;
            Status = status;
        }
    }
}
