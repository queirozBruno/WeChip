using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Tabelas
{
    public class Cliente
    {
        [Key]
        public long? ClienteId { get; set; }

        public long StatusId { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório")]
        [Display(Name = "Nome do Cliente")]
        public string ClienteNome { get; set; }

        [Required(ErrorMessage = "O cpf do cliente é obrigatório")]
        [Display(Name = "Cpf do Cliente")]
        public string ClienteCpf { get; set; }

        [Display(Name = "Crédito")]
        public double? ClienteCredito { get; set; }

        [Required(ErrorMessage = "O telefone do cliente é obrigatório")]
        [Display(Name = "Telefone do Cliente")]
        public string ClienteTelefone { get; set; }

        public Status Status { get; set; }

        //Método construtor sem parâmetros
        public Cliente() 
        {

        }

        //Método construtor com parâmetros. Vai ser usado, principalmente, no método Seed da Migration
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
