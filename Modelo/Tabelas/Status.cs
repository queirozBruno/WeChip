using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Tabelas
{
    public class Status
    {
        [Key]
        public long? StatusId { get; set; }

        [Display(Name = "Descrição")]
        public string StatusDescricao { get; set; }

        [Display(Name = "Finaliza Cliente")]
        public string StatusFinalizaCliente { get; set; }

        [Display(Name = "Contabiliza Venda")]
        public string StatusContabilizaVenda { get; set; }

        [Display(Name = "Código")]
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
