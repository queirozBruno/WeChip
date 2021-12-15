using Modelo.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Tabelas
{
    public class Produto
    {
        [Key]
        public long? ProdutoId { get; set; }

        [Display(Name = "Descrição")]
        public string ProdutoDescricao { get; set; }

        [Display(Name = "Preço")]
        public double ProdutoPreco { get; set; }

        [Display(Name = "Tipo")]
        [EnumDataType(typeof(TipoProduto))]
        public string ProdutoTipo { get; set; }

        [Display(Name = "Código")]
        [StringLength(5)]
        [Index(IsUnique = true)]
        public string ProdutoCodigo { get; set; }

        public Produto()
        {

        }

        //Método construtor com parâmetros. Vai ser usado, principalmente, no método Seed da Migration
        public Produto(long? produtoId, string produtoDescricao, double produtoPreco, string produtoTipo, string produtoCodigo)
        {
            ProdutoId = produtoId;
            ProdutoDescricao = produtoDescricao;
            ProdutoPreco = produtoPreco;
            ProdutoTipo = produtoTipo;
            ProdutoCodigo = produtoCodigo;
        }
    }
}
