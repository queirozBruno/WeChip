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
        public string StatusContabilizaVenda { get; set; }
        public string StatusCodigo { get; set; }
    }
}
