using Modelo.Tabelas;
using System.Linq;

namespace Modelo.ApiModels
{
    /// <summary>
    /// Classe destinada a API de vendas. Obtém os osbjetos de cliente, oferta e produtos e o total dos produtos
    /// </summary>
    public class Vendas
    {
        public Cliente Cliente { get; set; }
        public Oferta Oferta { get; set; }
        public IQueryable<Produto> Produtos { get; set; }
        public double Total { get; set; }
    }
}
