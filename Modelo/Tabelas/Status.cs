using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Tabelas
{
    public class Status
    {
        [Key]
        public long? StatusId { get; set; }
        public string StatusDescricao { get; set; }
        public string StatusFinalizaCliente { get; set; }
        public string StatusContabilizaVenda { get; set; }
        public string StatusCodigo { get; set; }

        //Método construtor sem parâmetros
        public Status() 
        {

        }

        //Método construtor com parâmetros. Vai ser usado, principalmente, no método Seed da Migration
        public Status(long? statusId, string statusDescricao, string statusFinalizaCliente, string statusContabilizaVenda, string statusCodigo)
        {
            StatusId = statusId;
            StatusDescricao = statusDescricao;
            StatusFinalizaCliente = statusFinalizaCliente;
            StatusContabilizaVenda = statusContabilizaVenda;
            StatusCodigo = statusCodigo;
        }
    }
}
