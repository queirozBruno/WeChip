using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Tabelas
{
    /// <summary>
    /// Classe de relação entre oferta e produtos
    /// </summary>
    public class OfertaProduto
    {
        public long? OfertaProdutoId { get; set; }

        public long OfertaId { get; set; }

        public long ProdutoId { get; set; }

        public Produto Produto { get; set; }
        public Oferta Oferta { get; set; }
    }
}
