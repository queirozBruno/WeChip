using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Tabelas
{
    public class Produto
    {
        [Key]
        public long? ProdutoId { get; set; }
        [Description]
        public string ProdutoDescricao { get; set; }
        public double ProdutoPreco { get; set; }
        [EnumDataType(typeof(TipoProduto))]
        public string ProdutoTipo { get; set; }
        [StringLength(5)]
        [Index(IsUnique = true)]
        public string ProdutoCodigo { get; set; }
    }
}
